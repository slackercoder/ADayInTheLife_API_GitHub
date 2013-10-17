using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADayInTheLifeAPI.Models.Entities;

namespace ADayInTheLifeAPI.Models.Interfaces
{
    public interface IGameRepo
    {
        GameModel NewGame(GameModel item);
        List<GameModel> AllGames();
        GameModel GameById(int id);

        List<Account> GetAccounts();
        Account AccountById(int id);
    }
}