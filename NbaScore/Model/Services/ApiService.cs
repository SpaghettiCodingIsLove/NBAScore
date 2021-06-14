using NbaScore.Model.Entities;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace NbaScore.View.Services
{
    public static class ApiService
    {
        private static RestClient client;

        static ApiService()
        {
            client = new RestClient("https://www.balldontlie.io/api/v1/{command}");
        }

        public static Games GetGames()
        {
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.AddParameter("command", "games", ParameterType.UrlSegment);

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Games>(response.Content);
            }
            return null;
        }

        public static Games GetGamesByDate(string startDate, string endDate)
        {
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.AddParameter("command", "games", ParameterType.UrlSegment);
            request.AddParameter("start_date", startDate);
            request.AddParameter("end_date", endDate);

            IRestResponse response = client.Execute(request);
            if(response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Games>(response.Content);
            }
            return null;
        }

        public static Games GetFavoriteTeamGames(int season, long teamId, int page)
        {
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.AddParameter("command", "games", ParameterType.UrlSegment);
            request.AddParameter("seasons[]", season);
            request.AddParameter("team_ids[]", teamId);
            request.AddParameter("per_page", 100);
            request.AddParameter("page", page);

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Games>(response.Content);
            }
            return null;
        }

        public static Model.Entities.Players GetPlayers()
        {
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.AddParameter("command", "players", ParameterType.UrlSegment);

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Model.Entities.Players>(response.Content);
            }
            return null;
        }

        public static async Task<Model.Entities.Players> GetPlayersPage(int perPage, int page)
        {
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.AddParameter("command", "players", ParameterType.UrlSegment);
            request.AddParameter("per_page", perPage);
            request.AddParameter("page", page);

            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Model.Entities.Players>(response.Content);
            }
            return null;
        }

        public static Model.Entities.Players GetSearchedPlayers(string word)
        {
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.AddParameter("command", "players", ParameterType.UrlSegment);
            request.AddParameter("per_page", 100);
            request.AddParameter("search", word);

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Model.Entities.Players>(response.Content);
            }
            return null;
        }

        public static SeasonAveragesResponse GetSeasonAverages()
        {
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.AddParameter("command", "season_averages", ParameterType.UrlSegment);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<SeasonAveragesResponse>(response.Content);
            }
            return null;
        }

        public static SeasonAveragesResponse GetPlayersSeasonAverages(long playerId, int season)
        {
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.AddParameter("command", "season_averages", ParameterType.UrlSegment);
            request.AddParameter("player_ids[]", playerId);
            request.AddParameter("season", season);

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<SeasonAveragesResponse>(response.Content);
            }
            return null;
        }

        public static StatsData GetStats()
        {
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.AddParameter("command", "stats", ParameterType.UrlSegment);

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<StatsData>(response.Content);
            }
            return null;
        }

        public static StatsData GetStatsFromGame(long gameId)
        {
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.AddParameter("command", "stats", ParameterType.UrlSegment);
            request.AddParameter("game_ids[]", gameId);
            request.AddParameter("perPage", 50);

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<StatsData>(response.Content);
            }
            return null;
        }

        public static Teams GetTeams()
        {
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.AddParameter("command", "teams", ParameterType.UrlSegment);

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Teams>(response.Content);
            }
            return null;
        }
    }
}
