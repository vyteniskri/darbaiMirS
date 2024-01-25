using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CMatch.Content;
using Antlr4.Runtime.Tree;

namespace CMatch
{
	public class CMatchVisitor : CMatchBaseVisitor<object?>
	{
		//V------------
		public record ReturnValue(object? value) 
		{
    		public object? getValue() 
			{
        		return value;
    		}
		}

		public class SymbolTable 
		{
   			private Dictionary<string, object?> table;
    		public SymbolTable() 
			{
        		table = new();
    		}
    		public void Add(string name, object value) 
			{
        		table.Add(name, value);
    		}
    		public object? Get(string name)
			{
        		return table[name];
    		}
    		public void setTable(Dictionary<string, object?> value)
			{
        		table=value;
    		}
    		public Dictionary<string, object?> getTable()
			{
        		return table;
    		}
    		public bool contains(string name) 
			{
        		return table.ContainsKey(name);
    		}
		}
		//V------------

		private Dictionary<string, object?> Variables {get; set;} = new();

		private Dictionary<string, CMatchParser.FunctionDeclareContext> functions {get; set;} = new();
		//private SymbolTable symbolTable = new SymbolTable();

		private int blockCounter = -1;
		public CMatchVisitor()
		{
			Variables["PI"] = Math.PI;
			Variables["E"] = Math.E;

			Variables["WriteLine"] = new Func<object?[], object?>(WriteLine);
			Variables["ReadFile"] = new Func<object?[], object?>(ReadFile);
			Variables["AppendFile"] = new Func<object?[], object?>(AppendFile);
			Variables["WriteFile"] = new Func<object?[], object?>(WriteFile);
			Variables["F"] = new Func<object?[], object?>(F);
			Variables["ABS"] = new Func<object?[], object?>(ABS);
			Variables["ReadLine"] = new Func<object?[], object?>(ReadLine);
		}


		private object? F(object?[] args)
		{
			
			return null;
		}
		private object? ReadLine(object?[] args)
		{
			Console.WriteLine("Enter input:");
    		string input = Console.ReadLine();
    		return input;
		}
		private object? ABS(object?[] args)
		{
			if(args.Length == 1)
			{
				if(int.TryParse(args[0].ToString(), out int negativeI))
				{
					return Math.Abs(negativeI);
				}
				else if(double.TryParse(args[0].ToString(), out double negativeD))
				{
					return Math.Abs(negativeD);
				}
				return false;
			}
			throw new Exception("Wrong args count in ABS it need to be only 1");
		}
		private object? WriteLine(object?[] args)
		{
			foreach (var arg in args)
			{
				Console.WriteLine(arg);
			}
			return null;
		}
		private object? ReadFile(object?[] args)
		{
			if(args.Length == 1)
			{
				string filePath = args[0].ToString();
				if(File.Exists(filePath))
				{
					return File.ReadAllText(filePath);
				}
				throw new Exception("File doesn't exists");
			}
			else
			{
				return null;
			}
		}
		private object? AppendFile(object?[] args)
		{
			if(args.Length == 2)
			{
				string filePath = args[0].ToString();
				string varName = args[1].ToString();
				var var = "";
				if(!Variables.ContainsKey(varName))
				{
					var = varName.ToString();
				}
				else 
				{
					var = Variables[varName].ToString();
				}

				if(File.Exists(filePath))
				{
					File.AppendAllText(filePath, "\n"+var);
				}
				else
				{
					return false;
				}
				return true;
			}
			else
			{
				throw new Exception("Wrong args count in AppendFile");
			}
		}
    	private object? WriteFile(object?[] args)
		{
			if(args.Length == 2)
			{
				string filePath = args[0].ToString();
				string varName = args[1].ToString();
				var var = "";
				if(!Variables.ContainsKey(varName))
				{
					var = varName.ToString();
				}
				else 
				{
					var = Variables[varName].ToString();
				}

				if(File.Exists(filePath))
				{
					File.Delete(filePath);
				}
				File.WriteAllText(filePath, var);
				return true;
			}
			else
			{
				throw new Exception("Wrong args count in WriteFile");
			}
		}

