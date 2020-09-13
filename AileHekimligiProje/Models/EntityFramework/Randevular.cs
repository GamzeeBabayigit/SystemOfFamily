using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AileHekimligiProje.Models.EntityFramework
{
    public class Randevular
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> RandevuSaati { get; set; }
        public string DoktorAdi { get; set; }
        public int DoktorId { get; set; }
        public int RandevuDurum { get; set; }
        public string HastaAdi { get; set; }
        public int HastaId { get; set; }
    }
}