using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitController : ControllerBase
    {
        public static List<String> Fruits = new List<string> { "Apple", "Banana", "Mango", "Guava", "Orange" };
        // GET: api/<FruitController>
        
        [HttpGet]
        [Route("ListFruits")]
        public IEnumerable<string> Get()
        {
            return Fruits;
        }

        // GET api/<FruitController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return Fruits[id];
        }

        // POST api/<FruitController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Fruits.Add(value);
        }

        // PUT api/<FruitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Fruits[id] = value;
        }

        // DELETE api/<FruitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Fruits.RemoveAt(id);
        }
    }
}
