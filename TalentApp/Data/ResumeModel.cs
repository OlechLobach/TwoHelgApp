public class ResumeModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FileName { get; set; }
    public byte[] ResumeFile { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public long FileSize { get; set; }
    public string ResumeType { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
}