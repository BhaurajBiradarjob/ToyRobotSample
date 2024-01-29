using AutoMoq;
using FluentAssertions;
using ToyRobotConsole.Implementation;

namespace TryRobotConsoleTest.Tests
{
    [Trait("Category", "CommandTests")]
    public class CommandTests
    {
        string[] inValidCommand = { "PLACE 1,2,EAST","","MOVE","LEFT","MOVE","REPORT" };
        string[] validInputCommand = { "PLACE 1,2,EAST", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT" };


        #region Constructor
        [Fact]
        public void Given_CurrentClass_When_CallingConstructor_Then_NoExceptionIsThrown()
        {
            // Arrange
            var autoMoq = new AutoMoqer();

            // Act
            Action action = () => autoMoq.Create<Command>();

            // Assert
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Given_CurrentClass_When_CallingConstructor_Then_RobotMovementsIsSetToExpectedValue()
        {
            // Arrange
            var autoMoq = new AutoMoqer();

            // Act
            var commands = autoMoq.Create<Command>();

            // Assert
            commands.Should().NotBeNull();
            commands.Placed.Equals(false);
            commands.Message.Should().BeEmpty();
            commands.Table.Should().NotBeNull();
            commands.Simulation.Should().BeNull();
            commands.ErrorInputs.Should().NotBeNullOrEmpty();
        }
        #endregion

        [Fact]
        public void Given_CurrentClass_When_CallingStartMethod_WithImProperCommands_Then_ExpectedValueReturns()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var commands = autoMoq.Create<Command>();

            // Act
            commands.Start(inValidCommand);

            // Assert
            commands.Should().NotBeNull();
            commands.Placed.Equals(true);
            commands.Message.Should().NotBeNullOrEmpty();
            commands.Table.Should().NotBeNull();
            commands.Simulation.Should().NotBeNull();
            commands.ErrorInputs.Should().NotBeNullOrEmpty();
            commands.Message.Should().BeEquivalentTo(commands.ErrorInputs);
        }

        [Fact]
        public void Given_CurrentClass_When_CallingStartMethod_WithProperCommands_Then_ExpectedValueReturns()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var commands = autoMoq.Create<Command>();

            // Act
            commands.Start(validInputCommand);

            // Assert
            commands.Should().NotBeNull();
            commands.Placed.Equals(true);
            commands.Message.Should().BeEmpty();
            commands.Table.Should().NotBeNull();
            commands.Simulation.Should().NotBeNull();
            commands.ErrorInputs.Should().NotBeNullOrEmpty();
            commands.Message.Should().NotBeSameAs(commands.ErrorInputs);
        }
    }
}
