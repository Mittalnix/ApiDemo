using ApiDemo.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptController : ControllerBase
    {
        _1026dbContext con = new _1026dbContext();
        [HttpGet]
        [Route("ListDept")]
        public IActionResult GetDept()
        {
            var data = from dept in con.Depts select new { Id = dept.Id, Name = dept.Name, Location = dept.Location };
            return Ok(data);
        }
        [HttpGet]
        [Route("ListDept/{id}")]
        public IActionResult GetDept(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be null");
            }
            var data = (from dept in con.Depts where dept.Id == id select new { Id = dept.Id, Name = dept.Name, Location = dept.Location }).FirstOrDefault();
            //var data1 = con.Depts.where(d => d.Id == id).Select(d=> new (Id=d.Id, Name = d.Name, Location = d.Location))
            if (data == null)
            {
                return NotFound($"Department{id} not present");

            }
            return Ok(data);
        }
        [HttpGet]
        [Route("ListCity")]
        public IActionResult GetCity([FromQuery] string city)
        {
            var data = con.Depts.Where(d => d.Location == city);
            return Ok(data);
        }
        [HttpPost]
        [Route("Add Dept")]
        public IActionResult PostDept( Dept depts)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //con.Depts.Add(depts);
                    //con.SaveChanges();
                    // calling store procedure
                    con.Database.ExecuteSqlInterpolated($"adddept {depts.Id},{depts.Name},{depts.Location}");
                }
                catch (Exception)
                {
                    return BadRequest("Something Went Wrong");
                }
            }
            return Created("Recoreds Sucessfully Added", depts);
        }
        [HttpPut]
        [Route("EditDept/{id}")]
        public IActionResult putDept( int id, Dept dept)
        {
            if(ModelState.IsValid)
            {
                Dept Dept1 = con.Depts.Find(id);
                    Dept1.Name = dept.Name;
                Dept1.Location = dept.Location;
                con.SaveChanges();
                return Ok("record updated");
            }
            return BadRequest("unable to edit the record");

        }
        [HttpDelete]
        [Route("DeleteDept/{id}")]
        public IActionResult DeleteDept(int id)
        {
            var data = con.Depts.Find(id);
            con.Depts.Remove(data);
            con.SaveChanges();
            return Ok("record deleted");
        }

    }
}