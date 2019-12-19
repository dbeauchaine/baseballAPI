using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using NUnit.Framework;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class PlayerMapperStats
    {
        private PlayerMapper _mapper;
        private TestHelpers _testHelpers;
        [SetUp]
        public void SetUp()
        {
            _mapper = new PlayerMapper();
            _testHelpers = new TestHelpers();
        }

        [Test]
        public void MapCopiesDataFromPeopleToPlayer()
        {
            People people = _testHelpers.GeneratePeople();
            Player player = _mapper.Map(people);

            AssertThatEachElementIsEqual(people, player);
        }

        private void AssertThatEachElementIsEqual(People people, Player player)
        {
            Assert.That(player.PlayerId, Is.EqualTo(people.PlayerId));
            Assert.That(player.BirthYear, Is.EqualTo(people.BirthYear));
            Assert.That(player.BirthMonth, Is.EqualTo(people.BirthMonth));
            Assert.That(player.BirthDay, Is.EqualTo(people.BirthDay));
            Assert.That(player.BirthCountry, Is.EqualTo(people.BirthCountry));
            Assert.That(player.BirthState, Is.EqualTo(people.BirthState));
            Assert.That(player.BirthCity, Is.EqualTo(people.BirthCity));
            Assert.That(player.DeathYear, Is.EqualTo(people.DeathYear));
            Assert.That(player.DeathMonth, Is.EqualTo(people.DeathMonth));
            Assert.That(player.DeathDay, Is.EqualTo(people.DeathDay));
            Assert.That(player.DeathCountry, Is.EqualTo(people.DeathCountry));
            Assert.That(player.DeathState, Is.EqualTo(people.DeathState));
            Assert.That(player.DeathCity, Is.EqualTo(people.DeathCity));
            Assert.That(player.NameFirst, Is.EqualTo(people.NameFirst));
            Assert.That(player.NameLast, Is.EqualTo(people.NameLast));
            Assert.That(player.NameGiven, Is.EqualTo(people.NameGiven));
            Assert.That(player.Weight, Is.EqualTo(people.Weight));
            Assert.That(player.Height, Is.EqualTo(people.Height));
            Assert.That(player.Bats, Is.EqualTo(people.Bats));
            Assert.That(player.Throws, Is.EqualTo(people.Throws));
            Assert.That(player.Debut, Is.EqualTo(people.Debut));
            Assert.That(player.FinalGame, Is.EqualTo(people.FinalGame));
            Assert.That(player.RetroId, Is.EqualTo(people.RetroId));
            Assert.That(player.BbrefId, Is.EqualTo(people.BbrefId));
        }
    }
}

