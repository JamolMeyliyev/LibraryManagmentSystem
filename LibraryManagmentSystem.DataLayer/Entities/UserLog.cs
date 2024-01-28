

namespace LibraryManagmentSystem.DataLayer.Entities;

public class UserLog
{
    public long UserId { get; set; }
    public User? User { get; set; }
    public int ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}
