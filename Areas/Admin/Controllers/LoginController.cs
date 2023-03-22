using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using mvcDangNhap.common;
using WEB_NUOCHOA_TQ.Models;

namespace WEB_NUOCHOA_TQ.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        WebNuocHoa_TQEntities4 db = new WebNuocHoa_TQEntities4();
        // GET: Admin/Login
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //localhos:xxxx/Login/Index

        public ActionResult Index()
        {
            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {
                ViewBag.username = Request.Cookies["username"].Value;
                ViewBag.password = Request.Cookies["password"].Value;
            }
            return View();
        }

        //public void ghinhotaikhoan(string username, string password)
        //{
        //    HttpCookie us = new HttpCookie("username");
        //    HttpCookie pas = new HttpCookie("password");

        //    us.Value = username;
        //    pas.Value = password;

        //    us.Expires = DateTime.Now.AddDays(1);
        //    pas.Expires = DateTime.Now.AddDays(1);
        //    Response.Cookies.Add(us);
        //    Response.Cookies.Add(pas);

        //}

        [HttpPost]
        public ActionResult kiemtradangnhap(string username, string password, string ghinho)
        {
            if (Request.Cookies["username"] != null && Request.Cookies["username"] != null)
            {
                username = Request.Cookies["username"].Value;
                password = Request.Cookies["password"].Value;
            }

            if (checkpassword(username, password))
            {
                var userSession = new UserLogin();
                userSession.UserName = username;

                var listGroups = GetListGroupID(username);//Có thể viết dòng lệnh lấy các GroupID từ CSDL, ví dụ gán ="ADMIN", dùng List<string>

                Session.Add("SESSION_GROUP", listGroups);
                Session.Add("USER_SESSION", userSession);

                //if (ghinho == "on")//Ghi nhớ
                //    ghinhotaikhoan(username, password);
                return Redirect("~/Admin/HomeAdmin");

            }
            return Redirect("~/Admin/Login");
        }
        public List<string> GetListGroupID(string userName)
        {
            var user = db.NguoiDung.Single(x => x.TaiKhoan == userName);

            var data = (from a in db.PhanQuyen
                        join b in db.NguoiDung on a.ID equals b.PhanQuyenID
                        //where b.Ten == userName

                        select new
                        {
                            UserGroupID = b.PhanQuyenID,
                            UserGroupName = a.Name,
                        });

            return data.Select(x => x.UserGroupName).ToList();

        }
        public bool checkpassword(string username, string password)
        {
            if (db.NguoiDung.Where(x => x.TaiKhoan == username && x.MatKhau == password).Count() > 0)

                return true;
            else
                return false;


        }




        public ActionResult Logout()
        {

            //Session["USER_SESSION"] = null;
            //Session["SESSION_GROUP"] = null;


            //if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            //{
            //    HttpCookie us = Request.Cookies["username"];
            //   HttpCookie ps = Request.Cookies["password"];

            //   ps.Expires = DateTime.Now.AddDays(-1);
            //   us.Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies.Add(us);
            //    Response.Cookies.Add(ps);

            //    //FormsAuthentication.SignOut();
            //}
            Session["USER_SESSION"] = null;

            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {
                HttpCookie us = Request.Cookies["username"];
                HttpCookie ps = Request.Cookies["password"];

                ps.Expires = DateTime.Now.AddDays(-1);
                us.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(us);
                Response.Cookies.Add(ps);
            }

            
            //return Redirect("~/Admin/Login");
            return RedirectToAction("Index", "Login");

            //Session["TaiKhoan"] = null;
            //return RedirectToAction("Index");
        }


    }
}