		///V----------------------------------
		public override object? VisitFunctionalCall(CMatchParser.FunctionalCallContext context)
        {

			string functionName = context.IDENTIFIER().GetText();
			
			Dictionary<string, object?> old = new Dictionary<string, object?>(Variables);

			if (!functions.ContainsKey(functionName))
			{
				throw new Exception($"Function  {functionName}  is not defined.");
			}

			CMatchParser.FunctionDeclareContext function = this.functions[functionName];

			List<Object> arguments = new List<object>();
			if (context.expressionList() != null)
			{
				foreach (var expr in context.expressionList().expression()) 
				{
                	arguments.Add(this.Visit(expr));
            	}
			}

			if (arguments.Count() != function.parameterList().IDENTIFIER().Count())
			{
				 throw new Exception($"Incorrect number of arguments for Function {functionName}.");
			}

			for (int i = 0; i < function.parameterList().IDENTIFIER().Count(); i++)
			{
				if (function.parameterList().IDENTIFIER(i) != null)
				{
					String paramName1 = function.parameterList().IDENTIFIER(i).GetText();
					//symbolTable.Add(paramName1, arguments[i]); 
					Variables[paramName1] = arguments[i];
				}
				else
				{
					String paramName2 = function.parameterList().IDENTIFIER(i).GetText();
					//symbolTable.Add(paramName2, arguments[i]); 
					Variables[paramName2] = arguments[i];
				}
				
			}
			
			ReturnValue value = (ReturnValue) this.VisitBlock(function.block());
			//object? value = VisitBlock(function.block());
			//symbolTable.setTable(old);
			Variables = old;
		
			return value;


        }
    	
		public override object? VisitFunctionDeclare(CMatchParser.FunctionDeclareContext context)
		{

			string functionName = context.IDENTIFIER().GetText();

			if (functions.ContainsKey(functionName))
			{
				throw new Exception($"Function  {functionName}  is already defined.");
			}

			functions[functionName] = context;
			return null;


			// if (function.parameterList() != null)
			// {
			// 	String paramName = function.parameterList().IDENTIFIER().GetText();
			// }
			
			// var name = context.IDENTIFIER().GetText();
			// var args = context.expressionList()?.expression().Select(Visit).ToArray();

			// if (!(Variables.ContainsKey(name)))
			// {
			// 	throw new Exception($"Function {name} is not defined.");
			// }

			// if (Variables[name] is not Func<object?[], object?> func)
			// {
			// 	throw new Exception($"Variable {name} is not a function.");
			// }

			// return func(args);
		}

		protected override bool ShouldVisitNextChild(IRuleNode node, object? currentResult) 
		{
        	return !(currentResult is ReturnValue);
    	}
    	public override object? VisitReturnStatement(CMatchParser.ReturnStatementContext context) 
		{
     		if (context.expression() == null) 
			{
            	return new ReturnValue(null);
        	} 
			else 
			{
            	return new ReturnValue(this.Visit(context.expression()));
        	}
    	}

		public override object? VisitBlock(CMatchParser.BlockContext context) 
		{
        	object? value = base.VisitBlock(context);
        	if (value is ReturnValue) {
            	return value;
        	}
        	return new ReturnValue(null);
    	}
		
