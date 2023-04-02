using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ICore
{
	public static class Utils
	{
		public static Random rnd = new Random();

		public static byte[] RandomByteArr(int size)
		{
			byte[] array = new byte[size];
			rnd.NextBytes(array);
			return array;
		}

		public static Code GetCode(bool supported = false)
		{
			Code[] array = new Code[5]
			{
				Code.Add,
				Code.And,
				Code.Xor,
				Code.Sub,
				Code.Or
			};
			if (supported)
			{
				array = new Code[3]
				{
					Code.Add,
					Code.Sub,
					Code.Xor
				};
			}
			return array[rnd.Next(0, array.Length)];
		}

		public static FieldDefUser CreateField(FieldSig sig)
		{
			return new FieldDefUser(GenerateString(), sig, FieldAttributes.Public | FieldAttributes.Static);
		}

		public static MethodDefUser CreateMethod(ModuleDef mod, int num, string mname, string content)
		{
			MethodDefUser methodDefUser = null;
			for (int i = 0; i < num; i++)
			{
				methodDefUser = new MethodDefUser(mname, MethodSig.CreateStatic(mod.CorLibTypes.Void), MethodImplAttributes.IL, MethodAttributes.Public | MethodAttributes.Static);
				methodDefUser.Body = new CilBody();
				methodDefUser.Body.Instructions.Add(OpCodes.Ldstr.ToInstruction(content));
				methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
				mod.GlobalType.Methods.Add(methodDefUser);
			}
			return methodDefUser;
		}

		public static string GenerateString()
		{
			return Safe.GenerateRandomString() + RandomSmallInt32();
		}

		public static int RandomTinyInt32()
		{
			return rnd.Next(2, 4);
		}

		public static int RandomSmallInt32()
		{
			return rnd.Next(15, 40);
		}

		public static int RandomInt32()
		{
			return rnd.Next(100, 300);
		}

		public static int RandomBigInt32()
		{
			return rnd.Next();
		}

		public static bool RandomBoolean()
		{
			return Convert.ToBoolean(rnd.Next(0, 2));
		}
	}
}
