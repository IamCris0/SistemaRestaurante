using System;

namespace Datos
{
    /// <summary>
    /// Administrador centralizado de cadenas de conexión para toda la aplicación
    /// </summary>
    public static class ConnectionStringManager
    {
        private static string _connectionString;

        /// <summary>
        /// Inicializa la cadena de conexión global. 
        /// Debe llamarse una sola vez al inicio de la aplicación (en Program.cs)
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a SQL Server</param>
        public static void Initialize(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "La cadena de conexión no puede ser nula o vacía");
            }
            _connectionString = connectionString;
        }

        /// <summary>
        /// Obtiene la cadena de conexión configurada
        /// </summary>
        /// <returns>Cadena de conexión activa</returns>
        /// <exception cref="InvalidOperationException">Si no se ha inicializado la cadena</exception>
        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException(
                    "La cadena de conexión no ha sido inicializada. " +
                    "Asegúrese de llamar a ConnectionStringManager.Initialize() en Program.cs " +
                    "ANTES de que la aplicación procese cualquier solicitud.");
            }
            return _connectionString;
        }
    }
}