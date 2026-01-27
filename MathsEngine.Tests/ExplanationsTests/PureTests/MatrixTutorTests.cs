using Xunit;
using MathsEngine.Modules.Explanations;
using MathsEngine.Modules.Explanations.Pure;
using MathsEngine.Modules.Pure.Matrices;

namespace MathsEngine.Tests.ExplanationsTests.PureTests;

public class MatrixTutorTests
{
    [Fact]
    public void AddMatrixWithSteps_ReturnsCorrectValue()
    {
        // Arrange
        var matrix1 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
        var matrix2 = new MatrixBase(new double[,] { { 5, 6 }, { 7, 8 } });

        // Act
        var result = MatrixTutor.AddMatrixWithSteps(matrix1, matrix2);

        // Assert
        Assert.True(result.IsMatrix);
        Assert.Equal(6, result.MatrixValue[0, 0], 2);
        Assert.Equal(8, result.MatrixValue[0, 1], 2);
        Assert.Equal(10, result.MatrixValue[1, 0], 2);
        Assert.Equal(12, result.MatrixValue[1, 1], 2);
    }

    [Fact]
    public void AddMatrixWithSteps_GeneratesSteps()
    {
        // Arrange
        var matrix1 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
        var matrix2 = new MatrixBase(new double[,] { { 5, 6 }, { 7, 8 } });

        // Act
        var result = MatrixTutor.AddMatrixWithSteps(matrix1, matrix2);

        // Assert
        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("addition", stepsText);
        Assert.Contains("2×2", stepsText);
    }

    [Fact]
    public void SubtractMatrixWithSteps_ReturnsCorrectValue()
    {
        // Arrange
        var matrix1 = new MatrixBase(new double[,] { { 5, 6 }, { 7, 8 } });
        var matrix2 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });

        // Act
        var result = MatrixTutor.SubtractMatrixWithSteps(matrix1, matrix2);

        // Assert
        Assert.True(result.IsMatrix);
        Assert.Equal(4, result.MatrixValue[0, 0], 2);
        Assert.Equal(4, result.MatrixValue[0, 1], 2);
        Assert.Equal(4, result.MatrixValue[1, 0], 2);
        Assert.Equal(4, result.MatrixValue[1, 1], 2);
    }

    [Fact]
    public void SubtractMatrixWithSteps_GeneratesSteps()
    {
        // Arrange
        var matrix1 = new MatrixBase(new double[,] { { 5, 6 }, { 7, 8 } });
        var matrix2 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });

        // Act
        var result = MatrixTutor.SubtractMatrixWithSteps(matrix1, matrix2);

        // Assert
        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("subtraction", stepsText);
    }

    [Fact]
    public void ScalarMultiplicationWithSteps_ReturnsCorrectValue()
    {
        // Arrange
        var matrix = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
        double scalar = 2;

        // Act
        var result = MatrixTutor.ScalarMultiplicationWithSteps(matrix, scalar);

        // Assert
        Assert.True(result.IsMatrix);
        Assert.Equal(2, result.MatrixValue[0, 0], 2);
        Assert.Equal(4, result.MatrixValue[0, 1], 2);
        Assert.Equal(6, result.MatrixValue[1, 0], 2);
        Assert.Equal(8, result.MatrixValue[1, 1], 2);
    }

    [Fact]
    public void ScalarMultiplicationWithSteps_GeneratesSteps()
    {
        // Arrange
        var matrix = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });

        // Act
        var result = MatrixTutor.ScalarMultiplicationWithSteps(matrix, 2);

        // Assert
        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("scalar", stepsText);
        Assert.Contains("2.00", stepsText);
    }

    [Fact]
    public void ScalarDivisionWithSteps_ReturnsCorrectValue()
    {
        // Arrange
        var matrix = new MatrixBase(new double[,] { { 2, 4 }, { 6, 8 } });
        double scalar = 2;

        // Act
        var result = MatrixTutor.ScalarDivisionWithSteps(matrix, scalar);

        // Assert
        Assert.True(result.IsMatrix);
        Assert.Equal(1, result.MatrixValue[0, 0], 2);
        Assert.Equal(2, result.MatrixValue[0, 1], 2);
        Assert.Equal(3, result.MatrixValue[1, 0], 2);
        Assert.Equal(4, result.MatrixValue[1, 1], 2);
    }

    [Fact]
    public void MatrixMultiplicationWithSteps_ReturnsCorrectValue()
    {
        // Arrange
        var matrix1 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
        var matrix2 = new MatrixBase(new double[,] { { 2, 0 }, { 1, 2 } });

        // Act
        var result = MatrixTutor.MatrixMultiplicationWithSteps(matrix1, matrix2);

        // Assert
        Assert.True(result.IsMatrix);
        Assert.Equal(4, result.MatrixValue[0, 0], 2);
        Assert.Equal(4, result.MatrixValue[0, 1], 2);
        Assert.Equal(10, result.MatrixValue[1, 0], 2);
        Assert.Equal(8, result.MatrixValue[1, 1], 2);
    }

    [Fact]
    public void MatrixMultiplicationWithSteps_GeneratesSteps()
    {
        // Arrange
        var matrix1 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
        var matrix2 = new MatrixBase(new double[,] { { 2, 0 }, { 1, 2 } });

        // Act
        var result = MatrixTutor.MatrixMultiplicationWithSteps(matrix1, matrix2);

        // Assert
        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("multiplication", stepsText);
        Assert.Contains("C[", stepsText);
    }

    [Fact]
    public void CalculateDeterminantWithSteps_ReturnsCorrectValue()
    {
        // Arrange
        var matrix = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });

        // Act
        var result = MatrixTutor.CalculateDeterminantWithSteps(matrix);

        // Assert
        Assert.False(result.IsMatrix);
        Assert.Equal(-2, result.Value, 2);
    }

    [Fact]
    public void CalculateDeterminantWithSteps_GeneratesSteps()
    {
        // Arrange
        var matrix = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });

        // Act
        var result = MatrixTutor.CalculateDeterminantWithSteps(matrix);

        // Assert
        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("determinant", stepsText);
        Assert.Contains("ad - bc", stepsText);
    }
}
