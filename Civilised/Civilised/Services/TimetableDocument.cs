using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Civilised.Services
{
    /// <summary>
    /// The base class for any class which is able to read a timetable and produce a collection of <see cref="TimetableEvent"/> instances matching those events.
    /// </summary>
    public abstract class TimetableDocument
    {
        
        /// <summary>
        /// Gets a collection of <see cref="ColumnDefinition"/> objects representing the columns present in the source timetable data.
        /// </summary>
        public abstract IEnumerable<ColumnDefinition> Columns
        {
            get;
        }
        public abstract IEnumerable<TimetableDocument> Events
        {
            get;
        }
        /// <summary>
        /// Loads HTML from the specified stream.
        /// </summary>
        /// <param name="stream">The stream containing the timetable HTML to be parsed.</param>
        public abstract void Load(Stream stream);
    }
}