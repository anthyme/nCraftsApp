﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Sessions.Command;
using NCrafts.App.Business.Sessions.Query;
using NCrafts.App.Business.Speakers.Query;
using NCrafts.App.Common.Infrastructure;
using Xamarin.Forms;

namespace NCrafts.App.Speakers
{
    public class SpeakerDetailsViewModel : ViewModelBase
    {
        private readonly GetSpeakerDetailsQuery getSpeakerDetailsQuery;
        private readonly GetSessionSumariesSpeakerQuery getSessionSumariesSpeakerQuery;
        private readonly SpeakerId id;
        private SpeakerDetails speaker;
        private double heightList;
        private ObservableCollection<SessionSummary> sessions; 

        public SpeakerDetailsViewModel(OpenSessionCommand openSessionCommand,
                                       GetSpeakerDetailsQuery getSpeakerDetailsQuery,
                                       GetSessionSumariesSpeakerQuery getSessionSumariesSpeakerQuery,
                                       SpeakerId id)
        {
            this.id = id;
            this.getSpeakerDetailsQuery = getSpeakerDetailsQuery;
            this.getSessionSumariesSpeakerQuery = getSessionSumariesSpeakerQuery;
            heightList = 0;
            OpenSessionCommand = new Command<SessionId>(x => openSessionCommand(x));
        }

        public ICommand OpenSessionCommand { get; }

        public SpeakerDetails Speaker
        {
            get { return speaker; }
            set { speaker = value; OnPropertyChanged(); }
        }

        // TODO: find a proper solution, Don't use binding!!
        public double HeightList
        {
            get { return heightList; }
            set { heightList = value; OnPropertyChanged(); }
        }

        public ObservableCollection<SessionSummary> Sessions
        {
            get { return sessions; }
            set { sessions = value; OnPropertyChanged(); }
        } 

        protected override Task OnStart()
        {
            Speaker = getSpeakerDetailsQuery(id);
            Sessions = new ObservableCollection<SessionSummary>(getSessionSumariesSpeakerQuery(Speaker.SessionsId));
            HeightList = sessions.Count*52;
            return Task.FromResult(0);
        }
    }
}