using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServiceTest.Model
{
    public class Car
    {
        public string Make { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int ID { get; set; }

        public static int Id = 0;

        public Car(string make, string type, int price)
        {
            Make = make;
            Type = type;
            Price = price;
            this.ID = Id;
            Id++;
        }

        public Car()
        {
            
        }

        
    }
}
