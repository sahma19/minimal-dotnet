using System.Collections;
using System.Globalization;

IEnumerable<RegionInfo> AllRegionInfo = 
CultureInfo.GetCultures(CultureTypes.SpecificCultures)
    .Where(culture => culture.LCID != 0x7F)
    .Select(culture => new RegionInfo(culture.Name))
    .ToList();

Console.WriteLine(string.Join(Environment.NewLine,AllRegionInfo));
