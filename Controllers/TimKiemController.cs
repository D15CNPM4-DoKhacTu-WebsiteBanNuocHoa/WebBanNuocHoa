using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_NUOCHOA_TQ.Models;
using PagedList;

namespace WEB_NUOCHOA_TQ.Controllers
{
    public class TimKiemController : Controller
    {
        WebNuocHoa_TQEntities4 db = new WebNuocHoa_TQEntities4();  
        // GET: TimKiem
        public ActionResult KQTimKiem(string sTuKhoa, int? page)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            //Thực hiện chức năng phân trang
            int pageSize = 6;
            //Số trang hiện tại
            int pageNumber = (page ?? 1);
            var lstSP = db.SanPham.Where(n => n.Ten.Contains(sTuKhoa));
            ViewBag.TuKhoa = sTuKhoa;
            return View(lstSP.OrderBy(n => n.Ten).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult LayTuKhoaTimKiem(string sTuKhoa)
        {

            return RedirectToAction("KQTimKiem", new { @sTuKhoa = sTuKhoa });
        }
    }
}