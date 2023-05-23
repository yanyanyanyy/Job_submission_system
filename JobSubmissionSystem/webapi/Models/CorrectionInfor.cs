using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace webapi.Models
{
    public class CorrectionInfor {
        //文件树 

        Student? student { get; set; }
        public TreeNode treeView { get; set; }
        public CorrectionInfor()
        {
            treeView = new TreeNode();
            
            GetFiles(new DirectoryInfo("C:\\Users\\yan\\Downloads\\DotNetHomeWork-master\\DotNetHomeWork-master\\assignment3\\project1"), treeView);
        }
        
        private void GetFiles(FileSystemInfo fileInfo, TreeNode node)
        {
            //判断是否是文件夹
            if (fileInfo is not DirectoryInfo)
            {
                //不是文件夹
                node.fileInformation = new FileInformation(fileInfo.FullName);
                return;
            }
            // 是文件夹
            DirectoryInfo directoryInfo = new DirectoryInfo(fileInfo.FullName);
            node.fileInformation.filename = fileInfo.Name;
            FileSystemInfo[] childFiles = directoryInfo.GetFileSystemInfos();
            foreach (FileSystemInfo fileInfor in childFiles)
            {
                TreeNode chldNode = new TreeNode();
                GetFiles(fileInfor, chldNode);
                node.sonNodes.Add(chldNode);
            }

        }
    }
    
    public class FileInformation
    {
        // 批改信息类，叶子节点
        public FileInformation(string filePath)
        {
            details = new List<Detail>();
            String line;
            filename =  (new FileInfo(filePath)).Name;
            System.IO.StreamReader stream =new System.IO.StreamReader(filePath);
            while ((line = stream.ReadLine()) != null)
            {
                
                //details.Add(new Detail(line, ""));
            }
        }
        public List<Detail> details { get; set; }
        public FileInformation() { }
        public string filename { get; set; } = "";
    }
    public class Detail
    {
        public Detail(string line, string v)
        {
            code = line;
            description = v;
        }

        public string? code { get; set; }
        public string? description { get; set; } 
    }

    public class TreeNode
    { 
        public List<TreeNode> sonNodes { get; set; } = new List<TreeNode>();
        public FileInformation fileInformation { get; set; } = new FileInformation();
    }
}
