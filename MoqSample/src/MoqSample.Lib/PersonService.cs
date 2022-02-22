using System.Collections.Generic;

namespace MoqSample.Lib
{
    internal class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Person> GetAll()
        {
            return _repository.FetchAll();
        }
    }

    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
    }

    public interface IPersonRepository
    {
        IEnumerable<Person> FetchAll();
    }
}

