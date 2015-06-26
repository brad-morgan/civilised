using Civilised.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Civilised.Tests
{
   public class TribalHtmlTimetableReaderTests
    {
       [Fact]
       public void IsATimetableReader()
       {
           Assert.IsAssignableFrom<TimetableReader>(new TribalHtmlTimetableReader());
       }
    }
}
