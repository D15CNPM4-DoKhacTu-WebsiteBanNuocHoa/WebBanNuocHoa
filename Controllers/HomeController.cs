using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using WEB_NUOCHOA_TQ.Models;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;

namespace WEB_NUOCHOA_TQ.Controllers
{
    public class HomeController : Controller
    {
        WebNuocHoa_TQEntities4 db = new WebNuocHoa_TQEntities4();

        public ActionResult Index()
        {
            
            return View(db.SanPham.ToList());
        }
        public ActionResult MenuPartial()
        {
            var lstSP = db.SanPham;
            return PartialView(lstSP);
        }

        [HttpGet]
        public ActionResult DangKi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKi(NguoiDung nd)
        {
            //Kiểm tra captcha hơp lệ
            if (this.IsCaptchaValid("Captcha không hợp lệ "))
            {
                if (ModelState.IsValid)
                {
                    ViewBag.ThongBao = "Đăng kí thành công";
                    //Thêm khách hàng vào csdl
                    db.NguoiDung.Add(nd);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.ThongBao = "Đăng kí thất bại";
                }
                return View();
            }
            ViewBag.ThongBao = "Mã captcha không đúng";

            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtDangNhap"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();

            NguoiDung nd = db.NguoiDung.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (nd != null)
            {
                Session["TaiKhoan"] = nd;
                //return Content("<script>window.location.reload()</script>");
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
            //return Content("Tài khoản hoặc mật khẩu không đúng");
        }
        //[ChildActionOnly]
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index");
        }
    }
}