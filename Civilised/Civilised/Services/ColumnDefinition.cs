using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Civilised.Services
{
    /// <summary>
    /// Defines the name of a column within Tribal timetable input.
    /// </summary>
    public class ColumnDefinition
    {
        private string name;
        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        /// <remarks>Column names appear in the header row of the Tribal HTML table.</remarks>
        /// <exception cref="ArgumentException"><paramref name="value"/> is an empty string. -or- <paramref name="value"/> contained only whitespace.</exception>
        public string Name
        {
            get { return name; }
            set { SetName(value); }
        }
        /// <summary>
        /// Gets or sets a value determining whether this column must be present in order for a timetable to be considered valid.
        /// </summary>
        public bool Mandatory { get; set; }
        /// <summary>
        /// Determines whether the specified <see cref="ColumnDefinition"/> is equal to the current instance.
        /// </summary>
        /// <param name="obj">The instance to compare.</param>
        /// <returns>true if the instances are equal, false otherwise.</returns>
        public bool Equals(ColumnDefinition obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                return name == obj.name && Mandatory == obj.Mandatory;
            }
        }
        /// <summary>
        /// Determines whether the current <see cref="object"/> is equal to the specified instance.
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>true if the instances are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is ColumnDefinition)
            {
                return Equals(obj as ColumnDefinition);
            }
            return base.Equals(obj);
        }
        /// <summary>
        /// Gets a unique hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the instance.</returns>
        public override int GetHashCode()
        {
            int seed = 246817;
            int multiplier = 163861;

            return HashCodeGenerator.GenerateHashCode(seed, multiplier, name.GetHashCode(), Mandatory.GetHashCode());
        }

        private void SetName(string value)
        {
            //Test whether the value being set is null or whitespace, if not, set value, if it is, throw the exception in ex.
            var ex = ExceptionFor.NullEmptyOrWhitespace(ref value, "value");
            if (ex == null)
            {
                name = value.Trim();
            }
            else
            {
                throw ex;
            }

        }
    }
}
