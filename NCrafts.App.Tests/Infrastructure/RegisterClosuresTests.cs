using System;
using Microsoft.Practices.Unity;
using NCrafts.App.Core.Common.Infrastructure.Fx;
using Shouldly;
using Xunit;

namespace NCrafts.App.Tests.Infrastructure
{
    public class RegisterClosuresTests
    {
        [Fact]
        public void TestRegisterClosures()
        {
            var container = new UnityContainer()
                .RegisterInstance<Initializer>(() => 2)
                .RegisterClosures<ClosureStub>();

            var closure = container.Resolve<Incrementer>();

            closure().ShouldBe(2);
            closure().ShouldBe(3);
            closure().ShouldBe(4);
        }

        public delegate int Initializer();
        public delegate int Incrementer();

        public class ClosureStub
        {
            public static Incrementer CreateIteratorClosure(Initializer initializer)
            {
                int i = initializer();
                return () => i++;
            }
        }

        [Fact]
        public void TestRegisterClosuresWithLambdas()
        {
            var container = new UnityContainer()
                .RegisterInstance<Func<double>>(() => 2)
                .RegisterClosures<ClosureStubWithLambdas>();

            var closure = container.Resolve<Func<int>>();

            closure().ShouldBe(2);
            closure().ShouldBe(3);
            closure().ShouldBe(4);
        }

        public class ClosureStubWithLambdas
        {
            public static Func<int> CreateIteratorClosure(Func<double> initializer)
            {
                int i = (int)initializer();
                return () => i++;
            }
        }
    }
}
