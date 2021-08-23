using RMWA.Models;
using RMWA.ServiceDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMWA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(FormCollection col)
        {
            IEnumerable<SelectListItem> resType = ValueService.GetTypeInfo().Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.TypeName,
                                      Value = x.TypeId.ToString()
                                  });
            ViewData["ResourceType"] = resType;

            IEnumerable<SelectListItem> resDetail = ValueService.GetResourceDetails().Select(x =>
                                    new SelectListItem()
                                    {
                                        Text = x.ResourceDisplayName,
                                        Value = x.ResourceId.ToString()
                                    });
            ViewData["ResourceDetails"] = resDetail;

            IEnumerable<SelectListItem> resTagDetail = ValueService.GetTagNameDetails().Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.TagName,
                                          Value = x.TagName,
                                      });
            ViewData["ResourceTagDetails"] = resTagDetail;

            IEnumerable<SelectListItem> resTagAddDetail = ValueService.GetTagNameDetails().Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.TagName,
                                          Value = x.TagId.ToString(),
                                      });
            ViewData["ResourceTagAddDetails"] = resTagAddDetail;

            //if(col.Count == 6 && col[6] == "ImportFile")
            //{

            //}

            if (col.Count > 0)
            {
                var z = col[1];
                switch (z)
                {
                    case "CreateResource": dbSaver.AddResource(col);
                        break;
                    case "AddTagValue": dbSaver.AddTagValue(col);
                        break;
                    case "RegisterTags": dbSaver.CreateTag(col);
                        break;
                    case "CreateTypes": dbSaver.CreateResourceType(col);
                        break;
                    case "CreateStatus": dbSaver.CreateStatus(col);
                        break;
                    case "CreateSystemTag": dbSaver.CreateSystemTag(col);
                        break;
                }

            }
            
            return View();
        }

        public ActionResult ResourceType(TypeModel typeObj)
        {
            return RedirectToAction("Index");
        }

        public ActionResult StatusType(StatusModel statusObj)
        {
            return RedirectToAction("Index");
        }

        public ActionResult SystemTag(TagModel tagObj)
        {
            return RedirectToAction("Index");
        }

        public ActionResult AddResource(ResourceModel resObj)
        {
            return RedirectToAction("Index");
        }

        public ActionResult CreateTag(TagRegistrationModel tagRegObj)
        {
            return RedirectToAction("Index");
        }

        public ActionResult AddTagValue(ResourceValue resValueObj)
        {
            return RedirectToAction("Index");
        }
    }
}