using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Lombiq.RoutePermissions.Models
{
    public class UrlPermissionPart : ContentPart<UrlPermissionPartRecord>
    {
        public string UrlPattern
        {
            get { return Record.UrlPattern; }
            set { Record.UrlPattern = value; }
        }

        public int Priority
        {
            get { return Record.Priority; }
            set { Record.Priority = value; }
        }
    }


    public class UrlPermissionPartRecord : ContentPartRecord
    {
        public virtual string UrlPattern { get; set; }
        public virtual int Priority { get; set; }
    }
}