using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstClass.Models
{
    public static class ProvaFactory
    {
        public static Prova NovaProva(int materiaId, int alunoId)
        {
            return new Prova(materiaId, alunoId);
        }

        public static List<ProvaModel> ToProvaModel(List<Prova> provas)
        {
            var provasModel = new List<ProvaModel>() { };

            foreach(var item in provas)
            {
                provasModel.Add(new ProvaModel(item.ProvaId, item.Nota, item.Materia.Nome));
            }

            return provasModel;
        }
    }

    public class ProvaModel
    {
        public ProvaModel(int provaId, decimal? nota, string materia)
        {
            this.Materia = materia;
            this.ProvaId = provaId;
            this.Nota = nota;
        }

        public int ProvaId { get; set; }

        public decimal? Nota { get; set; }

        public string Materia { get; set; }
    }
}