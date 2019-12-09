﻿using BaseballAPI.RepositoryModels;

namespace BaseballAPI.Services
{
    public interface IPlayerService
    {
        public string GetPlayerId(string firstName, string lastName);

        public People GetPlayer(string id);
    }
}
