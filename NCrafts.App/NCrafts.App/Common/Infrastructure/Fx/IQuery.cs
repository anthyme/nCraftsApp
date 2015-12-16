using System.Collections.Generic;

namespace NCrafts.App.Common.Infrastructure.Fx
{
    public interface IQuery<out T>
    {
        T Execute();
    }

    public interface IQuery<in TParamerter, out TOut>
    {
        TOut Execute(TParamerter sessionId);
    }

    public interface IQueryMany<T>
    {
        ICollection<T> Execute();
    }

    public interface IQueryMany<in TParamerter, TOut>
    {
        ICollection<TOut> Execute(TParamerter parameter);
    }
}
