using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gyldendal.Customer.Data.Entities;

namespace Gyldendal.Customer.Data.DbContext
{
    public class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //protected readonly IConfiguration Configuration;

        public DataContext()
        {

        }
        //public DataContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to postgres with connection string from app settings
        //    options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        //}

        public DbSet<Entities.Customer> customers { get; set; }
    }
}
