using System.Threading.Tasks;

namespace NCrafts.App.Core.Common.Infrastructure
{
    public interface INavigateTo
    {
        Task Session(SessionId sessionId);
        Task Sessions();
    }
}