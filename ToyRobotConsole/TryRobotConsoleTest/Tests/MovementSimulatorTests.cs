using AutoMoq;
using FluentAssertions;
using ToyRobotConsole;
using ToyRobotConsole.Implementation;
using ToyRobotConsole.Robots;

namespace TryRobotConsoleTest.Tests
{
    [Trait("Category", "MovementSimulatorTests")]
    public class MovementSimulatorTests
    {
        #region Constructor
        [Fact]
        public void Given_CurrentClass_When_CallingConstructor_Then_NoExceptionIsThrown()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var table = autoMoq.Create<Table>();
            autoMoq.SetInstance(table);
            // Act
            Action action = () => autoMoq.Create<MovementSimulator>();

            // Assert
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Given_CurrentClass_When_CallingConstructor_Then_RobotMovementsIsSetToExpectedValue()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var table = autoMoq.Create<Table>();
            autoMoq.SetInstance(table);

            // Act
            var movementSimulator = autoMoq.Create<MovementSimulator>();

            // Assert
            movementSimulator.Should().NotBeNull();
            movementSimulator.Robot.Should().NotBeNull();
        }
        #endregion

        #region PlaceMethod
        [Theory]
        [InlineData(RobotMovementDirection.East, 0, 0)]
        [InlineData(RobotMovementDirection.West, 0, 0)]
        [InlineData(RobotMovementDirection.North, 0, 0)]
        [InlineData(RobotMovementDirection.South, 0, 0)]
        public void Given_CurrentClass_When_CallingPlaceMethod_WithValidDirectionAndPlaces_Then_RobotMovementsIsSetToExpectedValue(RobotMovementDirection movement, int east, int north)
        {
            // Arrange
            Table tableTop = new Table();
            tableTop.Width = 4;
            tableTop.Length = 4;
            RobotMovements robotMovements = new RobotMovements();
            MovementSimulator instance = new MovementSimulator(tableTop, robotMovements);
            instance.Place(0, 0, RobotMovementDirection.North);

            // Act
            RobotMovements expectedToy = new RobotMovements
            {
                Direction = movement,
                East = east,
                North = north
            };

            // Assert
            expectedToy.East.Equals(instance.Robot.East);
            expectedToy.North.Equals(instance.Robot.North);
            expectedToy.Direction.Equals(instance.Robot.Direction);
        }
        #endregion

        #region RobotMovesMethod
        [Theory]
        [InlineData(MoveDirection.Move)]
        [InlineData(MoveDirection.Right)]
        [InlineData(MoveDirection.Left)]
        public void Given_CurrentClass_When_CallingRobotMovesMethod_WithValidMoveDirectionAndPlaces_Then_RobotMovementsIsSetToExpectedValue(MoveDirection movement)
        {
            // Arrange
            Table tableTop = new Table();
            tableTop.Width = 4;
            tableTop.Length = 4;
            RobotMovements robotMovements = new RobotMovements();
            MovementSimulator instance = new MovementSimulator(tableTop, robotMovements);
            instance.Place(0, 0, RobotMovementDirection.North);

            // Act
            instance.RobotMoves(movement);

            // Assert
            instance.Should().NotBeNull();
        }
        #endregion

        #region ReportMethod
        [Theory]
        [InlineData(RobotMovementDirection.East, 0, 0)]
        [InlineData(RobotMovementDirection.West, 1, 1)]
        [InlineData(RobotMovementDirection.North, 2,2)]
        [InlineData(RobotMovementDirection.South,3, 3)]
        public void Given_CurrentClass_When_CallingReportMethod_WithValidMoveDirectionAndPlaces_Then_ReportsFinalData(RobotMovementDirection movement, int east, int north)
        {
            // Arrange
            Table tableTop = new Table();
            tableTop.Width = 4;
            tableTop.Length = 4;
            RobotMovements robotMovements = new RobotMovements();
            MovementSimulator instance = new MovementSimulator(tableTop, robotMovements);
            instance.Place(east, north, movement);

            // Act
            instance.Report();

            // Assert
            instance.Should().NotBeNull();
        }
        #endregion
    }
}
