using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateBaseWebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        // GET
        [HttpGet]
        public string Get()
        {
            string result = "Hello! Welcome to RealtyEstateBase! \n\n" +
                "To get information about available RealtyEstateBase elements, just send GET request to:\n" +
                "/api/Apartments/\n" +
                "/api/LandPlots/\n" +
                "/api/NonResidentialPremises/\n\n" +

                "To add element you must send POST request with JSON object of proper type and a 'secret' token in body.\n" +
                "Body example: \n\n" +
                "{\"apartment\":{\n" +
                "\"Rooms\":1,\n" +
                "\"Floor\":25,\n" +
                "\"TotalSquare\":30.0,\n" +
                "\"LiveSquare\":12.0,\n" +
                "\"KitchenSquare\":7,\n" +
                "\"MaterialOfWall\":\"brick\",\n" +
                "\"YearOfConstruction\":2017,\n" +
                "\"Address\":\"New York, Random str., 88\",\n" +
                "\"Price\":250000\n" +
                "},\n" +
                "\"token\":\"123456789\"\n" +
                "}\n\n" +

                "'Secret' token is \"123456789\". Please don't tell anyone about it! :)\n\n" +

                "If you want to modify some element, please send PUT request with JSON object of proper type included element Id and a 'secret' token in body.\n" +
                "Body example: \n\n" +
                "{\"apartment\":{\n" +
                "\"Id\":1,\n" +
                "\"Rooms\":5,\n" +
                "\"Floor\":120,\n" +
                "\"TotalSquare\":150.0,\n" +
                "\"LiveSquare\":95.0,\n" +
                "\"KitchenSquare\":22,\n" +
                "\"MaterialOfWall\":\"brick\",\n" +
                "\"YearOfConstruction\":2020,\n" +
                "\"Address\":\"New York, Central str., 99\",\n" +
                "\"Price\":2100000\n" +
                "},\n" +
                "\"token\":\"123456789\"\n" +
                "}\n\n" +

                "To remove item, just send DELETE request with Id to the appropriate controller:\n" +
                "/api/Apartments/{Id}\n" +
                "/api/LandPlots/{Id}\n" +
                "/api/NonResidentialPremises/{Id}\n" +
                " DELETE request does not support body, that’s why in this example you don’t need a token. Be careful!";

            return result;
        }
    }

}
