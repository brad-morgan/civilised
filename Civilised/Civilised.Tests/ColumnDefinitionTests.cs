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
       [Fact]
       public void ArgumentNullExceptionWhenNameIsSetToNull()
       {
           var columnDefinition = new ColumnDefinition();
           Assert.Throws<ArgumentNullException>(() => { columnDefinition.Name = null; });
       }
    }
}
