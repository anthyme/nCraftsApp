using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Business.Core.Data;

namespace NCrafts.App.Business.Speakers.Query
{
    public delegate ICollection<SpeakerSummary> GetSpeakerSumariesQuery();

    class Queries
    {
        public static GetSpeakerSumariesQuery CreateGetSpeakerSumariesQuery(IDataSourceRepository dataSourceRepository)
        {
            return
                () =>
                    dataSourceRepository.Retreive()
                        .Speakers.Select(x => new SpeakerSummary {Id = x.Id, Name = x.FirstName + " " + x.LastName})
                        .ToList();
        }
    }
}