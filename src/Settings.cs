using ModSettings;
using System.Reflection;

namespace ToolsQuality
{
	internal class ToolsQualitySettings : JsonModSettings
	{
		[Section("Main settings")]
		[Name("Time multiplier when breaking branches")]
		[Description("Time multiplier when chopping or breaking branches - recommened 0.5")]
		[Slider(0.1f, 3f)]
		public float BreakBranchTimeMultiplier = 1f;

		[Name("Time multiplier when chopping limbs")]
		[Description("Time multiplier when chopping limbs - recommened 0.5")]
		[Slider(0.1f, 3f)]
		public float BreakLimbTimeMultiplier = 1f;

		[Name("Time multiplier when chopping pallets")]
		[Description("Time multiplier when chopping wood pallets - recommened 0.5")]
		[Slider(0.1f, 3f)]
		public float BreakPalletTimeMultiplier = 1f;

		[Name("Time multiplier when harvesting animals")]
		[Description("Time multiplier when harvesting animals")]
		[Slider(0.1f, 3f)]
		public float HarvestTimeMultiplier = 1f;

		[Name("Time multiplier when quatering animals")]
		[Description("Time multiplier when quatering animals")]
		[Slider(0.1f, 3f)]
		public float QuaterTimeMultiplier = 1f;

		[Name("Tools quality")]
		[Description("If enabled, lower condition of tool will increase action time (settings below). Vanila is off.")]
		public bool ToolsQualityEnabled = false;

		[Section("Manufactured tools")]
		[Name("Low Quality condition point")]
		[Description("Below (inclusive) this condition tool will be performing with multiplier of next value.")]
		[Slider(0, 100, 101)]
		public int ManLowQpct = 10;

		[Name("Low Quality time multiplier")]
		[Description("Time multiplier for bad condition - recommended 3-4")]
		[Slider(1f, 10f)]
		public int ManLowQTime = 3;

		[Name("High Quality condition point")]
		[Description("Above (inclusive) this condition, tool will not have penalty")]
		[Slider(0, 100, 101)]
		public int ManHighQpct = 85;

		[Name("Boost Quality condition point")]
		[Description("Above this point, tool will have efficiency bonus, used with next value. Set to 100 to disable.")]
		[Slider(0, 100, 101)]
		public int ManBoostQpct = 100;

		[Name("Boost Quality time multiplier")]
		[Description("Time multiplier for perfect condition - recommended 0.7 (if used)")]
		[Slider(0.1f, 1f)]
		public float ManBoostQTime = 0.7f;

		[Section("Hacksaw")]
		[Name("Low Quality condition point")]
		[Description("Below (inclusive) this condition tool will be performing with multiplier of next value.")]
		[Slider(0, 100, 101)]
		public int HackLowQpct = 0;

		[Name("Low Quality time multiplier")]
		[Description("Time multiplier for bad condition - recommended 3-4")]
		[Slider(1f, 10f)]
		public int HackLowQTime = 3;

		[Name("High Quality condition point")]
		[Description("Above (inclusive) this condition, tool will not have penalty")]
		[Slider(0, 100, 101)]
		public int HackHighQpct = 70;

		[Section("Improvised tools")]
		[Name("Low Quality condition point")]
		[Description("Below (inclusive) this condition tool will be performing with multiplier of next value.")]
		[Slider(0, 100, 101)]
		public int ImpLowQpct = 0;

		[Name("Low Quality time multiplier")]
		[Description("Time multiplier for bad condition - recommended 2-3")]
		[Slider(1f, 10f)]
		public int ImpLowQTime = 2;

		[Name("High Quality condition point")]
		[Description("Above (inclusive) this condition, tool will not have penalty")]
		[Slider(0, 100, 101)]
		public int ImpHighQpct = 100;

		[Section("Extraordinary tools")]
		[Name("Low Quality condition point")]
		[Description("Below (inclusive) this condition tool will be performing with multiplier of next value.")]
		[Slider(0, 100, 101)]
		public int ExtLowQpct = 10;

		[Name("Low Quality time multiplier")]
		[Description("Time multiplier for bad condition - recommended 2-3")]
		[Slider(1f, 10f)]
		public float ExtLowQTime = 1.5f;

		[Name("High Quality condition point")]
		[Description("Above (inclusive) this condition, tool will not have penalty")]
		[Slider(0, 100, 101)]
		public int ExtHighQpct = 50;

		[Name("Boost Quality condition point")]
		[Description("Above this point, tool will have efficiency bonus, used with next value. Set to 100 to disable.")]
		[Slider(0, 100, 101)]
		public int ExtBoostQpct = 100;

		[Name("Boost Quality time multiplier")]
		[Description("Time multiplier for perfect condition - recommended 0.7 (if used)")]
		[Slider(0.1f, 1f)]
		public float ExtBoostQTime = 0.95f;
		protected override void OnChange(FieldInfo field, object oldValue, object newValue)
		{
			RefreshFields();
		}

		internal void RefreshFields()
		{
			if (ManBoostQpct< ManHighQpct)
			{
				ManBoostQpct = ManHighQpct;
			}
			if (ManHighQpct < ManLowQpct)
			{
				ManHighQpct = ManLowQpct;
			}
			if (ImpHighQpct < ImpLowQpct)
			{
				ImpHighQpct = ImpLowQpct;
			}
			if (ExtHighQpct < ExtLowQpct)
			{
				ExtHighQpct = ExtLowQpct;
			}
			if (ToolsQualityEnabled)
            {
				SetFieldVisible(nameof(ManLowQpct), true);
				SetFieldVisible(nameof(ManLowQTime), true);
				SetFieldVisible(nameof(ManHighQpct), true);
				SetFieldVisible(nameof(ManBoostQpct), true);
				SetFieldVisible(nameof(ManBoostQTime), true);
				SetFieldVisible(nameof(ImpLowQpct), true);
				SetFieldVisible(nameof(ImpLowQTime), true);
				SetFieldVisible(nameof(ImpHighQpct), true);
				SetFieldVisible(nameof(ExtLowQpct), true);
				SetFieldVisible(nameof(ExtLowQTime), true);
				SetFieldVisible(nameof(ExtHighQpct), true);
			}
			else
            {
				SetFieldVisible(nameof(ManLowQpct), false);
				SetFieldVisible(nameof(ManLowQTime), false);
				SetFieldVisible(nameof(ManHighQpct), false);
				SetFieldVisible(nameof(ManBoostQpct), false);
				SetFieldVisible(nameof(ManBoostQTime), false);
				SetFieldVisible(nameof(ImpLowQpct), false);
				SetFieldVisible(nameof(ImpLowQTime), false);
				SetFieldVisible(nameof(ImpHighQpct), false);
				SetFieldVisible(nameof(ExtLowQpct), false);
				SetFieldVisible(nameof(ExtLowQTime), false);
				SetFieldVisible(nameof(ExtHighQpct), false);
			}
			RefreshGUI();
		}
	}
	internal static class Settings
	{
		public static ToolsQualitySettings options;
		public static void OnLoad()
		{
			options = new ToolsQualitySettings();
			options.RefreshFields();
			options.AddToModSettings("Tools Quality Settings");
		}
	}
}