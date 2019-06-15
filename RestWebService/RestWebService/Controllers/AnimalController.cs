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
        List<AnimalInfo> animalList = new List<AnimalInfo>();

        public AnimalController()
        {
            animalList.Add(new AnimalInfo { Id = 1, Age = 5, Gender = "Male", Name = "Doggo", Sterilization = "asd", Type = "Dog" });
            animalList.Add(new AnimalInfo { Id = 2, Age = 3, Gender = "Female", Name = "Cattie", Sterilization = "asd", Type = "Cat" });
        }

        // GET: api/Animal
        public List<AnimalInfo> Get()
        {
            return animalList;
        }

        // GET: api/Animal/5
        public AnimalInfo Get(int id)
        {
            return animalList.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/People
        public void Post(AnimalInfo val)
        {
            animalList.Add(val);
        }

        // DELETE: api/Animal/5
        public void Delete(int id)
        {

        }

    }
}
