using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogsHouseService.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Length { get; set; }
        public decimal Weight { get; set; }


        public(object, Type) GetAttributeWithType(string name)
        {
            var field = typeof(Dog).GetProperty(name);
            if (field == null) throw new Exception();
            var value = field.GetValue(this);
            return (value, field.PropertyType);
        }
    }
}
