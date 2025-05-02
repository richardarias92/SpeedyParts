using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SpeedyParts.Modelo;
using SpeedyParts.DTO;
using SpeedyParts.Servicio.Contrato;
using SpeedyParts.Repositorio.Contrato;
using AutoMapper;

namespace SpeedyParts.Servicio.Implementacion
{
    public class VentaServicio : IVentaServicio
    {
        private readonly IVenta _modeloRepositorio;
        private readonly IMapper _mapper;

        public VentaServicio(IVenta modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<VentaDTO> Registrar(VentaDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Venta>(modelo);
                var ventaGenerada = await _modeloRepositorio.Registrar(dbModelo);

                if (ventaGenerada.IdVenta != 0) 
                    throw new TaskCanceledException("No se pudo registrar");

                return _mapper.Map<VentaDTO>(ventaGenerada); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
