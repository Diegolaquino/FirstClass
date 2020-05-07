using FirstClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstClass.Controllers
{
    public class AlunosController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Alunos
        public ActionResult Index()
        {
            var alunos = db.Alunos.ToList();
            return View(alunos);
        }
    }

}