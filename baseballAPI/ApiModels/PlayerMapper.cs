using BaseballAPI.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.ApiModels
{
    public class PlayerMapper : IPlayerMapper
    {
        public Player Map(People person)
        {
            var player = CopyValues(person);
            
            generateValues(player);
            
            return player;
        }

        private void generateValues(Player player)
        {
            player.NameFull = $"{player.NameGiven} {player.NameLast}";
        }
        private Player CopyValues(People person)
        {
            return new Player()
            {
                PlayerId = person.PlayerId,
                BirthYear = person.BirthYear,
                BirthMonth = person.BirthMonth,
                BirthDay = person.BirthDay,
                BirthCountry = person.BirthCountry,
                BirthState = person.BirthState,
                BirthCity = person.BirthCity,
                DeathYear = person.DeathYear,
                DeathMonth = person.DeathMonth,
                DeathDay = person.DeathDay,
                DeathCountry = person.DeathCountry,
                DeathState = person.DeathState,
                DeathCity = person.DeathCity,
                NameFirst = person.NameFirst,
                NameLast = person.NameLast,
                NameGiven = person.NameGiven,
                Weight = person.Weight,
                Height = person.Height,
                Bats = person.Bats,
                Throws = person.Throws,
                Debut = person.Debut,
                FinalGame = person.FinalGame,
                RetroId = person.RetroId,
                BbrefId = person.BbrefId,
            };
        }
    }
}

