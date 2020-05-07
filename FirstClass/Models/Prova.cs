using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstClass.Models
{
    [Table("Provas")]
    public class Prova
    {
        [Key]
        public int ProvaId { get; set; }

        public decimal? Nota { get; set; }

        public int MateriaId { get; set; }

        [ForeignKey("MateriaId")]
        public virtual Materia Materia { get; set; }

        public int AlunoId { get; set; }

        [ForeignKey("AlunoId")]
        public virtual Aluno Aluno { get; set; }

        public Prova(int materiaId, int alunoId)
        {
            Random randNum = new Random();
            this.MateriaId = materiaId;
            this.AlunoId = alunoId;
            this.Nota = new decimal(randNum.NextDouble() * 10);
        }

        public Prova() { }
    }
}