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

        public decimal Peso1 { get; set; }

        public decimal Peso2 { get; set; }

        public decimal Peso3 { get; set; }

        public Materia(string nome)
        {
            this.Nome = nome;
        }

        public Materia(){}
    }
}