using System.Collections.Generic;

namespace FirstClass.Models
{
    public class Turma
    {
        public int TurmaId { get; set; }

        public string Nome { get; set; }

        public IList<Aluno> Alunos { get; set; }
    }
}