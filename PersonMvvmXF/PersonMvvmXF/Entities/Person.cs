using System;
using Newtonsoft.Json;
using Prism.Mvvm;
using SQLite;

namespace PersonMvvmXF.Entities
{
    public class Person: BindableBase, IBaseEntity
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }

        [PrimaryKey]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        public int Age => new Random().Next(20, 30);

        public string Photo => $"https://uinames.com/api/photos/{Gender}/{new Random().Next(1, 15)}.jpg";
    }
}
