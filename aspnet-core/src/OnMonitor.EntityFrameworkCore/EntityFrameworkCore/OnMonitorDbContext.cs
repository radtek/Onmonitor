using Microsoft.EntityFrameworkCore;
using OnMonitor.Users;
using OnMonitor.Monitor;
using OnMonitor.MonitorRepair;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users.EntityFrameworkCore;
using OnMonitor.MenusInfos;
using OnMonitor.OrderMaterials;

namespace OnMonitor.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See OnMonitorMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class OnMonitorDbContext : AbpDbContext<OnMonitorDbContext>
    {
        public DbSet<AppUser> Users { get; set; }
        //设定监控镜头实体类
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<DVR> DVRs { get; set; }
        public DbSet<CameraRepair> CameraRepairs { get; set; }
        public DbSet<ProjectManages> ProjectManages { get; set; }
        public DbSet<DVRCheckInfo> DVRCheckInfos { get; set; }
        public DbSet<Alarm> Alarms { get; set; }


        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside OnMonitorDbContextModelCreatingExtensions.ConfigureOnMonitor
         */
        public DbSet<SystemMenu> SystemMenus { get; set; }
      
        public DbSet<MaterialRepertory> MaterialRepertories { get; set; }
        public DbSet<ProcurementContent> ProcurementContents { get; set; }
        public DbSet<ProcurementDeltail> ProcurementDeltails { get; set; }
        public DbSet<ProductInfo> ProductInfos { get; set; }
        public DbSet<SaleContent> SaleContents { get; set; }
        public DbSet<SaleDeltail> SaleDeltails { get; set; }

        public OnMonitorDbContext(DbContextOptions<OnMonitorDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable("AbpUsers"); //Sharing the same table "AbpUsers" with the IdentityUser
                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                //Moved customization to a method so we can share it with the OnMonitorMigrationsDbContext class
                b.ConfigureCustomUserProperties();
            });

            /* Configure your own tables/entities inside the ConfigureOnMonitor method */

            builder.ConfigureOnMonitor();
        }
    }

}
