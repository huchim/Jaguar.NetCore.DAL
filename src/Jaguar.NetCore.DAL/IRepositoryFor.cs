// -----------------------------------------------------------------------
// <copyright file="IRepositoryFor.cs" company="Jaguar">
// Este archivo se entrega bajo los términos de la licencia del proyecto..
// </copyright>
// <summary>Conjunto de operaciones que pueden realizarse en cierta tabla.</summary>
// <author>Carlos Huchim Ahumada (huchim@live.com.mx)</author>
// -----------------------------------------------------------------------
namespace Jaguar.Core.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Conjunto de operaciones que pueden realizarse en cierta tabla.
    /// </summary>
    /// <typeparam name="T">Tipo de registros donde se realizará la operación.</typeparam>
    public interface IRepositoryFor<T> : IDisposable where T : class, IEntity
    {
        /// <summary>
        /// Obtiene todos los registros incluyendo las relaciones con otras tablas.
        /// </summary>
        /// <param name="navigationProperties">Lista de campos que se relacionan con otras tablas.</param>
        /// <returns>Lista de registros.</returns>
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Obtiene una lista de registros que cumpla con las condiciones e incluye las relaciones con otras tablas.
        /// </summary>
        /// <param name="where">Condiciones para el filtrado de los datos.</param>
        /// <param name="navigationProperties">Lista de campos que se relacionan con otras tablas.</param>
        /// <returns>Lista de registros.</returns>
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Obtiene un sólo registro que cumpla con las condiciones incluyendo las relaciones con otras tablas.
        /// </summary>
        /// <param name="where">Condiciones para el filtrado de los datos.</param>
        /// <param name="navigationProperties">Lista de campos que se relacionan con otras tablas.</param>
        /// <returns>Un registro único de la tabla <see cref="T"/>.</returns>
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Agrega registros a la tabla.
        /// </summary>
        /// <exception cref="DatabaseException">Lanzada en caso de un error con la base de datos.</exception>
        /// <param name="items">Lista de registros a agregar.</param>
        void Add(params T[] items);

        /// <summary>
        /// Actualiza el registro en la base de datos.
        /// </summary>
        /// <exception cref="DatabaseException">Lanzada cuando existe un error de la base de datos al actualizar el registro.</exception>
        /// <param name="items">Registros a actualizar.</param>
        void Update(params T[] items);

        /// <summary>
        /// Actualiza el registro, incluyendo únicamente ciertas propiedades. Usar <see cref="Update"/> en caso de querer actualizar
        /// todos los campos.
        /// </summary>
        /// <exception cref="DatabaseException">Lanzada en caso de un error con la base de datos.</exception>
        /// <param name="entity">Registro a actualizar.</param>
        /// <param name="navigationProperties">Lista de campos que se incluirán en la actualización.</param>
        void PartialUpdate(T entity, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Elimina registros de la tabla.
        /// </summary>
        /// <exception cref="DatabaseException">Lanzada en caso de un error con la base de datos.</exception>
        /// <param name="items">Lista de registros a eliminar.</param>
        void Remove(params T[] items);

        /// <summary>
        /// Agrega un registro al seguimiento de cambios.
        /// </summary>
        /// <exception cref="DatabaseException">Lanzada en caso de un error con la base de datos.</exception>
        /// <param name="items">Lista de registros a actualizar.</param>
        void Attach(params T[] items);

        /// <summary>
        /// Guarda todos los cambios desde la creación del contexto en la base de datos.
        /// </summary>
        /// <exception cref="DatabaseException">Lanzada en caso de un error con la base de datos.</exception>
        /// <returns>El número de objetos actualizados en la base de datos.</returns>
        int SaveChanges();

        /// <summary>
        /// Crea una nueva entidad a partir del <see cref="T.Id"/> la cual es agrega al control de 
        /// seguimiento de cambios para que posteriormente pueda se guardada utilizando <see cref="SaveChanges"/>.
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <returns>Nueva entidad.</returns>
        T Create(int id);
    }
}
