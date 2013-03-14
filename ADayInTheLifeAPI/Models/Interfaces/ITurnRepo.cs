using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADayInTheLifeAPI.Models.Interfaces
{
    public interface ITurnRepo
    {
        TurnModel NewTurn(TurnModel item);
        List<TurnModel> AllTurns(int playerId);
        TurnModel TurnById(int playerId, int turnId);
        TurnMoveModel AddMove(TurnMoveModel item);
    }
}
