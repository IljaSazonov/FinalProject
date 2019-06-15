using RestWebService.Database;
using RestWebService.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RestWebService.Controllers
{
    public class AnimalConnect : DbConnection

    {

        List<Animal> animalList = new List<Animal>();

        public AnimalConnect()
        {
            try
            {
                

                Connect();

                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Animal, AnimalInfo", Con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Animal temp = new Animal();
                        temp.Id = Convert.ToInt32(rdr[0]);
                        temp.Type = (rdr[1]).ToString();
                        temp.Breed = (rdr[2]).ToString();
                        temp.Gender = (rdr[3]).ToString();
                        if(rdr[9] == rdr[0])
                        {
                            temp.Name = (rdr[5]).ToString();
                            temp.Age = Convert.ToInt32(rdr[6]);
                            temp.Sterilization = (rdr[7]).ToString();
                            temp.Description = (rdr[8]).ToString();
                        }

                        animalList.Add(temp);
                    }

                    
                }

                Disconnect();
            }
            catch
            {

            }
            


        }

        public List<Animal> Get()
        {
            return animalList;
        }

        public Animal Get(int ID)
        {
            return animalList.Where(x => x.Id == ID).FirstOrDefault();
        }

        public void Post(Animal val)
        {
            animalList.Add(val);



        }

        public void Delete(int id)
        {

        }
    }
}