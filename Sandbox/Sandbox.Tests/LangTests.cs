using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sandbox.Tests
{
    /// <summary>
    /// Tests C# language concepts
    /// </summary>
    public class LangTests
    {
        [Fact]
        public void Can_Constrain_Generic_Class_To_Enum_Type()
        {
            EnumDerivedType d = new EnumDerivedType { ItemColorName = Color.Blue };
            Assert.Equal(Color.Blue, d.ItemColorName);
        }

        [Fact]
        public void Linq_Collection_ForEach_Does_Not_Mutate_Value()
        {
            List<DateTime> coll = new List<DateTime>();
            coll.Add(new DateTime(2022, 01, 01, 01, 01, 00));
            coll.Add(new DateTime(2022, 01, 01, 01, 02, 00));
            coll.Add(new DateTime(2022, 01, 01, 01, 03, 00));

            coll.ForEach(x => x = x.Date);
            Assert.True(coll[0] == new DateTime(2022, 01, 01, 01, 01, 00));

            List<DateTime> coll2 = new List<DateTime>();
            coll.ForEach(x => coll2.Add(x.Date));
            Assert.True(coll2[0] == new DateTime(2022, 01, 01));
        }

        [Fact]
        public void SelectMany_Throws_Exception_If_Target_Collection_Is_Null()
        {
            Department mktDept = new Department() {Name = "Marketing", Employees = new List<Employee>() {new Employee() {Name = "john"}, new Employee() { Name = "jake" } }};
            Department engDept = new Department() { Name = "Engineering", Employees = null };
            List<Department> depts = new List<Department>() { mktDept, engDept };

            Assert.Throws<ArgumentNullException>(() => depts.SelectMany(x => x.Employees).ToList());
            
            var employees = depts.SelectMany(x => x.Employees ?? Enumerable.Empty<Employee>()).ToList();
            Assert.True(employees.Count == 2);
        }

        [Fact]
        public void Child_String_References_Can_Be_Manipulated_Without_Affecting_The_Parent()
        {
            string parent = "parent";
            string child = parent;
            Assert.True(object.ReferenceEquals(parent, child));

            child = "child";
            Assert.False(object.ReferenceEquals(parent, child));
            Assert.True(parent == "parent");

            string parent2 = "parent";
            Assert.True(object.ReferenceEquals(parent, parent2));
        }
    }

    public abstract class EnumBasedType<T> where T:Enum
    {
        public T ItemColorName { get; set; }
    }

    //public class EnumDerivedType : EnumBasedType<ColorNames>   //Error: There is no implicit reference conversion from 'Sandbox.Tests.ColorNames' to 'System.Enum'.
    public class EnumDerivedType : EnumBasedType<Color>
    {
        
    }

    public enum Color
    {
        Red,
        Green,
        Blue
    }

    public class ColorNames
    {
        public string Name { get; set; }
    }

    class Department
    {
        public string Name { get; set; }
        public string CostCenter { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }

    class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
    }
}

