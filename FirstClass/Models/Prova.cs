using FirstClass.Models.Enum;
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

        public ETipoProva ETipoProva { get; set; }

        [ForeignKey("MateriaId")]
        public virtual Materia Materia { get; set; }

        public int AlunoId { get; set; }

        [ForeignKey("AlunoId")]
        public virtual Aluno Aluno { get; set; }

        public Prova(int materiaId, int alunoId, int tipoProva)
        {
            Random randNum = new Random();
            this.MateriaId = materiaId;
            this.AlunoId = alunoId;
            this.Nota = new decimal(randNum.NextDouble() * 10);

            switch (tipoProva)
            {
                case 1:
                    this.ETipoProva = ETipoProva.Primeira;
                    break;
                case 2:
                    this.ETipoProva = ETipoProva.Segunda;
                    break;
                case 3:
                    this.ETipoProva = ETipoProva.Terceira;
                    break;
                case 4:
                    this.ETipoProva = ETipoProva.Final;
                    break;
                default:
                    break;
            }
        }

        public Prova(int materiaId, int alunoId, int tipoProva, decimal? nota)
        {
            this.MateriaId = materiaId;
            this.AlunoId = alunoId;
            this.Nota = nota;
            this.ETipoProva = ETipoProva.Final;
        }

        public Prova() { }
    }
}