using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using LibGit2Sharp;
using Newtonsoft.Json;

public class CommitInfo
{
    // /commits.json获取的是List<CommitInfo>
    [JsonProperty("url")] public string url { get; set; }
    [JsonProperty("commit")] public CommitCommit commit { get; set; }
}
public class CommitCommit
{
    [JsonProperty("author")] public CommitAuthor author { get; set; }
}
public class CommitAuthor
{
    [JsonProperty("date")] public string date { get; set; }
}

public class Url
{
    [JsonProperty("files")] public List<UrlFile> files { get; set; }

}
public class UrlFile
{
    [JsonProperty("filename")] public string filename { get; set; }
    [JsonProperty("raw_url")] public string raw_url { get; set; }

}




public class Program
{
    public const string timeFormat = "yyyy-MM-dd'T'HH:mm:ss'Z'";
    private static int GetAssignmentsIndex(string input)
    {
        // 检查字符串长度是否满足要求
        if (input.Length < 3)
        {
            return -1;
        }

        // 检查字符串中是否包含 '/'
        int slashIndex = input.IndexOf('/');
        if (slashIndex == -1)
        {
            return -1;
        }

        // 从最左端的 '/' 往左截取数字部分
        int numberPart = 0;
        int multiplier = 1;
        for (int i = slashIndex - 1; i >= 0; i--)
        {
            char currentChar = input[i];
            if (currentChar >= '0' && currentChar <= '9')
            {
                numberPart = numberPart + ((currentChar - '0') * multiplier);
                multiplier *= 10;
            }
            else
            {
                break;
            }
        }
        // 返回截取到的数字
        return numberPart;
    }
    private static string GetOwnerAndRepoFromUrl(string url)
    {
        // 从URL中提取仓库所有者和仓库名
        var startIndex = url.IndexOf(".com/") + 5;
        var endIndex = url.LastIndexOf(".git") == -1 ? url.LastIndexOf("") + 1 : url.LastIndexOf(".git");
        return url.Substring(startIndex, endIndex - startIndex);
    }
    private static async Task<Url> GetUrlInfo(HttpClient httpClient, string commitInfoUrl)
    {
        // 对每一次提交-查询URL-要查的是filename
        var response = await httpClient.GetAsync(commitInfoUrl);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        var url = JsonConvert.DeserializeObject<Url>(responseContent);
        return url;
    }
    public static async Task<List<F>> GetFileInformation(string addr, string token)
    {
        // 构建请求地址
        //var apiUrl = $"https://api.github.com/repos/{GetOwnerAndRepoFromUrl(addr)}/git/trees/main?recursive=1";
        var apiUrl = $"https://api.github.com/repos/{GetOwnerAndRepoFromUrl(addr)}/commits";

        // 创建HttpClient对象，并设置Headers
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Token {token}");

            // 发送GET请求，并获取响应
            var response = await httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            // 读取响应内容
            var responseContent = await response.Content.ReadAsStringAsync();

            // 解析响应内容
            var apiResult = JsonConvert.DeserializeObject<List<CommitInfo>>(responseContent);

            // 获取提交信息
            var commitInfoTasks = new List<Task<Url>>();
            var timeList = new List<string>();
            foreach (var commitInfo in apiResult)
            {
                var commitInfoUrl = commitInfo.url;
                commitInfoTasks.Add(GetUrlInfo(httpClient, commitInfoUrl));
                timeList.Add(commitInfo.commit.author.date);
            }

            await Task.WhenAll(commitInfoTasks);

            // 处理文件信息
            List<F> files = new List<F>();
            for (var i = 0; i < timeList.Count; i++)
            {
                DateTime tmpTime = DateTime.ParseExact(timeList[i], timeFormat, null);
                foreach (var filename in commitInfoTasks[i].Result.files)
                {
                    string tmpPath = filename.filename;
                    int AssIdx = GetAssignmentsIndex(tmpPath);
                    if (AssIdx == -1)
                    {
                        continue;
                    }
                    int idx = files.FindIndex(f => f.Path == tmpPath);
                    if (idx == -1)
                    {
                        // 这个文件没有出现过
                        files.Add(new F
                        {
                            idx = AssIdx,
                            Path = tmpPath,
                            times = new List<DateTime> { tmpTime },
                            // 注意：times获取时就是按降序排序的！
                            rawUrl = filename.raw_url
                        });
                    }
                    else
                    {
                        files[idx].times.Add(tmpTime);
                        
                    }

                }
            }
            return files;
        }
    }
    public static List<CR> GetAssignments(string addr,string token)
    {

        var list = new List<CR>();
        var result = GetFileInformation(addr, token).GetAwaiter().GetResult();
        Console.WriteLine("Assignments04/1.txt: " + GetRawUrl(ref result, "Assignments04/1.txt"));

        foreach (var file in result)
        {
            // 只处理作业文件
            if (file.idx == -1) continue;
            file.disp();
            var created = file.times.Min();
            var updated = file.times.Max();
            bool flag = true;
            foreach (var cr in list)
            {
                if (cr.index == file.idx)
                {
                    flag = false;
                    // 更新时间的min-max
                    if (cr.updated == null || cr.updated < updated)
                    {
                        cr.updated = updated;
                    }
                    if (cr.created == null || cr.created > updated)
                    {
                        cr.created = updated;
                    }
                }
            }
            if (flag)
            {
                list.Add(new CR
                {
                    index = file.idx,
                    created = updated,
                    updated = updated
                });
            }

        }
        List<CR> sortedList = list.OrderBy(cr => cr.index).ToList();
        return sortedList;
    }
    public static string GetRawUrl(ref List<F> files, string Path)
    {
        return files.Find(f => f.Path == Path).rawUrl;
    }
    public static void Downloader(string addr,string localPath)
    {
        // addr是rawUrl，将addr处文件下载到本地的localPath。
        using (WebClient client = new WebClient())
        {
            client.DownloadFile(addr, localPath);
        }
    }
    public static void Main(string[] args)
    {
        // 测试示例
        string addr = "https://github.com/brinenick511/test";
        string token = "";

        var ans = 
            GetAssignments(addr,token);
        foreach(var a in ans)
        {
            a.disp();
        }

        Console.WriteLine("\nFinished");
        Console.ReadKey();
    }
}
public class CR
{
    //public Student? student { get; set; }
    // 提交记录所属学生
    public int index { get; set; } = -1;
    // 提交所属的作业序号，例如第一次作业，第二次作业
    public DateTime? created { get; set; }
    //作业提交时间
    public DateTime? updated { get; set; }
    //作业修改时间
    //public bool modified { get; set; }
    //作业从上次查询至今是否有修改
    //public bool isCorrected { get; set; }
    // 是否批改过
    public void disp()
    {
        Console.WriteLine($"\nCR.index: {index}, Cr.created: {created}, CR.updated: {updated}");
    }
}
public class F
{
    public string Path { get; set; } // 文件路径及文件名
    public List<DateTime> times { get; set; } // 每一次修改的时间
    public int idx { get; set; } // 文件所属的作业号
    public string rawUrl { get; set; } // 文件最新的下载地址
    public void disp()
    {
        Console.WriteLine($"\nPath: {Path}, Idx: {idx}, rawUrl: {rawUrl}");
        foreach (var times in times)
        {
            Console.WriteLine(times.ToString());
        }
    }
}
