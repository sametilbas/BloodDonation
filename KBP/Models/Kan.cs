using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KBP.Models
{
    public class Kan
    {
        [Key]
        public int KanID { get; set; }
        [Display(Name = "Kan Grubu:")]
        public string KanGrubu { get; set; }
        [Display(Name = "Miktar")]
        public string Miktar { get; set; }
        [Display(Name = "Zaman")]
        public DateTime zaman { get; set; } //kan verilen zamamn
        [Display(Name = "Kan Verilen Yer")]
        public string Yer { get; set; }

        [ForeignKey("UserID")]
        public  UyeAccount uyeAccounts { get; set; }
        public int UserID { get; set; }
        [ForeignKey("MerkezID")]
        public KanMerkeziAccount merkeziAccount { get; set; }
        public int MerkezID { get; set; }

    }


}