namespace ToolsQuality
{
    public static class ToolsQualityAPI
	{
		internal static HashSet<string> CustomImproviseds;
		internal static HashSet<string> CustomManufactureds;
		internal static HashSet<string> CustomExtraordinarys;
		internal static HashSet<string> CustomHacksaws;
		
		static ToolsQualityAPI ()
		{
			CustomImproviseds = new HashSet<string>();
			CustomManufactureds = new HashSet<string>();
			CustomExtraordinarys = new HashSet<string>();
			CustomHacksaws = new HashSet<string>();
		}
	
		public static void AddImproviseds (string[] gearItemNames)
		{
			for (int i = 0; i < gearItemNames.Length; i++)
				CustomImproviseds.Add(gearItemNames[i]);
		}

		public static void AddManufactureds (string[] gearItemNames)
		{
			for (int i = 0; i < gearItemNames.Length; i++)
				CustomManufactureds.Add(gearItemNames[i]);
		}

		public static void AddExtraordinarys (string[] gearItemNames)
		{
			for (int i = 0; i < gearItemNames.Length; i++)
				CustomExtraordinarys.Add(gearItemNames[i]);
		}

		public static void AddHacksaws (string[] gearItemNames)
		{
			for (int i = 0; i < gearItemNames.Length; i++)
				CustomHacksaws.Add(gearItemNames[i]);
		}
	}
}