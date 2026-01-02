using Datos.Clases;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class IngredienteLN
    {
        public List<Ingrediente> ViewIngrediente(string valor)
        {
            List<Ingrediente> lista = new List<Ingrediente>();
            Ingrediente oc;

            try
            {
                var auxLista = IngredienteCD.ListarIngredienteFiltro(valor);
                foreach (var obj in auxLista)
                {
                    oc = new Ingrediente(obj.IdIngrediente, obj.Nombre,
                                         obj.Cantidad, obj.UnidadMedida);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar ingredientes", ex);
            }
            return lista;
        }

        public bool CreateIngrediente(Ingrediente oc)
        {
            try
            {
                IngredienteCD.InsertarIngrediente(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar ingrediente", ex);
            }
        }

        public bool UpdateIngrediente(Ingrediente oc)
        {
            try
            {
                IngredienteCD.ModificarIngrediente(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar ingrediente", ex);
            }
        }

        public bool DeleteIngrediente(Ingrediente oc)
        {
            try
            {
                IngredienteCD.EliminarIngrediente(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar ingrediente", ex);
            }
        }

    }
}
