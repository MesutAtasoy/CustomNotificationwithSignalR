using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomNotificationsWithSignalR;

namespace CustomNotificationsWithSignalR.Models
{
    public partial class CustomNotificationDB
    {
        public override int SaveChanges()
        {
            IEnumerable<DbEntityEntry> addedEntries = this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();

            IEnumerable<DbEntityEntry> modifiedEntries = this.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();

            int result = base.SaveChanges();

            this.HandleAddedEntries(addedEntries);
            this.HandleModifiedEntries(modifiedEntries);

            return result;
        }

        private async Task HandleAddedEntries(IEnumerable<DbEntityEntry> addedEntries)
        {
            foreach (DbEntityEntry entry in addedEntries)
            {
                Type entityType = entry.Entity.GetType().BaseType == typeof(object) ? entry.Entity.GetType() : entry.Entity.GetType().BaseType;
                CustomNotificationHub.DataAdded(entry.Entity, entityType.Name);
            }

            await Task.Yield();
        }
        private async Task HandleModifiedEntries(IEnumerable<DbEntityEntry> modifiedEntries)
        {
            foreach (DbEntityEntry entry in modifiedEntries)
            {
                Type entityType = entry.Entity.GetType().BaseType == typeof(object) ? entry.Entity.GetType() : entry.Entity.GetType().BaseType;
                CustomNotificationHub.DataModified(entry.Entity, entityType.Name);
            }

            await Task.Yield();
        }

    }

}
