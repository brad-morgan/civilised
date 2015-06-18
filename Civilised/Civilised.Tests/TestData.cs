using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civilised.Tests
{
   internal static class TestData
    {
       private static readonly string[] emptyAndWhitespaceStrings = { string.Empty, " \t " };

       internal static IEnumerable<string> EmptyAndWhitespaceStrings
       {
           get { return emptyAndWhitespaceStrings; }
       }
    }
}
