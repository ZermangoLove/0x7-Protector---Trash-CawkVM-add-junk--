using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Core.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					resourceMan = new ResourceManager("Core.Properties.Resources", typeof(Resources).Assembly);
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static byte[] ConversionBack => (byte[])ResourceManager.GetObject("ConversionBack", resourceCulture);

		internal static byte[] NativeEncoderx64 => (byte[])ResourceManager.GetObject("NativeEncoderx64", resourceCulture);

		internal static byte[] NativeEncoderx86 => (byte[])ResourceManager.GetObject("NativeEncoderx86", resourceCulture);

		internal static byte[] XorMethod => (byte[])ResourceManager.GetObject("XorMethod", resourceCulture);

		internal Resources()
		{
		}
	}
}
