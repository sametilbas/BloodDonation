using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KBP.Models
{

    public class Stok
    {
        [Key]
        public int StokID { get; set; }
        public string S_Adı { get; set; } //stoktaki kan grubu adı
        public string S_Miktari { get; set; }
        [ForeignKey("MerkezID")]
        public KanMerkeziAccount merkeziAccount { get; set; }
        public int MerkezID { get; set; }
    }

}