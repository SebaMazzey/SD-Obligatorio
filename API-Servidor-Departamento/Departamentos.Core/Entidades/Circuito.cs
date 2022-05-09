using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departamentos_Core.Entidades
{
    public class Circuito
    {
        public Circuito()
        {
            Votos = new HashSet<Voto>();
            DispositivosHabilitados = new HashSet<DispositivoHabilitado>();
        }

        [Key]
        public int Numero { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }
        public virtual ICollection<DispositivoHabilitado> DispositivosHabilitados { get; set; }
    }
}
