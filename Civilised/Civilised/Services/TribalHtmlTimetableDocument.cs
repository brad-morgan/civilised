using Civilised.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Civilised.Services
{
    /// <summary>
    /// A <see cref="TimetableDocument"/> which can read timetable events from the HTML output of Tribal EBS 4 as implemented at CPIT.
    /// </summary>
    public class TribalHtmlTimetableDocument:TimetableDocument
    {
        public TribalHtmlTimetableDocument()
        {
            columns = new List<ColumnDefinition>();
        }
        private readonly List<ColumnDefinition> columns;
        /// <summary>
        /// Gets a collection of <see cref="ColumnDefiniton"/> objects representing all timetable columns.
        /// </summary>
        public override IEnumerable<ColumnDefinition> Columns
        {
            get { return columns; }
        }
        /// <summary>
        /// Gets a collection of <see cref="TimetableEvent"/> objects representing all event information.
        /// </summary>
        public override IEnumerable<TimetableDocument> Events
        {
            get { throw new NotImplementedException(); }
        }
        /// <summary>
        /// Loads source data from the specified stream.
        /// </summary>
        /// <param name="stream">A stream containing the HTML from the CPIT Tribal implementation's "Your Timetable" page.</param>
        public override void Load(Stream stream)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.Load(stream);
            var columnNodes = htmlDocument.CreateNavigator().Select("//td[@class='hierarchyhead align5']");
            foreach (HtmlNodeNavigator columnNode in columnNodes)
            {
                var column = new ColumnDefinition();
                column.Name = columnNode.Value;
                columns.Add(column);
            }
            
        }
    }
}