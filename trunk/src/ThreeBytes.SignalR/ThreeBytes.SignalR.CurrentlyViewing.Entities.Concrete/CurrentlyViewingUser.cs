using System;
using ThreeBytes.SignalR.CurrentlyViewing.Entities.Abstract;

namespace ThreeBytes.SignalR.CurrentlyViewing.Entities.Concrete
{
    [Serializable]
    public class CurrentlyViewingUser : ICurrentlyViewingUser
    {
        public string Username { get; set; }
        public string Colour { get; set; }
    }
}
