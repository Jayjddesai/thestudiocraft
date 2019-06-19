using StudioCraft.Web.DB;
using StudioCraft.Web.Helper;
using StudioCraft.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StudioCraft.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveInquiry(tblInquiry model)
        {
            if (ModelState.IsValid)
            {
                using(StudioCraftEntities context = CustomRepository.GetDbContext())
                {
                    context.tblInquiry.Add(model);
                    context.SaveChanges();
                }

                string bodyTemplate = System.IO.File.ReadAllText(Server.MapPath("~/Template/InquiryTemplate.html"));

                bodyTemplate = bodyTemplate.Replace("[@NAME]", model.Name);
                bodyTemplate = bodyTemplate.Replace("[@EMAIL]", model.Email);
                bodyTemplate = bodyTemplate.Replace("[@BUDGET]", model.Budget);
                bodyTemplate = bodyTemplate.Replace("[@MESSAGE]", model.Message);
                bodyTemplate = bodyTemplate.Replace("[@REGARDING]", model.Regarding);

                Task task = new Task(() => EmailHelper.SendMail("Studio Craft - New Inquiry", bodyTemplate, true));
                task.Start();

                return RedirectToAction("ThankYou");
            }
            return View("Index");
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}