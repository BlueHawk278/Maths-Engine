using VolumeUnit = MathsEngine.Core.Measurement.Units.Volume.VolumeUnit;
using VolumeMeasurement = MathsEngine.Core.Measurement.Units.Volume.Volume;
using LengthUnit = MathsEngine.Core.Measurement.Units.Length.LengthUnit;
using LengthMeasurement = MathsEngine.Core.Measurement.Units.Length.Length;
using AreaUnit = MathsEngine.Core.Measurement.Units.Area.AreaUnit;
using AreaMeasurement = MathsEngine.Core.Measurement.Units.Area.Area;

namespace MathsEngine.Core.Measurement.Units;

public class UnitConverter
{
    public static double AreaConvert(double value, AreaUnit from, AreaUnit to)
    {
        double baseValue = value * from.ScaleFactor;
        return baseValue / to.ScaleFactor;
    }
    public static AreaMeasurement AreaConvert(AreaMeasurement area, AreaUnit to)
    {
        return area.ConvertTo(to);
    }

    public static double LengthConvert(double value, LengthUnit from, LengthUnit to)
    {
        double baseValue = value * from.ScaleFactor;
        return baseValue / to.ScaleFactor;
    }
    public static LengthMeasurement LengthConvert(LengthMeasurement length, LengthUnit to)
    {
        return length.ConvertTo(to);
    }

    public static double VolumeConvert(double value, VolumeUnit from, VolumeUnit to)
    {
        double baseValue = value * from.ScaleFactor;
        return baseValue / to.ScaleFactor;
    }
    public static VolumeMeasurement VolumeConvert(VolumeMeasurement volume, VolumeUnit to)
    {
        return volume.ConvertTo(to);
    }
}