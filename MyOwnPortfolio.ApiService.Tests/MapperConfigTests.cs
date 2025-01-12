using AutoMapper;
using MyOwnPortfolio.ApiService.Entities;
using MyOwnPortfolio.ApiService.Models;
using MyOwnPortfolio.ApiService.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnPortfolio.ApiService.Tests
{
    [TestClass]
    public class MapperConfigTests
    {
        private IMapper? _mapper;

        [TestInitialize]
        public void Setup()
        {
            // Initialize the AutoMapper using your MapperConfig class
            _mapper = MapperConfig.InitializeAutoMapper();
        }


        [TestMethod]
        public void AutoMapper_ConfigurationIsValid()
        {
            // Act & Assert
            _mapper?.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void AutoMapper_MapsAboutMeUIModelToAboutMe_Correctly()
        {
            // Arrange
            var aboutMeUIModel = new AboutMeUIModel
            {
                Name = "John Doe",
                Email = "johndoe@example.com",
                ContactNumber = "1234567890"
            };

            // Act
            var aboutMe = _mapper.Map<AboutMe>(aboutMeUIModel);

            // Assert
            Assert.IsNotNull(aboutMe);
            Assert.AreEqual(aboutMeUIModel.Name, aboutMe.Name);
            Assert.AreEqual(aboutMeUIModel.Email, aboutMe.Email);
            Assert.AreEqual(aboutMeUIModel.ContactNumber, aboutMe.ContactNumber);
            Assert.IsNull(aboutMe.ID); // Ignored property should remain null
        }

        [TestMethod]
        public void AutoMapper_MapsAboutMeUIModelCollectionToAboutMeCollection_Correctly()
        {
            // Arrange
            var aboutMeUIModels = new List<AboutMeUIModel>
    {
        new AboutMeUIModel { Name = "John Doe", Email = "john@example.com", ContactNumber = "1234567890" },
        new AboutMeUIModel { Name = "Jane Smith", Email = "jane@example.com", ContactNumber = "9876543210" }
    };

            // Act
            var aboutMeList = _mapper.Map<List<AboutMe>>(aboutMeUIModels);

            // Assert
            Assert.IsNotNull(aboutMeList);
            Assert.AreEqual(aboutMeUIModels.Count, aboutMeList.Count);
            for (int i = 0; i < aboutMeUIModels.Count; i++)
            {
                Assert.AreEqual(aboutMeUIModels[i].Name, aboutMeList[i].Name);
                Assert.AreEqual(aboutMeUIModels[i].Email, aboutMeList[i].Email);
                Assert.AreEqual(aboutMeUIModels[i].ContactNumber, aboutMeList[i].ContactNumber);
                Assert.IsNull(aboutMeList[i].ID); // Ignored property should remain null
            }
        }

        [TestMethod]
        public void AutoMapper_MapsAboutMeToAboutMeUIModel_Correctly()
        {
            // Arrange
            var aboutMe = new AboutMe
            {
                ID = "12345",
                Name = "John Doe",
                Email = "johndoe@example.com",
                ContactNumber = "1234567890"
            };

            // Act
            var aboutMeUIModel = _mapper.Map<AboutMeUIModel>(aboutMe);

            // Assert
            Assert.IsNotNull(aboutMeUIModel);
            Assert.AreEqual(aboutMe.Name, aboutMeUIModel.Name);
            Assert.AreEqual(aboutMe.Email, aboutMeUIModel.Email);
            Assert.AreEqual(aboutMe.ContactNumber, aboutMeUIModel.ContactNumber);
        }

        [TestMethod]
        public void AutoMapper_MapsAboutMeCollectionToAboutMeUIModelCollection_Correctly()
        {
            // Arrange
            var aboutMeList = new List<AboutMe>
    {
        new AboutMe { ID = "12345", Name = "John Doe", Email = "john@example.com", ContactNumber = "1234567890" },
        new AboutMe { ID = "67890", Name = "Jane Smith", Email = "jane@example.com", ContactNumber = "9876543210" }
    };

            // Act
            var aboutMeUIModels = _mapper.Map<List<AboutMeUIModel>>(aboutMeList);

            // Assert
            Assert.IsNotNull(aboutMeUIModels);
            Assert.AreEqual(aboutMeList.Count, aboutMeUIModels.Count);
            for (int i = 0; i < aboutMeList.Count; i++)
            {
                Assert.AreEqual(aboutMeList[i].Name, aboutMeUIModels[i].Name);
                Assert.AreEqual(aboutMeList[i].Email, aboutMeUIModels[i].Email);
                Assert.AreEqual(aboutMeList[i].ContactNumber, aboutMeUIModels[i].ContactNumber);
            }
        }

    }

}
