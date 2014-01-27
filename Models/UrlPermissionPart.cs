using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Lombiq.RoutePermissions.Models
{
    public class UrlPermissionPart : ContentPart
    {
        [Required]
        public string UrlPattern
        {
            get { return this.Retrieve(x => x.UrlPattern); }
            set { this.Store(x => x.UrlPattern, value); }
        }

        public int Priority
        {
            get { return this.Retrieve(x => x.Priority); }
            set { this.Store(x => x.Priority, value); }
        }
    }
}