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
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext dbContext;
        public FollowingsController()
        {
            dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (dbContext.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == followingDto.FolloweeId))
                return BadRequest("The attendance already exists");
            var following = new Following()
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };

            dbContext.Followings.Add(following);
            dbContext.SaveChanges();
            return Ok();
        }

    }
}
