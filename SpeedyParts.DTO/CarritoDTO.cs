using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyParts.DTO
{   
    //Almacenar productos en el carrito e información
    public class CarritoDTO
    {
        public ProductoDTO?Producto { get; set; }
        public int ?Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
    }
}
