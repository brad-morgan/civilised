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
       [Fact]
       public void InstancesWithSamePropertyValuesHaveSameHashCode()
       {
           //FIXME: Reduce setup code size. Possibly a test data class?
           var instanceA = new TimetableEvent();
           var instanceB = new TimetableEvent();
           instanceA.CourseCode = "IS206";
           instanceA.Description = "Professional Practice";
           instanceA.EndDate = DateTime.Today.AddDays(1);
           instanceA.EndTime = DateTime.Today.AddHours(15);
           instanceA.Location = "L203";
           instanceA.StartDate = DateTime.Today;
           instanceA.StartTime = DateTime.Today.AddHours(13);

           instanceB.CourseCode = "IS206";
           instanceB.Description = "Professional Practice";
           instanceB.EndDate = DateTime.Today.AddDays(1);
           instanceB.EndTime = DateTime.Today.AddHours(15);
           instanceB.Location = "L203";
           instanceB.StartDate = DateTime.Today;
           instanceB.StartTime = DateTime.Today.AddHours(13);
           Assert.Equal(instanceA.GetHashCode(), instanceB.GetHashCode());
       }
       //FIXME: Need to add tests to do range checks on dates and times. e.g. StartTime can't be after end time etc.
    }
}