		///V-------------------------
		public override object? VisitFunctionCall(CMatchParser.FunctionCallContext context)
		{
			var name = context.IDENTIFIER().GetText();
			var args = context.expression().Select(Visit).ToArray();
			if (!(Variables.ContainsKey(name)))
			{
				throw new Exception($"Function {name} is not defined.");
			}

			if (Variables[name] is not Func<object?[], object?> func)
			{
				throw new Exception($"Variable {name} is not a function.");
			}
			return func(args);
		}
		public override object? VisitAssigment(CMatchParser.AssigmentContext context)
		{
			var varName = context.IDENTIFIER().GetText();
			var value = Visit(context.expression());

			Variables[varName] = value;
			return null;
		}
		public override object? VisitIdentifierExpression(CMatchParser.IdentifierExpressionContext context)
		{
			var varName = context.IDENTIFIER().GetText();
			if(!Variables.ContainsKey(varName))
			{
				throw new Exception($"Variables {varName} is not defined");
			}
			return Variables[varName];
		}
		public override object? VisitConstant(CMatchParser.ConstantContext context)
		{
			if (context.INTEGER() is { } i)
			{
				return int.Parse(i.GetText());
			}
			if (context.DOUBLE() is { } d)
			{
				try
				{
					string value = d.GetText();
					string[] values = value.Split('.');
					if(int.TryParse(values[1], out int lastNumbers))
					{
						if(lastNumbers <= 0)
						{
							return int.Parse(values[0]);
						}
					}
					return double.Parse(d.GetText());
				}
				catch
				{
					throw new Exception("Can't parse to double.");
				}
				
			}
			if (context.STRING() is { } s)
			{
				return s.GetText()[1..^1];
				//return s.GetText()[1..^1];
			}
			// if(context.SYMBOL() is { } sym)
			// {
			// 	if(context.GetText()[0] == '\'' && context.GetText()[2] == '\'')
			// 	{
			// 	return char.Parse(sym.GetText());
			// 	}
			// 	else
			// 	{
			// 		throw new Exception($"Cannot convert into char");
			// 	}
			// }
			if (context.BOOL() is { } b)
			{
				return b.GetText() == "true";
			}
			if(context.TOUPLE() is { } t)
			{
				return t.GetText();
			}
			if (context.NULL() is { })
			{
				return null;
			}

			throw new NotImplementedException();
		}

		public override object? VisitComparisonExpression(CMatchParser.ComparisonExpressionContext context) 
		{
			var left = Visit(context.expression(0));
			var right = Visit(context.expression(1));

			var op = context.compareOp().GetText();

			return op switch
			{
				"==" => IsEquals(left, right),
				"!=" => NotEquals(left, right),
				">" => GreaterThan(left, right),
				">=" => GreaterThanOrEqual(left, right),
				"<" => LessThan(left, right),
				"<=" => LessThanOrEqual(left, right),
				_ => throw new NotImplementedException()
			};
		}
		private bool IsEquals(object? left, object? right)
		{
			if(left is int l && right is int r)
			{
				return l == r;
			}

			if(left is double ld && right is double rd)
			{
				return ld == rd;
			}

			if(left is int lInt && right is double rDouble)
			{
				return lInt == rDouble;
			}

			if(left is double lDouble && right is int rInt)
			{
				return lDouble == rInt;
			}

			// if(left is string || right is string)	pavyzdinei nedare sito
			// {
			// 	return $"{left}{right}" == $"{left}{right}";
			// }

			throw new Exception($"Cannot compare values of types {left?.GetType()} and {right?.GetType()}.");
			
		}
		private bool NotEquals(object? left, object? right)
		{
			if(left is int l && right is int r)
			{
				return l != r;
			}

			if(left is double ld && right is double rd)
			{
				return ld != rd;
			}

			if(left is int lInt && right is double rDouble)
			{
				return lInt != rDouble;
			}

			if(left is double lDouble && right is int rInt)
			{
				return lDouble != rInt;
			}

			// if(left is string || right is string)	pavyzdinei nedare sito
			// {
			// 	return $"{left}{right}" != $"{left}{right}";
			// }

			throw new Exception($"Cannot compare values of types {left?.GetType()} and {right?.GetType()}.");
			
		}
		private bool GreaterThan(object? left, object? right)
		{
			if(left is int l && right is int r)
			{
				return l > r;
			}

			if(left is double ld && right is double rd)
			{
				return ld > rd;
			}

			if(left is int lInt && right is double rDouble)
			{
				return lInt > rDouble;
			}

			if(left is double lDouble && right is int rInt)
			{
				return lDouble > rInt;
			}

			// if(left is string || right is string)	pavyzdinei nedare sito
			// {
			// 	return $"{left}{right}" > $"{left}{right}";
			// }

			throw new Exception($"Cannot compare values of types {left?.GetType()} and {right?.GetType()}.");
			
		}
		private bool GreaterThanOrEqual(object? left, object? right)
		{
			if(left is int l && right is int r)
			{
				return l >= r;
			}

			if(left is double ld && right is double rd)
			{
				return ld >= rd;
			}

			if(left is int lInt && right is double rDouble)
			{
				return lInt >= rDouble;
			}

			if(left is double lDouble && right is int rInt)
			{
				return lDouble >= rInt;
			}

			// if(left is string || right is string)	pavyzdinei nedare sito
			// {
			// 	return $"{left}{right}" >= $"{left}{right}";
			// }

			throw new Exception($"Cannot compare values of types {left?.GetType()} and {right?.GetType()}.");
			
		}
		private bool LessThan(object? left, object? right)
		{
			if(left is int l && right is int r)
			{
				return l < r;
			}

			if(left is double ld && right is double rd)
			{
				return ld < rd;
			}

			if(left is int lInt && right is double rDouble)
			{
				return lInt < rDouble;
			}

			if(left is double lDouble && right is int rInt)
			{
				return lDouble < rInt;
			}

			// if(left is string || right is string)	pavyzdinei nedare sito
			// {
			// 	return $"{left}{right}" < $"{left}{right}";
			// }

			throw new Exception($"Cannot compare values of types {left?.GetType()} and {right?.GetType()}.");
			
		}
		private bool LessThanOrEqual(object? left, object? right)
		{
			if(left is int l && right is int r)
			{
				return l <= r;
			}

			if(left is double ld && right is double rd)
			{
				return ld <= rd;
			}

			if(left is int lInt && right is double rDouble)
			{
				return lInt <= rDouble;
			}

			if(left is double lDouble && right is int rInt)
			{
				return lDouble <= rInt;
			}

			// if(left is string || right is string)	pavyzdinei nedare sito
			// {
			// 	return $"{left}{right}" < $"{left}{right}";
			// }

			throw new Exception($"Cannot compare values of types {left?.GetType()} and {right?.GetType()}.");
			
		}

