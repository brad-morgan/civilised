using System;
namespace Civilised.Services
{
    /// <summary>
    /// Builds appropriate exceptions for common invalid data scenarios.
    /// </summary>
   internal static class ExceptionFor
    {
       internal static Exception NullEmptyOrWhitespace(ref string field, string fieldName)
       {
           if(field == null)
           {
               return new ArgumentNullException(fieldName);
           }
           if (field.Trim().Length < 1)
           {
               return new ArgumentException("Must contain at least one non-whitespace character", fieldName);
           }
           return null;
       }
    }
}
