﻿using System;
using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Business.Common;

namespace NCrafts.App.Business.Core.Data
{
    public class DataSource
    {
        // TODO: check how to manage the days with NCraft, if they send me the opening hours of each day or if I should retreive it form the conferences.
        public ICollection<TimeSlot> OpeningTime { get; } = new List<TimeSlot>
        {
            new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(9, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(19, 30, 0)},
            new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(1, 9, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(1, 19, 30, 0)},
            new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(2, 9, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(2, 19, 30, 0)},
            new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(3, 9, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(3, 19, 30, 0)},
            new TimeSlot { StartDate = Convert.ToDateTime("2016-05-12T08:30:00.0000000+00:00"), EndDate = Convert.ToDateTime("2016-05-12T20:30:00.0000000+00:00")},
        };

        public ICollection<Tag> Tags { get; set; } = new List<Tag>
            {
                new Tag { Title = "C#", Sessions = new List<SessionId>()},
                new Tag { Title = "F#", Sessions = new List<SessionId>()},
                new Tag { Title = "C++", Sessions = new List<SessionId>()},
                new Tag { Title = "C", Sessions = new List<SessionId>()},
                new Tag { Title = "Compiler", Sessions = new List<SessionId>()},
                new Tag { Title = "NCrafts", Sessions = new List<SessionId>()},
                new Tag { Title = "Mobile", Sessions = new List<SessionId>()},
                new Tag { Title = "Android", Sessions = new List<SessionId>()},
                new Tag { Title = "Xamarin", Sessions = new List<SessionId>()},
                new Tag { Title = "Testing", Sessions = new List<SessionId>()},
                new Tag { Title = "iOS", Sessions = new List<SessionId>()},
                new Tag { Title = "Null", Sessions = new List<SessionId>()},
                new Tag { Title = "tag_1", Sessions = new List<SessionId>()},
                new Tag { Title = "tag_2", Sessions = new List<SessionId>()},
                new Tag { Title = "tag_3", Sessions = new List<SessionId>()},
                new Tag { Title = "tag_4", Sessions = new List<SessionId>()},
                new Tag { Title = "tag_5", Sessions = new List<SessionId>()},
                new Tag { Title = "tag_6", Sessions = new List<SessionId>()},
                new Tag { Title = "tag_7", Sessions = new List<SessionId>()},
                new Tag { Title = "tag_8", Sessions = new List<SessionId>()},
                new Tag { Title = "Cloud", Sessions = new List<SessionId>()},
                new Tag { Title = "tag_9", Sessions = new List<SessionId>()},
                new Tag { Title = "tag_10", Sessions = new List<SessionId>()},
                new Tag { Title = "tag_11", Sessions = new List<SessionId>()},
            };

