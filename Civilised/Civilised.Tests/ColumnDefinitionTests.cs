using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Civilised.Services;

namespace Civilised.Tests
{
   public class ColumnDefinitionTests
    {
       public static readonly object[] EmptyAndWhitespaceStrings = new object[]{string.Empty, " \t "};

       [Fact]
       public void ArgumentNullExceptionWhenNameIsSetToNull()
       {
           var columnDefinition = new ColumnDefinition();
           Assert.Throws<ArgumentNullException>(() => { columnDefinition.Name = null; });
       }
       [Theory]
       [InlineData("")]
       [InlineData(" \t ")]
       public void ArgumentExceptionWhenNameIsSetToEmptyOrWhitespace(string emptyOrWhiteSpace)
       {
           var columnDefinition = new ColumnDefinition();
           Assert.Throws<ArgumentException>(() => { columnDefinition.Name = emptyOrWhiteSpace; });
       }
       [Fact]
       public void NameCanBeSetToAValidValue()
       {
           var columnDefinition = new ColumnDefinition();
           columnDefinition.Name = "A Valid Name";
       }
       [Fact]
       public void ColumnsDefinitionsWithSameNameAndMandatoryValueAreEqual()
       {
           var columnA = new ColumnDefinition() { Name = "Test", Mandatory = true };
           var columnB = new ColumnDefinition() { Name = "Test", Mandatory = true };
           Assert.Equal(columnA, columnB);
       }
       [Fact]
       public void EqualColumnDefinitionsHaveSameHashCode()
       {
           var columnA = new ColumnDefinition() { Name = "Test", Mandatory = true };
           var columnB = new ColumnDefinition() { Name = "Test", Mandatory = true };
           Assert.Equal(columnA.GetHashCode(), columnB.GetHashCode());
       }

    }
}
