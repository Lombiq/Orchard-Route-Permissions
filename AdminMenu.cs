using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;
using Orchard.Security;
using Orchard.UI.Navigation;

namespace Lombiq.RoutePermissions
{
    public class AdminMenu : Component, INavigationProvider
    {
        public string MenuName { get { return "admin"; } }


        public void GetNavigation(NavigationBuilder builder)
        {
            builder.AddImageSet("users")
                .Add(T("Users"), "11",
                    menu => menu
                        .Add(T("Route Permissions"), "3.0", item => item.Action("Index", "Admin", new { area = "Lombiq.RoutePermissions" })
                            .LocalNav().Permission(StandardPermissions.SiteOwner)));
        }
    }
}