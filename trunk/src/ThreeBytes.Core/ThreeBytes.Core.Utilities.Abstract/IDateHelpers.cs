using System;

namespace ThreeBytes.Core.Utilities.Abstract
{
    public interface IDateHelpers
    {
        void VerifyThrowNotLocalTime(DateTime value);
    }
}
