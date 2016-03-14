using System;
using System.Threading.Tasks;

namespace NCrafts.App.Business.Common.Infrastructure
{
    public delegate void OnError(Exception exception);
    public delegate void HandleError(Action call);
    public delegate Task HandleErrorAsync(Func<Task> asyncCall);

    public class ErrorHandler
    {
        public static OnError CreateOnError(LogError logError)
        {
            return ex => logError(ex);
        }

        public static HandleError CreateOnError(OnError onError)
        {
            return fn =>
            {
                try { fn(); }
                catch (Exception ex) { onError(ex); }
            };
        }

        public static HandleErrorAsync CreateHandleErrorAsync(OnError onError)
        {
            return async fn =>
            {
                try { await fn(); }
                catch (Exception ex) { onError(ex); }
            };
        }
    }
}
