using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstClass.Models
{
    [Table("Turmas")]
    public class Turma
    {
        [Key]
        public int TurmaId { get; set; }

        public string Nome { get; set; }

        public IList<Aluno> Alunos { get; set; }

        public Turma(string nome, int id)
        {
            this.Nome = nome;
            this.TurmaId = id;
        }
    }
}