		public override object? VisitAdditiveExpression(CMatchParser.AdditiveExpressionContext context)
		{
			var left = Visit(context.expression(0));
			var right = Visit(context.expression(1));
			var op = context.addOp().GetText();
			return op switch
			{
				"+" => Add(left,right),
				"-" => Substract(left,right),
				_ => throw new NotImplementedException()
			};
		}
		private object? Add(object? left, object? right)
		{
			if (left is int l && right is int r)
				return l + r;
			if (left is double lf && right is double rf)
				return lf + rf;
			if (left is int lInt && right is double rFloat)
				return lInt + rFloat;
			if (left is double lFloat && right is int rInt)
				return lFloat + rInt;
			if (left is string || right is string)
				return $"{left}{right}";
			throw new Exception($"Cannot add values of types {left?.GetType()} {left} and {right?.GetType()} {right}.");
		}
		private object? Substract(object? left, object? right)
		{
			if (left is int l && right is int r)
				return l - r;
			if (left is double lf && right is double rf)
				return lf - rf;
			if (left is int lInt && right is double rFloat)
				return lInt - rFloat;
			if (left is double lFloat && right is int rInt)
				return lFloat - rInt;
			if (left is string || right is string)
				return $"{left}{right}";
			throw new Exception($"Cannot substract values of types {left?.GetType()} and {right?.GetType()}.");
		}
		public override object? VisitMultiplicativeExpression(CMatchParser.MultiplicativeExpressionContext context)
		{
			var left = Visit(context.expression(0));
			var right = Visit(context.expression(1));
			var op = context.multOp().GetText();
			return op switch
			{
				"*" => Multiply(left,right),
				"/" => Divide(left,right),
				"%" => Remain(left,right),
				_ => throw new NotImplementedException()
			};
		}
		private object? Multiply(object? left, object? right)
		{
			if (left is int l && right is int r)
				return l * r;
			if (left is double ld && right is double rd)
				return ld * rd;
			if (left is int lInt && right is double rDouble)
				return lInt * rDouble;
			if (left is double lDouble && right is int rInt)
				return lDouble * rInt;
			throw new Exception($"Cannot multiply values of types {left?.GetType()} and {right?.GetType()}.");
		}
		private object? Divide(object? left, object? right)
		{
			if (left is int l && right is int r)
				return l / r;
			if (left is double ld && right is double rd)
				return ld / rd;
			if (left is int lInt && right is double rDouble)
				return lInt / rDouble;
			if (left is double lDouble && right is int rInt)
				return lDouble / rInt;
			throw new Exception($"Cannot divide values of types {left?.GetType()} and {right?.GetType()}.");
		}
		private object? Remain(object? left, object? right)
		{
			if (left is int l && right is int r)
				return l % r;
			if (left is double ld && right is double rd)
				return ld % rd;
			if (left is int lInt && right is double rDouble)
				return lInt % rDouble;
			if (left is double lDouble && right is int rInt)
				return lDouble % rInt;
			throw new Exception($"Cannot remain values of types {left?.GetType()} and {right?.GetType()}.");
		}	
		public override object? VisitStatementfor(CMatchParser.StatementforContext context)
        {
            Dictionary<string, object?> OuterScopeVars = Variables;
            Visit(context.assigment(0));
            while (IsTrue(Visit(context.expression())))
            {
                Visit(context.block());
                Visit(context.assigment(1));
            }
            Variables = OuterScopeVars;
            return null;
        }
		public override object? VisitStatementif(CMatchParser.StatementifContext context)
        {
            if (IsTrue(Visit(context.expression())))
            {
                Visit(context.block());
            }
            else
            {
                try
                {
                    Visit(context.statmentelseif());
                }
                catch (Exception a)
                {
	
                }

            }
			return null;
        }
		private bool IsTrue(object? value)
		{
			if(value is bool b)
				return b;

			throw new Exception("Value is not boolean.");
		}
		public bool IsFalse(object? value) => !IsTrue(value);

