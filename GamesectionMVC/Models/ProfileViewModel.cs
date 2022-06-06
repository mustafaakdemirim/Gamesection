using System;
using System.ComponentModel.DataAnnotations;

namespace GamesectionMVC.Models
{
    public class ProfileViewModel
    {
       
        [Required(ErrorMessage = "Kullanıcı Adı Zorunlu Alan!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Zorunlu Alan!")]
        [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir Email Giriniz!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Eski Şifre Zorunlu Alan!")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Yeni Şifre Zorunlu Alan!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Yeni Şifre Tekrar Zorunlu Alan!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
