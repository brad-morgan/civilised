using Civilised.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Civilised.Tests
{
    public class TribalHtmlDocumentTests
    {
        [Fact]
        public void IsATimetableReader()
        {
            Assert.IsAssignableFrom<TimetableDocument>(new TribalHtmlTimetableDocument());
        }
        [Fact]
        public void AfterFirstReadColumnsContainsColumnNamesFromSource()
        {
            var expectedColumnNames = new string[] { "Session", "Event Type", "Course(s)", "Description", "Day of Week", "Start Date", "End Date", "Start Time", "End Time", "Room" };
            using (var source = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.TribalTimetableHtml)))
            {
                var document = new TribalHtmlTimetableDocument();
                document.Load(source);
                var actualColumnNames = document.Columns.Select(column => { return column.Name; });
                Assert.Equal(expectedColumnNames, actualColumnNames);
            }

        }
    }
}
