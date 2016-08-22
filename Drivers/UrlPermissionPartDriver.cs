using System;
using System.Text.RegularExpressions;
using Lombiq.RoutePermissions.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;

namespace Lombiq.RoutePermissions.Drivers
{
    public class UrlPermissionPartDriver : ContentPartDriver<UrlPermissionPart>
    {
        public Localizer T { get; set; }


        public UrlPermissionPartDriver()
        {
            T = NullLocalizer.Instance;
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
            try
            {
                Regex.IsMatch("test", part.UrlPattern);
            }
            catch (ArgumentException ex)
            {
                updater.AddModelError("UrlPatternRegexMalformed", T("There was a problem with the regex you provided: {0}", ex.Message));
            }
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(UrlPermissionPart part, ExportContentContext context)
        {
            ExportInfoset(part, context);
        }

        protected override void Importing(UrlPermissionPart part, ImportContentContext context)
        {
            ImportInfoset(part, context);
        }
    }
}