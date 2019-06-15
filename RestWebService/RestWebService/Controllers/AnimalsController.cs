using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;

namespace RestWebService.Controllers
{
    public class AnimalsController : ApiController
    {
        public IEnumerable<Animal> Get()
        {
            using(AnimalsDBEntities entities = new AnimalsDBEntities())
            {
                return entities.Animals.ToList();
            }
        }

        public Animal Get(int id)
        {
            using (AnimalsDBEntities entities = new AnimalsDBEntities())
            {
                return entities.Animals.FirstOrDefault(e => e.ID ==id);
               
            }
        }
    }
}
