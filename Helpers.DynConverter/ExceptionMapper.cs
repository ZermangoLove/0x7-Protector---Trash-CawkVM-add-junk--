using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Helpers.DynConverter
{
	public class ExceptionMapper
	{
		[CompilerGenerated]
		private readonly IList<ExceptionHandler> eB;

		private IList<ExceptionHandler> eD
		{
			[CompilerGenerated]
			get
			{
				return eB;
			}
		}

		public ExceptionMapper(MethodDef method)
		{
			eB = method.Body.ExceptionHandlers;
		}

		public void MapAndWrite(BinaryWriter writer, Instruction instr)
		{
			int num = 0;
			List<int> list = new List<int>();
			foreach (ExceptionHandler item in eD)
			{
				if (item.TryStart == instr)
				{
					list.Add(0);
					num++;
				}
				else if (item.HandlerEnd == instr)
				{
					list.Add(5);
					num++;
				}
				else if (item.HandlerType == ExceptionHandlerType.Filter && item.FilterStart == instr)
				{
					list.Add(1);
					num++;
				}
				else
				{
					if (item.HandlerStart != instr)
					{
						continue;
					}
					switch (item.HandlerType)
					{
					case ExceptionHandlerType.Catch:
						list.Add(2);
						if (item.CatchType == null)
						{
							list.Add(-1);
						}
						else
						{
							list.Add(item.CatchType.MDToken.ToInt32());
						}
						break;
					case ExceptionHandlerType.Finally:
						list.Add(3);
						break;
					case ExceptionHandlerType.Fault:
						list.Add(4);
						break;
					}
					num++;
				}
			}
			writer.Write(num);
			foreach (int item2 in list)
			{
				writer.Write(item2);
			}
		}
	}
}
