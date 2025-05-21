using FluentAssertions;
using OOPsReview;

namespace TDDUnitTesting
{
    public class PersonShould
    {
        #region Constructors

        #region Fact
        [Fact]
        public void CreateAnInstanceWithDefaultConstructor()
        {
            //Setup
            string expectedFirstName = "Unknown";
            string expectedLastName = "Unknown";
            int expectedEmploymentPositions = 0;

            //Execution
            Person sut = new Person();

            //Assertion
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositions);
            sut.Address.Should().BeNull();
            sut.FullName.Should().Be($"{expectedFirstName} {expectedLastName}");
        }

        [Fact]
        public void CreateAnInstanceWithGreedyConstructor()
        {
            //Setup
            string expectedFirstName = "Jeff";
            string expectedLastName = "Bridges";
            int expectedEmploymentPositions = 0;

            //Execution
            Person sut = new Person("Jeff", "Bridges", null, null);

            //Assertion
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositions);
            sut.Address.Should().BeNull();
            sut.FullName.Should().Be($"{expectedFirstName} {expectedLastName}");
        }

        #endregion

        #region Theory

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void ThrowExceptionCreatingAnInstanceWithBadFirstName(string? testValue)
        {
            //No setup needed as we can't check the values

            //Execution
            Action action = () => new Person(testValue, "Last", null, null);

            action.Should().Throw<ArgumentException>();
        }

        #endregion

        #endregion

        #region Parameters

        #region Fact
        #endregion

        #region Theory
        #endregion

        #endregion

        #region Methods

        #region Fact
        #endregion

        #region Theory
        #endregion

        #endregion

    }
}