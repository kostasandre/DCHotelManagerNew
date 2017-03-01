// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The billing repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Lib.Repositories
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Script.Serialization;

    using DCHotelManagerCore.Lib.DbContext;
    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Repositories.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    /// The billing repository.
    /// </summary>
    public class HotelRepository : IEntityRepository<Hotel>
    {
        /// <summary>
        /// The data base context.
        /// </summary>
        private readonly DataBaseContext dataBaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelRepository"/> class.
        /// </summary>
        /// <param name="dataBaseContext">
        /// The data base context.
        /// </param>
        public HotelRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="room">
        /// The billing.
        /// </param>
        /// <returns>
        /// The <see cref="Hotel"/>.
        /// </returns>
        public Hotel Create(Hotel hotel)
        {
            this.dataBaseContext.Hotels.Add(hotel);
            try
            {
                this.dataBaseContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw;
            }

            return hotel;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="customersId">
        /// The customersId.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Hotel is null
        /// </exception>
        public void Delete(int[] hotelsId)
        {
            foreach (var id in hotelsId)
            {
                var localHotel = this.dataBaseContext.Hotels.SingleOrDefault(x => x.Id == id);
                if (localHotel == null)
                {
                    throw new ArgumentNullException();
                }

                this.dataBaseContext.Hotels.Remove(localHotel);
                this.dataBaseContext.SaveChanges();
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Hotel}"/>.
        /// </returns>
        public IEnumerable<Hotel> ReadAllList()
        {
            return this.dataBaseContext.Hotels.Include("Rooms").ToList();
        }

        /// <summary>
        /// The read all query.
        /// </summary>
        /// <param name="context">
        /// The dataBaseContext.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Hotel> ReadAllQuery(DataBaseContext context)
        {
            return context.Hotels.Include("Rooms");
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Hotel"/>.
        /// </returns>
        public Hotel ReadOne(int id)
        {
            var hotel = this.dataBaseContext.Hotels.Include("Rooms").SingleOrDefault(x => x.Id == id);
            return hotel;
        }

        /// <summary>
        /// The un link.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void UnLink(int id)
        {
            var databaseHotel = this.dataBaseContext.Hotels.SingleOrDefault(x => x.Id == id);

            if (databaseHotel == null)
            {
                return;
            }

            this.dataBaseContext.SaveChanges();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="hotel">
        /// The billing.
        /// </param>
        public void Update(Hotel hotel)
        {
            var databaseHotel = this.dataBaseContext.Hotels.SingleOrDefault(x => x.Id == hotel.Id);

            if (databaseHotel == null)
            {
                return;
            }

            databaseHotel.Name = hotel.Name;
            databaseHotel.Address = hotel.Address;
            databaseHotel.Email = hotel.Email;
            databaseHotel.Manager = hotel.Manager;
            databaseHotel.Phone = hotel.Phone;
            databaseHotel.TaxId = hotel.TaxId;

            // databaseHotel.PictureId = billing.PictureId;
            databaseHotel.Updated = DateTime.Now;
            databaseHotel.UpdatedBy = Environment.MachineName;
            this.dataBaseContext.SaveChanges();
        }



    }
}