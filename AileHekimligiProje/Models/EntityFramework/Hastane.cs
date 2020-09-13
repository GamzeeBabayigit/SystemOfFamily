using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AileHekimligiProje.Models.EntityFramework
{
    public class Hastane
    {
        public int HastaneId { get; set; }
        public string SehirAdi { get; set; }
        public string IlceAdi { get; set; }
        public string HastaneAdi { get; set; }
        public int DoktorId { get; set; }
        public int RandevuId { get; set; }
        public string DoktorAdi { get; set; }

        public virtual Doktor Doktor { get; set; }
        public virtual Randevular Randevu { get; set; }
       
    }
 }