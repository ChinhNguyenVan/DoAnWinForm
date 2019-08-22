using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BLL;
namespace Web_QLSV.Controllers
{
    public class LopHocController : Controller
    {
        // GET: LopHoc
        public ActionResult Index()
        {
            LopHocBLL bll = new LopHocBLL();
            return View(bll.GetAllLop());
        }
    }
}