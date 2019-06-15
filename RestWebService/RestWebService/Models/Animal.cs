using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestWebService.Models
{
    [DataContract]
    public class Animal
    {
        
            /// <summary>
            /// Id from sql database.
            /// </summary>
            [DataMember(Name = "id")]
            public int Id { get; set; }

            /// <summary>
            /// Animal's name.
            /// </summary>
            [DataMember(Name = "name")]
            public string Name { get; set; }

            /// <summary>
            /// Animal's type.
            /// </summary>
            [DataMember(Name = "type")]
            public string Type { get; set; }

            /// <summary>
            /// Animal's age.
            /// </summary>
            [DataMember(Name = "age")]
            public int Age { get; set; }

            /// <summary>
            /// Animals' gender.
            /// </summary>
            [DataMember(Name = "gender")]
            public string Gender { get; set; }

            /// <summary>
            /// Sterilization.
            /// </summary>
            [DataMember(Name = "sterilization")]
            public string Sterilization { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [DataMember(Name = "breed")]
            public string Breed { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [DataMember(Name = "description")]
            public string Description { get; set; }
        
    }
}