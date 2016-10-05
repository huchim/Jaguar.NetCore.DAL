// -----------------------------------------------------------------------
// <copyright file="DatabaseException.cs" company="Jaguar">
// Este archivo se entrega bajo los términos de la licencia del proyecto..
// </copyright>
// <summary>Excepción que es provocada por un error al intentar guardar los cambios en la base de datos.</summary>
// <author>Carlos Huchim Ahumada (huchim@live.com.mx)</author>
// -----------------------------------------------------------------------
namespace Jaguar.Core.DAL
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Excepción que es provocada por un error al intentar guardar los cambios en la base de datos.
    /// </summary>
    [Serializable]
    public class DatabaseException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DatabaseException"/>.
        /// </summary>
        public DatabaseException()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DatabaseException"/> con el mensaje de error especificado.
        /// </summary>
        /// <param name="message">Mensaje de error que explica el motivo de la excepción.</param>
        public DatabaseException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DatabaseException"/> con el mensaje de error especificado y una referencia a la excepción interna que representa la causa de esta excepción.
        /// </summary>
        /// <param name="message">Mensaje de error que explica el motivo de la excepción.</param>
        /// <param name="inner">La excepción que es la causa de la excepción actual o una referencia nula (Nothing en Visual Basic) si no se especifica ninguna excepción interna.</param>
        public DatabaseException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DatabaseException"/> con datos serializados..
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/> que contiene los datos serializados del objeto que hacen referencia a la excepción que se va a producir. </param>
        /// <param name="context"><see cref="StreamingContext"/> que contiene información contextual sobre el origen o el destino.</param>
        protected DatabaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
