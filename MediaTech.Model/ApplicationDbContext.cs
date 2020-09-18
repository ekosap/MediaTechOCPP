using System;
using System.Collections.Generic;
using System.Text;
using MediaTech.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediaTech.Model
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RoleModel> Role { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<LocationModel> Location { get; set; }
        public DbSet<UserLocationModel> UserLocation { get; set; }
    }
}
