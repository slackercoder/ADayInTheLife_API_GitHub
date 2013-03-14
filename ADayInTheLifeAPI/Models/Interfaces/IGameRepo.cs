using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADayInTheLifeAPI.Models.Interfaces
{
    public interface IGameRepo
    {
        GameModel NewGame(GameModel item);
        List<GameModel> AllGames();
        GameModel GameById(int id);
    }
}