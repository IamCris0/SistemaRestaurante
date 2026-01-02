using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class ConnectionStringManager
    {
        private static string _connectionString;

        public static void Initialize(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException(
                    "La cadena de conexión no ha sido inicializada. " +
                    "Llame a ConnectionStringManager.Initialize() en Program.cs");
            }
            return _connectionString;
        }
    }
}
