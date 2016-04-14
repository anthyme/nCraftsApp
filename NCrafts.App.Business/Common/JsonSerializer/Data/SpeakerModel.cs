using System.Collections.Generic;

namespace NCrafts.App.Business.Common.JsonSerializer.Data
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
    }
}
