﻿using MessagePack;
using Microsoft.AspNetCore.Identity;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace HouseBills.Domain.Models
{
   
    public class UserApp : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid BillId { get; set; }

        public Bill Bill { get; set; }
    }
}
