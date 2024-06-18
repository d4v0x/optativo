using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Datos
{
    [Table("Cliente")]
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }
        public int Id_banco { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }
        [Required]
        [MaxLength(20)]
        public string Documento { get; set; }
        [Required]
        [MaxLength(200)]
        public string Direccion { get; set; }
        [Required]
        [MaxLength(100)]
        public string Mail { get; set; }
        [Required]
        [MaxLength(20)]
        public string Celular { get; set; }
        [Required]
        [MaxLength(20)]
        public string Estado { get; set; }
    }
}
