using BaoCaoWebNangCao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaoCaoWebNangCao.Areas.User.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: User/TaiKhoan
        public ActionResult Index(int id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login","CongThuc");
            }
            else
            {
                WEBNANGCAOEntities1 db = new WEBNANGCAOEntities1();
                TAIKHOAN taikhoan = db.TAIKHOANs.Where(row => row.ID == id).FirstOrDefault();
                return View(taikhoan);
            }
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
            return RedirectToAction("Index", "TaiKhoan", new {id= Session["id"] });
        }
    }
}