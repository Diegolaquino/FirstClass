using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstClass.Models
{
    public static class AlunoFactory
    {
        public static Aluno NovoAluno(string nome, int turmaId)
        {
            return new Aluno(nome, turmaId);
        }

        public static string[] nomes = {
            "Alice",
            "Miguel",
            "Sophia",
            "Helena",
            "Bernardo",
            "Arthur",
            "Valentina",
            "Heitor",
            "Laura",
            "Davi",
            "Isabella",
            "Lorenzo",
            "Manuela",
            "Théo",
            "Júlia",
            "Pedro",
            "Heloísa",
            "Gabriel",
            "Luiza",
            "Enzo",
            "Maria Luiza",
            "Matheus",
            "Lorena",
            "Lucas",
            "Lívia",
            "Benjamin",
            "Giovanna",
            "Nicolas",
            "Maria Eduarda",
            "Guilherme",
            "Beatriz",
            "Rafael",
            "Maria Clara",
            "Joaquim",
            "Cecília",
            "Samuel",
            "Eloá",
            "Enzo Gabriel",
            "Lara",
            "João Miguel"
        };
    }
}