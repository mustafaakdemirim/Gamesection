using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Entity.POCO
{
    public class AppUser : IdentityUser<int>
    {
        public string Adress { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
