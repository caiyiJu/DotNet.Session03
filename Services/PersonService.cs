using DotNet.Session03.Models;
using System.Collections.Generic;
using System.Linq;

namespace DotNet.Session03.Services
{
    public class PersonService
    {
        public PersonDbContext _personDbContext { get; set; }
        public PersonService(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }
        public int Create(Person person)
        {
            _personDbContext.People.Add(person);
            _personDbContext.SaveChanges();
            return person.Id;
        }

        public void SoftDelete(int id)
        {
            var person = _personDbContext.People.FirstOrDefault(x => x.Id == id);
            person.IsDeleted = true;
            _personDbContext.People.Update(person);
            _personDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var person = new Person { Id = id };
            _personDbContext.People.Remove(person);
            _personDbContext.SaveChanges();
        }

        public IEnumerable<Person> GetAll()
        {
            return _personDbContext.People.ToList();
        }

        public Person GetBy(int id)
        {
            return _personDbContext.People.FirstOrDefault(x => x.Id == id);
        }




    }
}
