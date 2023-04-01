using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VoTaTung_2080601351_BigSchool.DTOs;
using VoTaTung_2080601351_BigSchool.Models;

namespace VoTaTung_2080601351_BigSchool.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _db;

        public AttendancesController()
        {
            _db = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_db.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The attendance already exists");
            var attendance = new Attendance()
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            };

            _db.Attendances.Add(attendance);
            _db.SaveChanges();
            return Ok();
        }
    }
}
