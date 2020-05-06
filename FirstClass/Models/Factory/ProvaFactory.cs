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
    }
}