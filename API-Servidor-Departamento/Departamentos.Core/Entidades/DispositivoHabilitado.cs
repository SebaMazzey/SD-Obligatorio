using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departamentos_Core.Entidades
{
    public class DispositivoHabilitado
    {
        [Key]
        public string Codigo { get; set; }
        public int Numero_Circuito { get; set; }

        public virtual Circuito Circuito { get; set; }
    }
}
