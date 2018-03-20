using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoretest1.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class SignUpModel
    {
        [Required(ErrorMessage = "*请输入用户名")]
        public string userName { get; set; }
        [Required(ErrorMessage = "*请输入邮箱")]
        public string userEmail { get; set; }
        [Required]
        public string userSex { get; set; }
        [Required(ErrorMessage="*请输入密码")]
        public string userPw { get; set; }
        [Required(ErrorMessage="*请重复您的密码")]
        [Compare("userPw",ErrorMessage="*两次输入密码不匹配")]
        public string passwdAgain { get; set; }
    }


    public class SignInModel
    {
        [Required(ErrorMessage = "*请输入用户名")]
        public  string userName{ get; set; }

        [Required(ErrorMessage = "*请输入密码")]
        public string userPw{ get; set; }
    }
}