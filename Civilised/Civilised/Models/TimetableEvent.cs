using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Civilised.Services;
namespace Civilised.Models
{
    /// <summary>
    /// Represents a single timetable event.
    /// </summary>
    public class TimetableEvent
    {
        /// <summary>
        /// Gets or sets the unique identifier for the course associated with this event.
        /// </summary>
        /// <remarks>This is the CPIT course code for the course associated with this event.</remarks>
        /// <example>IS206</example>
        [Required]
        public string CourseCode { get; set; }
        /// <summary>
        /// Gets or sets a description of the course associated with this event.
        /// </summary>
        /// <remarks>This is the title of the course associated with this event.</remarks>
        /// <example>Professional Practice.</example>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the date of the first occurance of this event.
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the date of the last occurance of this event.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Gets or sets the time at which this event starts
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Gets or sets the time at which this event ends.
        /// </summary>
        [Required]
        public DateTime EndTime { get; set; }
        /// <summary>
        /// Gets or sets the identifier for the location in which this event takes place.
        /// </summary>
        /// <remarks>This is the room identifier for the location where the event takes place</remarks>
        /// <example>L203</example>
        [Required]
        public string Location { get; set; }
        /// <summary>
        /// Generates a hash code for this instance.
        /// </summary>
        /// <returns>A hash code value.</returns>
        public override int GetHashCode()
        {
           return HashCodeGenerator.GenerateHashCode(14341, 14243, CourseCode, Description, StartDate, EndTime, StartTime, EndTime, Location);
        }
    }
}