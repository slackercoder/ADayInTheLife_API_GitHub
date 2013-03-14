using ADayInTheLifeAPI.Models.Entities;
using ADayInTheLifeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADayInTheLifeAPI.Models.Repositories
{
    public class TurnRepo: ITurnRepo
    {
        #region Game Level Actions
        public GameModel NewGame(GameModel item)
        {
            GameModel ret = null;

            using (ADayInTheLifeEntities db = new ADayInTheLifeEntities())
            {
                try
                {
                    Game g = new Game()
                    {
                        Players = item.Players,
                        WinCondition1 = item.WinCondition1,
                        WinCondition2 = item.WinCondition2,
                        WinCondition3 = item.WinCondition3,
                        WinCondition4 = item.WinCondition4,
                        CurrentTurn = item.CurrentTurn
                    };

                    db.Games.Add(g);
                    db.SaveChanges();

                    ret = new GameModel()
                    {
                        Players = g.Players,
                        WinCondition4 = g.WinCondition4,
                        WinCondition3 = g.WinCondition3,
                        WinCondition2 = g.WinCondition2,
                        WinCondition1 = g.WinCondition1,
                        CurrentTurn = g.CurrentTurn ?? 0
                    };
                }
                catch (Exception e)
                {
                    //TODO: Log This.
                }
            }

            return ret;
        }
        #endregion

        #region Turn Level Actions
        public TurnModel NewTurn(TurnModel item)
        {
            TurnModel ret = new TurnModel();

            using (ADayInTheLifeEntities db = new ADayInTheLifeEntities())
            {
                try
                {
                    Turn t = new Turn()
                    {
                        PlayerId = item.PlayerId,
                        GameId = item.GameId,
                        TimeLeft = item.TimeLeft,
                        TurnInGame = item.TurnInGame
                    };

                    db.Turns.Add(t);
                    db.SaveChanges();

                    ret = new TurnModel()
                    {
                        TurnId = t.TurnId,
                        PlayerId = t.PlayerId,
                        GameId = t.GameId,
                        TurnInGame = t.TurnInGame,
                        TimeLeft = t.TimeLeft
                    };
                }
                catch (Exception e)
                {
                    //TODO: Log this
                }
            }

            return ret;
        }

        public List<TurnModel> AllTurns(int playerId)
        {
            List<TurnModel> listing = new List<TurnModel>();

            using (ADayInTheLifeEntities db = new ADayInTheLifeEntities())
            {
                try
                {
                    List<Turn> turns = db.Turns.Where(o => o.PlayerId == playerId).ToList();

                    foreach (Turn t in turns)
                    {
                        TurnModel tm = new TurnModel()
                        {
                            TurnId = t.TurnId,
                            PlayerId = t.PlayerId,
                            GameId = t.GameId,
                            TimeLeft = t.TimeLeft,
                            TurnInGame = t.TurnInGame
                        };

                        listing.Add(tm);
                    }
                }
                catch (Exception e)
                {
                    //TODO: Log this
                }
            }

            return listing;
        }

        public TurnModel TurnById(int playerId, int turnId)
        {
            TurnModel ret = null;

            using (ADayInTheLifeEntities db = new ADayInTheLifeEntities())
            {
                try
                {
                    Turn t = db.Turns.Where(o => o.PlayerId == playerId && o.TurnId == turnId).FirstOrDefault();

                    if (t == null)
                    {
                        throw new Exception("Couldn't find that Turn record.");
                    }

                    ret = new TurnModel()
                    {
                        PlayerId = t.PlayerId,
                        GameId = t.GameId,
                        TurnInGame = t.TurnInGame,
                        TimeLeft = t.TimeLeft,
                        TurnId = t.TurnId
                    };
                }
                catch (Exception e)
                {
                    //TODO: Log This.
                }
            }

            return ret;
        }
        #endregion

        #region TurnMove Actions
        public TurnMoveModel AddMove(TurnMoveModel item)
        {
            TurnMoveModel ret = null;

            using (ADayInTheLifeEntities db = new ADayInTheLifeEntities())
            {
                try
                {
                    TurnMove tm = new TurnMove()
                    {
                        TurnId = item.TurnId,
                        TurnFrom = item.TurnFrom,
                        TurnTo = item.TurnTo,
                        Bought = item.Bought,
                        TimeUsed = item.TimeUsed
                    };

                    db.TurnMoves.Add(tm);
                    db.SaveChanges();

                    ret = new TurnMoveModel()
                    {
                        TurnMoveId = tm.TurnMoveId,
                        Bought = tm.Bought,
                        TurnTo  = tm.TurnTo,
                        TurnFrom = tm.TurnFrom,
                        TimeUsed = tm.TimeUsed,
                        TurnId = tm.TurnId,
                    };

                }
                catch (Exception e)
                {
                    //TODO: Log this
                }
            }

            return ret;
        } 
        #endregion
    }
}