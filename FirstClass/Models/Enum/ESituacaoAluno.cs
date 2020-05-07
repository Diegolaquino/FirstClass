using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstClass.Models
{
    public enum ESituacaoAluno
    {
        [Display(Name = "Aprovado")]
        Aprovado = 0,

        [Display(Name = "Reprovado")]
        Reprovado = 1,

        [Display(Name = "Final")]
        Final = 2,

        [Display(Name = "Pendente")]
        Pendente = 3
    }
}