using Brightskies.Restaurant.Domain.Common;
using System.Collections.Generic;

namespace Brightskies.Restaurant.Domain.Entities
{
    public class Item : Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public ICollection<MenuSelection> MenuSelections { get; set; }
    }
}