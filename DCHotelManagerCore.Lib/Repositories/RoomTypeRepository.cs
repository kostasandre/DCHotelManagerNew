// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomTypeRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The room type repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Lib.Repositories
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DCHotelManagerCore.Lib.DbContext;
    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Repositories.Interfaces;

    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// The room type repository.
    /// </summary>
    public class RoomTypeRepository : IEntityRepository<RoomType>
    {
        /// <summary>
        /// The data base context.
        /// </summary>
        private readonly DataBaseContext dataBaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomTypeRepository"/> class.
        /// </summary>
        /// <param name="dataBaseContext">
        /// The data base context.
        /// </param>
        public RoomTypeRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="billing">
        /// The billing type.
        /// </param>
        /// <returns>
        /// The <see cref="RoomType"/>.
        /// </returns>
        public RoomType Create(RoomType billing)
        {
            this.dataBaseContext.RoomTypes.Add(billing);
            try
            {
                this.dataBaseContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return billing;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The billing type is null
        /// </exception>
        public void Delete(int id)
        {
            var roomType = this.dataBaseContext.RoomTypes.SingleOrDefault(x => x.Id == id);
            if (roomType == null)
            {
                throw new ArgumentNullException();
            }

            this.dataBaseContext.RoomTypes.Remove(roomType);
            this.dataBaseContext.SaveChanges();
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{billing}"/>.
        /// </returns>
        public IList<RoomType> ReadAllList()
        {
            return this.dataBaseContext.RoomTypes.Include("Rooms").ToList();
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
        public IQueryable<RoomType> ReadAllQuery(DataBaseContext context)
        {
            return context.RoomTypes.Include("Rooms");
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="RoomType"/>.
        /// </returns>
        public RoomType ReadOne(int id)
        {
            var roomType = this.dataBaseContext.RoomTypes.Include("Rooms").SingleOrDefault(x => x.Id == id);
            return roomType;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="roomType">
        /// The billing type.
        /// </param>
        public void Update(RoomType roomType)
        {
            var databaseRoomType = this.dataBaseContext.RoomTypes.SingleOrDefault(x => x.Id == roomType.Id);

            if (databaseRoomType == null)
            {
                return;
            }

            databaseRoomType.Code = roomType.Code;
            databaseRoomType.BedType = roomType.BedType;
            databaseRoomType.Sauna = roomType.Sauna;
            databaseRoomType.Tv = roomType.Tv;
            databaseRoomType.WiFi = roomType.WiFi;
            databaseRoomType.Updated = DateTime.Now;
            databaseRoomType.UpdatedBy = Environment.MachineName;
            databaseRoomType.View = roomType.View;
            this.dataBaseContext.SaveChanges();
        }
    }
}