using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lombiq.RoutePermissions.Models;
using Lombiq.RoutePermissions.ViewModels;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Aspects;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Security;

namespace Lombiq.RoutePermissions.Controllers
{
    public class AdminController : Controller
    {
        private readonly IOrchardServices _orchardServices;
        private readonly IContentManager _contentManager;
        private readonly dynamic _shapeFactory;

        public Localizer T { get; set; }


        public AdminController(IOrchardServices orchardServices, IShapeFactory shapeFactory)
        {
            _orchardServices = orchardServices;
            _contentManager = orchardServices.ContentManager;
            _shapeFactory = shapeFactory;

            T = NullLocalizer.Instance;
        }


        public ActionResult Index()
        {
            if (!_orchardServices.Authorizer.Authorize(StandardPermissions.SiteOwner, T("Not allowed to manage route permissions"))) return new HttpUnauthorizedResult();

            var items = _contentManager
                .Query(VersionOptions.Latest, ContentTypes.UrlPermission)
                .List()
                .OrderBy(item => item.As<ITitleAspect>().Title);

            var list = _shapeFactory.List();
            list.AddRange(items.Select(item => _contentManager.BuildDisplay(item, "SummaryAdmin")));

            var viewModel = new AdminIndexViewModel
            {
                ListShape = list,
                CreateRouteValues = _contentManager.GetItemMetadata(_contentManager.New(ContentTypes.UrlPermission)).CreateRouteValues
            };
            
            return View(viewModel);
        }
    }
}