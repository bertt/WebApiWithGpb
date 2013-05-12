
using System.Collections.Generic;
using System.Web.Http;
using WebApiWithGpb.Core;

namespace WebApiWithGpb
{
    public class PersonsController:ApiController
    {
        public IEnumerable<Person> GetPersons()
        {
            var p1 = new Person{Id = 0, Name = "bert"};
            var p2 = new Person { Id = 0, Name = "bert1" };
            var persons = new List<Person>() {p1, p2};
            return persons;
        }
    }
}