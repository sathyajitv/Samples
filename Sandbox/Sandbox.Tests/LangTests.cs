using System;
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
}

