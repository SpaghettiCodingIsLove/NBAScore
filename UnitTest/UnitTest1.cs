
using NbaScore.Model;
using NbaScore.Model.Entities;
using NbaScore.View.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestApi()
        {
            Games games = ApiService.GetGames();
            Assert.NotNull(games);
        }

        [Fact]
        public async Task InitPlayer()
        {
            await HelperClass.Init();
            Assert.NotEmpty(HelperClass.AllPlayers);
        }


    }
}
