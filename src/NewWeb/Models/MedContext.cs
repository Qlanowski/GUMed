using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace NewWeb.Models
{
    public class MedContext : IdentityDbContext<Doctor>
    {
        private IConfigurationRoot _config;

        public MedContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<DoctorProject> DoctorProjects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //tworzenie tabeli łacznikowej miedzy Doctorem a Patientem
            modelBuilder.Entity<DoctorProject>()
                .HasKey(t => new { t.Id, t.ProjectId });

            modelBuilder.Entity<DoctorProject>()
             .HasOne(pt => pt.Project)
             .WithMany(p => p.DoctorProjects)
             .HasForeignKey(pt => pt.ProjectId);

            modelBuilder.Entity<DoctorProject>()
             .HasOne(pt => pt.Doctor)
             .WithMany(t => t.DoctorProjects)
             .HasForeignKey(pt => pt.Id);
            // magiczna linika, pozwala dodać Identity bo inaczej wyskakuje blad z UserLogin
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:MedContextConnection"]);//bierze ścieżke z config.json
        }


    }
}

