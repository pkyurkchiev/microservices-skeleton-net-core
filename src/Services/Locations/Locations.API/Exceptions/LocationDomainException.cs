﻿using System;

namespace Locations.API.Exceptions
{
    public class LocationDomainException : Exception
    {
        public LocationDomainException()
        { }

        public LocationDomainException(string message)
            : base(message)
        { }

        public LocationDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
