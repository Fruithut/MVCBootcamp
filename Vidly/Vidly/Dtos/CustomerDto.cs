using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    /// <summary>
    /// Customer Data Transfer Object
    /// Used to decouple our customer-api from implementation details.
    /// </summary>
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}