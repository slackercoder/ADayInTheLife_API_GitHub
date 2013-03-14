using ADayInTheLifeAPI.Models;
using ADayInTheLifeAPI.Models.Interfaces;
using ADayInTheLifeAPI.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ADayInTheLifeAPI.Controllers
{
    public class GameController : ApiController
    {
        public static IGameRepo gameRepository = new GameRepo();
        public static ITurnRepo turnRepository = new TurnRepo();

        #region Game
        public HttpResponseMessage PostStartGame(GameModel item)
        {
            item = gameRepository.NewGame(item);
            var response = Request.CreateResponse<GameModel>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApiWithAction", new { id = item.GameId });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage GetGames()
        {
            var item = gameRepository.AllGames();
            var response = Request.CreateResponse<List<GameModel>>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApiWithAction", new { id = item.First().GameId });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetGameById(int id)
        {
            var item = gameRepository.GameById(id);
            var response = Request.CreateResponse<GameModel>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApiWithAction", new { id = item.GameId });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        #endregion

        #region Turn Actions
        public HttpResponseMessage PostStartTurn(TurnModel item)
        {
            item = turnRepository.NewTurn(item);
            var response = Request.CreateResponse<TurnModel>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApiWithAction", new { id = item });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage PostAddTurnMove(TurnMoveModel item)
        {
            item = turnRepository.AddMove(item);
            var response = Request.CreateResponse<TurnMoveModel>(HttpStatusCode.Created, item);

            String uri = Url.Link("DefaultApiWithAction", new { id = item });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage GetTurns(int playerId)
        {
            var item = turnRepository.AllTurns(playerId);
            var response = Request.CreateResponse<List<TurnModel>>(HttpStatusCode.Created, item);

            String uri = Url.Link("DefaultApiWithAction", new { id = item });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage GetTurnById(int playerId, int turnId)
        {
            var item = turnRepository.TurnById(playerId, turnId);
            var response = Request.CreateResponse<TurnModel>(HttpStatusCode.Created, item);

            String uri = Url.Link("DefaultApiWithAction", new { id = item });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        #endregion
    }
}
