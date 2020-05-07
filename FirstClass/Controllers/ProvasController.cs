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

                // laço cria as provas e atualiza a situação do aluno de acordo com as notas
                for (int i = 0; i < alunos.Count; i++)
                {
                    for (int j = 0; j < materias.Count; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            var prova = ProvaFactory.NovaProva(materias[j].MateriaId, alunos[i].AlunoId, (k + 1));
                            provas.Add(prova);

                        }

                        var provasAlunoAtual = provas.Where(x => x.MateriaId == materias[j].MateriaId && x.AlunoId == alunos[i].AlunoId);


                        var media = CalcularFinal(provasAlunoAtual, materias[j]);

                        if(media >= 6)
                        {
                            alunos[i].Situacao = ESituacaoAluno.Aprovado;
                        }
                        else if(media <= 4)
                        {
                            alunos[i].Situacao = ESituacaoAluno.Reprovado;
                        }
                        else
                        {
                            alunos[i].Situacao = ESituacaoAluno.Final;
                            var final = ProvaFactory.ProvaFinal(materias[j].MateriaId, alunos[i].AlunoId, 4, media);

                            provas.Add(final);
                        }

                        
                    }
                }

                foreach(var aluno in alunos)
                {
                    db.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
                }


                db.SaveChanges();
               

                return provas;
            }
            catch
            {
                throw;
            }
        }

        private decimal? CalcularFinal(IEnumerable<Prova> provas, Materia materia)
        {
            var prova1 = provas.First(x => x.ETipoProva == Models.Enum.ETipoProva.Primeira);
            var prova2 = provas.First(x => x.ETipoProva == Models.Enum.ETipoProva.Segunda);
            var prova3 = provas.First(x => x.ETipoProva == Models.Enum.ETipoProva.Terceira);

            var media = (((prova1.Nota * materia.Peso1) + (prova2.Nota * materia.Peso2) + (prova3.Nota * materia.Peso3)) / (materia.Peso1 + materia.Peso2 + materia.Peso3));

            return media;
        }
    }
}