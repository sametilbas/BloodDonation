using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KBP.Models
{
    public class Duyuru
    {
        [Key]
        public int DuyuruID { get; set; }
        [Display(Name = "Duyuru Adı:")]
        public string D_Ad { get; set; }// kan grubu burda yazılabilir
        [Display(Name = "Duyuru Tarihi:")]
        public DataType D_Tarih { get; set; }
        [Display(Name = "Duyuru Durumu:")]
        public string D_Durumu { get; set; }
        [Display(Name = "Açıklama:")]
        public string Acıklama { get; set; }
        [ForeignKey("UserID")]
        public  HastaneAccount hastane { get; set; }
        public int UserID { get; set; }
    }
}