		//-------------------------------------------------------------------------------------------------------------------------
		
    	public override object? VisitStatmentmatch(CMatchParser.StatmentmatchContext context)
    	{	
			blockCounter++;
			CMatchParser.PatternContext pattern;
			while((pattern = context.pattern(blockCounter)) != null)
			{
				if(VisitPattern(pattern, context))
				{
					break;
				}
				blockCounter++;
			}
        	// switch (context.identifierPattern().GetType())
        	// {
            // 	case typeof(int):
            //     	Console.WriteLine("Integer value: " + intValue);
            //     	break;
            // 	case  strValue when strValue.Length > 5:
            //     	Console.WriteLine("Long string value: " + strValue);
            //     	break;
            // 	case string strValue:
            //     	Console.WriteLine("Short string value: " + strValue);
            //     	break;
            // 	case null:
            //     	Console.WriteLine("Null value");
            //     	break;
            // 	default:
            //     	Console.WriteLine("Unknown value");
            //     	break;
       		// }
			return null;
		}
		public bool VisitPattern(CMatchParser.PatternContext pattern, CMatchParser.StatmentmatchContext context)
		{
    		if (pattern.primaryPattern() != null)
    		{
        		return MatchPrimaryPattern(pattern.primaryPattern(), context);
    		}
    		// Handle other pattern types if needed

    		return false; // Default return value if no pattern matches
		}

		public bool MatchPrimaryPattern(CMatchParser.PrimaryPatternContext primaryPattern, CMatchParser.StatmentmatchContext context)
		{
			try
			{
				var givenValueName = context.identifierPattern().IDENTIFIER().GetText();// reiskias kad paduotas value po match yra kintamasis
				if(!Variables.ContainsKey(givenValueName))
				{
					throw new Exception($"Variables {givenValueName} is not defined");
				}

		    	if (primaryPattern.constantPattern() != null)
		    	{
		    	    return MatchConstantPattern(primaryPattern.constantPattern(), context);
		    	}
		    	else if (primaryPattern.wildcardPattern() != null)
		    	{
		    	    return MatchWildcardPattern(primaryPattern.wildcardPattern(), context);
		    	}
				else if(primaryPattern.decimalNumbersTail() != null)
				{
					return MatchDecimalNumbersTailPattern(primaryPattern.decimalNumbersTail(), context);
				}
				else if(primaryPattern.decimalNumbersHead() != null)
				{
					return MatchDecimalNumbersHeadPattern(primaryPattern.decimalNumbersHead(), context);
				}
				else if ( primaryPattern.touplePattern() != null)
				{
					return MatchTouplePattern(primaryPattern.touplePattern(), context);
				}
		   	 return false; // Default return value if no primary pattern matches
			}
			catch
			{
				throw new Exception($"MatchPrimaryPattern crashed");
			}
		}

