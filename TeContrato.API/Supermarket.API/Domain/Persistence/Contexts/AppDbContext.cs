using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } //Set = Conjunto. Por eso recomienda Categories, porque las tablas (categories), representa un conjunto
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ControlEmployees> ControlEmployees { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectControl> ProjectControls { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // User Entity

            builder.Entity<User>().ToTable("User");

            // Constraints

            builder.Entity<User>().HasKey(p => p.Cuser);
            builder.Entity<User>().Property(p => p.Cuser).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Cpassword).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Temail).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Cdni).IsRequired().HasMaxLength(8);
            builder.Entity<User>().Property(p => p.Nname).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Nlastname).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.is_admin).IsRequired();


            // Relationships

            builder.Entity<User>();
            // Initial Data

            //builder.Entity<User>().HasData
            //    (
            //        new User { Id = 100, Name = "Fruits and Vegetables"},
            //        new User { Id = 101, Name = "Dairy"}
            //    );

            // Client Entity

            builder.Entity<Client>().ToTable("Clients");

            // Constraints

            builder.Entity<Client>().HasKey(p => p.Cuser);
            builder.Entity<Client>().Property(p => p.Tbio).IsRequired().HasMaxLength(50);
            builder.Entity<Client>().Property(p => p.Taddress).IsRequired().HasMaxLength(50);
            builder.Entity<Client>()
                .HasOne(p => p.Ccity)
                .WithMany(q => q.Clients);

            builder.Entity<Client>()
                .HasMany(p => p.CProject)
                .WithOne(q => q.Client_Cuser);

            

            // Initial Data

            //builder.Entity<Client>().HasData
            //(
            //    new Client { Id = 100, Name = "Apple", QuantityInPackage = 1, UnitOfMeasurement = EUnitOfMeasurement.Unity, CategoryId = 100 },
            //    new Client { Id = 100, Name = "Milk", QuantityInPackage = 2, UnitOfMeasurement = EUnitOfMeasurement.Liter, CategoryId = 101 }
            //);

            // City Entity

            builder.Entity<City>().ToTable("Cities");

            // Constraints

            builder.Entity<City>().HasKey(p => p.Ccity);
            builder.Entity<City>().Property(p => p.Ncity).IsRequired().HasMaxLength(30);
            builder.Entity<City>()
                .HasMany(q => q.Clients)
                .WithOne(p => p.Ccity);
            builder.Entity<City>()
                .HasMany(q => q.Contractors)
                .WithOne(p => p.Ccity);

            // Contractor Entity

            builder.Entity<Contractor>().ToTable("Contractors");

            // Constraints

            builder.Entity<Contractor>().HasKey(p => p.Cuser);
            builder.Entity<Contractor>().Property(p => p.Tbio);
            builder.Entity<Contractor>().Property(p => p.Neducation).HasMaxLength(50);
            builder.Entity<Contractor>().Property(p => p.Numphone).HasMaxLength(50);


            // Relationships
            
            //Project Entity

            builder.Entity<Project>().ToTable("Projects");
            
            //Constraints

            builder.Entity<Project>().HasKey(p => p.Cproject);
            builder.Entity<Project>().Property(p => p.Nproject);
            builder.Entity<Project>().Property(p => p.Created_at);
            builder.Entity<Project>().Property(p => p.Tdescription);
            builder.Entity<Project>().Property(p => p.Fstatus);
            builder.Entity<Project>().Property(p => p.Mbudget);
            builder.Entity<Project>()
                .HasOne(p => p.Contractor_Cuser)
                .WithMany(q => q.CProject);
            builder.Entity<Project>()
                .HasOne(p => p.Client_Cuser)
                .WithMany(q => q.CProject);

            //Posts Entity

            builder.Entity<Posts>().ToTable("Posts");

            builder.Entity<Posts>().HasKey(p => p.Cposts);
            builder.Entity<Posts>().Property(p => p.Ntitle);
            builder.Entity<Posts>().Property(p => p.Tbody);
            builder.Entity<Posts>().Property(p => p.Created_at);
            builder.Entity<Posts>().Property(p => p.Mbudget);
            builder.Entity<Posts>().Property(p => p.Views);
            builder.Entity<Posts>().Property(p => p.Pic);
            //builder.Entity<Posts>().Property(p => p.CClient);
            //builder.Entity<Posts>().Property(p => p.CContractor);
            builder.Entity<Posts>()
                .HasOne(q => q.CContractor)
                .WithMany(p => p.Posts);

            builder.Entity<Posts>()
                .HasOne(q => q.CClient)
                .WithMany(p => p.Posts);

            //Employees Entity

            builder.Entity<Employees>().ToTable("Entities");

            builder.Entity<Employees>().HasKey(p => p.Cemployee);
            builder.Entity<Employees>().Property(p => p.Nemployee);
            builder.Entity<Employees>().Property(p => p.Tposition);
            builder.Entity<Employees>().Property(p => p.Mpayment);
            builder.Entity<Employees>().Property(p => p.Tworks);
            //builder.Entity<Employees>().Property(p => p.Cjob);

            builder.Entity<Employees>()
                .HasMany(p => p.Cjob)
                .WithOne(q => q.CEmployee);
            
            //Job Entity

            builder.Entity<Job>().ToTable("Jobs");
            
            builder.Entity<Job>().HasKey(p=>p.Cjob);
            builder.Entity<Job>().Property(p => p.Njob);
            builder.Entity<Job>().Property(p => p.Tdescription);

            builder.Entity<Job>()
                .HasOne(q => q.CEmployee)
                .WithMany(p => p.Cjob);
            
            //ProjectControl Entity

            builder.Entity<ProjectControl>().ToTable("ProjectControls");

            builder.Entity<ProjectControl>().HasKey(p => p.Ccontrol);
            builder.Entity<ProjectControl>().Property(p => p.Nproject);
            builder.Entity<ProjectControl>().Property(p => p.Fstatus);
            builder.Entity<ProjectControl>().Property(p => p.Dlastedited);
            builder.Entity<ProjectControl>().Property(p => p.Ttasks);
            builder.Entity<ProjectControl>().Property(p => p.Qemployees);
            builder.Entity<ProjectControl>().Property(p => p.Mbudget);
            builder.Entity<ProjectControl>().Property(p => p.Qprogress);

            builder.Entity<ProjectControl>()
                .HasMany(p => p.CProject)
                .WithOne(p => p.CProjectControl);
            
            //ControlEmployees Entity

            builder.Entity<ControlEmployees>().ToTable("ControlEmployees");

            builder.Entity<ControlEmployees>().HasKey(p => p.id);
            
            //builder.Entity<ControlEmployees>().HasKey(p => p.ProjectControl_Control);
            //builder.Entity<ControlEmployees>().HasKey(p => p.Employees_Cemployee);

            builder.Entity<ControlEmployees>()
                .HasMany(p => p.Employees_Cemployee)
                .WithOne(q => q.CControlEmployees);

            builder.Entity<ControlEmployees>()
                .HasMany(p => p.ProjectControl_Control)
                .WithOne(q => q.CControlEmployees);
        }
    }
}
