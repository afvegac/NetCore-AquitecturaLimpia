using System;

using NUnit.Framework;
using RealEstate.Application.App;
using RealEstate.Entities.Entities;
using RealEstate.Domain.Interface;
using RealEstate.Api.Controllers;
using RealEstate.Entities.Utilitarios;
using static RealEstate.Entities.Constants.Constants;
using RealEstate.Infra.Repository;

namespace UnitTest.RealEstateTest
{
	[TestFixture]
	public class OwnerControllerTest
	{
        [Test]
        public void CreateOwnerTest_Result_Ok()
        {
            RepositoryOwner interfaceOwner = new RepositoryOwner();
            AppOwner appOwner = new AppOwner(interfaceOwner);
            OwnerController owners = new OwnerController(appOwner);

            Owner owner = new Owner()
            {
                Address = "address",
                Birthday = DateTime.Now,
                Name = "name",
                Photo = "photo"
            };


            string expected = Message.Ok;
            string actual;

            //Act
            ResponseGeneric responseGeneric = owners.CreateOwner(owner);
            actual = responseGeneric.Message;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

