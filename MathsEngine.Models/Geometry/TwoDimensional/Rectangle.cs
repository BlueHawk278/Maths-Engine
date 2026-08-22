using MathsEngine.Core.Explanations.Enums;
using MathsEngine.Core.Explanations.Inputs;
using MathsEngine.Core.Explanations.Results;
using MathsEngine.Core.Explanations.Steps;
using MathsEngine.Core.Geometry.Abstractions;
using MathsEngine.Core.Measurement.Units.Area;
using MathsEngine.Core.Measurement.Units.Length;

namespace MathsEngine.Core.Geometry.TwoDimensional;

public class Rectangle : Shape2D
{
    public override string Name => "Rectangle";
    public override string DisplayName => "Rectangle";
    public override string Description => "A rectangle is a two-dimensional shape with four sides and four right angles. " +
                                          "It has opposite sides that are equal in length, and its area can be calculated by multiplying its length by its width.";
    
    public Length Length { get; }
    public Length Width { get; }

    public Rectangle(Length length, Length width)
    {
        Length = length;
        Width = width;

        if (!Validate())
            throw new ArgumentException("Invalid dimensions for a rectangle. Length and Width must be positive values.");
    }

    public override CalculationResult<Area> CalculateArea()
    {
        Area area = new Area(Length.InMetres * Width.InMetres, AreaUnit.SquareMeter);
        return new CalculationResult<Area>(
            CalculationType.Area,
            area,
            area.Unit.ToString(),
            new List<CalculationInput>
            {
                new CalculationInput("Length", Length, LengthUnit.Meter.ToString()),
                new CalculationInput("Width", Width, LengthUnit.Meter.ToString())
            }, 
            new List<CalculationStep>());
    }

    public override CalculationResult<Length> CalculatePerimeter()
    {
        Length perimeter = Length * 2 + Width * 2;
        return new CalculationResult<Length>(
            CalculationType.Perimeter,
            perimeter,
            perimeter.Unit.ToString(),
            new List<CalculationInput>
            {
                new CalculationInput("Length", Length, Length.Unit.ToString()),
                new CalculationInput("Width", Width, Width.Unit.ToString())
            }, 
            new List<CalculationStep>());
    }

    public override bool Validate()
    {
        if (Length == null || Width == null || Length.Value <= 0 || Width.Value <= 0)
        {
            return false;
        }
        return true;
    }
}