// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Room.cs" company="">
//   
// </copyright>
// <summary>
//   The room.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Lib.Models.Persistent
{
    #region

    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    using DCHotelManagerCore.Lib.Models.Persistent.Interfaces;

    #endregion

    /// <summary>
    /// The room.
    /// </summary>
    public class Room : IEntity, IEntityAudit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        public Room()
        {
            this.Created = DateTime.Now;
            this.CreatedBy = Environment.MachineName;
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the deleted.
        /// </summary>
        public DateTime? Deleted { get; set; }

        /// <summary>
        /// Gets or sets the deleted by.
        /// </summary>
        public string DeletedBy { get; set; }

        /// <summary>
        /// Gets or sets the hotel.
        /// </summary>
        public virtual Hotel Hotel { get; set; }

        /// <summary>
        /// Gets or sets the hotel id.
        /// </summary>
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        /// <summary>
        /// The hotel name.
        /// </summary>
        public string HotelName => this.Hotel.Name;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the room type.
        /// </summary>
        public virtual RoomType RoomType { get; set; }

        /// <summary>
        /// Gets or sets the room type id.
        /// </summary>
        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}