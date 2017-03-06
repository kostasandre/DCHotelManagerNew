// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="">
//   
// </copyright>
// <summary>
//   The customer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Lib.Models.Persistent
{
    #region

    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using DCHotelManagerCore.Lib.Models.Persistent.Interfaces;

    #endregion

    /// <summary>
    /// The customer.
    /// </summary>
    public class Customer : IEntity, IEntityAudit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            this.IsChecked = false;
            this.Created = DateTime.Now;
            this.CreatedBy = Environment.MachineName;
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

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
        /// Gets or sets the id number.
        /// </summary>
        public string IdNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is checked.
        /// </summary>
        [NotMapped]
        public bool IsChecked { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        public string Surname { get; set; }

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