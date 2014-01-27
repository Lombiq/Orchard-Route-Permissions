using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.RoutePermissions.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace Lombiq.RoutePermissions
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            ContentDefinitionManager.AlterTypeDefinition(ContentTypes.UrlPermission,
                cfg => cfg
                    .Creatable()
                    .WithPart("TitlePart")
                    .WithPart("CommonPart",
                        part => part
                            .WithSetting("OwnerEditorSettings.ShowOwnerEditor", "True")
                            .WithSetting("DateEditorSettings.ShowDateEditor", "False"))
                    .WithPart("IdentityPart") // For import/export
                    .WithPart("ContentPermissionsPart")
                    .WithPart(typeof(UrlPermissionPart).Name)
                );


            return 3;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterTypeDefinition(ContentTypes.UrlPermission,
                cfg => cfg
                    .Creatable(false)
                );


            return 2;
        }

        public int UpdateFrom2()
        {
            SchemaBuilder.DropTable("UrlPermissionPartRecord");

            return 3;
        }
    }
}