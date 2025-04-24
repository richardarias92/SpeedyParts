﻿using System;
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
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IGenericoRepositorio<Usuario> _modeloRepositorio;
        private readonly IMapper _mapper;

        public UsuarioServicio(IGenericoRepositorio<Usuario> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<SesionDTO> Autorizacion(LoginDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Correo == modelo.Correo && p.Clave == modelo.Clave);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<SesionDTO>(fromDbModelo);
                else throw new TaskCanceledException("No se Encontraron Coincidencias");   
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            try
            { 

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<bool> Editar(UsuarioDTO modelo)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<bool> Eliminar(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<List<UsuarioDTO>> Lista(string rol, string buscar)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<UsuarioDTO> Obtener(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
