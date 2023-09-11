using Microsoft.EntityFrameworkCore;
using WebApiEmpleados.Models;

namespace WebApiEmpleados
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { 
        }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
