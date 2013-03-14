using ADayInTheLifeAPI.Models.Entities;
using ADayInTheLifeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADayInTheLifeAPI.Models.Repositories
{
    public class GameRepo : IGameRepo
    {
        public GameModel NewGame(GameModel item)
        {
            GameModel ret = new GameModel();

            using (ADayInTheLifeEntities db = new ADayInTheLifeEntities())
            {
                try
                {
                    if (item.GameId == 0)
                    {
                        if (item.PlayerNames.Count > 0)
                        {
                            Game game = new Game()
                            {
                                Players = item.Players,
                                WinCondition1 = item.WinCondition1,
                                WinCondition2 = item.WinCondition2,
                                WinCondition3 = item.WinCondition3,
                                WinCondition4 = item.WinCondition4
                            };

                            db.Games.Add(game);
                            db.SaveChanges();

                            List<int> used = new List<int>();

                            foreach (String name in item.PlayerNames)
                            {
                                //Check for existing Id:
                                int id = db.Players.Where(o => o.PlayerName.Equals(name)).Select(o => o.PlayerId).FirstOrDefault();

                                if (id == 0)
                                {
                                    Player p = new Player()
                                    {
                                        PlayerName = name
                                    };

                                    db.Players.Add(p);
                                    db.SaveChanges();

                                    id = p.PlayerId;
                                }

                                Random r = new Random(game.Players);

                                int position = (int)r.Next(game.Players);

                                while ((position < 0 || position > game.Players) || used.Contains(position))
                                {
                                    position = (int)r.Next(game.Players);
                                }

                                used.Add(position);

                                PlayerInGame pig = new PlayerInGame()
                                {
                                    GameId = game.GameId,
                                    PlayerId = id,
                                    PlayerPosition = position
                                };

                                db.PlayerInGames.Add(pig);
                                db.SaveChanges();
                            }

                            ret = new GameModel()
                            {
                                GameId = game.GameId,
                                Players = game.Players,
                                WinCondition1 = game.WinCondition1,
                                WinCondition2 = game.WinCondition2,
                                WinCondition3 = game.WinCondition3,
                                WinCondition4 = game.WinCondition4
                            };
                        }
                    }
                }
                catch (Exception e)
                {
                    //TODO: Log this.
                } 
            }

            return ret;
        }

        public List<GameModel> AllGames()
        {
            List<GameModel> ret = new List<GameModel>();

            using (ADayInTheLifeEntities db = new ADayInTheLifeEntities())
            {
                try
                {
                    List<Game> games = db.Games.ToList();

                    foreach(Game g in games)
                    {
                        GameModel gm = new GameModel() 
                        { 
                            GameId = g.GameId,
                            Players = g.Players,
                            WinCondition1 = g.WinCondition1,
                            WinCondition2 = g.WinCondition2,
                            WinCondition3 = g.WinCondition3,
                            WinCondition4 = g.WinCondition4
                        };

                        ret.Add(gm);
                    }
                }
                catch (Exception e)
                {
                    //TODOL: Log This
                }
            }

            return ret;
        }

        public GameModel GameById(int id)
        {
            GameModel ret = new GameModel();

            using (ADayInTheLifeEntities db = new ADayInTheLifeEntities())
            {
                try
                {
                    Game game = db.Games.Where(o => o.GameId == id).FirstOrDefault();

                    if (game == null)
                    {
                        throw new Exception(String.Format("Issue: Game {0} cannot be found", id));
                    }

                    ret = new GameModel()
                    {
                        GameId = game.GameId,
                        Players = game.Players,
                        WinCondition1 = game.WinCondition1,
                        WinCondition2 = game.WinCondition2,
                        WinCondition3 = game.WinCondition3,
                        WinCondition4 = game.WinCondition4
                    };
                }
                catch (Exception e)
                {
                    //TODO: Log This.
                }
            }
            return ret;
        }
    }
}