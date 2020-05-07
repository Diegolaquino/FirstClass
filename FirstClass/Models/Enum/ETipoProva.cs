using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstClass.Models.Enum
{
    public enum ETipoProva
    {
        [Display(Name = "Primeira")]
        Primeira = 1,

        [Display(Name = "Segunda")]
        Segunda = 2,

        [Display(Name = "Terceira")]
        Terceira = 3,

        [Display(Name = "Final")]
        Final = 4
    }
}