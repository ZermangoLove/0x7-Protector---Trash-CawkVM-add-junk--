using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Pdb;
using dw;
using ICore;

namespace Protections.ControlFlow
{
	public class ControlFlow
	{
		public static void Execute(Context context)
		{
			MethodDef methodDef = context.Module.GlobalType.FindOrCreateStaticConstructor();
			foreach (TypeDef type in context.Module.GetTypes())
			{
				if (type.Namespace == "Costura")
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					if (method.HasBody && method.Body.HasInstructions && method.ReturnType != null && methodDef != method)
					{
						PhaseControlFlow(method, context);
					}
				}
			}
		}

		public static void Execute2(Context context)
		{
			MethodDef methodDef = context.Module.GlobalType.FindOrCreateStaticConstructor();
			foreach (TypeDef type in context.Module.GetTypes())
			{
				if (type.Namespace == "Costura")
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					if (method.HasBody && method.Body.HasInstructions && method.ReturnType != null && methodDef != method)
					{
						PhaseControlFlow2(method, context);
					}
				}
			}
		}

		public static void Execute3(Context context)
		{
			MethodDef methodDef = context.Module.GlobalType.FindOrCreateStaticConstructor();
			foreach (TypeDef type in context.Module.GetTypes())
			{
				if (type.Namespace == "Costura")
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					if (method.HasBody && method.Body.HasInstructions && method.ReturnType != null && methodDef != method)
					{
						PhaseControlFlow3(method, context);
					}
				}
			}
		}

		public static void PhaseControlFlow(MethodDef method, Context context)
		{
			CilBody body = method.Body;
			body.SimplifyBranches();
			cK.hd hd = cK.cM(body);
			new dy().cY(body, hd, context, method, method.ReturnType);
			body.Instructions.Clear();
			hd.gW(body);
			if (body.PdbMethod != null)
			{
				body.PdbMethod = new PdbMethod
				{
					Scope = new PdbScope
					{
						Start = body.Instructions.First(),
						End = body.Instructions.Last()
					}
				};
			}
			method.CustomDebugInfos.RemoveWhere((PdbCustomDebugInfo cdi) => cdi is PdbStateMachineHoistedLocalScopesCustomDebugInfo);
			foreach (ExceptionHandler exceptionHandler in body.ExceptionHandlers)
			{
				int num = body.Instructions.IndexOf(exceptionHandler.TryEnd) + 1;
				exceptionHandler.TryEnd = ((num < body.Instructions.Count) ? body.Instructions[num] : null);
				num = body.Instructions.IndexOf(exceptionHandler.HandlerEnd) + 1;
				exceptionHandler.HandlerEnd = ((num < body.Instructions.Count) ? body.Instructions[num] : null);
			}
		}

		public static void PhaseControlFlow2(MethodDef method, Context context)
		{
			CilBody body = method.Body;
			body.SimplifyBranches();
			cK.hd hd = cK.cM(body);
			new dg().cY(body, hd, context, method, method.ReturnType);
			body.Instructions.Clear();
			hd.gW(body);
			if (body.PdbMethod != null)
			{
				body.PdbMethod = new PdbMethod
				{
					Scope = new PdbScope
					{
						Start = body.Instructions.First(),
						End = body.Instructions.Last()
					}
				};
			}
			method.CustomDebugInfos.RemoveWhere((PdbCustomDebugInfo cdi) => cdi is PdbStateMachineHoistedLocalScopesCustomDebugInfo);
			foreach (ExceptionHandler exceptionHandler in body.ExceptionHandlers)
			{
				int num = body.Instructions.IndexOf(exceptionHandler.TryEnd) + 1;
				exceptionHandler.TryEnd = ((num < body.Instructions.Count) ? body.Instructions[num] : null);
				num = body.Instructions.IndexOf(exceptionHandler.HandlerEnd) + 1;
				exceptionHandler.HandlerEnd = ((num < body.Instructions.Count) ? body.Instructions[num] : null);
			}
		}

		public static void PhaseControlFlow3(MethodDef method, Context context)
		{
			CilBody body = method.Body;
			body.SimplifyBranches();
			cK.hd hd = cK.cM(body);
			new dx().cY(body, hd, context, method, method.ReturnType);
			body.Instructions.Clear();
			hd.gW(body);
			if (body.PdbMethod != null)
			{
				body.PdbMethod = new PdbMethod
				{
					Scope = new PdbScope
					{
						Start = body.Instructions.First(),
						End = body.Instructions.Last()
					}
				};
			}
			method.CustomDebugInfos.RemoveWhere((PdbCustomDebugInfo cdi) => cdi is PdbStateMachineHoistedLocalScopesCustomDebugInfo);
			foreach (ExceptionHandler exceptionHandler in body.ExceptionHandlers)
			{
				int num = body.Instructions.IndexOf(exceptionHandler.TryEnd) + 1;
				exceptionHandler.TryEnd = ((num < body.Instructions.Count) ? body.Instructions[num] : null);
				num = body.Instructions.IndexOf(exceptionHandler.HandlerEnd) + 1;
				exceptionHandler.HandlerEnd = ((num < body.Instructions.Count) ? body.Instructions[num] : null);
			}
		}
	}
}
