using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVCwithApiapp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCwithApiapp.Data
{
    public class ApiContext:DbContext
    {
        private readonly IConfiguration _config;

        public ApiContext(DbContextOptions options,IConfiguration config):base(options)
        {
            _config = config;

        }


        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("RESTAPI"));
        }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<User>()
        //        .HasData(new
        //        {
        //            UserId = 1,
        //            Name="Mr Rahim",
        //            Email="MrRahim@gmail.com"
        //        });
        //    builder.Entity<User>()
        //        .HasData(new
        //        {
        //            UserId = 2,
        //            Name = "Mr Karim",
        //            Email = "Mrkarim@gmail.com"
        //        });
        //    builder.Entity<User>()
        //        .HasData(new
        //        {
        //            UserId = 3,
        //            Name = "Mr SuperMan",
        //            Email = "MrSuperMan@gmail.com"
        //        });

        //    builder.Entity<Report>()
        //        .HasData(new
        //        {
        //            ReportId = 1,
        //            ReportDetails = "Road Light of R505 area doesnot work from the last seven days",
        //            UserId = 1,
                    
        //        });
        //    builder.Entity<Report>()
        //        .HasData(new
        //        {
        //            ReportId = 2,
        //            ReportDetails = "Road Light of R505 area doesnot work from the last seven days",
        //            UserId = 1,

        //        });
        //    builder.Entity<Report>()
        //        .HasData(new
        //        {
        //            ReportId = 1,
        //            ReportDetails = "Road Light of R505 area doesnot work from the last seven days",
        //            UserId = 3,

        //        });

        //}


    }
}
