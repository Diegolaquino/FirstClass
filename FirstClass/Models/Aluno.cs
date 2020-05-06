namespace FirstClass.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        public int Nome { get; set; }

        public int TurmaId { get; set; }

        public Turma Turma { get; set; }
    }
}