using System.Collections.Generic;
using NCrafts.App.Business.Common;

namespace NCrafts.App.Business.Core
{
    public class Tag
    {
        public string Title { get; set; }
        public List<SessionId> Sessions { get; set; }
    }
}