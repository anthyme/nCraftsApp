using System;
using System.Collections.Generic;

namespace NCrafts.App.Core.Common
{
    public class DataSource
    {
        public ICollection<Tag> Tags { get; } = new List<Tag>
            {
                new Tag { Title = "C#", Count = 4},
                new Tag { Title = "F#", Count = 17},
                new Tag { Title = "C++", Count = 1},
                new Tag { Title = "C", Count = 2},
                new Tag { Title = "Compiler", Count = 34},
                new Tag { Title = "NCrafts", Count = 2},
                new Tag { Title = "Mobile", Count = 6},
                new Tag { Title = "Android", Count = 7},
                new Tag { Title = "Xamarin", Count = 21},
                new Tag { Title = "Testing", Count = 4},
                new Tag { Title = "iOS", Count = 3},
                new Tag { Title = "Windows Phone", Count = 0},
            };

        public ICollection<Speaker> Speakers { get; } = new List<Speaker>
            {
                new Speaker { Id = new SpeakerId("1"), FirstName = "Lala", LastName = "Teletobies", Company = "Guilli", Skills = new List<string> {"Trotinette", "Chiller"}, ProfilPicture = "", Details = "Je suis rouge et timide. Dans la vie je sers pas à grand chose... SUICIDE!!!!"},
                new Speaker { Id = new SpeakerId("2"), FirstName = "Bob", LastName = "The Builder", Company = "BBC", Skills = new List<string> {"Build", "Push"}, ProfilPicture = "", Details = "When it's build I push!"},
                new Speaker { Id = new SpeakerId("3"), FirstName = "Test", LastName = "Test-Name", Company = "Dozije", Skills = new List<string> {"Build", "Push"}, ProfilPicture = "", Details = "olfjposdfojigpodfs dsfpogjpdsofgu dsfopg jpdf gpdfu gpoduifpgousdfpog udpof guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi"},
                new Speaker { Id = new SpeakerId("4"), FirstName = "Batman", LastName = "Wayne", Company = "Rich bitch", Skills = new List<string> {"Money", "Batmobile"}, ProfilPicture = "", Details = "I'm a secret guy"},
                new Speaker { Id = new SpeakerId("5"), FirstName = "Peter", LastName = "Spiderman", Company = "League", Skills = new List<string> {"Beam", "Super cool hair cut"}, ProfilPicture = "", Details = "\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!"},
                new Speaker { Id = new SpeakerId("6"), FirstName = "Bat", LastName = "Man", Company = "BatLeague", Skills = new List<string> {"Bat", "BatVoice", "Bat...", "BatMobile"}, ProfilPicture = "", Details = "I'm BATMAN!!!"},
            };

        public ICollection<Session> Sessions { get; } = new List<Session>
            {
                new Session { Id = new SessionId("1"), Title = "C# pour les nuls", Description = "C# pour les devs vraiment pas bons", Speakers = new List<Speaker>(), Room = new Room {Name = "42"}, Tags = new List<Tag>()},
                new Session { Id = new SessionId("2"), Title = "F# pour les nuls", Description = "F# pour les devs vraiment pas bons", Speakers = new List<Speaker>(), Room = new Room {Name = "69"}, Tags = new List<Tag>()},
                new Session { Id = new SessionId("3"), Title = "Xamarin pour les nuls", Description = "Xamarin pour les devs vraiment pas bons", Speakers = new List<Speaker>(), Room = new Room {Name = "WhiteRoom"}, Tags = new List<Tag>()},
                new Session { Id = new SessionId("4"), Title = "Xamarin FORMS", Description = "Xamarin.Forms is a cross-platform UI toolkit that allows developers to easily create native user interface layouts that can be shared across Android, iOS, and Windows Phone. This section contains the introduction to Xamarin.Forms and our guides to help you build Xamarin.Forms apps. You can also learn more about its capabilities, try our samples, and browse the API documentation.", Speakers = new List<Speaker>(), Room = new Room {Name = "VIP"}, Tags = new List<Tag>()},
                new Session { Id = new SessionId("5"), Title = "YOLO Speak!!", Description = "F# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bons", Speakers = new List<Speaker>(), Room = new Room {Name = "SecretRoom"}, Tags = new List<Tag>()}
            };

        public DataSource()
        {
            var speaker = Speakers.GetEnumerator();
            var interval = new TimeSlot {StartDate = DateTime.Now, EndDate = DateTime.MaxValue};
            var tag = Tags.GetEnumerator();
            foreach (var session in Sessions)
            {
                session.Interval = interval;
                if (speaker.MoveNext())
                {
                    session.Speakers.Add(speaker.Current);
                }
                if (session.Id.ToString() == "5")
                {
                    if (speaker.MoveNext())
                    {
                        session.Speakers.Add(speaker.Current);
                    }
                    while (tag.MoveNext())
                    {
                        session.Tags.Add(tag.Current);
                    }
                }
                else if (tag.MoveNext())
                {
                    session.Tags.Add(tag.Current);
                }
            }
        }
    }
}
