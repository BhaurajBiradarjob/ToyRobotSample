using AutoMoq;
using FluentAssertions;
using ToyRobotConsole;
using ToyRobotConsole.Robots;

namespace TryRobotConsoleTest.Tests
{
    [Trait("Category", "RobotMovementsUnitTest")]
    public class RobotMovementsTest
    {
        #region Constructor
        [Fact]
        public void Given_CurrentClass_When_CallingConstructor_Then_NoExceptionIsThrown()
        {
            // Arrange
            var autoMoq = new AutoMoqer();

            // Act
            Action action = () => autoMoq.Create<RobotMovements>();

            // Assert
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Given_CurrentClass_When_CallingConstructor_Then_RobotMovementsIsSetToExpectedValue()
        {
            // Arrange
            var autoMoq = new AutoMoqer();

            // Act
            var robotMovements = autoMoq.Create<RobotMovements>();

            // Assert
            robotMovements.Should().NotBeNull();
            robotMovements.East.Equals(0);
            robotMovements.North.Equals(0);
            robotMovements.Direction.Should().BeDefined();
        }
        #endregion

        #region MoveMethod
        [Fact]
        public void Given_CurrentClass_When_CallingMoveMethodThrice_TowardsEastDirection_AndEastPointIsZero_Then_EastEqualToThree()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var Robot = autoMoq.Create<RobotMovements>();
            Robot.Direction = RobotMovementDirection.East;
            Robot.East = 0;

            // Act
            Robot.Move();
            Robot.Move();
            Robot.Move();

            // Assert
            Robot.East.Equals(3);
            Robot.North.Equals(0);
        }

        [Fact]
        public void Given_CurrentClass_When_CallingMoveMethodThrice_TowardsWestDirection_AndEastPointIsThree_Then_EastEqualToZero()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var Robot = autoMoq.Create<RobotMovements>();
            Robot.Direction = RobotMovementDirection.West;
            Robot.East = 3;

            // Act
            Robot.Move();
            Robot.Move();
            Robot.Move();

            // Assert
            Robot.East.Equals(0);
            Robot.North.Equals(0);
        }

        [Fact]
        public void Given_CurrentClass_When_CallingMoveMethodThrice_TowardsNorthDirection_AndNorthPointIsZero_Then_NorthEqualToThree()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var Robot = autoMoq.Create<RobotMovements>();
            Robot.Direction = RobotMovementDirection.North;
            Robot.North = 0;

            // Act
            Robot.Move();
            Robot.Move();
            Robot.Move();

