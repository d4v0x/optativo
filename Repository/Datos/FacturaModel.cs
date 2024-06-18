using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Datos
{
    [Table("Factura")]
    public class FacturaModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Id_cliente { get; set; }
        [Required]
        [MaxLength(20)]
        public string Nro_Factura { get; set; }
        [Required]
        public DateTime Fecha_Hora { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public int Total_iva5 { get; set; }
        [Required]
        public int Total_iva10 { get; set; }
        [Required]
        public int Total_iva { get; set; }
        [Required]
        [MaxLength(500)]
        public string Total_letras { get; set; }
        [Required]
        [MaxLength(100)]
        public string Sucursal { get; set; }

    }
}
