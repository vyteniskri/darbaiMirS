using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

public class CMatchErrorListener : BaseErrorListener
{
    private string errorMsg = null;
    private bool isPartialTree = false;

    public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
    {
        if (msg.StartsWith("mismatched input '<EOF>'") || System.Text.RegularExpressions.Regex.IsMatch(msg, "missing '.*' at '<EOF>'"))
        {
            isPartialTree = true;
        }
        else
        {
            errorMsg = $"Syntax error at line {line}, position {charPositionInLine}: {msg}";
        }
    }

    public bool HasSyntaxError()
    {
        return errorMsg != null;
    }

    public bool IsPartialTree()
    {
        return isPartialTree;
    }

    public string GetErrorMsg()
    {
        return errorMsg;
    }
}