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
                var entity = entities.Animals.FirstOrDefault(a => a.ID ==id);
               
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

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (AnimalsDBEntities entities = new AnimalsDBEntities())
                {
                    var entity = entities.Animals.FirstOrDefault(a => a.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Animal with ID " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.Animals.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }

                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        public HttpResponseMessage Put(int id,[FromBody]Animal animal)
        {
            try
            {
                using (AnimalsDBEntities entities = new AnimalsDBEntities())
                {
                    var entity = entities.Animals.FirstOrDefault(a => a.ID == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Animal with id " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.Type = animal.Type;
                        entity.Breed = animal.Breed;
                        entity.Gender = animal.Gender;
                        entity.Age = animal.Age;
                        entity.Name = animal.Name;
                        entity.Description = animal.Description;
                        entity.Sterilization = animal.Sterilization;

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }



                }
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
