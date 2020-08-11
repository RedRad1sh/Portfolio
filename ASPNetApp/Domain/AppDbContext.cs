using ASPNetApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetApp.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ProjectItem> ProjectItems;
        public DbSet<TextField> TextFields;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "182e19c5-2ab0-42b1-b854-b6badc35c459",
                Name = "admin",
                NormalizedName = "ADMIN",
            });
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "84c95c59-b1bc-4321-81eb-b4ce82c4441b",
                UserName = "admin",
                NormalizedUserName="ADMIN",
                Email="admin@radishportfolio.com",
                NormalizedEmail= "admin@radishportfolio.com",
                EmailConfirmed=true,
                PasswordHash=new PasswordHasher<IdentityUser>().HashPassword(null, "adminpass420"),
                SecurityStamp=string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "84c95c59-b1bc-4321-81eb-b4ce82c4441b",
                RoleId = "182e19c5-2ab0-42b1-b854-b6badc35c459"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("ea8bb180-3d17-4caa-b5ce-2f78a9ff6bf2"),
                Title = "Главная",
                CodeWord="PageIndex"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("0c291603-659c-4d83-bd2d-86541fd6f857"),
                Title = "Проекты",
                CodeWord = "PageProjects"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("625c2e3f-f9cf-445b-8ae4-4365281bb5b2"),
                Title = "Контакты",
                CodeWord = "PageContacts"
            });
        }


    }
}
