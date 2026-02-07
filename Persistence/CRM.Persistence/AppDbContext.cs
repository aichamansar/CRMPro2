using CRM.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM.Persistence
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public required DbSet<CrmActivity> Activities { get; set; }

        public required DbSet<Account> Accounts { get; set; }

        public required DbSet<Contact> Contacts { get; set; }

        public required DbSet<User> Users { get; set; }

        public required DbSet<Tenant> Tenants { get; set; }

        public required DbSet<Role> Roles { get; set; }

        public required DbSet<Permission> Permissions { get; set; }

        public required DbSet<Entity> Entities { get; set; }

        public required DbSet<Addresse> Addresses { get; set; }
    }
}
