using System;
using System.Web.Mvc;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.ProjectHollywood.News.List.Entities;
using ThreeBytes.ProjectHollywood.News.List.Entities.Enums;
using ThreeBytes.ProjectHollywood.News.List.Frontend.Models;
using ThreeBytes.ProjectHollywood.News.List.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.News.List.Frontend.Controllers
{
    public class NewsListController : StatelessSessionController
    {
        private readonly INewsListNewsArticleService service;

        public NewsListController(INewsListNewsArticleService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        [HttpGet]
        public ActionResult List()
        {
            IPagedResult<NewsListNewsArticle> actors = service.GetAllPaged(10, null);
            return PartialView(new PagedNewsListNewsArticleViewModel(actors));
        }

        [HttpGet]
        public JsonResult GetPage(int? page, DateTime? datetime, NewsListOrderByProperty? orderBy, SortBy? sortBy)
        {
            IPagedResult<NewsListNewsArticle> users = service.GetAllPaged(10, datetime, page ?? 1);
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetNewerThan(DateTime datetime)
        {
            IMostRecentResult<NewsListNewsArticle> mostRecentNews = service.GetLatestSince(datetime);
            return Json(mostRecentNews, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(Guid id)
        {
            NewsListNewsArticle item = service.GetById(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}
