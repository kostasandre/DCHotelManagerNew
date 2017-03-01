// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The room repository.
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

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    /// The room repository.
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
        /// <param name="room">
        /// The room.
        /// </param>
        /// <returns>
        /// The <see cref="Room"/>.
        /// </returns>
        public Room Create(Room room)
        {
            this.dataBaseContext.Rooms.Add(room);
            this.dataBaseContext.SaveChanges();

            return room;
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
                var localRoom = this.dataBaseContext.Rooms.SingleOrDefault(x => x.Id == id);
                if (localRoom == null)
                {
                    throw new ArgumentNullException();
                }

                this.dataBaseContext.Rooms.Remove(localRoom);
                this.dataBaseContext.SaveChanges();
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Room}"/>.
        /// </returns>
        public IEnumerable<Room> ReadAllList()
        {
            return this.dataBaseContext.Rooms.Include("RoomType").ToList();
            
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
        /// The room.
        /// </param>
        public void Update(Room room)
        {
            var databaseRoom =
                this.dataBaseContext.Rooms.Include("Hotel").Include("RoomType").SingleOrDefault(x => x.Id == room.Id);
            if (databaseRoom == null)
            {
                return;
            }

            // var databaseHotel = dataBaseContext.Hotels.SingleOrDefault(x => x.Id == room.HotelId);          //to evala se sxolio giati sto update den mporoume na allaksoume Hotel
            // databaseRoom.HotelId = databaseHotel.Id;                                               //to evala se sxolio giati sto update den mporoume na allaksoume Hotel
            databaseRoom.Code = room.Code;

            // databaseRoom.RoomTypeId = room.RoomTypeId;                                            // to evala se sxolio giati sto update den mporoume na allaksoume room Type
            databaseRoom.Updated = DateTime.Now;
            databaseRoom.UpdatedBy = Environment.MachineName;

            this.dataBaseContext.SaveChanges();
        }
    }
}