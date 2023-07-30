using BasseinProekt.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;

namespace BasseinProekta.Models
{
    public class BasseinContext : DbContext
    {
        public BasseinContext(DbContextOptions<BasseinContext> options) : base(options)
        { }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Karta> Kartas { get; set; }
        public DbSet<TypeGroup> TypeGroups { get; set; }
        public DbSet<KartaKlienta> KartaKlientas { get; set; }
        public DbSet<Klient> Klients { get; set; }
        public DbSet<Kontakt> Kontakts { get; set; }
        public DbSet<Raspisanie> Raspisanies { get; set; }
        public DbSet<Spravka> Spravkas { get; set; }
        public DbSet<Trener> Treners { get; set; }
        public DbSet<TypeTrener> TypeTreners { get; set; }
        public DbSet<TypeZanRti> TypeZanRtis { get; set; }
        public DbSet<TypeVanna> TypeVannas { get; set; }
        public DbSet<Vanna> Vannas { get; set; }
        public DbSet<Ychet> Ychets { get; set; }
        public DbSet<ZanRti> ZanRtis { get; set; }
    }
}
