using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.RoutePermissions.Models;
using Orchard.Caching;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Lombiq.RoutePermissions.Handlers
{
    public class UrlPermissionPartHandler : ContentHandler
    {
        private readonly ISignals _signals;


        public UrlPermissionPartHandler(
            IRepository<UrlPermissionPartRecord> repository,
            ISignals signals)
        {
            Filters.Add(StorageFilter.For(repository));
            _signals = signals;

            OnUpdated<UrlPermissionPart>(EmptyCache);
            OnRemoved<UrlPermissionPart>(EmptyCache);
        }


        private void EmptyCache(ContentContextBase ctx, UrlPermissionPart part)
        {
            _signals.Trigger(Signals.UrlPatternsSignal);
        }
    }
}