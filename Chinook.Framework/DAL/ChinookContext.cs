using Chinook.Framework.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace Chinook.Framework.DAL
{
    public partial class ChinookContext : DbContext
    {
        public ChinookContext()
            : base("name=ChinookDb")
        {
            //this is alternative to using the web.congif
            //to make sure that Entity framework does NOT
            // Created the Database if it can't find the databse

            Database.SetInitializer<ChinookContext>(null);
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>()
                .HasMany(e => e.Tracks)
                .WithMany(e => e.Playlists)
                .Map(m => m.ToTable("PlaylistTrack").MapLeftKey("PlaylistId").MapRightKey("TrackId"));
        }
    }
}
