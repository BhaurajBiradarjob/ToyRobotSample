using AutoMoq;
using FluentAssertions;
using ToyRobotConsole;
using ToyRobotConsole.Implementation;
using ToyRobotConsole.Interfaces;
using ToyRobotConsole.Robots;
using Xunit;

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
        [InlineData(RobotMovementDirection.East, 1, 1)]
        [InlineData(RobotMovementDirection.West, 1, 1)]
        [InlineData(RobotMovementDirection.North, 1, 1)]
        [InlineData(RobotMovementDirection.South, 1, 1)]
        public void Given_CurrentClass_When_CallingPlaceMethod_WithValidDirectionAndPlaces_Then_RobotMovementsIsSetToExpectedValue(RobotMovementDirection movement, int east, int north)
        {
            // Arrange
            Table tableTop = new Table();
            tableTop.Width = 4;
            tableTop.Length = 4;
            RobotMovements robotMovements = new RobotMovements();
            MovementSimulator instance = new MovementSimulator(tableTop, robotMovements);

            // Act
            instance.Place(east, north, RobotMovementDirection.North);
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
            instance.Robot.Should().NotBeNull();
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
            string report = instance.Report();

            // Assert
            instance.Should().NotBeNull();
            instance.Robot.Should().NotBeNull();
            instance.Robot.East.Should().Be(east);
            instance.Robot.North.Should().Be(north);
        }
        #endregion

        #region RobotMovementsVerification
        [Fact]
        public void Given_CurrentClass_When_CallingReportMethod_WithRoobotMovesLeftRight_Then_ShouldReportsFinalData()
        {
            // Arrange
            Table tableTop = new Table();
            tableTop.Width = 5;
            tableTop.Length = 5;
            RobotMovements robotMovements = new RobotMovements();
            MovementSimulator instance = new MovementSimulator(tableTop, robotMovements);

            // Act

            //Input
            //PLACE 1,2,EAST
            //MOVE
            //MOVE
            //LEFT
            //MOVE
            //REPORT
            instance.Place(1, 2, RobotMovementDirection.East); //PLACE 1,2,EAST
            instance.RobotMoves(MoveDirection.Move);//MOVE
            instance.RobotMoves(MoveDirection.Move);//MOVE
            instance.RobotMoves(MoveDirection.Left);//LEFT
            instance.RobotMoves(MoveDirection.Move);//MOVE
            string report = instance.Report();

            // Assert
            instance.Should().NotBeNull();
            instance.Robot.Should().NotBeNull();
            report.Should().NotBeNullOrEmpty();
            ////Output: 3,3, NORTH
            string[] values = report.Split(',');
            values.Length.Should().Be(3);
            values[0].Equals(3);
            values[1].Equals(3);
            RobotMovementDirection direction;
            Enum.TryParse(values[2], true, out direction);
            direction.Equals(RobotMovementDirection.North);
        }

        [Fact]
        public void Given_CurrentClass_When_CallingReportMethod_WithRoobotSecondSpecifiedInput_Then_ShouldReportsFinalData()
        {
            // Arrange
            Table tableTop = new Table();
            tableTop.Width = 5;
            tableTop.Length = 5;
            RobotMovements robotMovements = new RobotMovements();
            MovementSimulator instance = new MovementSimulator(tableTop, robotMovements);

            // Act

            //Input
            //PLACE 0,0,NORTH
            //MOVE
            //REPORT
            //Output: 0,1, NORTH
            instance.Place(0, 0, RobotMovementDirection.North); //PLACE 0,0,NORTH
            instance.RobotMoves(MoveDirection.Move);//MOVE
            string report = instance.Report();

            // Assert
            instance.Should().NotBeNull();
            instance.Robot.Should().NotBeNull();
            report.Should().NotBeNullOrEmpty();
            string[] values = report.Split(',');
            //Output: 0,1, NORTH
            values.Length.Should().Be(3);
            values[0].Equals(0);
            values[1].Equals(1);
            RobotMovementDirection direction;
            Enum.TryParse(values[2], true, out direction);
            direction.Equals(RobotMovementDirection.North);
        }

        [Fact]
        public void Given_CurrentClass_When_CallingReportMethod_WithRoobotThirdSpecifiedInput_Then_ShouldReportsFinalData()
        {
            // Arrange
            Table tableTop = new Table();
            tableTop.Width = 5;
            tableTop.Length = 5;
            RobotMovements robotMovements = new RobotMovements();
            MovementSimulator instance = new MovementSimulator(tableTop, robotMovements);

            // Act

            //Input
            //PLACE 0,0,NORTH
            //LEFT
            //REPORT
            //Output: 0,0, WEST
            instance.Place(0, 0, RobotMovementDirection.North); //PLACE 0,0,NORTH
            instance.RobotMoves(MoveDirection.Left);//LEFT
            string report = instance.Report();

            // Assert
            instance.Should().NotBeNull();
            instance.Robot.Should().NotBeNull();
            report.Should().NotBeNullOrEmpty();
            string[] values = report.Split(',');
            //Output: 0,0, WEST
            values.Length.Should().Be(3);
            values[0].Equals(0);
            values[1].Equals(0);
            RobotMovementDirection direction;
            Enum.TryParse(values[2], true, out direction);
            direction.Equals(RobotMovementDirection.West);
        }
        #endregion
    }
}
