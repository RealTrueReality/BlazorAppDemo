namespace AspireApp1.Models.Models;

public class LoginResponseModel {
    public string? Token { get; set; }
    public DateTime TokenExpireTime { get; set; }
}