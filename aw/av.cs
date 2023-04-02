using System;
using System.Collections.Generic;
using dnlib.DotNet.Writer;

namespace aw
{
	internal static class av
	{
		internal static void ax(this List<PESection> sections, PESection newSection)
		{
			if (sections == null)
			{
				throw new ArgumentNullException("sections");
			}
			sections.ay(sections.Count, newSection);
		}

		internal static void ay(this List<PESection> sections, int preferredIndex, PESection newSection)
		{
			if (sections != null)
			{
				if (preferredIndex >= 0 && preferredIndex <= sections.Count)
				{
					if (newSection == null)
					{
						throw new ArgumentNullException("newSection");
					}
					int num = sections.FindIndex(0, Math.Min(preferredIndex + 1, sections.Count), az);
					if (num == -1)
					{
						sections.Insert(preferredIndex, newSection);
					}
					else
					{
						sections.Insert(num, newSection);
					}
					return;
				}
				throw new ArgumentOutOfRangeException("preferredIndex", preferredIndex, "Preferred index is out of range.");
			}
			throw new ArgumentNullException("sections");
		}

		private static bool az(PESection section)
		{
			return section.Name.Equals(".reloc", StringComparison.Ordinal);
		}
	}
}
