using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace CustomNotificationsWithSignalR
{
    [HubName("customnotificationhub")]
    public class CustomNotificationHub : Hub
    {
        public static void DataAdded(object entity, string entityType)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<CustomNotificationHub>();
            context.Clients.All.DataAdded(entity, entityType);
        }
        public static void DataModified(object entity, string entityType)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<CustomNotificationHub>();
            context.Clients.All.DataModified(entity, entityType);
        }
    }
}