        public ICollection<Speaker> Speakers { get; set; } = new List<Speaker>
            {
                new Speaker { Id = new SpeakerId("1"), FirstName = "Lala", LastName = "Teletobies", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "Je suis rouge et timide. Dans la vie je sers pas à grand chose... SUICIDE!!!!", Company = "Viseo", Github = "testGitHub", Twitter = "@anthyme"},
                new Speaker { Id = new SpeakerId("2"), FirstName = "Bob", LastName = "The Builder", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "When I build!!! I push!", Github = "testGitHub", Twitter = "@anthyme"},
                new Speaker { Id = new SpeakerId("3"), FirstName = "Test", LastName = "Test-Name", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "olfjposdfojigpodfs dsfpogjpdsofgu dsfopg jpdf gpdfu gpoduifpgousdfpog udpof guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi", Company = "Viseo", Twitter = "@anthyme"},
                new Speaker { Id = new SpeakerId("4"), FirstName = "Peter", LastName = "Spiderman", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "I'm a secret guy", Company = "Viseo", Github = "testGitHub"},
                new Speaker { Id = new SpeakerId("5"), FirstName = "Clarck", LastName = "Zuper", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!", Company = "Viseo"},
                new Speaker { Id = new SpeakerId("6"), FirstName = "Bat", LastName = "Man", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "I'm BATMAN!!!", Github = "testGitHub"},
                new Speaker { Id = new SpeakerId("7"), FirstName = "Test1", LastName = "Name", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "Je suis rouge et timide. Dans la vie je sers pas à grand chose... SUICIDE!!!!", Twitter = "@anthyme"},
                new Speaker { Id = new SpeakerId("8"), FirstName = "Test2", LastName = "Name", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "When it's build I push!"},
                new Speaker { Id = new SpeakerId("9"), FirstName = "Test3", LastName = "Name", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "olfjposdfojigpodfs dsfpogjpdsofgu dsfopg jpdf gpdfu gpoduifpgousdfpog udpof guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi"},
                new Speaker { Id = new SpeakerId("10"), FirstName = "Test4", LastName = "Name", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "I'm a secret guy"},
                new Speaker { Id = new SpeakerId("11"), FirstName = "Test5", LastName = "Name", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!"},
                new Speaker { Id = new SpeakerId("12"), FirstName = "Test6", LastName = "Name", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "I'm BATMAN!!!"},
                new Speaker { Id = new SpeakerId("13"), FirstName = "Test7", LastName = "Name", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "Je suis rouge et timide. Dans la vie je sers pas à grand chose... SUICIDE!!!!"},
                new Speaker { Id = new SpeakerId("14"), FirstName = "Test8", LastName = "Name", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "When it's build I push!"},
                new Speaker { Id = new SpeakerId("15"), FirstName = "Test9", LastName = "Name", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "olfjposdfojigpodfs dsfpogjpdsofgu dsfopg jpdf gpdfu gpoduifpgousdfpog udpof guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi  guupd fugpodfugpodifpgi erpo gujvpdsf ugpdsou gpds ufgpd fuspg usdpogif p)dou fgpodu fjgdsf pg dpfg updof iicv)ài gv)dsfg)d f)àgi sp fogpdfo gdf )bgdàfi"},
                new Speaker { Id = new SpeakerId("16"), FirstName = "Test10", LastName = "Name", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "I'm a secret guy"},
                new Speaker { Id = new SpeakerId("17"), FirstName = "Test11", LastName = "Name", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!\n\tI'm with Lois Lane!!!\nI'm with Lois Lane!!!"},
                new Speaker { Id = new SpeakerId("18"), FirstName = "Test12", LastName = "Name", Sessions = new List<SessionId>( ), ProfilPicture = "simonbrown.jpg", ProfilPictureIcon = "simonbrown75.jpg", Details = "I'm BATMAN!!!"},
            };

        public ICollection<Session> Sessions { get; set; } = new List<Session>
            {
                new Session { Id = new SessionId("1"), Title = "C# pour les nuls", Description = "C# pour les devs vraiment pas bons", Speakers = new List<SpeakerId>(), Room = new Room {Name = "42"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(9, 45, 0), EndDate = DateTime.Now.Date + new TimeSpan(14, 30, 0)}},
                new Session { Id = new SessionId("2"), Title = "F# pour les nuls", Description = "F# pour les devs vraiment pas bons", Speakers = new List<SpeakerId>(), Room = new Room {Name = "69"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(9, 45, 0), EndDate = DateTime.Now.Date + new TimeSpan(12, 30, 0)}},
                new Session { Id = new SessionId("3"), Title = "Xamarin pour les nuls", Description = "Xamarin pour les devs vraiment pas bons", Speakers = new List<SpeakerId>(), Room = new Room {Name = "WhiteRoom"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(16, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(18, 30, 0)}},
                new Session { Id = new SessionId("4"), Title = "Xamarin FORMS", Description = "Xamarin.Forms is a cross-platform UI toolkit that allows developers to easily create native user interface layouts that can be shared across Android, iOS, and Windows Phone. This section contains the introduction to Xamarin.Forms and our guides to help you build Xamarin.Forms apps. You can also learn more about its capabilities, try our samples, and browse the API documentation.", Speakers = new List<SpeakerId>(), Room = new Room {Name = "VIP"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(1, 10, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(1, 19, 00, 0)}},
                new Session { Id = new SessionId("5"), Title = "Random Speak!!", Description = "F# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bons", Speakers = new List<SpeakerId>(), Room = new Room {Name = "SecretRoom"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(2, 11, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(2, 17, 30, 0)}},
                new Session { Id = new SessionId("6"), Title = "AAAAAAAAAAAAAAAA", Description = "C# pour les devs vraiment pas bons", Speakers = new List<SpeakerId>(), Room = new Room {Name = "42"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(2, 10, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(2, 11, 30, 0)}},
                new Session { Id = new SessionId("7"), Title = "oidjfpsdjofpcvd", Description = "F# pour les devs vraiment pas bons", Speakers = new List<SpeakerId>(), Room = new Room {Name = "69"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(2, 10, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(2, 11, 30, 0)}},
                new Session { Id = new SessionId("8"), Title = "ksdosdfh éé sdijpsdjc", Description = "Xamarin pour les devs vraiment pas bons", Speakers = new List<SpeakerId>(), Room = new Room {Name = "WhiteRoom"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(2, 11, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(2, 14, 30, 0)}},
                new Session { Id = new SessionId("9"), Title = "Test long text description", Description = "\tXamarin.Forms is a cross-platform UI toolkit that allows developers to easily create native user interface layouts that can be shared across Android, iOS, and Windows Phone.\n\tThis section contains the introduction to Xamarin.Forms and our guides to help you build Xamarin.Forms apps.\n\tYou can also learn more about its capabilities, try our samples, and browse the API documentation.\n\n DEUXIEME text:\n\tXamarin.Forms is a cross-platform UI toolkit that allows developers to easily create native user interface layouts that can be shared across Android, iOS, and Windows Phone.\n\tThis section contains the introduction to Xamarin.Forms and our guides to help you build Xamarin.Forms apps.\n\tYou can also learn more about its capabilities, try our samples, and browse the API documentation.\n\n TROISIEME text:\n\tXamarin.Forms is a cross-platform UI toolkit that allows developers to easily create native user interface layouts that can be shared across Android, iOS, and Windows Phone.\n\tThis section contains the introduction to Xamarin.Forms and our guides to help you build Xamarin.Forms apps.\n\tYou can also learn more about its capabilities, try our samples, and browse the API documentation.", Speakers = new List<SpeakerId>(), Room = new Room {Name = "VIP"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(2, 12, 0, 0), EndDate = DateTime.Now.Date + new TimeSpan(2, 18, 45, 0)}},
                new Session { Id = new SessionId("10"), Title = "sdjkf", Description = "F# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bons", Speakers = new List<SpeakerId>(), Room = new Room {Name = "SecretRoom"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(2, 10, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(2, 19, 0, 0)}},
                new Session { Id = new SessionId("11"), Title = "C# posdckmùsdur les nuls", Description = "C# pour les devs vraiment pas bons", Speakers = new List<SpeakerId>(), Room = new Room {Name = "42"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(2, 15, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(2, 18, 30, 0)}},
                new Session { Id = new SessionId("12"), Title = "F# pour les slkdcjnuls", Description = "F# pour les devs vraiment pas bons", Speakers = new List<SpeakerId>(), Room = new Room {Name = "69"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(2, 11, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(2, 14, 0, 0)}},
                new Session { Id = new SessionId("13"), Title = "X", Description = "Xamarin pour les devs vraiment pas bons", Speakers = new List<SpeakerId>(), Room = new Room {Name = "WhiteRoom"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(2, 15, 0, 0), EndDate = DateTime.Now.Date + new TimeSpan(2, 16, 00, 0)}},
                new Session { Id = new SessionId("14"), Title = "LONG sdioufhios iosdufhosdjif oisdufoisdj osidfosfdjif oisfopisdjf oisdufoisjd sidhfosfidj LONG", Description = "Xamarin.Forms is a cross-platform UI toolkit that allows developers to easily create native user interface layouts that can be shared across Android, iOS, and Windows Phone. This section contains the introduction to Xamarin.Forms and our guides to help you build Xamarin.Forms apps. You can also learn more about its capabilities, try our samples, and browse the API documentation.", Speakers = new List<SpeakerId>(), Room = new Room {Name = "VIP"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(2, 11, 15, 0), EndDate = DateTime.Now.Date + new TimeSpan(2, 11, 45, 0)}},
                new Session { Id = new SessionId("15"), Title = "4 Speakers !!", Description = "F# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bonsF# pour les devs vraiment pas bons", Speakers = new List<SpeakerId>(), Room = new Room {Name = "SecretRoom"}, Tags = new List<Tag>(), Interval = new TimeSlot { StartDate = DateTime.Now.Date + new TimeSpan(2, 14, 30, 0), EndDate = DateTime.Now.Date + new TimeSpan(2, 17, 45, 0)}}
            };

        public ICollection<SessionId> SelectedSessions { get; set; } = new List<SessionId>();

        public DataSource()
        {
            var speaker = Speakers.GetEnumerator();
            var tag = Tags.GetEnumerator();
            foreach (var session in Sessions)
            {
                if (speaker.MoveNext())
                {
                    session.Speakers.Add(speaker.Current.Id);
                    speaker.Current.Sessions.Add(session.Id);
                }
                if (int.Parse(session.Id.ToString()) % 3 == 0)
                {
                    SelectedSessions.Add(session.Id);
                }
                if (session.Id.ToString() == "15")
                {
                    while (speaker.MoveNext())
                    {
                        session.Speakers.Add(speaker.Current.Id);
                        speaker.Current.Sessions.Add(session.Id);
                    }
                    while (tag.MoveNext())
                    {
                        session.Tags.Add(tag.Current);
                        tag.Current.Sessions.Add(session.Id);
                    }
                }
                else if (tag.MoveNext())
                {
                    session.Tags.Add(tag.Current);
                    tag.Current.Sessions.Add(session.Id);
                }
            }
        }

        // TODO: remove Union because right now the data is hard encoded after we will just have network data.
        public void AddSpeakers(ICollection<Speaker> speakers)
        {
            Speakers = Speakers.Union(speakers).ToList();
        }

        public void AddSessions(ICollection<Session> sessions)
        {
            Sessions = Sessions.Union(sessions).ToList();
        }

        public void AddTags(ICollection<Tag> tags)
        {
            Tags = Tags.Union(tags).ToList();
        }
    }
}
