using System;

namespace HospitalAppointment.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message)
    {
    }
}
