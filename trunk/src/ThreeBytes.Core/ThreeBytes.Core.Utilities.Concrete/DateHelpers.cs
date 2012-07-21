using System;
using ThreeBytes.Core.Utilities.Abstract;

namespace ThreeBytes.Core.Utilities.Concrete
{
    public class DateHelpers : IDateHelpers
    {
        public void VerifyThrowNotLocalTime(DateTime value)
        {
            // When we want UTC time, we have to accept Unspecified kind
            // because that's how it is set to us in the database.
            if (value.Kind == DateTimeKind.Local)
            {
                throw new ArgumentException("DateTime must be given in UTC time but was " + value.Kind.ToString());
            }
        }
    }
}
