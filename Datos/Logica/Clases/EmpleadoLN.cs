using Datos.Clases;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class EmpleadoLN
    {
        public List<Empleado> ViewEmpleado(string valor)
        {
            List<Empleado> lista = new List<Empleado>();
            Empleado oc;

            try
            {
                var auxLista = EmpleadoCD.ListaEmpleadoFiltro(valor);
                foreach (var obj in auxLista)
                {
                    oc = new Empleado(obj.IdCargo, obj.Cedula, obj.Nombres, obj.Apellidos,
                                      obj.Telefono, obj.Email, obj.Salario, obj.IdCargo);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar empleados", ex);
            }
            return lista;
        }

        public bool CreateEmpleado(Empleado oc)
        {
            try
            {
                EmpleadoCD.InsertarEmpleado(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar empleado", ex);
            }
        }

        public bool UpdateEmpleado(Empleado oc)
        {
            try
            {
                EmpleadoCD.ModificarEmpleado(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar empleado", ex);
            }
        }

        public bool DeleteEmpleado(Empleado oc)
        {
            try
            {
                EmpleadoCD.EliminarEmpleado(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar empleado", ex);
            }
        }

    }
}
