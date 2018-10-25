using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestServiceTest.Model;

namespace RestServiceTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private static List<Car> cList = new List<Car>()
        {
            new Car("Audi", "A6", 5000000),
            new Car("BMW", "320D", 450000),
            new Car("Mercedes", "A180", 350000)
        };
        

        // GET: api/Car
        [HttpGet]
        public List<Car> Get()
        {
            return cList;
        }

        // GET: api/Car/5
        [HttpGet("{id}", Name = "Get")]
        //Finder en car hvor ID matcher det angivne input
        public IActionResult GetCar(int id)
        {
            Car car = cList.Find(c => c.ID == id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // POST: api/Car
        [HttpPost]
        //Test i postman ved at tilføje en json body
        public HttpResponseMessage PostCar(Car c)
        {
            cList.Add(c);
            return new HttpResponseMessage(System.Net.HttpStatusCode.Created);
        }

        //PUT: api/Customer
        [HttpPut]
        public HttpResponseMessage PutCar(Car car)
        {
            Car carToChange = cList.Find(c => c.ID == car.ID);
      
            if (carToChange == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            }

            carToChange.ID = car.ID;
            carToChange.Make = car.Make;
            carToChange.Type = car.Type;
            carToChange.Price = car.Price;

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IEnumerable<Car> DeleteCar(int id)
        {
            Car car = cList.Find(c => c.ID == id);
            cList.Remove(car);

            return cList;
        }
    }
}
