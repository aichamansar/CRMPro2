using CRM.Domain;
using CRM.Domain.Commun;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Persistence
{
    public class DbInitializer
    {
        public async Task SeedData(AppDbContext context)
        {
            // Seed only once (idempotent)
            if (await context.Tenants.AnyAsync() ||
                await context.Roles.AnyAsync() ||
                await context.Permissions.AnyAsync() ||
                await context.Entities.AnyAsync() ||
                await context.Addresses.AnyAsync() ||
                await context.Activities.AnyAsync())
            {
                return;
            }

            var now = DateTime.UtcNow;
            const string seedUser = "seed";
            var updateDate = now.ToString("O");

            var tenant = new Tenant
            {
                Name = "Default Tenant",
                Plan = "Monthly",
                Status = 1
            };
            Stamp(tenant, seedUser, now, updateDate);

            var adminRole = new Role
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin"
            };
            Stamp(adminRole, seedUser, now, updateDate);

            var viewPermission = new Permission
            {
                Id = Guid.NewGuid().ToString(),
                PermissionCode = "ACTIVITIES_VIEW"
            };
            Stamp(viewPermission, seedUser, now, updateDate);

            var accountEntity = new Domain.Entity
            {
                Name = "Account",
                Description = "CRM Account entity"
            };
            Stamp(accountEntity, seedUser, now, updateDate);

            var user = new User
            {
                TenantId = tenant.Id,
                Email = "admin@wisecrm.com",
                IsActive = 1
            };
            Stamp(user, seedUser, now, updateDate);

            var account = new Account
            {
                TenantId = tenant.Id,
                Name = "Electronic company",
                OwnerUser = user.Id,
                Website = "https://electronic.com",
                Phone = "+1-555-0100",
                Address = "1 Main St",
                LastActivity = now
            };
            Stamp(account, seedUser, now, updateDate);

            var contact = new Contact
            {
                TenantId = tenant.Id,
                ContactId = "C-0001",
                Email = "Jon@electronic.com",
                Title = "Mr.",
                Name = "Jon. Babbouchkin",
                Phone = "+1-555-0101",
                OwnerUser = user.Email
            };
            Stamp(contact, seedUser, now, updateDate);

            var address = new Addresse
            {
                ContactId = contact.Id,
                EntityId = 1,
                EntityType = 1,
                City = "Casablanca",
                Country = "MA",
                Phone = "+212-000-0000",
                PostalCode = "20000",
                Street = "100 Avenue Example"
            };
            Stamp(address, seedUser, now, updateDate);

            var activity = new CrmActivity
            {
                TenantId = tenant.Id,
                Type = "Task",
                Title = "First activity",
                Priority = "High",
                EntityId = 1,
                ActivityType = "Call",
                Description = "Seeded activity",
                DueDateTime = now.AddDays(1),
                Note = "Created by seeding",
                RelatedAccount = account,
                RelatedContact = contact,
                AssignedUser = user
            };
            Stamp(activity, seedUser, now, updateDate);

            await context.AddRangeAsync(tenant, adminRole, viewPermission, accountEntity, user, account, contact, address, activity);
            await context.SaveChangesAsync();
        }

        private static void Stamp(DomainBase entity, string user, DateTime now, string updateDate)
        {
            entity.CreatedBy = user;
            entity.CreatedDate = now;
            entity.UpdatedBy = user;
            entity.UpdateDate = updateDate;

            // These are non-nullable and mapped as NOT NULL in the DB
            entity.DeletedBy = string.Empty;
            entity.DeletedDate = DateTime.UnixEpoch;
            entity.IsDeleted = 0;
        }
    }
}
