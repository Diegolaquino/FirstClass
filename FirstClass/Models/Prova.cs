namespace FirstClass.Models
{
    public class Prova
    {
        public int ProvaId { get; set; }

        public decimal? Nota { get; set; }

        public int MateriaId { get; set; }

        public virtual Materia Materia { get; set; }

        public int AlunoId { get; set; }

        public virtual Aluno Aluno { get; set; }

    }
}