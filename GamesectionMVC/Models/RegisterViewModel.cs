using System;
using System.ComponentModel.DataAnnotations;

namespace GamesectionMVC.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Zorunlu Alan!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Zorunlu Alan!")]
        [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir Email Giriniz!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Zorunlu Alan!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
