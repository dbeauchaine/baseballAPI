using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;

namespace BaseballAPI.Services
{
    public interface IFieldingService
    {
        public IEnumerable<FieldingStats> GetFieldingStats(string id);
        public IEnumerable<FieldingPostStats> GetFieldingPostStats(string id);
    }
}
