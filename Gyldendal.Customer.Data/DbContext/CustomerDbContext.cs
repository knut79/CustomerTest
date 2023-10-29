using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Gyldendal.Customer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Gyldendal.Customer.Data.DbContext
{
    //public class CustomerDbContext : Microsoft.EntityFrameworkCore.DbContext
    //{
    //    protected readonly IConfiguration Configuration;
    //    public DbSet<CarEntity> Cars { get; set; }
    //    //public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
    //    //{
    //    //    ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    //    //    ChangeTracker.LazyLoadingEnabled = false;
    //    //}
    //    public CustomerDbContext(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    {
    //        // connect to postgres with connection string from app settings
    //        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    //    }

    //    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    //{
    //    //    modelBuilder.Entity<CarEntity>(eb => { eb.HasKey(l => new { l.Model }); });
    //    //}

    //    //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    //    //{
    //    //    var res = await base.SaveChangesAsync(cancellationToken);
    //    //    ChangeTracker.Clear();
    //    //    return res;
    //    //}
    //}
}
