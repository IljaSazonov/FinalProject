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

        public HttpResponseMessage Get(int id)
        {
            using (AnimalsDBEntities entities = new AnimalsDBEntities())
            {
                var entity = entities.Animals.FirstOrDefault(e => e.ID ==id);
               
                if(entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Animal with ID = " + id.ToString() + " not found");
                }
            }
        }

        public HttpResponseMessage Post([FromBody] Animal animal)
        {
            try
            {

                using (AnimalsDBEntities entities = new AnimalsDBEntities())
                {
                    entities.Animals.Add(animal);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, animal);
                    message.Headers.Location = new Uri(Request.RequestUri + animal.ID.ToString());
                    return message;
                }

            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
