using System.Collections.Generic;

namespace NCrafts.App.Sessions
{
    public interface ISessionRespository
    {
        ICollection<Session> GetAll();
    }

    public class SessionRespository : ISessionRespository
    {
        public ICollection<Session> GetAll()
        {
            return new List<Session>
            {
                new Session { Id = 1, Title = "C# pour les nuls", Description = "C# pour les devs vraiment pas bon"},
                new Session { Id = 2, Title = "F# pour les nuls", Description = "F# pour les devs vraiment pas bon"},
                new Session { Id = 3, Title = "Xamarin pour les nuls", Description = "Xamarin pour les devs vraiment pas bon"},
            };
        }  
    }
}