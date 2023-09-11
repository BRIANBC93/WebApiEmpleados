using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiEmpleados.Models.Repository
{
    public interface IEmpleadoRepository
    {
        Task<Empleado> CreateEmpleadoAsync(Empleado empleado);
        Task<bool> DeleteEmpleadoAsync(int id);
        Empleado GetEmpleadoById(int id);
        IEnumerable<Empleado> GetEmpleados();
        Task<bool> UpdateEmpleadoAsync(Empleado empleado);
        IEnumerable<Empleado> SearchEmpleados(string nombre, string rfc, string estatus);
    }
}
