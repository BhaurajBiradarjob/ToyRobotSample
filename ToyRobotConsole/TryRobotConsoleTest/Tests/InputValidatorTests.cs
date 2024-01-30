using AutoMoq;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotConsole;
using ToyRobotConsole.Implementation;

namespace TryRobotConsoleTest.Tests
{
    [Trait("Category", "InputValidatorTests")]
    public class InputValidatorTests
    {
        #region Constructor
        [Fact]
        public void Given_CurrentClass_When_CallingConstructor_Then_NoExceptionIsThrown()
        {
            // Arrange
            var autoMoq = new AutoMoqer();

            // Act
            Action action = () => autoMoq.Create<ValidateInputs>();

            // Assert
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Given_CurrentClass_When_CallingConstructor_Then_RobotMovementsIsSetToExpectedValue()
        {
            // Arrange
            var autoMoq = new AutoMoqer();

            // Act
            var validateInputs = autoMoq.Create<ValidateInputs>();

            // Assert
            validateInputs.Should().NotBeNull();
        }
        #endregion

        #region ValidateInputMethod
        [Theory]
        [InlineData("PLACE 1,2,EAST", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT")]
        [InlineData("PLACE 0,0,NORTH","MOVE","REPORT")]
        [InlineData("PLACE 0,0,NORTH","LEFT","REPORT")]
        [InlineData("PLACE 0,1,NORTH","LEFT","REPORT")]
        public void Given_CurrentClass_When_CallingValidateInput_WithValidData_Then_ValueShouldReturnTrue(params string[] command)
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var validateInputs = autoMoq.Create<ValidateInputs>();
            // Act
            bool result = validateInputs.ValidateInput(command);

            // Assert
            validateInputs.Should().NotBeNull();
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("PLACE 1,2,EAST","gggg", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT")]
        [InlineData("PLACE 0,0,NORTH"," ", "MOVE", "REPORT")]
        [InlineData("left", "LEFT", "REPORT")]
        [InlineData("PLACE 0,1,NORTH"," ", "LEFT", "REPORT")]
        public void Given_CurrentClass_When_CallingValidateInput_WithInValidData_Then_ValueShouldReturnFalse(params string[] command)
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var validateInputs = autoMoq.Create<ValidateInputs>();
            // Act
            bool result = validateInputs.ValidateInput(command);

            // Assert
            validateInputs.Should().NotBeNull();
            result.Should().BeFalse();
        }
        #endregion

        #region FormatInputMethod
        [Theory]
        [InlineData("PLACE 1,2,EAST", "move", "MOVE", "LEFT", "MOVE", "REPORT")]
        [InlineData("PLACE 0,0,NORTH", "MOVE ", "REPORT")]
        [InlineData("PLACE 0,0,NORTH","", "LEFT", "REPORT")]
        [InlineData("PLACE 0,1,NORTH"," ", "LEFT", "REPORT")]
        public void Given_CurrentClass_When_CallingFormatInput_WithValidData_Then_ShouldReturnProperCommand(params string[] command)
        {
            // Arrange
            var autoMoq = new AutoMoqer();
            var validateInputs = autoMoq.Create<ValidateInputs>();
            // Act
            string[] result = validateInputs.FormatInput(command);
            bool Isvalid = validateInputs.ValidateInput(result);

            // Assert
            validateInputs.Should().NotBeNull();
            result.Should().NotBeNullOrEmpty();
            Isvalid.Should().BeTrue();
        }
        #endregion
    }
}
