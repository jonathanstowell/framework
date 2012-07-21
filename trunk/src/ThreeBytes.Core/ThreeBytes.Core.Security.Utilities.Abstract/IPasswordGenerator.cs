namespace ThreeBytes.Core.Security.Utilities.Abstract
{
    public interface IPasswordGenerator
    {
        string Generate();
        string Generate(int minimum, int maximum);
    }
}
