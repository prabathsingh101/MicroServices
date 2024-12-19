namespace StudentService.Response
{
    public class StudentResponse
    {
        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public List<StudentDetailsResponse> StudentDetails { get; set; }
    }
}
