using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AileHekimligiProje.Controllers;
using AileHekimligiProje.Models.EntityFramework;


namespace AileHekimligiProje.Models.EntityFramework
{
    public class Model1 : DbContext
    {
        public virtual DbSet<Doktor> Doktors { get; set; }
        public virtual DbSet<Veriler> Verilers { get; set; }
        public virtual DbSet<Hasta> Hastas { get; set; }
        public virtual DbSet<Hastane> Hastanes { get; set; }
        public virtual DbSet<Randevular> Randevulars { get; set; }

        



    }
}