using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class ValidationException :Exception
    {
        public IEnumerable<string> Errors { get;}

        public ValidationException(IEnumerable<string> errors)
            : base("One or more validation errors occurred")
        {
            Errors = errors;
        }

        public ValidationException(string error)
            :base("Validation error occurred")
        {
            Errors = new[] { error };
        }

    }
}
