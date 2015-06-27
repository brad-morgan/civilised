using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Civilised.Services
{
    /// <summary>
    /// Generates unique hash codes for objects.
    /// </summary>
    internal class HashCodeGenerator
    {
        /// <summary>
        /// Generates a unique hash code for an object.
        /// </summary>
        /// <param name="seed">A large prime number.</param>
        /// <param name="multiplier">A large prime number</param>
        /// <param name="fields">Field values which form part of the identity of the object for which a hash code is being generated.</param>
        /// <returns>A hash code value.</returns>
        internal static int GenerateHashCode(int seed, int multiplier, params object[] fields)
        {
            //Credit to John Skeet for his excellent explaination of this algorithm:
            //http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode

            int hash = seed;
            //Doesn't matter if this wraps, we're using the value as an identity, mathmatical precision is not the goal here. unchecked will cause the int to wrap rather than
            //throw an exception if the calculation overflows.
            unchecked
            {
                foreach (var field in fields)
                {
                    hash *= multiplier + field.GetHashCode();
                }
                return hash;
        }

        }
    }
}