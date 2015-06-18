using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Civilised.Services;
using System.IO;
using System.Runtime.Serialization;

namespace Civilised.Tests
{
    public class ColumnDefinitionTests
    {
        public static readonly object[] EmptyAndWhitespaceStrings = new object[] { string.Empty, " \t " };

        [Fact]
        public void ArgumentNullExceptionWhenNameIsSetToNull()
        {
            var columnDefinition = new ColumnDefinition();
            Assert.Throws<ArgumentNullException>(() => { columnDefinition.Name = null; });
        }
        [Theory]
        [InlineData("")]
        [InlineData(" \t ")]
        public void ArgumentExceptionWhenNameIsSetToEmptyOrWhitespace(string emptyOrWhiteSpace)
        {
            var columnDefinition = new ColumnDefinition();
            Assert.Throws<ArgumentException>(() => { columnDefinition.Name = emptyOrWhiteSpace; });
        }
        [Fact]
        public void NameCanBeSetToAValidValue()
        {
            var columnDefinition = new ColumnDefinition();
            columnDefinition.Name = "A Valid Name";
        }
        //Q: Why do we care if column definitions are equal?

        //A: Because equality is used during testing of deserialization to be able to tell if the serialized instance and deserialized instance match 
        //(see the question on serialization and deserialization). Equality is also used to figure out if we have duplicate column definitions in both
        //the expected column list, and the list of columns actually in the input (in TimetableEventExtractor)

        [Fact]
        public void ColumnsDefinitionsWithSameNameAndMandatoryValueAreEqual()
        {
            var columnA = new ColumnDefinition() { Name = "Test", Mandatory = true };
            var columnB = new ColumnDefinition() { Name = "Test", Mandatory = true };
            Assert.Equal(columnA, columnB);
        }
        //Q: What's a hash code, why do we need them to be equal?
        
        //A: A hash code is a (hopefully) unique number that acts as an identity for a particular object. Hash tables are a type of collection which use the hash code for
        //quick lookups. We aren't using one directly, but some of the facilities we use may use them internally, so it's a good idea to provide a unique hash code implementation
        //Microsoft also considers this a best practice when implementing equality.

        [Fact]
        public void EqualColumnDefinitionsHaveSameHashCode()
        {
            var columnA = new ColumnDefinition() { Name = "Test", Mandatory = true };
            var columnB = new ColumnDefinition() { Name = "Test", Mandatory = true };
            Assert.Equal(columnA.GetHashCode(), columnB.GetHashCode());
        }
        //Q: What's serialization, and what's deserialization?

        //A: Serialization is the process of converting an object in memory into a format suitable for storage or transmission over a network.Deserialization is the opposite
        //process, converting serialized XML back into an object in memory.  We're implementing this so that we can store a set of ColumnDefinition objects in a config file
        //These will be deserialized and used by the TimetableEventExtractor to figure out which columns are mandatory and which are optional.

        //Here, we're building an object, serializing it, then deserializing it and comparing it to the original.

        [Fact]
        public void DeserializedInstanceIsEqualToOriginalInstance()
        {
            var original = new ColumnDefinition() { Name = "Test", Mandatory = true };
            ColumnDefinition deserialized;
            //Q: What's this using(...) thing?

            //A:Some objects allocate resources that .NET can't clean up automagically. To release these resources, one calls Dispose(). a using block does this for us
            //for the taeget object (ie. stream, which is a block of RAM), when the code in the block (between the {}) is done executing.
            using(var stream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(ColumnDefinition));
                serializer.WriteObject(stream, original);
                stream.Seek(0, SeekOrigin.Begin);
                deserialized = (ColumnDefinition)serializer.ReadObject(stream);
            }
            Assert.Equal(original, deserialized);
        }

    }
}
