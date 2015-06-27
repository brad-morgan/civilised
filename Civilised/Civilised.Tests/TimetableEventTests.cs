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
           var instanceA = new TimetableEvent() 
           {
               CourseCode = "IS206",
               Description = "Professional Practice",
               StartDate=DateTime.Today,
               EndDate=DateTime.Today.AddDays(7*10),
               StartTime=DateTime.Now,
               EndTime=DateTime.Now.AddHours(2),
               Location="L210"
           };
           var instanceB = new TimetableEvent()
           {
               CourseCode = "IS206",
               Description = "Professional Practice",
               StartDate = DateTime.Today,
               EndDate = DateTime.Today.AddDays(7 * 10),
               StartTime = DateTime.Now,
               EndTime = DateTime.Now.AddHours(2),
               Location = "L210"
           };
           
           Assert.Equal(instanceA.GetHashCode(), instanceB.GetHashCode());
       }
       [Fact]
       public void InstancesWithEqualPropertiesAreConsideredEqual()
       {
           var instanceA = new TimetableEvent() 
           {
               CourseCode = "IS206",
               Description = "Professional Practice",
               StartDate=DateTime.Today,
               EndDate=DateTime.Today.AddDays(7*10),
               StartTime=DateTime.Now,
               EndTime=DateTime.Now.AddHours(2),
               Location="L210"
           };
           var instanceB = new TimetableEvent()
           {
               CourseCode = "IS206",
               Description = "Professional Practice",
               StartDate = DateTime.Today,
               EndDate = DateTime.Today.AddDays(7 * 10),
               StartTime = DateTime.Now,
               EndTime = DateTime.Now.AddHours(2),
               Location = "L210"
           };
           Assert.Equal(instanceA,instanceB);
       }
       //FIXME: Need to add tests to do range checks on dates and times. e.g. StartTime can't be after end time etc.
    }
}
