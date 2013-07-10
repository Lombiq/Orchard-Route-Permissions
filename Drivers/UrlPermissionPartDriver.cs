using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.RoutePermissions.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;

namespace Lombiq.RoutePermissions.Drivers
{
    public class UrlPermissionPartDriver : ContentPartDriver<UrlPermissionPart>
    {
        protected override string Prefix
        {
            get { return "Lombiq.RoutePermissions.UrlPermissionPart"; }
        }


        protected override DriverResult Editor(UrlPermissionPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_UrlPermission_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts.UrlPermission",
                    Model: part,
                    Prefix: Prefix));
        }

        protected override DriverResult Editor(UrlPermissionPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(UrlPermissionPart part, ExportContentContext context)
        {
            var element = context.Element(part.PartDefinition.Name);

            element.SetAttributeValue("UrlPattern", part.UrlPattern);
        }

        protected override void Importing(UrlPermissionPart part, ImportContentContext context)
        {
            var partName = part.PartDefinition.Name;

            context.ImportAttribute(partName, "UrlPattern", value => part.UrlPattern = value);
        }
    }
}