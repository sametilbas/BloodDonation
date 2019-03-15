﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KBP.Models
{
    public class UyeAccount
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [Display(Name = "İsim")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Lütfen şifrenizi doğru giriniz..")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [Display(Name = "Yaş")]
        public int Yas { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [Display(Name = "Boy")]
        public float Boy { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [Display(Name = "Kilo")]
        public int Kilo { get; set; }
        [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [Display(Name = "Adres")]
        public string Adres { get; set; }
        [Display(Name = "Kan Grubu")]
        public string Kan_Grubu { get; set; }
       [Required(ErrorMessage = "Lütfen boş alanları doldurunuz..")]
        [Display(Name = "Tel")]
        public String Tel { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        [Display(Name = "Üyelik Durumu")]
        public bool UyeDurumu { get; set; }
        
    }
}