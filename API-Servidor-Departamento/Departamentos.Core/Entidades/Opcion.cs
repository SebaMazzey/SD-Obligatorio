using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departamentos_Core.Entidades
{
    public class Opcion
    {
        public Opcion()
        {
            Votos = new HashSet<Voto>();
        }

        [Key]
        public string Nombre { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }
    }
}
