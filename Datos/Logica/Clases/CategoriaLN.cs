using Datos.Clases;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class CategoriaLN
    {
        public List<Categoria> ViewCategoria(string valor)
        {
            List<Categoria> lista = new List<Categoria>();
            Categoria oc;

            try
            {
                var auxLista = CategoriaCD.ListarCategoriaFiltro(valor);
                foreach (var obj in auxLista)
                {
                    oc = new Categoria(obj.IdCategoria, obj.Nombre, obj.Descripcion);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar categorías", ex);
            }
            return lista;
        }

        public bool CreateCategoria(Categoria oc)
        {
            try
            {
                CategoriaCD.InsertarCategoria(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar categoría", ex);
            }
        }

        public bool UpdateCategoria(Categoria oc)
        {
            try
            {
                CategoriaCD.ModificarCategoria(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar categoría", ex);
            }
        }

        public bool DeleteCategoria(Categoria oc)
        {
            try
            {
                CategoriaCD.EliminarCategoria(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar categoría", ex);
            }
        }

    }
}
