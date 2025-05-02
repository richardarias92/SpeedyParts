using AutoMapper;
using SpeedyParts.DTO;
using SpeedyParts.Modelo;
using SpeedyParts.Repositorio.Contrato;
using SpeedyParts.Servicio.Contrato;
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
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly IGenericoRepositorio<Categoria> _modeloRepositorio;
        private readonly IMapper _mapper;

        public CategoriaServicio(IGenericoRepositorio<Categoria> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<CategoriaDTO> Crear(CategoriaDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Categoria>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdCategoria != 0)
                    return _mapper.Map<CategoriaDTO>(rspModelo);

                else throw new TaskCanceledException("No se pudo crear");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Editar(CategoriaDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdCategoria == modelo.IdCategoria);
                var fromDbmodelo = await consulta.FirstOrDefaultAsync();

                if (fromDbmodelo != null)

                {
                    fromDbmodelo.Nombre = modelo.Nombre;
                    var respuesta = await _modeloRepositorio.Editar(fromDbmodelo);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo editar");

                    return respuesta;
                }
                else throw new TaskCanceledException("No se encontraron resultados");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<bool> Editar(UsuarioDTO modelo)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdCategoria == id);
                var fromDbmodelo = await consulta.FirstOrDefaultAsync();

                if (fromDbmodelo != null)
                {
                    var respuesta = await _modeloRepositorio.Eliminar(fromDbmodelo);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo eliminar");

                    return respuesta;
                }
                else throw new TaskCanceledException("No se encontraron resultados");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<CategoriaDTO>> Lista( string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                
                string.Concat(p.Nombre.ToLower()).Contains(buscar.ToLower()));

                List<CategoriaDTO> lista = _mapper.Map<List<CategoriaDTO>>(await consulta.ToListAsync());

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<CategoriaDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdCategoria == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<CategoriaDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
