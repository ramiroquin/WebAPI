using Api.DAL.DataContext;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DAL.Repository
{
    public class EmpleadoRepository : IGenericRepository<Empleado>
    {
        private readonly WebApiContext _context;

        public EmpleadoRepository(WebApiContext context)
        {
            _context = context;
        }
        public async Task<bool> Actualizar(Empleado modelo)
        {
            _context.Empleados.Update(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Empleado modelo = _context.Empleados.First(e => e.Id == id);

            if (modelo == null)
            {
                return false;
            }
            _context.Empleados.Remove(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Empleado modelo)
        {
            _context.Empleados.Add(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Empleado> Obtener(int id)
        {
            Empleado? empleado = await _context.Empleados.FindAsync(id);

            empleado = await _context.Empleados.Where(e => e.Id == id).FirstOrDefaultAsync();

            return empleado;
        }

        public async Task<IQueryable<Empleado>> ObtenerTodos()
        {
            IQueryable<Empleado> consultaEmpleadoSQL = _context.Empleados;
            return consultaEmpleadoSQL;
        }
    }
}
