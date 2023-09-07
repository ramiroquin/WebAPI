using Api.DAL.Repository;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.BLL.Service
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IGenericRepository<Empleado> _repository;

        public EmpleadoService(IGenericRepository<Empleado> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Actualizar(Empleado modelo)
        {
            return await _repository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repository.Eliminar(id);
        }

        public async Task<bool> Insertar(Empleado modelo)
        {
            return await _repository.Insertar(modelo);
        }

        public async Task<Empleado> Obtener(int id)
        {
            return await _repository.Obtener(id);
        }

        public async Task<IQueryable<Empleado>> ObtenerTodos()
        {
            return await _repository.ObtenerTodos();

        }
    }
}
