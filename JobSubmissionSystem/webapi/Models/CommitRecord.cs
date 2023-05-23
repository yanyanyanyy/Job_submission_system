namespace webapi.Models
{
    public class CommitRecord
    {
        public Student? student { get; set; }
        // 提交记录所属学生
        public int index { get; set; } = 0;
        // 提交所属的作业序号，例如第一次作业，第二次作业
        public DateTime? created { get; set; }
        //作业提交时间
        public DateTime? updated { get; set; }
        //作业修改时间
        public bool modified { get; set; }
        //作业从上次查询至今是否有修改
        public bool isCorrected { get; set; }
        // 是否批改过

    }
}
