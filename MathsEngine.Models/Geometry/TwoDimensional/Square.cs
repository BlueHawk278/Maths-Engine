using MathsEngine.Core.Explanations.Enums;
using MathsEngine.Core.Explanations.Inputs;
using MathsEngine.Core.Explanations.Results;
using MathsEngine.Core.Explanations.Steps;
using MathsEngine.Core.Geometry.Abstractions;
using MathsEngine.Core.Measurement.Units.Geometry.Area;
using MathsEngine.Core.Measurement.Units.Geometry.Length;

namespace MathsEngine.Core.Geometry.TwoDimensional;

public class Square : Shape2D
{
    public override string Name => "Square";
    public override string DisplayName => string.Empty;
    public override string Description => "A square is a two-dimensional shape with four equal sides and four right angles. " +
                                          "It is a special case of a rectangle where all sides are of equal length.";
    
    public Length SideLength { get; }

    public Square(Length sideLength)
    {
        SideLength = sideLength;
        
        if (!Validate())
        {
            throw new ArgumentException("Invalid side length for a square. Side length must be greater than zero.");
        }
    }

    public override CalculationResult<Area> CalculateArea()
    {
        Area area = new Area(SideLength.InMetres * SideLength.InMetres, AreaUnit.SquareMeter);
        return new CalculationResult<Area>(
            CalculationType.Area,
            area,
            area.Unit.ToString(),
            new List<CalculationInput>
            {
                new CalculationInput("Side Length", SideLength, LengthUnit.Meter.ToString())
            }, 
            new List<CalculationStep>());
    }

    public override CalculationResult<Length> CalculatePerimeter()
    {
        Length perimeter = SideLength * 4;
        return new CalculationResult<Length>(
            CalculationType.Perimeter,
            perimeter,
            perimeter.Unit.ToString(),
            new List<CalculationInput>
            {
                new CalculationInput("Side Length", SideLength, SideLength.Unit.ToString())
            }, 
            new List<CalculationStep>());
    }

    public override bool Validate()
    {
        if (SideLength == null || SideLength.Value <= 0)
            return false;
        return true;
    }
}