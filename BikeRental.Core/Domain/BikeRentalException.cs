using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRental.Core.Domain
{
    public abstract class BikeRentalException : Exception
    {
        public string Code { get; }

        protected BikeRentalException()
        {
        }

        protected BikeRentalException(string code)
        {
            Code = code;
        }

        protected BikeRentalException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected BikeRentalException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected BikeRentalException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        protected BikeRentalException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
