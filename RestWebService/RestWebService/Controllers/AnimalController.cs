using RestWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestWebService.Controllers
{
    public class AnimalController : ApiController
    {
        // GET: api/Animal
        public IEnumerable<AnimalInfo> Get()
        {
            var animalInfoList = new List<AnimalInfo>();
            for (int i = 0; i <2; i++)
            {
                var AnimalInfo = new AnimalInfo
                {
                    Name = "Doggo",
                    Age = 10,
                    Gender = "Male",
                    Type = "Dog",
                    Sterilization = "asd"
                };

                animalInfoList.Add(AnimalInfo);
            }
            return animalInfoList;
        }

        // GET: api/Animal/5
        public AnimalInfo Get(int id)
        {
            return  new AnimalInfo
            {
                Name = "Doggo",
                Age = 10,
                Gender = "Male",
                Type = "Dog",
                Sterilization = "asd"
            };
        }

    }
}
