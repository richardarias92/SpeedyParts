using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeedyParts.Modelo;
using SpeedyParts.Repositorio.Contrato;
using SpeedyParts.Repositorio.DBContext;

namespace SpeedyParts.Repositorio.Implementacion
{
    public class VentaRepositorio : GenericoRepositorio<Venta>, IVenta
    {
        private readonly DbecommerceContext _dbContext;

        public VentaRepositorio(DbecommerceContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

            using (var transaction = _dbContext.Database.BeginTransaction())
            { 
                //Disminuir stock de venta
                try
                {    
                    foreach (DetalleVenta dv in modelo.DetalleVenta)
                    {
                        Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        producto_encontrado.Cantidad = producto_encontrado.Cantidad - dv.Cantidad;

                        _dbContext.Productos.Update(producto_encontrado);
                    }
                    //Guardar los cambios
                    await _dbContext.SaveChangesAsync();

                    //Guardar informacion en tabla de ventas
                    await _dbContext.Venta.AddAsync(modelo);

                    ventaGenerada = modelo;

                    transaction.Commit();
                }
                catch (Exception)
                {

                    transaction.Rollback();
                    throw;
                }

                return ventaGenerada;
            }
        }
    }
}
