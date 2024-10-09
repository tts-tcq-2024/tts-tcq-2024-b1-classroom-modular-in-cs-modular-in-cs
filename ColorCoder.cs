using System;

namespace TelCo.ColorCoder
{
    public static class ColorCoder
    {
        public static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            int minorSize = ColorMapping.MinorColors.Length;
            if (pairNumber < 1 || pairNumber > minorSize * ColorMapping.MajorColors.Length)
                throw new ArgumentOutOfRangeException($"PairNumber:{pairNumber} is outside the allowed range");

            int majorIndex = (pairNumber - 1) / minorSize;
            int minorIndex = (pairNumber - 1) % minorSize;
            return new ColorPair { MajorColor = ColorMapping.MajorColors[majorIndex], MinorColor = ColorMapping.MinorColors[minorIndex] };
        }

        public static int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = ColorMapping.GetColorIndex(pair.MajorColor, ColorMapping.MajorColors);
            int minorIndex = ColorMapping.GetColorIndex(pair.MinorColor, ColorMapping.MinorColors);
            if (majorIndex == -1 || minorIndex == -1)
                throw new ArgumentException($"Unknown Colors: {pair}");

            return (majorIndex * ColorMapping.MinorColors.Length) + (minorIndex + 1);
        }
    }
}
