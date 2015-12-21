using System.Collections.Generic;

namespace NCrafts.App.Core.Common
{
    public class DataSource
    {
        public ICollection<Session> Sessions { get; } = new List<Session>
            {
                new Session { Id = new SessionId("1"), Title = "C# pour les nuls", Description = "C# pour les devs vraiment pas bons"},
                new Session { Id = new SessionId("2"), Title = "F# pour les nuls", Description = "F# pour les devs vraiment pas bons"},
                new Session { Id = new SessionId("3"), Title = "Xamarin pour les nuls", Description = "Xamarin pour les devs vraiment pas bons"},
            };
    }
}
