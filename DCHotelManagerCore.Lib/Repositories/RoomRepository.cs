// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomRepository.cs" company="">
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

    using DCHotelManagerCore.Lib.DbContext;
    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Repositories.Interfaces;

    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// The billing repository.
    /// </summary>
    public class RoomRepository : IEntityRepository<Room>
    {
        /// <summary>
        /// The data base context.
        /// </summary>
        private readonly DataBaseContext dataBaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomRepository"/> class.
        /// </summary>
        /// <param name="dataBaseContext">
        /// The data base context.
        /// </param>
        public RoomRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="billing">
        /// The billing.
        /// </param>
        /// <returns>
        /// The <see cref="Room"/>.
        /// </returns>
        public Room Create(Room billing)
        {
            this.dataBaseContext.Rooms.Add(billing);
            this.dataBaseContext.SaveChanges();

            return billing;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="customersId"></param>
        /// <param name="entities"></param>
        /// <exception cref="ArgumentNullException">
        /// Room is null
        /// </exception>
        public void Delete(int[] roomId)
        {
            foreach (var id in roomId)
            {
                var localRoom = this.dataBaseContext.Hotels.SingleOrDefault(x => x.Id == id);
                if (localRoom == null)
                {
                    throw new ArgumentNullException();
                }

                this.dataBaseContext.Hotels.Remove(localRoom);
                this.dataBaseContext.SaveChanges();
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Room}"/>.
        /// </returns>
        public IList<Room> ReadAllList()
        {
            return this.dataBaseContext.Rooms.Include("Hotel").Include("RoomType").ToList();
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
        public IQueryable<Room> ReadAllQuery(DataBaseContext context)
        {
            return context.Rooms.Include("Hotel").Include("RoomType");
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Room"/>.
        /// </returns>
        public Room ReadOne(int id)
        {
            var room = this.dataBaseContext.Rooms.Include("Hotel").Include("RoomType").SingleOrDefault(x => x.Id == id);
            return room;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="room">
        /// The billing.
        /// </param>
        public void Update(Room room)
        {
            var databaseRoom =
                this.dataBaseContext.Rooms.Include("Hotel").Include("RoomType").SingleOrDefault(x => x.Id == room.Id);
            if (databaseRoom == null)
            {
                return;
            }

            // var databaseHotel = dataBaseContext.Hotels.SingleOrDefault(x => x.Id == billing.HotelId);          //to evala se sxolio giati sto update den mporoume na allaksoume Hotel
            // databaseRoom.HotelId = databaseHotel.Id;                                               //to evala se sxolio giati sto update den mporoume na allaksoume Hotel
            databaseRoom.Code = room.Code;

            // databaseRoom.RoomTypeId = billing.RoomTypeId;                                            // to evala se sxolio giati sto update den mporoume na allaksoume billing Type
            databaseRoom.Updated = DateTime.Now;
            databaseRoom.UpdatedBy = Environment.MachineName;

            this.dataBaseContext.SaveChanges();
        }
    }
}