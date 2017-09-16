using System;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace PersonMvvmXF.Entities
{
    public class Person: BindableBase
    {
        private string _name;

        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _surname;

        [JsonProperty(PropertyName = "surname")]
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        private string _gender;

        [JsonProperty(PropertyName = "gender")]
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private string _region;

        [JsonProperty(PropertyName = "region")]
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }
        
        public int Age
        {
            get { return new Random().Next(20, 30); }
        }

        public string Photo
        {
            get {return $"https://uinames.com/api/photos/{Gender}/{new Random().Next(1, 15)}.jpg"; }
        }

    }
}
