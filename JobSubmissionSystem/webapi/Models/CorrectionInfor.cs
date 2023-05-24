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
            if (fileInfo is DirectoryInfo)
            {
                // 是文件夹
                DirectoryInfo directoryInfo = new DirectoryInfo(fileInfo.FullName);
                node.filename = fileInfo.Name;
                FileSystemInfo[] childFiles = directoryInfo.GetFileSystemInfos();
                foreach (FileSystemInfo fileInfor in childFiles)
                {
                    if(fileInfor is DirectoryInfo)
                    {
                        TreeNode chldNode = new TreeNode();
                        GetFiles(fileInfor, chldNode);
                        node.sonNodes.Add(chldNode);
                    }
                }
                foreach (FileSystemInfo fileInfor in childFiles)
                {
                    if (fileInfor is not DirectoryInfo)
                    {
                        TreeNode chldNode = new TreeNode();
                        GetFiles(fileInfor, chldNode);
                        node.sonNodes.Add(chldNode);
                    }
                }

            }
            else
            {
                //不是文件夹
                node.filename = fileInfo.Name;
                node.fileInformation = new FileInformation(fileInfo.FullName);
            }

        }
    }
    
    public class FileInformation
    {
        // 批改信息类，叶子节点
        public FileInformation(string filePath)
        {
            code = File.ReadAllText(filePath);
        }
        public FileInformation() { }
        public string? code { get; set; }
    }

    public class TreeNode
    { 
        public List<TreeNode> sonNodes { get; set; } = new List<TreeNode>();
        public FileInformation fileInformation { get; set; } = new FileInformation();
        public string filename { get; set; }
    }
}
