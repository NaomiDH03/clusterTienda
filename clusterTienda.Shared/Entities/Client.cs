using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clusterTienda.Shared.Entities
{
    public class Client
    {
        public int Id { get; set; }
        [Required] //Esto significa que será un campo requerido, o sea, obligatorio
        [MaxLength(100, ErrorMessage = "El campo{0} debe tener máximo {1} caracteres ")]
        //Nota: El required y MaxLenght solo afecta a la propiedad siguiente, o sea, Flavour
        [Display(Name = "Cliente")]
        public string Name { get; set; } = null!;
        public int telephone { get; set; }

        //Los helados pueden tener muchos compradores
        public Icecream Icecream { get; set; } = null!;
    }
}
