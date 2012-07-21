using System;
using System.Web.Mvc;
using ThreeBytes.Core.Extensions.Web;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.ProjectHollywood.News.View.Entities;
using ThreeBytes.ProjectHollywood.News.View.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.News.View.Frontend.Controllers
{
    public class NewsViewController : StatelessSessionController
    {
        private readonly INewsViewNewsArticleService service;

        public NewsViewController(INewsViewNewsArticleService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        public ActionResult Details()
        {
            return PartialView();
        }

        public ActionResult GetDetails(Guid id)
        {
            NewsViewNewsArticle newsArticle = service.GetById(id);
            return Json(newsArticle, JsonRequestBehavior.AllowGet);
        }
    }
}
