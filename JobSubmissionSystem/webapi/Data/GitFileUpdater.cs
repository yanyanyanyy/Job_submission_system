using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

public class CR//CommitRecord
{
    //public Student? student { get; set; }
    // 提交记录所属学生
    public int index { get; set; } = 0;
    // 提交所属的作业序号，例如第一次作业，第二次作业
    //public DateTime? created { get; set; }
    //作业提交时间
    public DateTime? updated { get; set; }
    //作业修改时间
    //public bool modified { get; set; }
    //作业从上次查询至今是否有修改
    //public bool isCorrected { get; set; }
    // 是否批改过

}
public class F
{
    public string Path { get; set; } // 文件路径及文件名
    public DateTime Updated { get; set; } // 对此文件最后的操作时间，操作包括上传、创建、更新修改等等
    public int idx { get; set; } // 文件所属的作业号
}

public class Commit
{
    public string Sha { get; set; }
    public CommitInfo CommitInfo { get; set; }
}

public class CommitInfo
{
    [JsonProperty("commit")]
    public CommitDetails Commit { get; set; }
}

public class CommitDetails
{
    [JsonProperty("author")]
    public CommitAuthor Author { get; set; }

    [JsonProperty("committer")]
    public CommitAuthor Committer { get; set; }
}

public class CommitAuthor
{
    [JsonProperty("date")]
    public string Date { get; set; }
}

public class GitHubApiResult
{
    public List<GitHubFileInfo> Tree { get; set; }
}

public class GitHubFileInfo
{
    public string Path { get; set; }
    public string Type { get; set; }
    public string Sha { get; set; }
}

public class Program
{
    public static async Task<List<F>> GetFileInformation(string addr, string token)
    {
        // 构建请求地址
        var apiUrl = $"https://api.github.com/repos/{GetOwnerAndRepoFromUrl(addr)}/git/trees/main?recursive=1";

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
            var apiResult = JsonConvert.DeserializeObject<GitHubApiResult>(responseContent);

            // 获取提交信息
            var commitInfoTasks = new List<Task<Commit>>();
            foreach (var file in apiResult.Tree)
            {
                if (file.Type == "blob") // 只获取文件的提交信息
                {
                    var commitInfoUrl = $"https://api.github.com/repos/{GetOwnerAndRepoFromUrl(addr)}/commits?path={file.Path}&per_page=1";
                    commitInfoTasks.Add(GetCommitInfo(httpClient, commitInfoUrl));
                }
            }

            await Task.WhenAll(commitInfoTasks);

            // 处理文件信息
            var fileInfoList = new List<F>();
            foreach (var file in apiResult.Tree)
            {
                if (file.Type == "blob") // 只处理文件
                {
                    var fileInfo = new F
                    {
                        Path = file.Path,
                        Updated = GetFileUpdatedTime(commitInfoTasks, file.Path),
                        idx = GetNumberFromSubstring(file.Path)
                };
                    fileInfoList.Add(fileInfo);
                }
            }

            return fileInfoList;
        }
    }

    private static async Task<Commit> GetCommitInfo(HttpClient httpClient, string commitInfoUrl)
    {
        var response = await httpClient.GetAsync(commitInfoUrl);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var commits = JsonConvert.DeserializeObject<List<Commit>>(responseContent);

        return commits.Count > 0 ? commits[0] : null;
    }

    private static DateTime GetFileUpdatedTime(List<Task<Commit>> commitInfoTasks, string filePath)
    {
        foreach (var task in commitInfoTasks)
        {
            // 等待任务完成
            task.Wait();

            var commit = task.Result;
            //if(commit.CommitInfo!=null) Console.WriteLine("1");
            if (commit != null && commit.CommitInfo != null && commit.CommitInfo.Commit != null && commit.CommitInfo.Commit.Author != null && !string.IsNullOrEmpty(commit.CommitInfo.Commit.Author.Date))
            {
                if (DateTime.TryParse(commit.CommitInfo.Commit.Author.Date, out DateTime updatedTime))
                {
                    return updatedTime;
                }
            }
        }

        // 如果没有更新时间，则使用创建时间
        return DateTime.MinValue;
    }


    private static string GetOwnerAndRepoFromUrl(string url)
    {
        // 从URL中提取仓库所有者和仓库名
        var startIndex = url.IndexOf(".com/") + 5;
        var endIndex = url.LastIndexOf(".git");
        return url.Substring(startIndex, endIndex - startIndex);
    }

    public static int GetNumberFromSubstring(string str, int startIndex=11, int length=2)
    {
        if (startIndex + length > str.Length)
        {
            // 子串长度超过字符串长度，返回 -1
            return -1;
        }
        string sub = str.Substring(startIndex, length);
        int number;
        if (int.TryParse(sub, out number))
        {
            // 子串是数字，返回解析后的整数值
            return number;
        }
        // 子串不是数字，返回 -1
        return -1;
    }
    public static List<CR> GetLatestUpdate(string addr,string token)
    {
        var list = new List<CR>();
        var result = GetFileInformation(addr, token).GetAwaiter().GetResult();
        foreach (var file in result)
        {
            //Console.WriteLine($"Path: {file.Path}, Updated: {file.Updated}, Idx: {file.idx}");
            if (file.idx == -1) continue;
            bool flag = true;
            foreach(var cr in list)
            {
                if (cr.index == file.idx)
                {
                    if (cr.updated == null|| cr.updated < file.Updated)
                    {
                        cr.updated = file.Updated;
                    }
                    flag = false;
                }
            }
            if (flag)
            {
                list.Add(new CR
                {
                    index = file.idx,
                    updated = file.Updated
                });
            }
        }
        return list;
    }
    public static void Main(string[] args)
    {
        // 测试示例
        string addr = "https://github.com/brinenick511/test.git";
        string token = "请使用自己的token测试（token作为代码上传到git后会失效）";

        var ans = GetLatestUpdate(addr, token);

        foreach(var cr in ans)
        {
            Console.WriteLine($"CR.index: {cr.index}, CR.updated: {cr.updated}");
        }

        Console.WriteLine("Finished");
        Console.ReadKey();
    }
}
