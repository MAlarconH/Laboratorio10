using Semana10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana10.Controllers
{
    public class productsController : Controller
    {
        private NeptunoEntities1 db = new NeptunoEntities1();
        // GET: products
        public ActionResult Index()
        {
            return View(db.productos.ToList());
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombreProducto,precioUnidad,categoriaProducto")] productos producto)
        {
            if (ModelState.IsValid)
            {
                db.productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }


    }
}