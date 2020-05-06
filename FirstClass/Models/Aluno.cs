using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstClass.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        public int AlunoId { get; set; }

        public string Nome { get; set; }

        public int TurmaId { get; set; }

        public virtual Turma Turma { get; set; }

        public Aluno(string nome, int turmaId)
        {
            this.Nome = nome;
            this.TurmaId = turmaId;
        }

        public static class AlunoFactory
        {
            public static Aluno NovoAluno(string nome, int turmaId)
            {
                return new Aluno(nome, turmaId);
            }
        }
    }
}