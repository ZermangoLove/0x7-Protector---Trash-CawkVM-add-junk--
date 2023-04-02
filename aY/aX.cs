using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace aY
{
	internal class aX
	{
		public enum ArithmeticTypes
		{
			Add,
			Sub,
			Div,
			Mul,
			Xor,
			Abs,
			Log,
			Log10,
			Sin,
			Cos,
			Round,
			Sqrt,
			Ceiling,
			Floor,
			Tan,
			Tanh,
			Truncate
		}

		public class ArithmeticEmulator
		{
			private double an;

			private double dC;

			private ArithmeticTypes gF;

			[CompilerGenerated]
			private ArithmeticTypes dE;

			public new ArithmeticTypes GetType
			{
				[CompilerGenerated]
				get
				{
					return dE;
				}
				[CompilerGenerated]
				private set
				{
					dE = value;
				}
			}

			public ArithmeticEmulator(double x, double y, ArithmeticTypes ArithmeticTypes)
			{
				an = x;
				dC = y;
				gF = ArithmeticTypes;
			}

			public double GetValue()
			{
				switch (gF)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Add:
					return an - dC;
				case ArithmeticTypes.Sub:
					return an + dC;
				case ArithmeticTypes.Div:
					return an * dC;
				case ArithmeticTypes.Mul:
					return an / dC;
				case ArithmeticTypes.Xor:
					return (int)an ^ (int)dC;
				}
			}

			public double GetValue(List<ArithmeticTypes> arithmetics)
			{
				Generator generator = new Generator();
				ArithmeticTypes arithmeticTypes2 = (GetType = arithmetics[generator.Next(arithmetics.Count)]);
				switch (gF)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Abs:
					switch (arithmeticTypes2)
					{
					default:
						return -1.0;
					case ArithmeticTypes.Sub:
						return an - Math.Abs(dC) * -1.0;
					case ArithmeticTypes.Add:
						return an + Math.Abs(dC) * -1.0;
					}
				case ArithmeticTypes.Log:
					switch (arithmeticTypes2)
					{
					default:
						return -1.0;
					case ArithmeticTypes.Sub:
						return an + Math.Log(dC);
					case ArithmeticTypes.Add:
						return an - Math.Log(dC);
					}
				case ArithmeticTypes.Log10:
					switch (arithmeticTypes2)
					{
					default:
						return -1.0;
					case ArithmeticTypes.Sub:
						return an + Math.Log10(dC);
					case ArithmeticTypes.Add:
						return an - Math.Log10(dC);
					}
				case ArithmeticTypes.Sin:
					switch (arithmeticTypes2)
					{
					default:
						return -1.0;
					case ArithmeticTypes.Sub:
						return an + Math.Sin(dC);
					case ArithmeticTypes.Add:
						return an - Math.Sin(dC);
					}
				case ArithmeticTypes.Cos:
					switch (arithmeticTypes2)
					{
					default:
						return -1.0;
					case ArithmeticTypes.Sub:
						return an + Math.Cos(dC);
					case ArithmeticTypes.Add:
						return an - Math.Cos(dC);
					}
				case ArithmeticTypes.Round:
					switch (arithmeticTypes2)
					{
					default:
						return -1.0;
					case ArithmeticTypes.Sub:
						return an + Math.Round(dC);
					case ArithmeticTypes.Add:
						return an - Math.Round(dC);
					}
				case ArithmeticTypes.Sqrt:
					switch (arithmeticTypes2)
					{
					default:
						return -1.0;
					case ArithmeticTypes.Sub:
						return an + Math.Sqrt(dC);
					case ArithmeticTypes.Add:
						return an - Math.Sqrt(dC);
					}
				case ArithmeticTypes.Ceiling:
					switch (arithmeticTypes2)
					{
					default:
						return -1.0;
					case ArithmeticTypes.Sub:
						return an + Math.Ceiling(dC);
					case ArithmeticTypes.Add:
						return an - Math.Ceiling(dC);
					}
				case ArithmeticTypes.Floor:
					switch (arithmeticTypes2)
					{
					default:
						return -1.0;
					case ArithmeticTypes.Sub:
						return an + Math.Floor(dC);
					case ArithmeticTypes.Add:
						return an - Math.Floor(dC);
					}
				case ArithmeticTypes.Tan:
					switch (arithmeticTypes2)
					{
					default:
						return -1.0;
					case ArithmeticTypes.Sub:
						return an + Math.Tan(dC);
					case ArithmeticTypes.Add:
						return an - Math.Tan(dC);
					}
				case ArithmeticTypes.Tanh:
					switch (arithmeticTypes2)
					{
					default:
						return -1.0;
					case ArithmeticTypes.Sub:
						return an + Math.Tanh(dC);
					case ArithmeticTypes.Add:
						return an - Math.Tanh(dC);
					}
				case ArithmeticTypes.Truncate:
					switch (arithmeticTypes2)
					{
					default:
						return -1.0;
					case ArithmeticTypes.Sub:
						return an + Math.Truncate(dC);
					case ArithmeticTypes.Add:
						return an - Math.Truncate(dC);
					}
				}
			}

			public double GetX()
			{
				return an;
			}

			public double GetY()
			{
				return dC;
			}
		}

		public class Arithmetic
		{
			private ModuleDef gG;

			private List<iFunction> gH = new List<iFunction>
			{
				new Add(),
				new Sub(),
				new Div(),
				new Mul(),
				new Xor(),
				new Abs(),
				new Log(),
				new Log10(),
				new Sin(),
				new Cos(),
				new Floor(),
				new Round(),
				new Tan(),
				new Tanh(),
				new Sqrt(),
				new Ceiling(),
				new Truncate()
			};

			public Arithmetic(ModuleDef moduleDef)
			{
				gG = moduleDef;
			}

			public void Execute(MethodDef mDef)
			{
				Generator generator = new Generator();
				if (!mDef.HasBody)
				{
					return;
				}
				for (int i = 0; i < mDef.Body.Instructions.Count; i++)
				{
					if (!ArithmeticUtils.CheckArithmetic(mDef.Body.Instructions[i]))
					{
						continue;
					}
					if (mDef.Body.Instructions[i].GetLdcI4Value() < 0)
					{
						iFunction iFunction = gH[generator.Next(5)];
						List<Instruction> list = dz(iFunction.Arithmetic(mDef.Body.Instructions[i], gG));
						if (list == null)
						{
							continue;
						}
						mDef.Body.Instructions[i].OpCode = OpCodes.Nop;
						foreach (Instruction item in list)
						{
							mDef.Body.Instructions.Insert(i + 1, item);
							i++;
						}
						continue;
					}
					iFunction iFunction2 = gH[generator.Next(gH.Count)];
					List<Instruction> list2 = dz(iFunction2.Arithmetic(mDef.Body.Instructions[i], gG));
					if (list2 == null)
					{
						continue;
					}
					mDef.Body.Instructions[i].OpCode = OpCodes.Nop;
					foreach (Instruction item2 in list2)
					{
						mDef.Body.Instructions.Insert(i + 1, item2);
						i++;
					}
				}
			}

			private List<Instruction> dz(ArithmeticVT arithmeticVTs)
			{
				List<Instruction> list = new List<Instruction>();
				if (dA(arithmeticVTs.GetArithmetic()))
				{
					list.Add(new Instruction(OpCodes.Ldc_R8, arithmeticVTs.GetValue().GetX()));
					list.Add(new Instruction(OpCodes.Ldc_R8, arithmeticVTs.GetValue().GetY()));
					if (arithmeticVTs.GetToken().GetOperand() != null)
					{
						list.Add(new Instruction(OpCodes.Call, arithmeticVTs.GetToken().GetOperand()));
					}
					list.Add(new Instruction(arithmeticVTs.GetToken().GetOpCode()));
					list.Add(new Instruction(OpCodes.Call, gG.Import(typeof(Convert).GetMethod("ToInt32", new Type[1] { typeof(double) }))));
				}
				else if (dB(arithmeticVTs.GetArithmetic()))
				{
					list.Add(new Instruction(OpCodes.Ldc_I4, (int)arithmeticVTs.GetValue().GetX()));
					list.Add(new Instruction(OpCodes.Ldc_I4, (int)arithmeticVTs.GetValue().GetY()));
					list.Add(new Instruction(arithmeticVTs.GetToken().GetOpCode()));
					list.Add(new Instruction(OpCodes.Conv_I4));
				}
				return list;
			}

			private bool dA(ArithmeticTypes arithmetic)
			{
				if (arithmetic != 0 && arithmetic != ArithmeticTypes.Sub && arithmetic != ArithmeticTypes.Div && arithmetic != ArithmeticTypes.Mul && arithmetic != ArithmeticTypes.Abs && arithmetic != ArithmeticTypes.Log && arithmetic != ArithmeticTypes.Log10 && arithmetic != ArithmeticTypes.Truncate && arithmetic != ArithmeticTypes.Sin && arithmetic != ArithmeticTypes.Cos && arithmetic != ArithmeticTypes.Floor && arithmetic != ArithmeticTypes.Round && arithmetic != ArithmeticTypes.Tan && arithmetic != ArithmeticTypes.Tanh && arithmetic != ArithmeticTypes.Sqrt)
				{
					return arithmetic == ArithmeticTypes.Ceiling;
				}
				return true;
			}

			private bool dB(ArithmeticTypes arithmetic)
			{
				return arithmetic == ArithmeticTypes.Xor;
			}
		}

		public class Value
		{
			private double an;

			private double dC;

			public Value(double x, double y)
			{
				an = x;
				dC = y;
			}

			public double GetX()
			{
				return an;
			}

			public double GetY()
			{
				return dC;
			}
		}

		public class ArithmeticVT
		{
			private Value dF;

			private Token dG;

			private ArithmeticTypes dD;

			public ArithmeticVT(Value value, Token token, ArithmeticTypes arithmeticTypes)
			{
				dF = value;
				dG = token;
				dD = arithmeticTypes;
			}

			public Value GetValue()
			{
				return dF;
			}

			public Token GetToken()
			{
				return dG;
			}

			public ArithmeticTypes GetArithmetic()
			{
				return dD;
			}
		}

		public abstract class iArithmetic
		{
			public abstract string Name { get; }

			public abstract string Description { get; }

			public abstract void Init();
		}

		public abstract class iFunction
		{
			public abstract ArithmeticTypes ArithmeticTypes { get; }

			public abstract ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module);
		}

		public class Token
		{
			private OpCode dH;

			private object dI;

			public Token(OpCode opCode, object Operand)
			{
				dH = opCode;
				dI = Operand;
			}

			public Token(OpCode opCode)
			{
				dH = opCode;
				dI = null;
			}

			public OpCode GetOpCode()
			{
				return dH;
			}

			public object GetOperand()
			{
				return dI;
			}
		}

		public class Add : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Add;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(), arithmeticEmulator.GetY()), new Token(OpCodes.Add), ArithmeticTypes);
			}
		}

		public class Div : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Div;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(), arithmeticEmulator.GetY()), new Token(OpCodes.Div), ArithmeticTypes);
			}
		}

		public class Mul : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Mul;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(), arithmeticEmulator.GetY()), new Token(OpCodes.Mul), ArithmeticTypes);
			}
		}

		public class Sub : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Sub;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(), arithmeticEmulator.GetY()), new Token(OpCodes.Sub), ArithmeticTypes);
			}
		}

		public class Xor : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Xor;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				Generator generator = new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), generator.Next(), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(), arithmeticEmulator.GetY()), new Token(OpCodes.Xor), ArithmeticTypes);
			}
		}

		public class Abs : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Abs;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
				{
					ArithmeticTypes.Add,
					ArithmeticTypes.Sub
				};
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes);
			}
		}

		public class Ceiling : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Ceiling;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
				{
					ArithmeticTypes.Add,
					ArithmeticTypes.Sub
				};
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes);
			}
		}

		public class Cos : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Cos;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
				{
					ArithmeticTypes.Add,
					ArithmeticTypes.Sub
				};
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes);
			}
		}

		public class Floor : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Floor;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
				{
					ArithmeticTypes.Add,
					ArithmeticTypes.Sub
				};
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes);
			}
		}

		public class Log : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Log;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
				{
					ArithmeticTypes.Add,
					ArithmeticTypes.Sub
				};
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes);
			}
		}

		public class Log10 : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Log10;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
				{
					ArithmeticTypes.Add,
					ArithmeticTypes.Sub
				};
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes);
			}
		}

		public class Round : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Round;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
				{
					ArithmeticTypes.Add,
					ArithmeticTypes.Sub
				};
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes);
			}
		}

		public class Sin : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Sin;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
				{
					ArithmeticTypes.Add,
					ArithmeticTypes.Sub
				};
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes);
			}
		}

		public class Sqrt : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Sqrt;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
				{
					ArithmeticTypes.Add,
					ArithmeticTypes.Sub
				};
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes);
			}
		}

		public class Tan : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Tan;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
				{
					ArithmeticTypes.Add,
					ArithmeticTypes.Sub
				};
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes);
			}
		}

		public class Tanh : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Tanh;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
				{
					ArithmeticTypes.Add,
					ArithmeticTypes.Sub
				};
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes);
			}
		}

		public class Truncate : iFunction
		{
			public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Truncate;

			public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
			{
				new Generator();
				if (!ArithmeticUtils.CheckArithmetic(instruction))
				{
					return null;
				}
				List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
				{
					ArithmeticTypes.Add,
					ArithmeticTypes.Sub
				};
				ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
				return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes);
			}
		}

		public class Generator
		{
			private Random al;

			public Generator()
			{
				al = new Random(Guid.NewGuid().GetHashCode());
			}

			public int Next()
			{
				return al.Next(int.MaxValue);
			}

			public int Next(int value)
			{
				return al.Next(value);
			}

			public int Next(int min, int max)
			{
				return al.Next(min, max);
			}
		}

		public class ArithmeticUtils
		{
			public static bool CheckArithmetic(Instruction instruction)
			{
				if (!instruction.IsLdcI4())
				{
					return false;
				}
				if (instruction.GetLdcI4Value() == 1)
				{
					return false;
				}
				if (instruction.GetLdcI4Value() == 0)
				{
					return false;
				}
				return true;
			}

			public static double GetY(double x)
			{
				return x / 2.0;
			}

			public static MethodInfo GetMethod(ArithmeticTypes mathType)
			{
				switch (mathType)
				{
				default:
					return null;
				case ArithmeticTypes.Abs:
					return typeof(Math).GetMethod("Abs", new Type[1] { typeof(double) });
				case ArithmeticTypes.Log:
					return typeof(Math).GetMethod("Log", new Type[1] { typeof(double) });
				case ArithmeticTypes.Log10:
					return typeof(Math).GetMethod("Log10", new Type[1] { typeof(double) });
				case ArithmeticTypes.Sin:
					return typeof(Math).GetMethod("Sin", new Type[1] { typeof(double) });
				case ArithmeticTypes.Cos:
					return typeof(Math).GetMethod("Cos", new Type[1] { typeof(double) });
				case ArithmeticTypes.Round:
					return typeof(Math).GetMethod("Round", new Type[1] { typeof(double) });
				case ArithmeticTypes.Sqrt:
					return typeof(Math).GetMethod("Sqrt", new Type[1] { typeof(double) });
				case ArithmeticTypes.Ceiling:
					return typeof(Math).GetMethod("Ceiling", new Type[1] { typeof(double) });
				case ArithmeticTypes.Floor:
					return typeof(Math).GetMethod("Floor", new Type[1] { typeof(double) });
				case ArithmeticTypes.Tan:
					return typeof(Math).GetMethod("Tan", new Type[1] { typeof(double) });
				case ArithmeticTypes.Tanh:
					return typeof(Math).GetMethod("Tanh", new Type[1] { typeof(double) });
				case ArithmeticTypes.Truncate:
					return typeof(Math).GetMethod("Truncate", new Type[1] { typeof(double) });
				}
			}

			public static OpCode GetOpCode(ArithmeticTypes arithmetic)
			{
				switch (arithmetic)
				{
				default:
					return null;
				case ArithmeticTypes.Sub:
					return OpCodes.Sub;
				case ArithmeticTypes.Add:
					return OpCodes.Add;
				}
			}
		}
	}
}
