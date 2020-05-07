using FirstClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstClass.Controllers
{
    public class SimulacaoController : Controller
    {
        private AppDBContext db = new AppDBContext();
        // GET: Simulacao
        public ActionResult Index()
        {
            return View();
        }

        // POST: Simulacao/Create
        [HttpPost]
        [Route("{controller}/create")]
        public JsonResult Create(ModelSimulacao collection)
        {
            try
            {
                var result = CriarDadosSimulacao(collection);

                return Json(new { message = "Dados cadastrados com sucesso", success = true});
            }
            catch(Exception e)
            {
                return Json(new { message = e.Message, success = false, stacktrace = e.StackTrace });
            }
        }

        private bool CriarDadosSimulacao(ModelSimulacao collection)
        {
            try
            {
                var turmas = GerarTurmas(collection.NumeroTurmas);
                db.Turmas.AddRange(turmas);
                db.SaveChanges();

                var alunos = new Aluno[collection.NumeroAlunos];

                for (var i = 0; i < turmas.Length; i++)
                {
                    alunos = GerarAlunos(collection.NumeroAlunos, turmas[i].TurmaId);
                    db.Alunos.AddRange(alunos);
                }

                db.Materias.AddRange(collection.Materias);

                db.SaveChanges();

                return true;
            }
            catch
            {
                throw;
            }
 
        }

        private Turma[] GerarTurmas(int quantidadeTurmas)
        {
            var turmas = new Turma[quantidadeTurmas];

            for (int i = 0; i < quantidadeTurmas; i++)
            {
                turmas[i] = TurmaFactory.NovaTurma($"Turma { i + 1}", i + 1);
            }

            return turmas;
        }

        private Aluno[] GerarAlunos(int quantidadealunos, int turmaId)
        {
            var alunos = new Aluno[quantidadealunos];

            for (int i = 0; i < quantidadealunos; i++)
            {
                alunos[i] = AlunoFactory.NovoAluno(AlunoFactory.nomes[i], turmaId);
            }

            return alunos;
        }

        public ActionResult DeletarTudo()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM [Materias]");
            db.Database.ExecuteSqlCommand("DELETE FROM [Provas]");
            db.Database.ExecuteSqlCommand("DELETE FROM [Finalistas]");
            db.Database.ExecuteSqlCommand("DELETE FROM [Alunos]");

            return RedirectToAction("Index");
        }
    }
}
