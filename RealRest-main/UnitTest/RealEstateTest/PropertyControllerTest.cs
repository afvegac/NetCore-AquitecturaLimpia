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
    public class PropertyControllerTest
    {
        [Test]
        public void CreatePropertyTest_Result_Ok()
        {
            RepositoryProperty interfaceProperty = new RepositoryProperty();
            AppProperty appProperty = new AppProperty(interfaceProperty);
            PropertyController Properties = new PropertyController(appProperty);

            Property property = new Property()
            {
                Name = "name property",
                Address = "address property",
                Price = 0,
                Codeinternal = 0,
                Year = 0,
                Idowner = 1
            };

            string expected = Message.Ok;
            string actual;

            //Act
            ResponseGeneric responseGeneric = Properties.CreateProperty(property);
            actual = responseGeneric.Message;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdatePricePropertyTest_Result_Ok()
        {
            RepositoryProperty interfaceProperty = new RepositoryProperty();
            AppProperty appProperty = new AppProperty(interfaceProperty);
            PropertyController Properties = new PropertyController(appProperty);

            PropertyPriceRequest propertyPrice = new PropertyPriceRequest()
            {
                idProperty = 3,
                price =15000
            };

            string expected = Message.Ok;
            string actual = "";

            //Act
            ResponseGeneric responseGeneric = Properties.UpdatePriceProperty(propertyPrice);
            actual = responseGeneric.Message;

            //Assert
            Assert.IsInstanceOf<ResponseGeneric>(responseGeneric);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdatePropertyTest_Result_Ok()
        {
            RepositoryProperty interfaceProperty = new RepositoryProperty();
            AppProperty appProperty = new AppProperty(interfaceProperty);
            PropertyController Properties = new PropertyController(appProperty);

            Property property = new Property()
            {
                Idproperty = 1,
                Name = "name property 2",
                Address = "address property 2",
                Price = 0,
                Codeinternal = 0,
                Year = 0,
                Idowner = 1
            };

            string expected = Message.Ok;
            string actual = "";

            //Act
            ResponseGeneric responseGeneric = Properties.UpdateProperty(property);
            actual = responseGeneric.Message;

            //Assert
            Assert.IsInstanceOf<ResponseGeneric>(responseGeneric);
            Assert.AreEqual(expected, actual);
        }

    }

}