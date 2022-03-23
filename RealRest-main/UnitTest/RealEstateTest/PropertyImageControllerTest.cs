using System;
using NUnit.Framework;
using RealEstate.Application.App;
using RealEstate.Entities.Entities;
using RealEstate.Domain.Interface;
using RealEstate.Api.Controllers;
using RealEstate.Entities.Utilitarios;
using static RealEstate.Entities.Constants.Constants;
using RealEstate.Infra.Repository;
using RealEstate.Entities.Customers.Property;

namespace UnitTest.RealEstateTest
{
    [TestFixture]
    public class PropertyImageControllerTest
	{
        [Test]
        public void CreatePropertyImageTest_Result_Ok()
        {
            RepositoryPropertyImage interfacePropertyImage = new RepositoryPropertyImage();
            AppPropertyImage appPropertyImage = new AppPropertyImage(interfacePropertyImage);
            PropertyImageController Properties = new PropertyImageController(appPropertyImage);

            PropertyImage propertyImage = new PropertyImage()
            {
                Idproperty = 1,
                Filename = "foto",
                Enabled = true
            };

            string expected = Message.Ok;
            string actual;

            //Act
            ResponseGeneric responseGeneric = Properties.CreatePropertyImage(propertyImage);
            actual = responseGeneric.Message;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

