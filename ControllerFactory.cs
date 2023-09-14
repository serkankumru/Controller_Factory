using BusinessLayer;
using DAL;
using News.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace News.ControllerFactory
{
    public class ContFact:DefaultControllerFactory
    {
        static INewsRepository _repo;
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (_repo == null)
            {
                _repo = RepositoryFactory.CreateRepositoryNews();
            }
            if (controllerName == "Home")
            {
               // IController cnt = new HomeController(_repo);
               // return cnt;
            }
            return base.CreateController(requestContext, controllerName);
        }
    }
}