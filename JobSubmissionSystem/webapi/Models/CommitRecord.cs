namespace webapi.Models
{
    public class CommitRecord
    {
        Student? student { get; set; }
        // 提交记录所属学生
        int index { get; set; } = 0;
        // 提交所属的作业序号，例如第一次作业，第二次作业
        DateTime? created { get; set; }
        //作业提交时间
        DateTime? updated { get; set; }
        //作业修改时间
        bool modified { get; set; }
        //作业从上次查询至今是否有修改
        bool isCorrected { get; set; }
        // 是否批改过

    }
}
