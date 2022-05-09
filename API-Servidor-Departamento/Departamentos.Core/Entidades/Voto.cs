using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departamentos_Core.Entidades
{
    public class Voto
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero_Circuito { get; set; }
        public string Nombre_Opcion { get; set; }

        public virtual Opcion Opcion { get; set; }
        public virtual Circuito Circuito { get; set; }
    }
}
