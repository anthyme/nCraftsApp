using System.Collections.Generic;
using NCrafts.App.Sessions;

namespace NCrafts.App.Common
{
    public class DataSource
    {
        public ICollection<Session> Sessions { get; } = new List<Session>
            {
                new Session { Id = 1, Title = "C# pour les nuls", Description = "C# pour les devs vraiment pas bons"},
                new Session { Id = 2, Title = "F# pour les nuls", Description = "F# pour les devs vraiment pas bons"},
                new Session { Id = 3, Title = "Xamarin pour les nuls", Description = "Xamarin pour les devs vraiment pas bons"},
            };
    }
}
