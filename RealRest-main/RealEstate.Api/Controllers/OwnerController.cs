using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Interface;
using RealEstate.Entities.Entities;
using RealEstate.Entities.Utilitarios;
using static RealEstate.Entities.Constants.Constants;

namespace RealEstate.Api.Controllers
{
    [Route("api/v1/owner")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IAppOwner _iAppOwner;
        public OwnerController(IAppOwner iAppOwner)
        {
            _iAppOwner = iAppOwner;
        }

        [HttpPost]
        [Route("CreateOwner")]
        public ResponseGeneric CreateOwner([FromBody] Owner data)
        {
            ResponseGeneric response = new ResponseGeneric();

            try
            {
                _iAppOwner.Add(data);

                response.Message = Message.Ok;
                response.Status = HttpStatusCode.OK.ToString();
                response.Success = true;
                response.Data = data;

            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = HttpStatusCode.Forbidden.ToString();
            }

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseGeneric GetOwner(int id)
        {
            ResponseGeneric response = new ResponseGeneric();

            try
            {
                Owner owner = _iAppOwner.GetEntityById(id);

                response.Message = Message.Ok;
                response.Status = HttpStatusCode.OK.ToString();
                response.Success = true;
                response.Data = owner;

            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = HttpStatusCode.Forbidden.ToString();
            }

            return response;
        }
    }
}

