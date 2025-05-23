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

        // Write theory test for Greedy constructor w/ bad LastName
        [Theory]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("")]
        public void ThrowExceptionCreatingAnInstanceWithBadLastName(string? testValue)
        {
            //No setup needed.

            //Execution
            Action action = () => new Person("First", testValue, null, null);

            //Assertion
            action.Should().Throw<ArgumentException>();
        }

        //TODO: Greedy full name
        [Theory]
        [InlineData("   ", "Last")]
        [InlineData(null, "Last")]
        [InlineData("", "Last")]
        [InlineData("First", "   ")]
        [InlineData("First", null)]
        [InlineData("First", "")]
        public void ThrowExceptionCreatingAnInstanceWithBadFullName(string? firstValue, string? lastValue)
        {
            //No setup needed.

            //Execution
            Action action = () => new Person(firstValue, lastValue, null, null);

            //Assertion
            action.Should().Throw<ArgumentException>();
        }


        #endregion

        #endregion

        #region Parameters

        #region Fact
        // Write fact test for Attribute w/ good FirstName
        [Fact]
        public void DirectlyChangeFirstNameViaProperty()
        {
            string expectedFirstName = "Bob";

            Person sut = new Person("Dave", "Bowie", null, null);

            sut.FirstName = "Bob";

            sut.FirstName.Should().Be(expectedFirstName);
        }

        // Write fact test for Attribute w/ good LastName
        [Fact]
        public void DirectlyChangeLastNameViaProperty()
        {
            string expectedLastName = "Smith";

            Person sut = new Person("Dave", "Bowie", null, null);

            sut.LastName = "Smith";

            sut.LastName.Should().Be(expectedLastName);
        }

        //TODO: Change address
        //These two tests could be replaced with a Theory test that has both address values.
        [Fact]
        public void DirectlyChangeAddressViaProperty()
        {
            ResidentAddress expectedAddress = new ResidentAddress(321, "Ash Lane", "Edmonton", "AB", "E4R5T6");

            Person sut = new Person("Don", "Welch", new ResidentAddress(123, "Maple St", "Edmonton", "AB", "Y7U8I9"), null);

            sut.Address = new ResidentAddress(321, "Ash Lane", "Edmonton", "AB", "E4R5T6");

            sut.Address.Should().Be(expectedAddress);
        }

        [Fact]
        public void DirectlyChangeAddressToEmptyViaProperty()
        {

            Person sut = new Person("Don", "Welch", new ResidentAddress(123, "Maple St", "Edmonton", "AB", "Y7U8I9"), null);

            sut.Address = null;

            sut.Address.Should().BeNull();
        }

        #endregion

        #region Theory

        // Write theory test for Attribute w/ bad FirstName
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void ThrowExceptionWhenDirectlyChangingFirstNameWithBadData(string testValue)
        {
            Person sut = new Person("Lowan", "Behold", null, null);

            Action action = () => sut.FirstName = testValue;

            action.Should().Throw<ArgumentException>();
        }

        // Write theory test for Attribute w/ bad LastName
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void ThrowExceptionWhenDirectlyChangingLastNameWithBadData(string testValue)
        {
            Person sut = new Person("Lowan", "Behold", null, null);

            Action action = () => sut.LastName = testValue;

            action.Should().Throw<ArgumentException>();
        }

        #endregion

        #endregion

        #region Methods

        #region Fact

        [Fact]
        public void ChangeFullName()
        {
            string expectedFirstName = "Remi";
            string expectedLastName = "The Rat";
            string extectedFullName = "The Rat, Remi";

            Person sut = new Person("Mickey", "Mouse", null, null);

            sut.ChangeFullName("Remi", "The Rat");

            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.FullName.Should().Be(extectedFullName);
        }
        #endregion

        #region Theory
        #endregion

        #endregion

    }
}