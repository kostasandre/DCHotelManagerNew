// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Hotel.cs" company="">
//   
// </copyright>
// <summary>
//   The hotel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Lib.Models.Persistent
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using DCHotelManagerCore.Lib.Models.Persistent.Interfaces;

    using Microsoft.AspNetCore.Http;

    #endregion

    /// <summary>
    /// The hotel.
    /// </summary>
    public class Hotel : IEntity, IEntityAudit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hotel"/> class.
        /// </summary>
        public Hotel()
        {
            this.Rooms = new List<Room>();
            this.Pictures = new List<Picture>();
            this.Created = DateTime.Now;
            this.CreatedBy = Environment.MachineName;

            this.SelectedRooms = new List<Room>();
            this.AllRooms = new List<Room>();

            this.IsChecked = false;
            this.Id = 0;
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the all rooms.
        /// </summary>
        [NotMapped]
        public List<Room> AllRooms { get; set; }

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
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is checked.
        /// </summary>
        [NotMapped]
        public bool IsChecked { get; set; }

        /// <summary>
        /// Gets or sets the manager.
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the pictures.
        /// </summary>
        public List<Picture> Pictures { get; set; }

        /// <summary>
        /// Gets or sets the rooms.
        /// </summary>
        public virtual List<Room> Rooms { get; set; }

        /// <summary>
        /// Gets or sets the selected rooms.
        /// </summary>
        [NotMapped]
        public List<Room> SelectedRooms { get; set; }

        /// <summary>
        /// Gets or sets the tax id.
        /// </summary>
        public string TaxId { get; set; }

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