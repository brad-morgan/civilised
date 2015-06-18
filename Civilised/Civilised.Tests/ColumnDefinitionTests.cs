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

    }
}
