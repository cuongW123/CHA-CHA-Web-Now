using BaoCaoWebNangCao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaoCaoWebNangCao.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: Admin/TaiKhoan
        
        public ActionResult Index(string search="")
        {
            WEBNANGCAOEntities1 db = new WEBNANGCAOEntities1();
            List<TAIKHOAN> taikhoan = db.TAIKHOANs.Where(row=>row.TENNGUOIDUNG.Contains(search)).ToList();
            /*List<TAIKHOAN> taikhoan= db.TAIKHOANs.ToList();*/
            ViewBag.Search=search;
            return View(taikhoan);
        }
        public ActionResult Detail(int id)
        {
            WEBNANGCAOEntities1 db = new WEBNANGCAOEntities1();
            TAIKHOAN taikhoan = db.TAIKHOANs.Where(row => row.ID==id).FirstOrDefault();
			/*Modal detail*/
			if (taikhoan == null)
			{
				return HttpNotFound();
			}

			if (Request.IsAjaxRequest())
			{
				return PartialView("Detail", taikhoan);
			}
			return View(taikhoan);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TAIKHOAN t, HttpPostedFileBase hinhanh)
        {
            WEBNANGCAOEntities1 db = new WEBNANGCAOEntities1();
            if (hinhanh != null && hinhanh.ContentLength > 0)
            {
                //lưu file ảnh
                string rootFolder = Server.MapPath("/Data/Image/");
                string pathImage = rootFolder + hinhanh.FileName;
                hinhanh.SaveAs(pathImage);
                //Lưu thuộc tính url
                t.HINHANH = "/Data/Image/" + hinhanh.FileName;

            }
            db.TAIKHOANs.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Edit(int id)
        {
            WEBNANGCAOEntities1 db = new WEBNANGCAOEntities1();
            TAIKHOAN taikhoan = db.TAIKHOANs.Where(row => row.ID == id).FirstOrDefault();
            return View(taikhoan);
        }
        [HttpPost]
        public ActionResult Edit(TAIKHOAN t, HttpPostedFileBase hinhanh)
        {
            WEBNANGCAOEntities1 db = new WEBNANGCAOEntities1();
            TAIKHOAN taikhoan = db.TAIKHOANs.Where(row => row.ID == t.ID).FirstOrDefault();
            /*Cập nhật*/
            if (hinhanh != null && hinhanh.ContentLength > 0)
            {
                //lưu file ảnh
                string rootFolder = Server.MapPath("/Data/Image/");
                string pathImage = rootFolder + hinhanh.FileName;
                hinhanh.SaveAs(pathImage);
                //Lưu thuộc tính url
                t.HINHANH = "/Data/Image/" + hinhanh.FileName;
                taikhoan.HINHANH = t.HINHANH;

            }
            taikhoan.TENDANGNHAP = t.TENDANGNHAP;
            taikhoan.MATKHAU = t.MATKHAU;
            taikhoan.LOAITAIKHOAN = t.LOAITAIKHOAN;
            taikhoan.TENNGUOIDUNG = t.TENNGUOIDUNG;
            taikhoan.NGAYSINH = t.NGAYSINH;
            taikhoan.DIACHI = t.DIACHI;
            taikhoan.SODIENTHOAI = t.SODIENTHOAI;
            taikhoan.EMAIL = t.EMAIL;
            taikhoan.GIOITINH = t.GIOITINH;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            WEBNANGCAOEntities1 db = new WEBNANGCAOEntities1();
            TAIKHOAN taikhoan = db.TAIKHOANs.Where(row => row.ID == id).FirstOrDefault();
            return View(taikhoan);
        }
        [HttpPost]
        public ActionResult Delete(int id, TAIKHOAN t)
        {
            WEBNANGCAOEntities1 db = new WEBNANGCAOEntities1();
            TAIKHOAN taikhoan = db.TAIKHOANs.Where(row => row.ID == id).FirstOrDefault();
            db.TAIKHOANs.Remove(taikhoan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}