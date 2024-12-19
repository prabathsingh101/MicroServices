using System;
using System.Collections.Generic;

namespace StudentService.DBModels;

public partial class StudentMaster
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public virtual ICollection<StudentDetail> StudentDetails { get; set; } = new List<StudentDetail>();
}
