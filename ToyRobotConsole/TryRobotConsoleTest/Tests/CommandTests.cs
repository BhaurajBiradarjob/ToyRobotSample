using AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using ToyRobotConsole;
using ToyRobotConsole.Implementation;
using ToyRobotConsole.Interfaces;
using ToyRobotConsole.Robots;

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
            IItem item = new Table();
            IRobotMoves robotMoves = new RobotMovements();
            IMovement movement = new MovementSimulator(item, robotMoves);
            
            // Act
            Action action = () => new Mock<Command>(movement, item);

            // Assert
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Given_CurrentClass_When_CallingConstructor_Then_RobotMovementsIsSetToExpectedValue()
        {
            // Arrange
            IItem item = new Table();
            IRobotMoves robotMoves = new RobotMovements();
            IMovement movement = new MovementSimulator(item, robotMoves);

            // Act
            var commands = new Mock<Command>(movement, item).Object;

            // Assert
            commands.Should().NotBeNull();
            commands.Placed.Equals(false);
            commands.Message.Should().BeEmpty();
            commands.ErrorInputs.Should().NotBeNullOrEmpty();
        }
        #endregion

        [Fact]
        public void Given_CurrentClass_When_CallingStartMethod_WithImProperCommands_Then_ExpectedValueReturns()
        {
            // Arrange
            IItem item = new Table();
            IRobotMoves robotMoves = new RobotMovements();
            IMovement movement = new MovementSimulator(item, robotMoves);
            var commands = new Mock<Command>(movement, item).Object;

            // Act
            commands.Start(inValidCommand);

            // Assert
            commands.Should().NotBeNull();
            commands.Placed.Equals(true);
            commands.Message.Should().NotBeNullOrEmpty();
            commands.ErrorInputs.Should().NotBeNullOrEmpty();
            commands.Message.Should().BeEquivalentTo(commands.ErrorInputs);
        }

        [Fact]
        public void Given_CurrentClass_When_CallingStartMethod_WithProperCommands_Then_ExpectedValueReturns()
        {
            // Arrange
            IItem item = new Table();
            IRobotMoves robotMoves = new RobotMovements();
            IMovement movement = new MovementSimulator(item, robotMoves);
            var commands = new Mock<Command>(movement, item).Object;

            // Act
            commands.Start(validInputCommand);

            // Assert
            commands.Should().NotBeNull();
            commands.Placed.Equals(true);
            commands.Message.Should().BeEmpty();
            commands.ErrorInputs.Should().NotBeNullOrEmpty();
            commands.Message.Should().NotBeSameAs(commands.ErrorInputs);
        }
    }
}
