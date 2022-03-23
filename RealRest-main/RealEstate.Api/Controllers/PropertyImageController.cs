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
    [Route("api/v1/propertyImage")]
    [ApiController]
    public class PropertyImageController : Controller
    {
        private readonly IAppPropertyImage _iAppPropertyImage;
        public PropertyImageController(IAppPropertyImage iAppPropertyImage)
        {
            _iAppPropertyImage = iAppPropertyImage;
        }

        [HttpPost]
        [Route("CreatePropertyImage")]
        public ResponseGeneric CreatePropertyImage([FromBody] PropertyImage data)
        {
            ResponseGeneric response = new ResponseGeneric();

            try
            {
                _iAppPropertyImage.Add(data);

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
        public ResponseGeneric GetPropertyImage(int id)
        {
            ResponseGeneric response = new ResponseGeneric();

            try
            {
                PropertyImage propertyImage = _iAppPropertyImage.GetEntityById(id);

                response.Message = Message.Ok;
                response.Status = HttpStatusCode.OK.ToString();
                response.Success = true;
                response.Data = propertyImage;

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

