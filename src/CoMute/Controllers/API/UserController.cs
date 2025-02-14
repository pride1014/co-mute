﻿using CoMute.Web.Data;
using CoMute.Web.Models;
using CoMute.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoMute.Web.Controllers.API
{
    /* [RoutePrefix("api/users")]*/

   [Route("api/[controller]")]
  
    public class UserController : ApiController
    {

        CarPoolEntities db = new CarPoolEntities();
        [Route("user/add")]
        public HttpResponseMessage Post(RegistrationRequest registrationRequest)
        {
            var user = new User()
            {
                Name = registrationRequest.Name,
                Surname = registrationRequest.Surname,
                EmailAddress = registrationRequest.EmailAddress,
                
            };

            return Request.CreateResponse(HttpStatusCode.Created, user);
        }


        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(RegistrationRequest registrationRequest)
        {
            var user = new Register
            {
                Name = registrationRequest.Name,
                Surname = registrationRequest.Surname,
                Email = registrationRequest.EmailAddress,
                Password = registrationRequest.Password,
                Phone= Convert.ToInt32(registrationRequest.PhoneNumber),



            };
            db.Registers.Add(user);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, user);
        }
    }


}
