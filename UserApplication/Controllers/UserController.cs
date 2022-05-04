using DAL_Class.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        FlightApplicationDBContext _flightApplicationDBContext;
        public UserController(FlightApplicationDBContext flightApplicationDBContext)
        {
            _flightApplicationDBContext = flightApplicationDBContext;
        }

        [HttpGet]
        [Route("GetUserDetails")]
        public IEnumerable<TblUserDetail> GetUserDetails()
        {
            return _flightApplicationDBContext.TblUserDetails.ToList();
        }


        [HttpPost]
        [Route("PostUserDetails")]
        public IActionResult PostUserDetails([FromBody] TblUserDetail tblUserDetail)
        {
            
            _flightApplicationDBContext.TblUserDetails.Add(tblUserDetail);           
             _flightApplicationDBContext.SaveChanges();
            return new OkResult();
        }


        [HttpPut]
        [Route("PutUserDetails")]
        public IActionResult PutUserDetails([FromBody] TblUserDetail tblUserDetail)
        {

            _flightApplicationDBContext.Entry(tblUserDetail).State = EntityState.Modified;
            _flightApplicationDBContext.SaveChanges();
            return new OkResult();
        }


        [HttpDelete]
        [Route("DeleteUserDetails")]
        public IActionResult DeleteUserDetails(int UserId)
        {

            var userId=_flightApplicationDBContext.TblUserDetails.Find(UserId);
            _flightApplicationDBContext.TblUserDetails.Remove(userId);
            _flightApplicationDBContext.SaveChanges();
            return new OkResult();
        }


    }
}
