using System.ComponentModel.DataAnnotations;

namespace AspireApp1.Models.Models;

public class LoginModel {
    [Required(ErrorMessage = "用户名是必填项")]
    
    public string? UserName { get; set; }
    [Required(ErrorMessage = "密码是必填项")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}