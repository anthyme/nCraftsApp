using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Core;
using Shouldly;
using Xunit;

namespace NCrafts.App.Tests.Sessions
{
    public class ConflitBetweenSessions
    {
        [Fact]
        public void TestConflitFalseBetweenSessions()
        {
            var alonePrev = new Session
            {
                Id = new SessionId("01"),
                Interval =
                    new TimeSlot
                    {
                        StartDate = DateTime.Now.Date,
                        EndDate = DateTime.Now.Date + new TimeSpan(1, 0, 0)
                    }
            };
            var aloneNext = new Session
            {
                Id = new SessionId("02"),
                Interval =
                    new TimeSlot
                    {
                        StartDate = DateTime.Now.Date + new TimeSpan(2, 0, 0),
                        EndDate = DateTime.Now.Date + new TimeSpan(3, 0, 0)
                    }
            };
            aloneNext.IsInConflict(alonePrev).ShouldBe(false);
            alonePrev.IsInConflict(aloneNext).ShouldBe(false);
        }

        [Fact]
        public void TestConflitTrueBetweenSessionsOneIncludedTheOther()
        {
            var hugeSession = new Session
            {
                Id = new SessionId("01"),
                Interval =
                    new TimeSlot
                    {
                        StartDate = DateTime.Now.Date,
                        EndDate = DateTime.Now.Date + new TimeSpan(2, 0, 0)
                    }
            };
            var includedSession = new Session
            {
                Id = new SessionId("02"),
                Interval =
                    new TimeSlot
                    {
                        StartDate = DateTime.Now.Date + new TimeSpan(0, 1, 0),
                        EndDate = DateTime.Now.Date + new TimeSpan(0, 20, 0)
                    }
            };
            hugeSession.IsInConflict(includedSession).ShouldBe(true);
            includedSession.IsInConflict(hugeSession).ShouldBe(true);
        }

        [Fact]
        public void TestConflitTrueBetweenSessionsOneOverlapTheOther()
        {
            var overlapFirst = new Session
            {
                Id = new SessionId("01"),
                Interval =
                    new TimeSlot
                    {
                        StartDate = DateTime.Now.Date,
                        EndDate = DateTime.Now.Date + new TimeSpan(2, 0, 0)
                    }
            };
            var overlapSecond = new Session
            {
                Id = new SessionId("02"),
                Interval =
                    new TimeSlot
                    {
                        StartDate = DateTime.Now.Date + new TimeSpan(1, 0, 0),
                        EndDate = DateTime.Now.Date + new TimeSpan(3, 0, 0)
                    }
            };
            overlapFirst.IsInConflict(overlapSecond).ShouldBe(true);
            overlapSecond.IsInConflict(overlapFirst).ShouldBe(true);
        }

    }
}
