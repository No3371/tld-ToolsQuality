using MelonLoader;
using UnityEngine;
using Il2Cpp;


namespace ToolsQuality
{
    public static class BuildInfo
	{
		internal const string ModName = "ToolsQuality";
		internal const string ModAuthor = "ttr";
		internal const string ModVersion = "1.2.1";
	}

    internal class ToolsQuality : MelonMod
	{

        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
            LoggerInstance.Msg($"[{BuildInfo.ModName}] Version {BuildInfo.ModVersion} loaded!");
        }

        public static float ToolsQualityMod(GearItem tool)
        {
			if (!Settings.options.ToolsQualityEnabled) { return 1f; }
			string tname = tool.name;
			float tcond = tool.GetNormalizedCondition() * 100;

			if ((tname == "GEAR_KnifeImprovised") || (tname == "GEAR_KnifeScrapMetal") || (tname == "GEAR_HatchetImprovised") || ToolsQualityAPI.CustomImproviseds.Contains(tname))
			{
				if (tcond > Settings.options.ImpHighQpct) { return 1f; }
				else if (tcond <= Settings.options.ImpLowQpct) { return Settings.options.ImpLowQTime; }
				else {
					float TimeDiff = Settings.options.ImpLowQTime - 1f;
					float QualityRatio = 1f - Mathf.InverseLerp(Settings.options.ImpLowQpct, Settings.options.ImpHighQpct, tcond);
					return 1f + (TimeDiff * QualityRatio);
				}
			}
			else if ((tname == "GEAR_Knife") || (tname == "GEAR_Hatchet") || ToolsQualityAPI.CustomManufactureds.Contains(tname))
			{
				if (tcond > Settings.options.ManBoostQpct) {

					float TimeDiff = 1f - Settings.options.ManBoostQTime;
					float QualitryRatio = Mathf.InverseLerp(Settings.options.ManHighQpct, Settings.options.ManBoostQpct, tcond);
					return 1f - (TimeDiff * QualitryRatio);
				}
				else if (tcond > Settings.options.ManHighQpct) { return 1f; }
				else if (tcond <= Settings.options.ManLowQpct) { return Settings.options.ManLowQTime; }
				else
				{
					float TimeDiff = Settings.options.ManLowQTime - 1f;
					float QualityRatio = 1f - Mathf.InverseLerp(Settings.options.ManLowQpct, Settings.options.ManHighQpct, tcond);
					return 1f + (TimeDiff * QualityRatio);
				}
			}
			else if (ToolsQualityAPI.CustomExtraordinarys.Contains(tname))
			{
				if (tcond > Settings.options.ExtBoostQpct) {

					float TimeDiff = 1f - Settings.options.ExtBoostQTime;
					float QualitryRatio = Mathf.InverseLerp(Settings.options.ExtHighQpct, Settings.options.ExtBoostQpct, tcond);
					return 1f - (TimeDiff * QualitryRatio);
				}
				else if (tcond > Settings.options.ExtHighQpct) { return 1f; }
				else if (tcond <= Settings.options.ExtLowQpct) { return Settings.options.ExtLowQTime; }
				else
				{
					float TimeDiff = Settings.options.ExtLowQTime - 1f;
					float QualityRatio = 1f - Mathf.InverseLerp(Settings.options.ExtLowQpct, Settings.options.ExtHighQpct, tcond);
					return 1f + (TimeDiff * QualityRatio);
				}
			}
			else if (tname == "GEAR_Hacksaw" || ToolsQualityAPI.CustomHacksaws.Contains(tname))
            {
				if (tcond > Settings.options.HackHighQpct) { return 1f; }
				else if (tcond <= Settings.options.HackLowQpct) { return Settings.options.HackLowQTime; }
				else
				{
					float TimeDiff = Settings.options.HackLowQTime - 1f;
					float QualityRatio = 1f - Mathf.InverseLerp(Settings.options.HackLowQpct, Settings.options.HackHighQpct, tcond);
					return 1f + (TimeDiff * QualityRatio);
				}
			}
			else
			{
				return 1f;
			}
		}
	}
}