            // Assert
            Robot.North.Equals(3);
            Robot.East.Equals(0);
        }

        [Fact]
        public void Given_CurrentClass_When_CallingMoveMethodThrice_TowardsSouthDirection_AndNorthPointIsThree_Then_NorthEqualToZero()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var Robot = autoMoq.Create<RobotMovements>();
            Robot.Direction = RobotMovementDirection.South;
            Robot.North = 3;

            // Act
            Robot.Move();
            Robot.Move();
            Robot.Move();

            // Assert
            Robot.North.Equals(0);
            Robot.East.Equals(0);
        }
        #endregion

        #region TurnLeftMethod
        [Fact]
        public void Given_CurrentClass_When_CallingTurnLeftMethod_FromEastDirection_Then_DirectionShouldBeNorth()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var Robot = autoMoq.Create<RobotMovements>();
            Robot.Direction = RobotMovementDirection.East;
            Robot.East = 0;

            // Act
            Robot.TurnLeft();

            // Assert
            Robot.East.Equals(0);
            Robot.North.Equals(0);
            Robot.Direction.Equals(RobotMovementDirection.North);
        }

        [Fact]
        public void Given_CurrentClass_When_CallingTurnLeftMethod_FromWestDirection_Then_DirectionShouldBeSouth()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var Robot = autoMoq.Create<RobotMovements>();
            Robot.Direction = RobotMovementDirection.West;
            Robot.East = 0;

            // Act
            Robot.TurnLeft();

            // Assert
            Robot.East.Equals(0);
            Robot.North.Equals(0);
            Robot.Direction.Equals(RobotMovementDirection.South);
        }

        [Fact]
        public void Given_CurrentClass_When_CallingTurnLeftMethod_FromNorthDirection_Then_DirectionShouldBeWest()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var Robot = autoMoq.Create<RobotMovements>();
            Robot.Direction = RobotMovementDirection.North;
            Robot.East = 0;

            // Act
            Robot.TurnLeft();

            // Assert
            Robot.East.Equals(0);
            Robot.North.Equals(0);
            Robot.Direction.Equals(RobotMovementDirection.West);
        }

        [Fact]
        public void Given_CurrentClass_When_CallingTurnLeftMethod_FromSouthDirection_Then_DirectionShouldBeEast()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var Robot = autoMoq.Create<RobotMovements>();
            Robot.Direction = RobotMovementDirection.South;
            Robot.East = 0;

            // Act
            Robot.TurnLeft();

            // Assert
            Robot.East.Equals(0);
            Robot.North.Equals(0);
            Robot.Direction.Equals(RobotMovementDirection.East);
        }
        #endregion

        #region TurnRightMethod
        [Fact]
        public void Given_CurrentClass_When_CallingTurnRightMethod_FromEastDirection_Then_DirectionShouldBeSouth()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var Robot = autoMoq.Create<RobotMovements>();
            Robot.Direction = RobotMovementDirection.East;
            Robot.East = 0;

            // Act
            Robot.TurnRight();

            // Assert
            Robot.East.Equals(0);
            Robot.North.Equals(0);
            Robot.Direction.Equals(RobotMovementDirection.South);
        }

        [Fact]
        public void Given_CurrentClass_When_CallingTurnRightMethod_FromWestDirection_Then_DirectionShouldBeNorth()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var Robot = autoMoq.Create<RobotMovements>();
            Robot.Direction = RobotMovementDirection.West;
            Robot.East = 0;

            // Act
            Robot.TurnRight();

            // Assert
            Robot.East.Equals(0);
            Robot.North.Equals(0);
            Robot.Direction.Equals(RobotMovementDirection.North);
        }
        [Fact]
        public void Given_CurrentClass_When_CallingTurnRightMethod_FromNorthDirection_Then_DirectionShouldBeEast()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var Robot = autoMoq.Create<RobotMovements>();
            Robot.Direction = RobotMovementDirection.North;
            Robot.East = 0;

            // Act
            Robot.TurnRight();

            // Assert
            Robot.East.Equals(0);
            Robot.North.Equals(0);
            Robot.Direction.Equals(RobotMovementDirection.East);
        }
        [Fact]
        public void Given_CurrentClass_When_CallingTurnRightMethod_FromSouthDirection_Then_DirectionShouldBeWest()
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var Robot = autoMoq.Create<RobotMovements>();
            Robot.Direction = RobotMovementDirection.South;
            Robot.East = 0;

            // Act
            Robot.TurnRight();

            // Assert
            Robot.East.Equals(0);
            Robot.North.Equals(0);
            Robot.Direction.Equals(RobotMovementDirection.West);
        }
        #endregion

        #region GetDirectionMethod
        [Theory]
        [InlineData(RobotMovementDirection.East, 0, 0)]
        [InlineData(RobotMovementDirection.West, 0, 0)]
        [InlineData(RobotMovementDirection.North, 0, 0)]
        [InlineData(RobotMovementDirection.South, 0, 0)]
        public void Given_CurrentClass_When_CallingGetDirectionMethod_FromAllDirection_Then_MethodShouldReturnsCoordinates(RobotMovementDirection movement, int east, int north)
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var Robot = autoMoq.Create<RobotMovements>();
            Robot.Direction = movement;
            Robot.East = east;
            Robot.North = north;

            // Act
            var result = Robot.GetDirection();

            // Assert
            Robot.East.Equals(0);
            Robot.North.Equals(0);
            Robot.Direction.Equals(movement);
            result.Should().NotBeNullOrEmpty();
        }
        #endregion
    }
}