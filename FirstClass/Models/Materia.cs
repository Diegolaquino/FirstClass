using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstClass.Models
{
    [Table("Materias")]
    public class Materia
    {
        [Key]
        public int MateriaId { get; set; }

        public string Nome { get; set; }

        public int TurmaId { get; set; }

        public virtual Turma Turma { get; set; }

        public Materia(string nome, int turmaId)
        {
            this.Nome = nome;
            this.TurmaId = turmaId;
        }

        public static class MateriaFactory
        {
            public static Materia NovaMateria(string nome, int turmaId)
            {
                return new Materia(nome, turmaId);
            }
        }
    }
}