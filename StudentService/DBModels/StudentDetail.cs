using System;
using System.Collections.Generic;

namespace StudentService.DBModels;

public partial class StudentDetail
{
    public int DetailsId { get; set; }

    public int? StudentId { get; set; }

    public string? SubjectName { get; set; }

    public virtual StudentMaster? Student { get; set; }
}
