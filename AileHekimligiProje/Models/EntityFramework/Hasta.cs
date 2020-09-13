using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;


namespace AileHekimligiProje.Models.EntityFramework
{
    public class Hasta
    {
        public Hasta()
        {
            this.Doktors = new HashSet<Doktor>();
        }

        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string TC { get; set; }
        public string Sifre { get; set; }
        public string Yas { get; set; }
        public string Cinsiyet { get; set; }
        public string AnneAdi { get; set; }
        public string BabaAdi { get; set; }
        public string SeriNo { get; set; }
        public Nullable<int> VerilerId { get; set; }
        public Nullable<int> DoktorId { get; set; }
        public string CalismaDurumu { get; set; }
        public string IsYeriBilgileri { get; set; }
        public string Sigara { get; set; }
        public string Alkol { get; set; }
        public string KullanilanIlaclar { get; set; }
        public Nullable<int> RandevuId { get; set; }
        public string Teshis { get; set; }
        public string YenmiIlac { get; set; }

        public virtual ICollection<Doktor> Doktors { get; set; }
        public virtual Veriler Verilers { get; set; }


    }
    
}