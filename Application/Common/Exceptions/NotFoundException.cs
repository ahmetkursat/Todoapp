using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public string ResourceName { get; }

        public object ResourceId { get; }

        public NotFoundException(string resourceName, object resourceId)
           : base($"{resourceName} with id {resourceId} not found")
        {
            ResourceName = resourceName;
            ResourceId = resourceId;
        }
    }
}
