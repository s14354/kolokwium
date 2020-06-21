using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_KOL.Models
{
    public class MyDbContext : DbContext

    {
        public MyDbContext() { }

        public MyDbContext(DbContextOptions options)
        : base(options)
        {

        }

        //entities
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artist_Event> Artist_Events { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Event_Organiser> Event_Organisers { get; set; }
        public DbSet<Organiser> Organiser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //PK
            builder.Entity<Artist>().HasKey(q => q.IdArtist);
            builder.Entity<Artist_Event>().HasKey(q => new
            {
                q.IdArtist,
                q.IdEvent
            });
            builder.Entity<Event>().HasKey(q => q.IdEvent);
            builder.Entity<Event_Organiser>().HasKey(q => new
            {
                q.IdEvent,
                q.IdOrganiser
            });
            builder.Entity<Organiser>().HasKey(q => q.IdOrganiser);

            //REF
            builder.Entity<Artist_Event>().HasOne(t => t.Artist).WithMany(t => t.Artist_Events).HasForeignKey(t => t.IdArtist);
            builder.Entity<Artist_Event>().HasOne(t => t.Event).WithMany(t => t.Artist_Events).HasForeignKey(t => t.IdEvent);

            builder.Entity<Event_Organiser>().HasOne(t => t.Event).WithMany(t => t.Event_Organisers).HasForeignKey(t => t.IdEvent);
            builder.Entity<Event_Organiser>().HasOne(t => t.Organiser).WithMany(t => t.Event_Organisers).HasForeignKey(t => t.IdOrganiser);

            //Data
            var artists = new List<Artist>();
            artists.Add(new Artist
            {
                IdArtist = 1,
                Nickname = "Artist1"
            });

            artists.Add(new Artist
            {
                IdArtist = 2,
                Nickname = "Artist2"
            });

            builder.Entity<Artist>().HasData(artists);

            var organisers = new List<Organiser>();
            organisers.Add(new Organiser
            {
                IdOrganiser = 1,
                Name = "Org1"
            });

            organisers.Add(new Organiser
            {
                IdOrganiser = 2,
                Name = "Org2"
            });

            builder.Entity<Organiser>().HasData(organisers);

            var events = new List<Event>();
            events.Add(new Event
            {
                IdEvent = 1,
                Name = "Event1",
                StastDate = DateTime.Now
            }); ;

            events.Add(new Event
            {
                IdEvent = 2,
                Name = "Event2",
                StastDate = DateTime.Now
            });

            builder.Entity<Event>().HasData(events);

            var artistevents = new List<Artist_Event>();
            artistevents.Add(new Artist_Event
            {
                IdArtist = 1,
                IdEvent = 1,
                PerformanceDate = DateTime.Now
            });

            artistevents.Add(new Artist_Event
            {
                IdArtist = 2,
                IdEvent = 2,
                PerformanceDate = DateTime.Now
            });

            builder.Entity<Artist_Event>().HasData(artistevents);

            var eventorgsnisers = new List<Event_Organiser>();
            eventorgsnisers.Add(new Event_Organiser
            {
                IdEvent = 1,
                IdOrganiser = 1
            });

            eventorgsnisers.Add(new Event_Organiser
            {
                IdEvent = 2,
                IdOrganiser = 2
            });

            builder.Entity<Event_Organiser>().HasData(eventorgsnisers);
        }

    }
}
