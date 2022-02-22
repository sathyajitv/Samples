using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MoqSample.Lib.Tests
{
    public class PersonServiceTests
    {
        [Fact]
        public void Can_Fetch_All_Persons()
        {
            Mock<IPersonRepository> mockRepository = new Mock<IPersonRepository>();

            IList<Person> persons = new List<Person>() { new Person() };
            mockRepository.Setup(c => c.FetchAll()).Returns(persons);

            //PersonService is not visible to the test assembly, unless AssemblyAttribute Include="System.Runtime.CompilerServices.InternalsVisibleTo"
            //is added to the target project
            IPersonService service = new PersonService(mockRepository.Object);
            IEnumerable<Person> result = service.GetAll();

            result.Should().HaveCount(1);
        }
    }
}
