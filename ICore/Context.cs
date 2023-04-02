using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using at;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using ExAntiTamper;

namespace ICore
{
	public class Context
	{
		[CompilerGenerated]
		private string dJ;

		[CompilerGenerated]
		private string dK;

		[CompilerGenerated]
		private string dL;

		[CompilerGenerated]
		private string dM;

		[CompilerGenerated]
		private static bool dN;

		[CompilerGenerated]
		private ModuleDefMD dv;

		public Context ctx;

		public string Path
		{
			[CompilerGenerated]
			get
			{
				return dJ;
			}
			[CompilerGenerated]
			set
			{
				dJ = value;
			}
		}

		public string FileName
		{
			[CompilerGenerated]
			get
			{
				return dK;
			}
			[CompilerGenerated]
			set
			{
				dK = value;
			}
		}

		public string OutPutPath
		{
			[CompilerGenerated]
			get
			{
				return dL;
			}
			[CompilerGenerated]
			set
			{
				dL = value;
			}
		}

		public string DirPath
		{
			[CompilerGenerated]
			get
			{
				return dM;
			}
			[CompilerGenerated]
			set
			{
				dM = value;
			}
		}

		public static bool samePath
		{
			[CompilerGenerated]
			get
			{
				return dN;
			}
			[CompilerGenerated]
			set
			{
				dN = value;
			}
		}

		public ModuleDefMD Module
		{
			[CompilerGenerated]
			get
			{
				return dv;
			}
			[CompilerGenerated]
			set
			{
				dv = value;
			}
		}

		public Context(string path)
		{
			Path = path;
			Module = ModuleDefMD.Load(path);
			LoadAssemblies();
		}

		public void LoadAssemblies()
		{
			AssemblyResolver assemblyResolver = new AssemblyResolver();
			ModuleContext context = (assemblyResolver.DefaultModuleContext = new ModuleContext(assemblyResolver));
			assemblyResolver.EnableTypeDefCache = true;
			List<AssemblyRef> list = Module.GetAssemblyRefs().ToList();
			Module.Context = context;
			foreach (AssemblyRef item in list)
			{
				if (item != null)
				{
					AssemblyDef assemblyDef = assemblyResolver.Resolve(item.FullName, Module);
					if (assemblyDef != null)
					{
						((AssemblyResolver)Module.Context.AssemblyResolver).AddToCache(assemblyDef);
					}
				}
			}
		}

		private void ap(object sender, ModuleWriterEventArgs e)
		{
			switch (e.Event)
			{
			case ModuleWriterEvent.BeginStrongNameSign:
				new AntiTamperNormal().EncryptSection(e.Writer);
				break;
			case ModuleWriterEvent.MDEndCreateTables:
				new AntiTamperNormal().CreateSections(e.Writer);
				break;
			}
		}

		public void SaveFile()
		{
			ModuleWriterOptions moduleWriterOptions = new ModuleWriterOptions(Module);
			moduleWriterOptions.MetadataOptions.Flags = MetadataFlags.PreserveAllMethodRids | MetadataFlags.AlwaysCreateGuidHeap | MetadataFlags.AlwaysCreateStringsHeap | MetadataFlags.AlwaysCreateUSHeap | MetadataFlags.AlwaysCreateBlobHeap;
			moduleWriterOptions.MetadataLogger = DummyLogger.NoThrowInstance;
			if (@as.au)
			{
				moduleWriterOptions.WriterEvent += ap;
			}
			if (samePath)
			{
				OutPutPath = Path.Replace(".exe", "-protected.exe");
				Module.Write(OutPutPath, moduleWriterOptions);
			}
			else
			{
				Directory.CreateDirectory(DirPath + "\\");
				Module.Write(OutPutPath, moduleWriterOptions);
			}
		}

		public void Clear()
		{
			Path = null;
			Module = null;
		}
	}
}
