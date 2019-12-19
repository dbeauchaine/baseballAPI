using BaseballAPI.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseballAPI.UnitTests
{
    class TestHelpers
    {
        public People GeneratePeople()
        {
            return new People()
            {
                PlayerId = "id",
                BirthYear = 1991,
                BirthMonth = 1,
                BirthDay = 20,
                BirthCountry = "country",
                BirthState = "state",
                BirthCity = "city",
                DeathYear = 2011,
                DeathMonth = 2,
                DeathDay = 1,
                DeathCountry = "country",
                DeathState = "state",
                DeathCity = "city",
                NameFirst = "first",
                NameLast = "last",
                NameGiven = "first middle",
                Weight = 200,
                Height = 128,
                Bats = "R",
                Throws = "L",
                Debut = "1/2/2010",
                FinalGame = "1/30/2010",
                RetroId = "flast102",
                BbrefId = "ffflast-012",
            };
        }
    }
}
