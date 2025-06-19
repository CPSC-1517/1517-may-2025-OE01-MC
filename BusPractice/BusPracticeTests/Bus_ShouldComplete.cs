using System;
using System.Collections.Generic;
using BusPractice;
using FluentAssertions;
using Xunit;

/// <summary>
/// These will test that your Bus class is working correctly.
/// </summary>
public class BusTestsComplete
{
    [Fact]
    public void CreateValidBus()
    {
        var bus = new Bus("Route1", "Bus100", 50);

        bus.Route.Should().Be("Route1");
        bus.BusNumber.Should().Be("Bus100");
        bus.Capacity.Should().Be(50);
        bus.Fare.Should().Be(2.50);
        bus.Stops.Should().BeEmpty();
    }

    [Theory]
    [InlineData(null, "Bus100", 50, "*null or empty*")]
    [InlineData("Route1", null, 50, "*null or empty*")]
    [InlineData("Route1", "Bus100", 0, "*greater than zero*")]
    public void ThrowExceptionForInvalidConstructorParameters(string route, string busNumber, int capacity, string expectedMessage)
    {
        Action act = () => new Bus(route, busNumber, capacity);

        act.Should().Throw<ArgumentException>().WithMessage(expectedMessage);
    }

    [Fact]
    public void AddStopToList()
    {
        var bus = new Bus("Route1", "Bus100", 50);
        bus.AddStop("Stop1");

        bus.Stops.Should().Contain("Stop1");
    }

    [Fact]
    public void ThrowExceptionForAddingInvalidStop()
    {
        var bus = new Bus("Route1", "Bus100", 50);
        Action act = () => bus.AddStop(null);

        act.Should().Throw<ArgumentException>().WithMessage("Stop cannot be null or empty.");
    }

    [Fact]
    public void RemoveStopFromList()
    {
        var bus = new Bus("Route1", "Bus100", 50);
        bus.AddStop("Stop1");
        bus.RemoveStop("Stop1");

        bus.Stops.Should().NotContain("Stop1");
    }

    [Fact]
    public void ThrowExceptionForRemovingInvalidStop()
    {
        var bus = new Bus("Route1", "Bus100", 50);
        Action act = () => bus.RemoveStop(null);

        act.Should().Throw<ArgumentException>().WithMessage("Stop cannot be null or empty.");
    }

    [Fact]
    public void ReturnCSVFormatedString()
    {
        var bus = new Bus("Route1", "Bus100", 50);
        bus.AddStop("Stop1");
        bus.AddStop("Stop2");

        var result = bus.ToString();

        result.Should().Be("Route1,Bus100,50,2.5,Stop1;Stop2");
    }
}