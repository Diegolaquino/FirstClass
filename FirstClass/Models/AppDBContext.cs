using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstClass.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("name=AppDBContext")
        {
        }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Prova> Provas { get; set; }
    }
}