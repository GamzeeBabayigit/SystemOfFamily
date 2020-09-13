using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AileHekimligiProje.Models.EntityFramework
{
    public class Veriler
    {
        public int Id { get; set; }
        public string humidity { get; set; }
        public string temp { get; set; }
        public string time { get; set; }
    }
}