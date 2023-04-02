using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Core.ByteEncryption;
using Core.Injection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;
using VMUtils;

namespace Core.Protection
{
	public class MethodProccesor
	{
		public static List<MethodData> AllMethods = new List<MethodData>();

		public static EBytes eBytes = new EBytes("IVM");

		public static void ModuleProcessor()
		{
			int num = 1997372919;
			int num2 = 1;
			int num4 = default(int);
			IEnumerator<TypeDef> enumerator3 = default(IEnumerator<TypeDef>);
			while (true)
			{
				if (num2 == -1997372918 + num)
				{
					if (!VMUtils.Utils.ProtectAll)
					{
						InjectInitialise.initaliseMethod();
						int num3 = 1997372919 - num;
						foreach (TypeDef type in Protector.moduleDefMD.GetTypes())
						{
							if (type == Protector.moduleDefMD.GlobalType || type.HasGenericParameters || type.CustomAttributes.Count((CustomAttribute i) => i.TypeFullName.Contains("CompilerGenerated")) != 0 || type.IsValueType)
							{
								continue;
							}
							foreach (MethodDef method in type.Methods)
							{
								if (!VMUtils.Utils.SelectedMethods.Contains(method.MDToken.ToString()) || method.IsConstructor || !CanBeProtected(method) || !method.HasBody || (type.IsGlobalModuleType && method.IsConstructor) || method.HasGenericParameters || method.CustomAttributes.Count((CustomAttribute i) => i.TypeFullName.Contains("CompilerGenerated")) != 0 || method.ReturnType == null || method.ReturnType.IsGenericParameter || method.Parameters.Count(delegate(Parameter i)
								{
									int num8 = 788106975;
									return i.Type.FullName.EndsWith("&") ? ((i.ParamDef.IsOut ? 1 : 0) == 788106975 - num8) : ((byte)(-788106975 + num8) != 0);
								}) != 0 || method.CustomAttributes.Count(delegate(CustomAttribute i)
								{
									int num7 = 1923424248;
									return (i.NamedArguments.Count == 2 && i.NamedArguments[-1923424248 + num7].Value.ToString().Contains("Encrypt") && i.NamedArguments[-1923424247 + num7].Name.Contains("Exclude")) ? i.NamedArguments[1923424249 - num7].Value.ToString().ToLower().Contains("true") : ((byte)(1923424248 - num7) != 0);
								}) != 0)
								{
									continue;
								}
								MethodData methodData = new MethodData(method);
								method.Body.SimplifyMacros(method.Parameters);
								method.Body.SimplifyBranches();
								ConvertToBytes convertToBytes = new ConvertToBytes(method);
								try
								{
									convertToBytes.ConversionMethod();
									if (convertToBytes.Successful)
									{
										methodData.Converted = (byte)(0x770D7DF6u ^ (uint)num) != 0;
										methodData.DecryptedBytes = convertToBytes.ConvertedBytes;
										methodData.ID = num3;
										AllMethods.Add(methodData);
										num3 += 0x770D7DF6 ^ num;
									}
								}
								catch
								{
								}
							}
						}
						break;
					}
					num2 = 0x770D7DF5 ^ num;
				}
				if (num2 == -1997372917 + num)
				{
					InjectInitialise.initaliseMethod();
					num2 = -1997372916 + num;
				}
				if (num2 == 1997372922 - num)
				{
					num4 = -1997372919 + num;
					num2 = -1997372915 + num;
				}
				if (num2 == 1997372923 - num)
				{
					enumerator3 = Protector.moduleDefMD.GetTypes().GetEnumerator();
					num2 = 0x770D7DF2 ^ num;
				}
				if (num2 == 1997372919 - num)
				{
					num2 = 1997372920 - num;
				}
				if (num2 != (0x770D7DF2 ^ num))
				{
					continue;
				}
				try
				{
					while (enumerator3.MoveNext())
					{
						TypeDef current3 = enumerator3.Current;
						if (current3 == Protector.moduleDefMD.GlobalType || current3.HasGenericParameters || current3.CustomAttributes.Count((CustomAttribute i) => i.TypeFullName.Contains("CompilerGenerated")) != 0 || current3.IsValueType)
						{
							continue;
						}
						foreach (MethodDef method2 in current3.Methods)
						{
							if (method2.IsConstructor || !CanBeProtected(method2) || !method2.HasBody || (current3.IsGlobalModuleType && method2.IsConstructor) || method2.HasGenericParameters || method2.CustomAttributes.Count((CustomAttribute i) => i.TypeFullName.Contains("CompilerGenerated")) != 0 || method2.ReturnType == null || method2.ReturnType.IsGenericParameter || method2.Parameters.Count(delegate(Parameter i)
							{
								int num6 = 1269178476;
								return i.Type.FullName.EndsWith("&") ? ((i.ParamDef.IsOut ? 1 : 0) == (0x4BA6206C ^ num6)) : ((byte)(1269178476 - num6) != 0);
							}) != 0 || method2.CustomAttributes.Count(delegate(CustomAttribute i)
							{
								int num5 = 717472387;
								return (i.NamedArguments.Count == 2 && i.NamedArguments[0x2AC3C283 ^ num5].Value.ToString().Contains("Encrypt") && i.NamedArguments[0x2AC3C282 ^ num5].Name.Contains("Exclude")) ? i.NamedArguments[0x2AC3C282 ^ num5].Value.ToString().ToLower().Contains("true") : ((byte)(-717472387 + num5) != 0);
							}) != 0)
							{
								continue;
							}
							MethodData methodData2 = new MethodData(method2);
							method2.Body.SimplifyMacros(method2.Parameters);
							method2.Body.SimplifyBranches();
							ConvertToBytes convertToBytes2 = new ConvertToBytes(method2);
							try
							{
								convertToBytes2.ConversionMethod();
								if (convertToBytes2.Successful)
								{
									methodData2.Converted = (byte)(1997372920 - num) != 0;
									methodData2.DecryptedBytes = convertToBytes2.ConvertedBytes;
									methodData2.ID = num4;
									AllMethods.Add(methodData2);
									num4 += -1997372918 + num;
								}
							}
							catch
							{
							}
						}
					}
				}
				finally
				{
					enumerator3?.Dispose();
				}
				break;
			}
			string text = Xor.XorProcess(ICore.Utils.GenerateString(), "IVM");
			InjectInitialise.injectIntoCctor(text);
			InjectMethods.methodInjector();
			if (((uint)Protector.moduleDefMD.Characteristics & (uint)((-1973778544 ^ num) + (0x19D67D42 ^ num) - (-182100699 + num))) == 0)
			{
				bool flag = (byte)(1997372919 - num) != 0;
				CilBody body = Protector.moduleDefMD.GlobalType.FindOrCreateStaticConstructor().Body;
				for (int j = 1997372920 - num; j < body.Instructions.Count; j += 1997372920 - num)
				{
					if (body.Instructions[j].OpCode == OpCodes.Call)
					{
						MethodDef obj3 = (MethodDef)body.Instructions[j].Operand;
						obj3.Body.Instructions.Insert(-1997372919 + num, new Instruction(OpCodes.Ldstr, text));
						obj3.Body.Instructions.Insert(-1997372918 + num, new Instruction(OpCodes.Call, InjectInitialise.conversionInit));
						flag = (byte)(1997372920 - num) != 0;
						break;
					}
				}
				if (!flag)
				{
					CilBody body2 = Protector.moduleDefMD.EntryPoint.Body;
					body2.Instructions.Insert(0x770D7DF7 ^ num, new Instruction(OpCodes.Ldstr, text));
					body2.Instructions.Insert(1997372920 - num, new Instruction(OpCodes.Call, InjectInitialise.conversionInit));
				}
			}
			Process.processConvertedMethods(AllMethods);
			List<byte> list = new List<byte>();
			foreach (MethodData allMethod in AllMethods)
			{
				list.AddRange(allMethod.EncryptedBytes);
			}
			byte[] bytes = Encoding.ASCII.GetBytes(Protector.name);
			byte[] array = new byte[1997372935 - num];
			RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle));
			byte[] data = array;
			bytes = Core.ByteEncryption.ByteEncryption.Encrypt(eBytes.Encrypt(data), eBytes.Encrypt(bytes));
			list.AddRange(bytes);
			byte[] data2 = exclusiveOR(list.ToArray());
			EmbeddedResource item = new EmbeddedResource(text, data2, (ManifestResourceAttributes)(0x770D7DF5u ^ (uint)num));
			Protector.moduleDefMD.Resources.Add(item);
		}

		public static byte[] exclusiveOR(byte[] arr1)
		{
			int num = 1894096506;
			int num2 = 1;
			Random random = default(Random);
			byte[] array = default(byte[]);
			int num3 = default(int);
			do
			{
				if (num2 == -1894096505 + num)
				{
					random = new Random((-1906656257 ^ num) + (-541024465 - num) - (0x1CD74566 ^ num));
					num2 = 0x70E59E78 ^ num;
				}
				if (num2 == (0x70E59E78 ^ num))
				{
					array = new byte[arr1.Length];
					num2 = -1894096503 + num;
				}
				if (num2 == -1894096503 + num)
				{
					num3 = 0x70E59E7A ^ num;
					num2 = -1894096502 + num;
				}
				if (num2 == -1894096502 + num)
				{
					goto IL_00ae;
				}
				if (num2 == 1894096511 - num)
				{
					goto IL_00bd;
				}
				goto IL_013a;
				IL_00bd:
				array[num3] = (byte)(arr1[num3] ^ random.Next(1894096506 - num, 886822544 - num + (-697767413 - num) - (0x599C1CD7 ^ num)));
				num2 = 0x70E59E7C ^ num;
				goto IL_013a;
				IL_013a:
				if (num2 == -1894096500 + num)
				{
					num3 += 1894096507 - num;
					num2 = 0x70E59E7D ^ num;
				}
				if (num2 == 1894096513 - num)
				{
					goto IL_00ae;
				}
				goto IL_015f;
				IL_00ae:
				if (num3 < arr1.Length)
				{
					goto IL_00bd;
				}
				num2 = 1894096514 - num;
				goto IL_015f;
				IL_015f:
				if (num2 == (0x70E59E7A ^ num))
				{
					num2 = 0x70E59E7B ^ num;
				}
			}
			while (num2 != -1894096498 + num);
			return array;
		}

		private static bool CanBeProtected(MethodDef method)
		{
			int num = 200019538;
			int num2 = 1;
			do
			{
				if (num2 == 200019539 - num)
				{
					if (method.HasBody)
					{
						break;
					}
					num2 = 200019540 - num;
				}
				if (num2 != 200019540 - num)
				{
					if (num2 == (0xBEC0E52 ^ num))
					{
						num2 = 0xBEC0E53 ^ num;
					}
					continue;
				}
				return (method.DeclaringType.IsGlobalModuleType ? 1 : 0) == (0xBEC0E52 ^ num);
			}
			while (num2 != -200019535 + num);
			return (byte)(200019539 - num) != 0;
		}
	}
}
