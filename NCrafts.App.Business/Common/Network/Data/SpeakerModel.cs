using System.Collections.Generic;

namespace NCrafts.App.Business.Common.Network.Data
{
    public class SpeakerModel
    {
        public AvatarModel Avatar { get; set; }
        public IList<BookModel> Books { get; set; }
        public string Company { get; set; }
        public string Id { get; set; }
        public IList<string> Languages { get; set; }
        public string Name { get; set; }
        public IList<SessionModel> Sessions { get; set; }
        public string Slides { get; set; }
        public string Site { get; set; }
        public string Twitter { get; set; }
        public string Github { get; set; }

        // useless it was for fun so I keep it for one git commit
        // TODO: remove this code
        public static bool operator ==(SpeakerModel speaker1, SpeakerModel speaker2)
        {
            return speaker1?.Id == speaker2?.Id;
        }

        public static bool operator !=(SpeakerModel speaker1, SpeakerModel speaker2)
        {
            return speaker1?.Id != speaker2?.Id;
        }

        protected bool Equals(SpeakerModel other)
        {
            return string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SpeakerModel)obj);
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
        }
    }
}