		public bool MatchConstantPattern(CMatchParser.ConstantPatternContext constantPattern, CMatchParser.StatmentmatchContext context)
		{
			string constantValue = constantPattern.GetText();
			object? givenValue = "";

			try{
			  	var givenValueName = context.identifierPattern().IDENTIFIER().GetText();// reiskias kad paduotas value po match yra kintamasis
			  	if(!Variables.ContainsKey(givenValueName))
			 	{
					throw new Exception($"Variables {givenValueName} is not defined");
			  	}
			  	else
			  	{
					givenValue = Variables[givenValueName];
				
					switch(constantValue)
					{
					case "constint":
					if(givenValue is int)
					{
						Visit(context.block(blockCounter));
						return true;
					}
					break;
					case "conststring" :
					{
						//"^[a-zA-Z0-9]+$"
						//string pattern = "[A-za-z]([A-Za-z0-9]+)?";
						//if(!(bool.TryParse(givenValue, out bool booolean))&&(Regex.IsMatch(givenValue, pattern)))
						//if(givenValue.GetType() == typeof(string))
						//if(givenValue.Length >= 3)
						//if(givenValue.StartsWith('"') && givenValue.EndsWith('"')) //reiktu padaryt kad bandytu parsint kaip string, bet tada reikia given value keist
						if (givenValue is string)
						{
							Visit(context.block(blockCounter));
							return true;
						}
					}
					break;
					case "constdouble" :
					{
						if (givenValue is double)
						{
							Visit(context.block(blockCounter));
							return true;
						}
					}
					break;
					case "constbool" :
					{
						if (givenValue is bool)
						{
							Visit(context.block(blockCounter));
							return true;
						}
					}
					break;
					default:
					{
					    return MakeFurtherChecks(constantValue, givenValue, context);
					}
					};	
			  	}
			}
			catch (Exception e)
			{
				throw new Exception($"Variable undefind in MatchconstantPattern");
			}
			  
			//}
		    return false; // Default return value if constant pattern doesn't match
		}
		public bool MakeFurtherChecks(string constantValue, object? givenValue, CMatchParser.StatmentmatchContext context)
		{
			string trimmedConstantValue = constantValue.TrimEnd('"');
			trimmedConstantValue = trimmedConstantValue.TrimStart('"');
			
			if(constantValue==givenValue.ToString() && givenValue is int)
			{
				Visit(context.block(blockCounter));
				return true;
			}
			if(constantValue.StartsWith('"') && constantValue.EndsWith('"'))
			{

				if(trimmedConstantValue==givenValue.ToString())
				{
					Visit(context.block(blockCounter));
					return true;
				}
			}

			if(givenValue is string) //if the given value is a text
			{
				string[] BigGivenText = givenValue.ToString().Split(' ');
				foreach (string word in BigGivenText)
				{
					if(trimmedConstantValue == word)
					{
						Visit(context.block(blockCounter));
						return true;
					}
				}

			}
			
			return false;
		}
		public bool MatchDecimalNumbersTailPattern(CMatchParser.DecimalNumbersTailContext decimalNumbers, CMatchParser.StatmentmatchContext context)
		{
			try{
				string constantValue = decimalNumbers.GetText();
			    object? givenValue = "";
				var givenValueName = context.identifierPattern().IDENTIFIER().GetText();// reiskias kad paduotas value po match yra kintamasis
			  	if(!Variables.ContainsKey(givenValueName)) throw new Exception($"Variables {givenValueName} is not defined");
			  	else
			  	{
					givenValue = Variables[givenValueName];
					if(!(givenValue is double) || !givenValue.ToString().Contains('.')) return false;
					string[] values = constantValue.Split('.');
					constantValue = values[0];
					if(!int.TryParse(values[1], out int intNumber)) return false;
					switch(constantValue)
					{
					case "#":
						if(givenValue is double)
						{
							double.TryParse(givenValue.ToString(), out double temp);
							if(CheckDecimalTailEquals(temp, intNumber, 1))
							{
								Visit(context.block(blockCounter));
								return true;
							}
							return false;
						}
					break;
					case "##":
					{
						if(givenValue is double)
						{
							double.TryParse(givenValue.ToString(), out double temp);
							if(CheckDecimalTailEquals(temp, intNumber, 2))
							{
								Visit(context.block(blockCounter));
								return true;
							}
							return false;
						}
					}
					break;
					case "###" :
					{
						if(givenValue is double)
						{
							double.TryParse(givenValue.ToString(), out double temp);
							if(CheckDecimalTailEquals(temp, intNumber, 3))
							{
								Visit(context.block(blockCounter));
								return true;
							}
							return false;
						}
					}
					break;
					case "####" :
					{
						if(givenValue is double)
						{
							double.TryParse(givenValue.ToString(), out double temp);
							if(CheckDecimalTailEquals(temp, intNumber, 4))
							{
								Visit(context.block(blockCounter));
								return true;
							}
							return false;
						}
					}
					break;
					case "-#":
						if(givenValue is double)
						{
							double.TryParse(givenValue.ToString(), out double temp);
							if(CheckDecimalTailEquals(temp, intNumber, 2))
							{
								Visit(context.block(blockCounter));
								return true;
							}
							return false;
						}
					break;
					case "-##":
					{
						if(givenValue is double)
						{
							double.TryParse(givenValue.ToString(), out double temp);
							if(CheckDecimalTailEquals(temp, intNumber, 3))
							{
								Visit(context.block(blockCounter));
								return true;
							}
							return false;
						}
					}
					break;
					case "-###" :
					{
						if(givenValue is double)
						{
							double.TryParse(givenValue.ToString(), out double temp);
							if(CheckDecimalTailEquals(temp, intNumber, 4))
							{
								Visit(context.block(blockCounter));
								return true;
							}
							return false;
						}
					}
					break;
					case "-####" :
					{
						if(givenValue is double)
						{
							double.TryParse(givenValue.ToString(), out double temp);
							if(CheckDecimalTailEquals(temp, intNumber, 5))
							{
								Visit(context.block(blockCounter));
								return true;
							}
							return false;
						}
					}
					break;
					default:
					return false;
					};	
				}
			}
			catch (Exception ex) { throw new Exception($"Error in decimal tail pattern checker"); }
			return false;
		}
		public bool CheckDecimalTailEquals(double doubleNum, int intNumber, int quantity)
		{
			// Convert the double number to a string
    		string numStr = doubleNum.ToString();
    		// Split the string at the decimal point
    		string[] parts = numStr.Split('.');
    		// Convert the decimal part string to an integer
    		int decimalInt = int.Parse(parts[1]);
			switch(quantity)
			{
				case 1:
				if(parts[0].Length == 1)
				{
					break;
				}
				return false;
				case 2:
				if(parts[0].Length == 2)
				{
					break;
				}
				return false;
				case 3:
				if(parts[0].Length == 3)
				{
					break;
				}
				return false;
				case 4:
				if(parts[0].Length == 4)
				{
					break;
				}
				return false;
				case 5:
				if(parts[0].Length == 5)
				{
					break;
				}
				return false;
				default:
				return false;
			}
    		// Compare the decimal part integer with the given integer
    		if (decimalInt == intNumber) return true;
			return false;
 
		}
		public bool MatchDecimalNumbersHeadPattern(CMatchParser.DecimalNumbersHeadContext decimalNumbers, CMatchParser.StatmentmatchContext context)
		{
			try{
				string constantValue = decimalNumbers.GetText();
			    object? givenValue = "";
				var givenValueName = context.identifierPattern().IDENTIFIER().GetText();// reiskias kad paduotas value po match yra kintamasis
			  	if(!Variables.ContainsKey(givenValueName)) throw new Exception($"Variables {givenValueName} is not defined");
			  	else
			  	{
					givenValue = Variables[givenValueName];
					if(!(givenValue is double) || !givenValue.ToString().Contains('.')) return false;
					string[] values = constantValue.Split('.');
					constantValue = values[1];
					if(!int.TryParse(values[0], out int intNumber)) return false;
					switch(constantValue)
					{
					case "#":
						if(givenValue is double)
						{
							double.TryParse(givenValue.ToString(), out double temp);
							if(CheckDecimalHeadEquals(temp, intNumber, 1))
							{
								Visit(context.block(blockCounter));
								return true;
							}
							return false;
						}
					break;
					case "##":
					{
						if(givenValue is double)
						{
							double.TryParse(givenValue.ToString(), out double temp);
							if(CheckDecimalHeadEquals(temp, intNumber, 2))
							{
								Visit(context.block(blockCounter));
								return true;
							}
							return false;
						}
					}
					break;
					case "###" :
					{
						if(givenValue is double)
						{
							double.TryParse(givenValue.ToString(), out double temp);
							if(CheckDecimalHeadEquals(temp, intNumber, 3))
							{
								Visit(context.block(blockCounter));
								return true;
							}
							return false;
						}
					}
					break;
					case "####" :
					{
						if(givenValue is double)
						{
							double.TryParse(givenValue.ToString(), out double temp);
							if(CheckDecimalHeadEquals(temp, intNumber, 4))
							{
								Visit(context.block(blockCounter));
								return true;
							}
							return false;
						}
					}
					break;
					default:
					return false;
					};	
				}
			}
			catch (Exception ex) { throw new Exception($"Error in decimal head pattern checker"); }
			return false;
		}
		public bool CheckDecimalHeadEquals(double doubleNum, int intNumber, int quantity)
		{
			// Convert the double number to a string
    		string numStr = doubleNum.ToString();
    		// Split the string at the decimal point
    		string[] parts = numStr.Split('.');
    		// Convert the decimal part string to an integer
    		int decimalInt = int.Parse(parts[0]);
			switch(quantity)
			{
				case 1:
				if(parts[1].Length == 1)
				{
					break;
				}
				return false;
				case 2:
				if(parts[1].Length == 2)
				{
					break;
				}
				return false;
				case 3:
				if(parts[1].Length == 3)
				{
					break;
				}
				return false;
				case 4:
				if(parts[1].Length == 4)
				{
					break;
				}
				return false;
				default:
				return false;
			}
    		// Compare the decimal part integer with the given integer
    		if (decimalInt == intNumber) return true;
			return false;
 
		}
		public bool MatchTouplePattern(CMatchParser.TouplePatternContext touple, CMatchParser.StatmentmatchContext context)
		{
			string toupleValue = touple.GetText();// po case duota verte
			string givenValue = "";

			try{
			  	var givenValueName = context.identifierPattern().IDENTIFIER().GetText();// reiskias kad paduotas value po match yra kintamasis
			  	if(!Variables.ContainsKey(givenValueName))
			 	{
					throw new Exception($"Variable {givenValueName} is not defined");
			  	}
			  	else
			  	{
					givenValue = Variables[givenValueName].ToString();
				
					string[] splitTouple = toupleValue.Split(',');
					string splitToupleFirst = splitTouple[0];
					string splitToupleSecond = splitTouple[1];
					

					var pradzia = givenValue[0];
					var pabaiga = givenValue[givenValue.Length -1 ];
					if(givenValue[0] == '(' && givenValue[givenValue.Length -1 ] == ')')
					{
						string[] splitGivenValue = givenValue.Split(',');
						string splitGivenValueFirst = splitGivenValue[0];
						string splitGivenValueSecond = splitGivenValue[1];
						if(splitToupleFirst == "(#")
						{
							if(splitToupleSecond == splitGivenValueSecond)
							{
								Visit(context.block(blockCounter));
								return true;
							}
						}
						if(splitToupleSecond == "#)")
						{
							if(splitToupleFirst == splitGivenValueFirst)
							{
								Visit(context.block(blockCounter));
								return true;
							}
						}
					}
				}
			}
			catch (Exception ex) { throw new Exception($"Error in touplepattern checker"); }
			return false;
		}
		public bool MatchWildcardPattern(CMatchParser.WildcardPatternContext wildcardPattern, CMatchParser.StatmentmatchContext context)
		{
		    // Implement logic to match wildcard patterns
		    // A wildcard pattern matches any value, so you can always return true for this case
			Visit(context.block(blockCounter));
		    return true; // Wildcard pattern always matches
		}
	}
}