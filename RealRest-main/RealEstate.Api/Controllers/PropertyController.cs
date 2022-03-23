using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Interface;
using RealEstate.Entities.Entities;
using RealEstate.Entities.Customers.Property;
using RealEstate.Entities.Utilitarios;
using static RealEstate.Entities.Constants.Constants;
using System.Linq.Expressions;
using LinqKit;

namespace RealEstate.Api.Controllers
{
    [Route("api/v1/property")]
    [ApiController]
    public class PropertyController : Controller
    {
        private readonly IAppProperty _iAppProperty;
        public PropertyController(IAppProperty iAppProperty)
        {
            _iAppProperty = iAppProperty;
        }

        [HttpPost]
        [Route("CreateProperty")]
        public ResponseGeneric CreateProperty([FromBody] Property data)
        {
            ResponseGeneric response = new ResponseGeneric();

            try
            {
                _iAppProperty.Add(data);

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
        public ResponseGeneric GetProperty(int id)
        {
            ResponseGeneric response = new ResponseGeneric();

            try
            {
                Property property = _iAppProperty.GetEntityByIdIncludes(id);

                response.Message = Message.Ok;
                response.Status = HttpStatusCode.OK.ToString();
                response.Success = true;
                response.Data = property;

            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = HttpStatusCode.Forbidden.ToString();
            }

            return response;
        }

        [HttpGet]
        [Route("getAll")]
        public ResponseGeneric GetProperties()
        {
            ResponseGeneric response = new ResponseGeneric();

            try
            {
                List<Property> properties = _iAppProperty.GetAll();

                response.Message = Message.Ok;
                response.Status = HttpStatusCode.OK.ToString();
                response.Success = true;
                response.Data = properties;

            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = HttpStatusCode.Forbidden.ToString();
            }

            return response;
        }

        [HttpGet]
        [Route("get")]
        public ResponseGeneric GetProperties([FromQuery]propertyFiltersRequest filters)
        {
            ResponseGeneric response = new ResponseGeneric();
            var predicate = PredicateBuilder.New<Property>();

            if (!string.IsNullOrEmpty(filters.Name))
                predicate = predicate.And(p => p.Name.Contains(filters.Name.Trim()));

            if (!string.IsNullOrEmpty(filters.Address))
                predicate = predicate.And(p => p.Address.Contains(filters.Address.Trim()));

            if (filters.Price != null)
                predicate = predicate.And(p => p.Price.Equals(filters.Price));

            if (filters.Codeinternal != null)
                predicate = predicate.And(p => p.Codeinternal.Equals(filters.Codeinternal));

            if (filters.Year != null)
                predicate = predicate.And(p => p.Year.Equals(filters.Year));

            if (filters.Idowner != null)
                predicate = predicate.And(p => p.Idowner.Equals(filters.Idowner));

            try
            {
                List<Property> properties = _iAppProperty.List(predicate);

                response.Message = Message.Ok;
                response.Status = HttpStatusCode.OK.ToString();
                response.Success = true;
                response.Data = properties;

            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = HttpStatusCode.Forbidden.ToString();
            }

            return response;
        }

        [HttpPost]
        [Route("UpdatePrice")]
        public ResponseGeneric UpdatePriceProperty([FromBody] PropertyPriceRequest data)
        {
            ResponseGeneric response = new ResponseGeneric();

            try
            {
                Property property = _iAppProperty.GetEntityByIdIncludes(data.idProperty);
                property.Price = data.price;
                _iAppProperty.Update(property);

                response.Message = Message.Ok;
                response.Status = HttpStatusCode.OK.ToString();
                response.Success = true;
                response.Data = property;

            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = HttpStatusCode.Forbidden.ToString();
            }

            return response;
        }

        [HttpPost]
        [Route("Update")]
        public ResponseGeneric UpdateProperty([FromBody] Property data)
        {
            ResponseGeneric response = new ResponseGeneric();

            try
            {
                _iAppProperty.Update(data);

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
    }
}

