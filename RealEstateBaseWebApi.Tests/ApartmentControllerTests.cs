using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using RealEstateBaseWebApi.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static RealEstateBaseWebApi.Models.Requests;

namespace RealEstateBaseWebApi.Tests
{
    public class ApartmentControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ApartmentControllerTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
            
        }


        [Fact]
        public async Task GetAllApartments_ReturnResult()
        {
            // Act
            var response = await _client.GetAsync("api/apartments");
            response.EnsureSuccessStatusCode();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task PostApartment_ReturnApartment()
        {
            // Arrange
            string expected = JsonConvert.SerializeObject(testApartments[0]);
            string actual;

            ApartmentRequest apartmentRequest = new ApartmentRequest
            {
                Apartment = testApartments[0],
                token = Security.Token
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(apartmentRequest), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("api/apartments", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            var actualObj = JsonConvert.DeserializeObject<Apartment>(responseString);
            actualObj.Id = 0;
            actual = JsonConvert.SerializeObject(actualObj);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetApartmentsById_ReturnNotFound()
        {
            // Arrange
            string expected = "NotFound";
            string actual;

            // Act
            var response = await _client.GetAsync("api/apartments/99");
            actual = response.StatusCode.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetApartmentsById_ReturnApartment()
        {
            // Arrange
            string expected = JsonConvert.SerializeObject(testApartments[0]);
            string actual;

            ApartmentRequest apartmentRequest = new ApartmentRequest
            {
                Apartment = testApartments[0],
                token = Security.Token
            };
           StringContent content = new StringContent(JsonConvert.SerializeObject(apartmentRequest), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("api/apartments", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var actualObj = JsonConvert.DeserializeObject<Apartment>(responseString);

            int apartmentId = actualObj.Id;

            response = await _client.GetAsync("api/apartments/"+ apartmentId.ToString());
            response.EnsureSuccessStatusCode();
            responseString = await response.Content.ReadAsStringAsync();
            actualObj = JsonConvert.DeserializeObject<Apartment>(responseString);
            actualObj.Id = 0;
            actual = JsonConvert.SerializeObject(actualObj);

            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public async Task PutApartment_ReturnApartment()
        {
            // Arrange
            string expected = JsonConvert.SerializeObject(testApartments[1]);
            string actual;
            ApartmentRequest apartmentRequest = new ApartmentRequest
            {
                Apartment = testApartments[0],
                token = Security.Token
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(apartmentRequest), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("api/apartments", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var actualObj = JsonConvert.DeserializeObject<Apartment>(responseString);
            int apartmentId = actualObj.Id;

            testApartments[1].Id = apartmentId;
            apartmentRequest = new ApartmentRequest
            {
                Apartment = testApartments[1],
                token = Security.Token
            };
            content = new StringContent(JsonConvert.SerializeObject(apartmentRequest), Encoding.UTF8, "application/json");
            response = await _client.PutAsync("api/apartments/" + apartmentId.ToString(), content);
            response.EnsureSuccessStatusCode();
            response = await _client.GetAsync("api/apartments/" + apartmentId.ToString());
            response.EnsureSuccessStatusCode();
            responseString = await response.Content.ReadAsStringAsync();
            actualObj = JsonConvert.DeserializeObject<Apartment>(responseString);
            actualObj.Id = 0;
            actual = JsonConvert.SerializeObject(actualObj);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task DeleteApartment_ReturnApartment()
        {
            // Arrange
            string expected = JsonConvert.SerializeObject(testApartments[0]);
            string actual;

            ApartmentRequest apartmentRequest = new ApartmentRequest
            {
                Apartment = testApartments[0],
                token = Security.Token
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(apartmentRequest), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("api/apartments", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var actualObj = JsonConvert.DeserializeObject<Apartment>(responseString);
            int apartmentId = actualObj.Id;
            testApartments[1].Id = apartmentId;
            response = await _client.DeleteAsync("api/apartments/" + apartmentId.ToString());
            response.EnsureSuccessStatusCode();
            responseString = await response.Content.ReadAsStringAsync();
            actualObj = JsonConvert.DeserializeObject<Apartment>(responseString);
            actualObj.Id = 0;
            actual = JsonConvert.SerializeObject(actualObj);
            // Assert
            Assert.Equal(expected, actual);
        }












        private List<Apartment> testApartments = new List<Apartment>()
        {
            new Apartment(){
                Rooms = 1,
                Floor = 1,
                TotalSquare = 35,
                LiveSquare = 20,
                KitchenSquare = 9,
                MaterialOfWall = "bricks",
                YearOfConstruction = 2019,
                Address = "New York, Central str, 124",
                Price = 700000
            },
            new Apartment(){
                Rooms = 2,
                Floor = 2,
                TotalSquare = 50,
                LiveSquare = 30,
                KitchenSquare = 10,
                MaterialOfWall = "bricks",
                YearOfConstruction = 2020,
                Address = "New York, Central str, 127",
                Price = 900000
            }
        };

    }

}
