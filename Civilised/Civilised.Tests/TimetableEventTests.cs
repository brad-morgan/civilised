using Civilised.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace Civilised.Tests
{
   public class TimetableEventTests
    {
       [Theory]
       [InlineData("CourseCode")]
       [InlineData("Description")]
       [InlineData("StartDate")]
       [InlineData("EndDate")]
       [InlineData("StartTime")]
       [InlineData("EndTime")]
       [InlineData("Location")]
       public void RequiredPropertiesAreAnnotated(string propertyName)
       {
           //TODO: Q & A about reflection, and BindingFlags
           var property = typeof(TimetableEvent).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
           var attributes = property.GetCustomAttributes(typeof(RequiredAttribute));
           Assert.NotEmpty(attributes);
       }
    }
}
