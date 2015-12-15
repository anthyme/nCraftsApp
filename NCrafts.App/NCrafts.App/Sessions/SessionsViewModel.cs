using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NCrafts.App.Annotations;
using NCrafts.App.Common.Infrastructure;

namespace NCrafts.App.Sessions
{
    public class SessionsViewModel : Observable
    {
        private readonly ISessionRespository sessionRespository;
        private ObservableCollection<Session> sessions;
        private string header;

        public SessionsViewModel(ISessionRespository sessionRespository)
        {
            this.sessionRespository = sessionRespository;
        }

        public async Task StartAsync()
        {
            Sessions = new ObservableCollection<Session>(sessionRespository.GetAll());
            Header = "Sessions";
        }

        public string Header
        {
            get { return header; }
            set { header = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Session> Sessions
        {
            get { return sessions; }
            set { sessions = value; OnPropertyChanged(); }
        }
    }
}
