namespace ThreeBytes.Core.DataStructures
{
    public interface IRegisterNavigation
    {
        NavigationNode Path { get; }
        string[] Roles { get; }
        bool RequireAllRoles { get; }
    }
}
