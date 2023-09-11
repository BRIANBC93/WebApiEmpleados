using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiEmpleados.Models.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        protected readonly Context _context;

        public EmpleadoRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Empleado> GetEmpleados()
        {
            return _context.Empleados.ToList();
        }

        public Empleado GetEmpleadoById(int id)
        {
            return _context.Empleados.Find(id);
        }
        public async Task<Empleado> GetEmpleadoByIdAsync(int id)
        {
            return await Task.Run(() => _context.Empleados.Find(id));
        }

        public async Task<Empleado> CreateEmpleadoAsync(Empleado empleado)
        {
            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task<bool> UpdateEmpleadoAsync(Empleado empleado)
        {
            _context.Entry(empleado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmpleadoAsync(int id)
        {
            var empleado = await GetEmpleadoByIdAsync(id);
            if (empleado is null)
            {
                return false;
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Empleado> SearchEmpleados(string nombre, string rfc, string estatus)
        {
            // Implementa la lógica para buscar empleados según los criterios proporcionados
            var query = _context.Empleados.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(e => e.Nombre.Contains(nombre));
            }

            if (!string.IsNullOrEmpty(rfc))
            {
                query = query.Where(e => e.RFC.Contains(rfc));
            }

            if (!string.IsNullOrEmpty(estatus))
            {
                if (estatus.Equals("labora", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(e => e.FechaBaja == null);
                }
                else if (estatus.Equals("baja", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(e => e.FechaBaja != null);
                }
            }

            return query.ToList();
        }
    
    }
}