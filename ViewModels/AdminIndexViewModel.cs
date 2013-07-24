using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Orchard.ContentManagement;

namespace Lombiq.RoutePermissions.ViewModels
{
    public class AdminIndexViewModel
    {
        public dynamic ListShape { get; set; }
        public RouteValueDictionary CreateRouteValues { get; set; }
    }
}