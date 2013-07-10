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
            SchemaBuilder.CreateTable(typeof(UrlPermissionPartRecord).Name,
                table => table
                    .ContentPartRecord()
                    .Column<string>("UrlPattern", column => column.WithLength(2000))
                    .Column<int>("Priority")
				);

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


            return 1;
        }
    }
}