namespace FirstClass.Models
{
    public class Materia
    {
        public int MateriaId { get; set; }

        public string Nome { get; set; }

        public int TurmaId { get; set; }

        public virtual Turma Turma { get; set; }
    }
}