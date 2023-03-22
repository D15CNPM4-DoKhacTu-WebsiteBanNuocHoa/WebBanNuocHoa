using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_NUOCHOA_TQ.Models;

namespace WEB_NUOCHOA_TQ.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        WebNuocHoa_TQEntities4 db = new WebNuocHoa_TQEntities4();


        //
        [ChildActionOnly]
        public ActionResult SanPhamStyle1()
        {
            return PartialView();
        }
        //Xây dựng trang xem chi tiết
        public ActionResult XemChiTiet(int? id)
        {
            //Kiểm tra tham số truyền vào có rỗng hay không
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            }
            SanPham sp = db.SanPham.SingleOrDefault(n => n.ID == id);
            if (sp == null)
            {
                return HttpNotFound();

            }
            return View(sp);
        }
        //Load sản phẩm theo mã loại sản phẩm
        public ActionResult SanPham(int? IDLoaiSP)
        {
            if (IDLoaiSP == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            }
            var lstSP = db.SanPham.Where(n => n.IDLoaiSanPham == IDLoaiSP);
            if (lstSP.Count() == 0)
            {
                //Thông báo nếu không có sản phẩm 
                return HttpNotFound();
            }
            return View(lstSP);
        }
    }
}