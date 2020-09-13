using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AileHekimligiProje.Models.EntityFramework
{
    public class Doktor
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Sifre { get; set; }
        public string TC { get; set; }
        public string SehirAdi { get; set; }
        public string IlceAdi { get; set; }
        public string HastaneAdi { get; set; }
        public Nullable<int> HastaneId { get; set; }
        public Nullable<int> HastaId { get; set; }
        public virtual Hasta Hastas { get; set; }
        public virtual Randevular Randevulars { get; set; }
        public int RandevuId { get; set; }
    }

}