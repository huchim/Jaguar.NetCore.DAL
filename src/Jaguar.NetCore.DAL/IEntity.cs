// -----------------------------------------------------------------------
// <copyright file="IEntity.cs" company="Jaguar">
// Este archivo se entrega bajo los términos de la licencia del proyecto..
// </copyright>
// <summary>Representa las propiedades que debe tener como mínimo la entidad a manipular.</summary>
// <author>Carlos Huchim Ahumada (huchim@live.com.mx)</author>
// -----------------------------------------------------------------------
namespace Jaguar.Core.DAL
{
    using System;

    /// <summary>
    /// Representa las propiedades que debe tener como mínimo la entidad a manipular.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de creación del registro.
        /// </summary>
        DateTime Created { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de modificación del registro.
        /// </summary>
        DateTime Modified { get; set; }
    }
}
