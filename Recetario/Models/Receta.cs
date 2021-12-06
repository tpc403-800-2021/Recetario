using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recetario.Models
{
    public class Receta
    {
        [Key] //Data Annotation que sirve para indicar que el atributo será la llave primaria
        public int Id { get; set; }
        //Data Annotation que sirve para establecer el largo de un tipo de texto, y adicionalmente configurado un mensage en caso de error
        [StringLength(255, ErrorMessage = "El largo máximo del campo es {0} carácteres.")]
        //DAta annotation para indicar que el campo es requerido en cualquier contexto.
        [Required]
        [DisplayName("Nombre de la Receta")]
        public string Nombre { get; set; }
        [StringLength(511, ErrorMessage = "El largo máximo del campo es {0} carácteres.")]
        [Required]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Preparada Anteriormente")]
        public bool EstaPreparada { get; set; }

        //si tuvvieramos un campo numérico(int, long, float, double)
        //[Range(1, 10)]

       
    }
}
