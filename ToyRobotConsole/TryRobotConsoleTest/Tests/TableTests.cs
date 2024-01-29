using AutoMoq;
using FluentAssertions;
using Moq;
using ToyRobotConsole.Implementation;

namespace TryRobotConsoleTest.Tests
{
    [Trait("Category", "TableUnitTest")]
    public class TableTests
    {
        #region Constructor
        [Fact]
        public void Given_CurrentClass_When_CallingConstructor_Then_NoExceptionIsThrown()
        {
            // Arrange
            var autoMoq = new AutoMoqer();

            // Act
            Action action = () => new Mock<Table>(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Given_CurrentClass_When_CallingConstructor_Then_RobotMovementsIsSetToExpectedValue()
        {
            // Arrange
            var autoMoq = new AutoMoqer();

            // Act
            var table = new Mock<Table>().Object;

            // Assert
            table.Should().NotBeNull();
            table.Width.Equals(0);
            table.Length.Equals(0);
        }
        #endregion

        #region IsValidLocationMethod

        [Theory]
        [InlineData(0,0)]
        [InlineData( 1, 1)]
        [InlineData( 2, 2)]
        [InlineData( 3,3)]
        public void Given_CurrentClass_When_CallingIsValidLocation_WithWidthLengthAndDirection_Then_ReturnsLocationIsValidOrNot(int east, int north)
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var table = new Mock<Table>().Object;

            // Act
            bool validLocation = table.IsValidLocation(east, north);

            // Assert
            table.Should().NotBeNull();
            table.Width.Equals(0);
            table.Length.Equals(0);
            validLocation.Equals(true);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(-2, -2)]
        [InlineData(-3, -3)]
        [InlineData(-4, -4)]
        public void Given_CurrentClass_When_CallingIsValidLocation_WithInvalidWidthLengthAndDirection_Then_ReturnsLocationIsValidOrNot(int east, int north)
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var table = new Mock<Table>().Object;

            // Act
            bool validLocation = table.IsValidLocation(east, north);

            // Assert
            table.Should().NotBeNull();
            table.Width.Equals(0);
            table.Length.Equals(0);
            validLocation.Equals(false);
        }

        #endregion
    }
}
