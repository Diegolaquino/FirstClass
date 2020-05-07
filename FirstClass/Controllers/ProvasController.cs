using FirstClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstClass.Controllers
{
    public class ProvasController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Provas
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetProvas(int idAluno)
        {
            try
            {
                var provas = db.Provas.Where(p => p.AlunoId == idAluno).ToList();
                var provasModel = ProvaFactory.ToProvaModel(provas);

                return Json(new { provasModel, sucess = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { mensagem = e.Message, statcktrace = e.StackTrace, sucess = false }, JsonRequestBehavior.AllowGet);

            }

            
        }

        [HttpGet]
        public JsonResult GerarProvas()
        {
            try
            {
                var provas = CriarCenario();

                db.Provas.AddRange(provas);

                db.SaveChanges();

                return Json(new { message = "provas geradas", success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { message = e.Message, stacktrace = e.StackTrace, success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        private List<Prova> CriarCenario()
        {
            try
            {
                var materias = db.Materias.ToList();
                var alunos = db.Alunos.ToList();

                var provas = new List<Prova>();

                for (int i = 0; i < alunos.Count; i++)
                {
                    for (int j = 0; j < materias.Count; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            provas.Add(ProvaFactory.NovaProva(materias[j].MateriaId, alunos[i].AlunoId));
                        }
                        
                    }
                }

                return provas;
            }
            catch
            {
                throw;
            }
        }
    }
}