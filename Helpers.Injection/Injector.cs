using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using ICore;

namespace Helpers.Injection
{
	public class Injector
	{
		[CompilerGenerated]
		private readonly ModuleDefMD eb;

		[CompilerGenerated]
		private readonly Type ec;

		[CompilerGenerated]
		private readonly List<IDnlibDef> ed;

		public ModuleDefMD TargetModule
		{
			[CompilerGenerated]
			get
			{
				return eb;
			}
		}

		public Type RuntimeType
		{
			[CompilerGenerated]
			get
			{
				return ec;
			}
		}

		public List<IDnlibDef> Members
		{
			[CompilerGenerated]
			get
			{
				return ed;
			}
		}

		public Injector(ModuleDefMD targetModule, Type type, bool injectType = true)
		{
			eb = targetModule;
			ec = type;
			ed = new List<IDnlibDef>();
			if (injectType)
			{
				InjectType();
			}
		}

		public void InjectType()
		{
			TypeDef typeDef = ModuleDefMD.Load(RuntimeType.Module).ResolveTypeDef(MDToken.ToRID(RuntimeType.MetadataToken));
			Members.AddRange(InjectHelper.Inject(typeDef, TargetModule.GlobalType, TargetModule).ToList());
		}

		public IDnlibDef FindMember(string name)
		{
			foreach (IDnlibDef member in Members)
			{
				if (member.Name == name)
				{
					return member;
				}
			}
			throw new Exception("Error to find member.");
		}

		public void Rename()
		{
			foreach (IDnlibDef member in Members)
			{
				if (!(member is MethodDef methodDef) || (!methodDef.HasImplMap && !methodDef.DeclaringType.IsDelegate))
				{
					member.Name = Safe.GenerateRandomString();
				}
			}
		}
	}
}
