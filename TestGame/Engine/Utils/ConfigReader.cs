using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameEngineTK.Engine
{
	[Serializable]
	public class ConfigReader
	{
		/// <summary>
		/// <para>Parse ovconfig values</para>
		/// <para>usage: config_name["value"]; </para>
		/// </summary>
		/// <param name="path">Config source</param>
		/// <returns>Dictionary&lt;key, value&gt;();</returns>
		static public Dictionary<string, string> Parse(string path)
		{
			var config = File.ReadAllText(Path.Combine("../../../", path));
			List<string> trimmed = new List<string>();
			Dictionary<string, string> result = new Dictionary<string, string>();
			var lines = config.Split('\n').ToList();
			for (int i = 0; i < lines.Count; i++)
			{
				lines[i] = lines[i].Split('#')[0].Trim();
				lines[i] = Regex.Replace(lines[i], @"^\s*$\n", string.Empty, RegexOptions.Multiline);
			}
			foreach (var l in lines)
				if (l.Length != 0)
					trimmed.Add(l);
			foreach (var t in trimmed)
				result.Add(t.Split(':', 2)[0].Trim(), t.Split(':', 2)[1].Trim());
			return result;
		}
	}
}
