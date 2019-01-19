using System;
using System.Collections.Generic;

namespace GraphQLNetCore.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Menu> Menus { get; set; }
    }
}
