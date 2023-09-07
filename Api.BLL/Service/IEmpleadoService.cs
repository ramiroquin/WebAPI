using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.BLL.Service
{
    public interface IEmpleadoService
    {
        Task<bool> Insertar(Empleado modelo);
        Task<bool> Actualizar(Empleado modelo);
        Task<bool> Eliminar(int id);
        Task<Empleado> Obtener(int id);
        Task<IQueryable<Empleado>> ObtenerTodos();
    }
}
