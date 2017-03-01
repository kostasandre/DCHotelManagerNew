// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The EntityRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Lib.Repositories.Interfaces
{
    #region

    using System.Collections.Generic;
    using System.Linq;

    using DCHotelManagerCore.Lib.DbContext;
    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Models.Persistent.Interfaces;

    #endregion

    /// <summary>
    /// The EntityRepository interface.
    /// </summary>
    /// <typeparam name="T">
    /// Any Entity parameter
    /// </typeparam>
    public interface IEntityRepository<T>
        where T : IEntity
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="entity">
        /// The billing.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T Create(T entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="customersId"></param>
        void Delete(int[] customersId );

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{List}"/>.
        /// </returns>
        IEnumerable<T> ReadAllList();

        /// <summary>
        /// The read all query.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<T> ReadAllQuery(DataBaseContext context);

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T ReadOne(int id);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The billing.
        /// </param>
        void Update(T entity);
    }
}