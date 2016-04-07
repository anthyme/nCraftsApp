using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Business.Common;

namespace NCrafts.App.Business.Core
{
    public class Session
    {
        public SessionId Id { get; set; }
        public string Title { get; set; }
        public List<SpeakerId> Speakers { get; set; }
        public TimeSlot Interval { get; set; }
        public Room Room { get; set; }
        public List<Tag> Tags { get; set; }
        public string Description { get; set; }
        public bool IsRegister { get; set; }
        public List<Session> SessionsConflit { get; set; }

        public bool IsInConflict(Session session)
        {
            return Id.ToString() != session.Id.ToString() && Interval.IsOverlap(session.Interval);
        }

        public void UnRegister()
        {
            IsRegister = false;
            foreach (var session in SessionsConflit)
            {
                session.SessionsConflit.Remove(this);
            }
            SessionsConflit.Clear();
        }

        // TODO: Fix register check it the register is not already in the list
        public void Register(List<Session> registerSessions)
        {
            IsRegister = true;
            foreach (var registerSession in registerSessions)
            {
                if (SessionsConflit.All(x => x.Id.ToString() != registerSession.Id.ToString()) && IsInConflict(registerSession))
                {
                    SessionsConflit.Add(registerSession);
                    registerSession.SessionsConflit.Add(this);
                }
            }
        }
    }
}
