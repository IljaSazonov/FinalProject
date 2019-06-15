using RestWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestWebService.Controllers
{
    /// <summary>
    /// Information about all animals.
    /// </summary>
    public class AnimalController : ApiController
    {
        List<AnimalInfo> animalList = new List<AnimalInfo>();

        public AnimalController()
        {
            animalList.Add(new AnimalInfo { Id = 1, Age = 5, Gender = "Male", Name = "Doggo", Sterilization = "asd", Type = "Dog" });
            animalList.Add(new AnimalInfo { Id = 2, Age = 3, Gender = "Female", Name = "Cattie", Sterilization = "asd", Type = "Cat" });
        }
        
        /// <summary>
        /// List containing all animals.
        /// </summary>
        /// <returns> animal list </returns>
        // GET: api/Animal
        public List<AnimalInfo> Get()
        {
            return animalList;
        }

        /// <summary>
        /// Finds animal by his id.
        /// </summary>
        /// <param name="id">Id of an animal</param>
        /// <returns>Animal with an specific id</returns>
        // GET: api/Animal/5
        public AnimalInfo Get(int id)
        {
            return animalList.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Add new animal entry to list.
        /// </summary>
        /// <param name="val">Animal list</param>
        // POST: api/People
        public void Post(AnimalInfo val)
        {
            animalList.Add(val);
        }

        /// <summary>
        /// Deletes animal from the list.
        /// </summary>
        /// <param name="id">Id of an animal</param>
        // DELETE: api/Animal/5
        public void Delete(int id)
        {

        }

    }
}
