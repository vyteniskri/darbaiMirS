using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CMatch;
using CMatch.Content;
using static System.Net.Mime.MediaTypeNames;

namespace CMatch
{
	internal class CMatch
	{
		static void Main(string[] args)
		{
			string filename = "Content\\Test.cm";
			//string filename = null;
        	bool isInteractiveMode = false;

        	for (int i = 0; i < args.Length; i++)
        	{
            	switch (args[i])
            	{
                	case "-f":
                    	if (i + 1 < args.Length)
                    	{
                       		filename = args[i + 1];
                        	i++;
                    	}
                    	else
                    	{
                        	Console.Error.WriteLine("Error: Missing filename argument for -f flag.");
                        	PrintHelp();
                        	Environment.Exit(1);
                    	}
                    	break;
                	case "-i":
                    	isInteractiveMode = true;
                    	break;
                	case "-h":
                    	PrintHelp();
                    	Environment.Exit(0);
                    	break;
                	default:
                    	Console.Error.WriteLine("Error: Invalid argument: " + args[i]);
                    	PrintHelp();
                    	Environment.Exit(1);
                    	break;
				}
            }
			try
        	{
            	if (isInteractiveMode)
            	{
                	ProcessInteractiveInput();
            	}
            	else
            	{
                	ProcessFile(filename);
            	}
        	}
        	catch (Exception e)
        	{
            	Console.WriteLine(e.StackTrace);
            	Environment.Exit(1);
        	}
            // string input = "Content\\test.cm";
            // //string input = "Content\\FibFor.cm";

			// var fileContents = File.ReadAllText(input);
		    // var inputStream = new AntlrInputStream(fileContents);
		    // var cmatchLexer = new CMatchLexer(inputStream);
            // CommonTokenStream commonTokenStream = new CommonTokenStream(cmatchLexer);
            // var cmatchParser = new CMatchParser(commonTokenStream);
            // var matchContext = cmatchParser.program();
            // var visitor = new CMatchVisitor();        
            
            // visitor.Visit(matchContext);
		}
	
		private static void PrintHelp()
    	{
        	Console.WriteLine("Usage: dotnet run --project CMatch.csproj -- [-f filename] [-i] [-h]");
        	Console.WriteLine("-f filename\tPass a file as an argument");
        	Console.WriteLine("-i\t\tEnable interactive mode");
        	Console.WriteLine("-h\t\tDisplay help information");
    	}

    	private static void ProcessInteractiveInput()
    	{

 	       	string input = "";
   	    	while (true)
       		{
            	Console.Write("> ");
            	string line = Console.ReadLine();
            	if (line == "exit")
            	{
                	break;
            	}
            	input += line + "\n";
            	try
            	{
                	string output = ExecuteCode(input);
                	if (!string.IsNullOrEmpty(output))
                	{
                    	input = "";
                    	if (!string.IsNullOrEmpty(output))
                    	{
                        	Console.WriteLine(output);
                    	}
                	}	
            	}
            	catch (Exception e)
            	{
                	Console.WriteLine("<ERROR> " + e.Message);
                	input = "";
            	}
        	}
    	}
	 	public static void ProcessFile(string filename)
    	{
        	try
        	{
            	Console.WriteLine("<PROGRAM OUTPUT>");
            	string output = Execute(filename);
            	Console.WriteLine(output);
        	}
        	catch (Exception e)
        	{
            	Console.WriteLine("<ERROR> " + e.Message);
	        }
    	}
		public static string Execute(string program)
    	{
			var fileContents = File.ReadAllText(program);
			return ExecuteCode(fileContents);
    	}
    	private static string ExecuteCode(string input)
    	{
			var inputStream = new AntlrInputStream(input);
        	CMatchLexer lexer = new CMatchLexer(inputStream);
        	CommonTokenStream tokens = new CommonTokenStream(lexer);
        	CMatchParser parser = new CMatchParser(tokens);
			var matchContext = parser.program();
			var visitor = new CMatchVisitor();

			visitor.Visit(matchContext);
			parser.RemoveErrorListeners();
        	CMatchErrorListener errorListener = new CMatchErrorListener();
        	parser.AddErrorListener(errorListener);

        	CMatchParser.ProgramContext tree = parser.program();
			
        	if (errorListener.HasSyntaxError())
        	{
          		throw new Exception("Program error: Parser was canceled and came as a complete surprise to me? :D");
        	}
        	if (errorListener.IsPartialTree())
        	{
            	return null;
        	}

        	CMatchVisitor interpreter = new CMatchVisitor();
        	return (string)interpreter.Visit(tree);
		}
	}
}