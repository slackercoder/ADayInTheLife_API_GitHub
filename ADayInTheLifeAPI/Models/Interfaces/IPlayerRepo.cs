using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADayInTheLifeAPI.Models.Interfaces
{
    public interface IPlayerRepo
    {
        PlayerModel NewPlayer(PlayerModel item);
    }
}
