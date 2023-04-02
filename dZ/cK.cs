using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using dnlib.DotNet.Emit;

namespace dZ
{
	internal static class cK
	{
		internal abstract class gR
		{
			[CompilerGenerated]
			private gX gS;

			public gX gV
			{
				[CompilerGenerated]
				get
				{
					return gS;
				}
				[CompilerGenerated]
				private set
				{
					gS = value;
				}
			}

			public gR(gX type)
			{
				gV = type;
			}

			public abstract void gW(CilBody body);
		}

		internal enum gX
		{
			Normal,
			gY,
			gZ,
			ha,
			hb,
			hc
		}

		internal class hd : gR
		{
			[CompilerGenerated]
			private ExceptionHandler he;

			[CompilerGenerated]
			private List<gR> hf;

			public ExceptionHandler hi
			{
				[CompilerGenerated]
				get
				{
					return he;
				}
				[CompilerGenerated]
				private set
				{
					he = value;
				}
			}

			public List<gR> hl
			{
				[CompilerGenerated]
				get
				{
					return hf;
				}
				[CompilerGenerated]
				set
				{
					hf = value;
				}
			}

			public hd(gX type, ExceptionHandler handler)
				: base(type)
			{
				hi = handler;
				hl = new List<gR>();
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (base.gV == gX.gY)
				{
					stringBuilder.Append("try ");
				}
				else if (base.gV == gX.gZ)
				{
					stringBuilder.Append("handler ");
				}
				else if (base.gV == gX.ha)
				{
					stringBuilder.Append("finally ");
				}
				else if (base.gV == gX.hc)
				{
					stringBuilder.Append("fault ");
				}
				stringBuilder.AppendLine("{");
				foreach (gR item in hl)
				{
					stringBuilder.Append(item);
				}
				stringBuilder.AppendLine("}");
				return stringBuilder.ToString();
			}

			public Instruction hm()
			{
				gR gR = hl.First();
				if (gR is hd)
				{
					return ((hd)gR).hm();
				}
				return ((ho)gR).hr.First();
			}

			public Instruction hn()
			{
				gR gR = hl.Last();
				if (gR is hd)
				{
					return ((hd)gR).hn();
				}
				return ((ho)gR).hr.Last();
			}

			public override void gW(CilBody body)
			{
				if (base.gV != 0)
				{
					if (base.gV == gX.gY)
					{
						hi.TryStart = hm();
						hi.TryEnd = hn();
					}
					else if (base.gV == gX.hb)
					{
						hi.FilterStart = hm();
					}
					else
					{
						hi.HandlerStart = hm();
						hi.HandlerEnd = hn();
					}
				}
				foreach (gR item in hl)
				{
					item.gW(body);
				}
			}
		}

		internal class ho : gR
		{
			[CompilerGenerated]
			private List<Instruction> ds;

			public List<Instruction> hr
			{
				[CompilerGenerated]
				get
				{
					return ds;
				}
				[CompilerGenerated]
				set
				{
					ds = value;
				}
			}

			public ho()
				: base(gX.Normal)
			{
				hr = new List<Instruction>();
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (Instruction item in hr)
				{
					stringBuilder.AppendLine(item.ToString());
				}
				return stringBuilder.ToString();
			}

			public override void gW(CilBody body)
			{
				foreach (Instruction item in hr)
				{
					body.Instructions.Add(item);
				}
			}
		}

		public static hd cM(CilBody body)
		{
			Dictionary<ExceptionHandler, Tuple<hd, hd, hd>> dictionary = new Dictionary<ExceptionHandler, Tuple<hd, hd, hd>>();
			foreach (ExceptionHandler exceptionHandler in body.ExceptionHandlers)
			{
				hd item = new hd(gX.gY, exceptionHandler);
				gX type = gX.gZ;
				if (exceptionHandler.HandlerType == ExceptionHandlerType.Finally)
				{
					type = gX.ha;
				}
				else if (exceptionHandler.HandlerType == ExceptionHandlerType.Fault)
				{
					type = gX.hc;
				}
				hd item2 = new hd(type, exceptionHandler);
				if (exceptionHandler.FilterStart != null)
				{
					hd item3 = new hd(gX.hb, exceptionHandler);
					dictionary[exceptionHandler] = Tuple.Create(item, item2, item3);
				}
				else
				{
					dictionary[exceptionHandler] = Tuple.Create<hd, hd, hd>(item, item2, null);
				}
			}
			hd hd = new hd(gX.Normal, null);
			Stack<hd> stack = new Stack<hd>();
			stack.Push(hd);
			foreach (Instruction instruction in body.Instructions)
			{
				foreach (ExceptionHandler exceptionHandler2 in body.ExceptionHandlers)
				{
					_ = dictionary[exceptionHandler2];
					if (instruction == exceptionHandler2.TryEnd)
					{
						stack.Pop();
					}
					if (instruction == exceptionHandler2.HandlerEnd)
					{
						stack.Pop();
					}
					if (exceptionHandler2.FilterStart != null && instruction == exceptionHandler2.HandlerStart)
					{
						stack.Pop();
					}
				}
				foreach (ExceptionHandler item4 in body.ExceptionHandlers.Reverse())
				{
					Tuple<hd, hd, hd> tuple = dictionary[item4];
					hd hd2 = ((stack.Count > 0) ? stack.Peek() : null);
					if (instruction == item4.TryStart)
					{
						hd2?.hl.Add(tuple.Item1);
						stack.Push(tuple.Item1);
					}
					if (instruction == item4.HandlerStart)
					{
						hd2?.hl.Add(tuple.Item2);
						stack.Push(tuple.Item2);
					}
					if (instruction == item4.FilterStart)
					{
						hd2?.hl.Add(tuple.Item3);
						stack.Push(tuple.Item3);
					}
				}
				hd hd3 = stack.Peek();
				ho ho = hd3.hl.LastOrDefault() as ho;
				if (ho == null)
				{
					hd3.hl.Add(ho = new ho());
				}
				ho.hr.Add(instruction);
			}
			foreach (ExceptionHandler exceptionHandler3 in body.ExceptionHandlers)
			{
				if (exceptionHandler3.TryEnd == null)
				{
					stack.Pop();
				}
				if (exceptionHandler3.HandlerEnd == null)
				{
					stack.Pop();
				}
			}
			return hd;
		}
	}
}
