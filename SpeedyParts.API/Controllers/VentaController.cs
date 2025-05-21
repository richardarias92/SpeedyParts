﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SpeedyParts.Servicio.Contrato;
using SpeedyParts.DTO;
using SpeedyParts.Servicio.Implementacion;

namespace SpeedyParts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaServicio _ventaServicio;

        public VentaController(IVentaServicio ventaServicio)
        {
            _ventaServicio = ventaServicio;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO modelo)
        {

            var response = new ResponseDTO<VentaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _ventaServicio.Registrar(modelo);
            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
        
    }
}
