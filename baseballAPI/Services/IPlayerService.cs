using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.Services
{
    public interface IPlayerService
    {
        public string GetPlayerId(string firstName, string lastName);
    }
}
