using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KBP.Models
{
    public class HastaneAccount
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [Display(Name = "Hastane Adı:")]
        public string HospitalName { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre:")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Lütfen şifrenizi doğru giriniz..")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar:")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [Display(Name = "Adres:")]
        public string Adres { get; set; }
        [Display(Name = "Telefon:")]
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        public int Tel { get; set; }
        [Display(Name = "Açıklama:")]
        public string Aciklama { get; set; }


    }
}