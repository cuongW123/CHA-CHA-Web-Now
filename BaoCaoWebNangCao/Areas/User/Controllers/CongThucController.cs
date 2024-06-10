using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaoCaoWebNangCao.Models;

namespace BaoCaoWebNangCao.Areas.User.Controllers
{
    public class CongThucController : Controller
    {
        // GET: User/CongThuc
        public ActionResult Index(string search="")
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                WEBNANGCAOEntities1 db = new WEBNANGCAOEntities1();
                /*List<CONGTHUC> congthuc = db.CONGTHUCs.ToList();*/
                List<CONGTHUC> congthuc = db.CONGTHUCs.Where(row => row.TENCONGTHUC.Contains(search)).ToList();
                return View(congthuc);
            }
        }
        public ActionResult Details(int id)
        {
            WEBNANGCAOEntities1 db = new WEBNANGCAOEntities1();
            CONGTHUC congthuc = db.CONGTHUCs.Where(row => row.ID == id).FirstOrDefault();
            return View(congthuc);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string tendangnhap, string matkhau)
        {
            WEBNANGCAOEntities1 db = new WEBNANGCAOEntities1();
            var demtaikhoan = db.TAIKHOANs.Where(m=>m.TENDANGNHAP.ToLower()==tendangnhap.ToLower()&&m.MATKHAU==matkhau).FirstOrDefault();
            if(demtaikhoan !=null)
            {
                Session["user"] = demtaikhoan.TENDANGNHAP;
                Session["id"] = demtaikhoan.ID;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult AddFavourite()
        {  
            return View();       
        }
        [HttpPost]
        public ActionResult AddFavourite(int idtaikhoan, int idcongthuc)
        {
            WEBNANGCAOEntities1 db = new WEBNANGCAOEntities1();
            YEUTHICH love = db.YEUTHICHes.FirstOrDefault(row=>row.IDTAIKHOAN==idtaikhoan && row.IDCONGTHUC==idcongthuc);
            if(love!=null)
            {
                return RedirectToAction("Index");
            }
            var yeuthich = new YEUTHICH()
            {
                IDTAIKHOAN = idtaikhoan,
                IDCONGTHUC = idcongthuc
            };
            db.YEUTHICHes.Add(yeuthich);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DropFavourite(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DropFavourite(int id, YEUTHICH y)
        {
            WEBNANGCAOEntities1 db = new WEBNANGCAOEntities1();
            YEUTHICH love = db.YEUTHICHes.Where(row => row.ID == id).FirstOrDefault();
            db.YEUTHICHes.Remove(love);
            db.SaveChanges();
            return RedirectToAction("Index", "TaiKhoan", new { id = Session["id"] });
        }

    }
}