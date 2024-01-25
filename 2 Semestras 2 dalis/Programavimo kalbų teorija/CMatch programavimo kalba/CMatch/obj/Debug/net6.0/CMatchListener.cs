//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\Labas\Desktop\Cmatch aruno\CMatch\CMatch\Content\CMatch.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace CMatch.Content {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="CMatchParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface ICMatchListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>constantExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstantExpression([NotNull] CMatchParser.ConstantExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>constantExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstantExpression([NotNull] CMatchParser.ConstantExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>parentsizedExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParentsizedExpression([NotNull] CMatchParser.ParentsizedExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>parentsizedExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParentsizedExpression([NotNull] CMatchParser.ParentsizedExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>additiveExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAdditiveExpression([NotNull] CMatchParser.AdditiveExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>additiveExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAdditiveExpression([NotNull] CMatchParser.AdditiveExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>functionalCallExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionalCallExpression([NotNull] CMatchParser.FunctionalCallExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>functionalCallExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionalCallExpression([NotNull] CMatchParser.FunctionalCallExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>identifierExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifierExpression([NotNull] CMatchParser.IdentifierExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>identifierExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifierExpression([NotNull] CMatchParser.IdentifierExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>notExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNotExpression([NotNull] CMatchParser.NotExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>notExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNotExpression([NotNull] CMatchParser.NotExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>comparisonExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComparisonExpression([NotNull] CMatchParser.ComparisonExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>comparisonExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComparisonExpression([NotNull] CMatchParser.ComparisonExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>multiplicativeExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultiplicativeExpression([NotNull] CMatchParser.MultiplicativeExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>multiplicativeExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultiplicativeExpression([NotNull] CMatchParser.MultiplicativeExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>statementforExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatementforExpression([NotNull] CMatchParser.StatementforExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>statementforExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatementforExpression([NotNull] CMatchParser.StatementforExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>booleanExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBooleanExpression([NotNull] CMatchParser.BooleanExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>booleanExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBooleanExpression([NotNull] CMatchParser.BooleanExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>functionCallExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionCallExpression([NotNull] CMatchParser.FunctionCallExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>functionCallExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionCallExpression([NotNull] CMatchParser.FunctionCallExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>statmentmatchExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatmentmatchExpression([NotNull] CMatchParser.StatmentmatchExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>statmentmatchExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatmentmatchExpression([NotNull] CMatchParser.StatmentmatchExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>statementifExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatementifExpression([NotNull] CMatchParser.StatementifExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>statementifExpression</c>
	/// labeled alternative in <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatementifExpression([NotNull] CMatchParser.StatementifExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] CMatchParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] CMatchParser.ProgramContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLine([NotNull] CMatchParser.LineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLine([NotNull] CMatchParser.LineContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] CMatchParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] CMatchParser.StatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.statementif"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatementif([NotNull] CMatchParser.StatementifContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.statementif"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatementif([NotNull] CMatchParser.StatementifContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.statmentelseif"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatmentelseif([NotNull] CMatchParser.StatmentelseifContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.statmentelseif"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatmentelseif([NotNull] CMatchParser.StatmentelseifContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.statementfor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatementfor([NotNull] CMatchParser.StatementforContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.statementfor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatementfor([NotNull] CMatchParser.StatementforContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.statmentmatch"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatmentmatch([NotNull] CMatchParser.StatmentmatchContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.statmentmatch"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatmentmatch([NotNull] CMatchParser.StatmentmatchContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.identifierPattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifierPattern([NotNull] CMatchParser.IdentifierPatternContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.identifierPattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifierPattern([NotNull] CMatchParser.IdentifierPatternContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.primaryPattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrimaryPattern([NotNull] CMatchParser.PrimaryPatternContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.primaryPattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrimaryPattern([NotNull] CMatchParser.PrimaryPatternContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.pattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPattern([NotNull] CMatchParser.PatternContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.pattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPattern([NotNull] CMatchParser.PatternContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.assigment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssigment([NotNull] CMatchParser.AssigmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.assigment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssigment([NotNull] CMatchParser.AssigmentContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionCall([NotNull] CMatchParser.FunctionCallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionCall([NotNull] CMatchParser.FunctionCallContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.functionalCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionalCall([NotNull] CMatchParser.FunctionalCallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.functionalCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionalCall([NotNull] CMatchParser.FunctionalCallContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.expressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpressionList([NotNull] CMatchParser.ExpressionListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.expressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpressionList([NotNull] CMatchParser.ExpressionListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.functionDeclare"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionDeclare([NotNull] CMatchParser.FunctionDeclareContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.functionDeclare"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionDeclare([NotNull] CMatchParser.FunctionDeclareContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameterList([NotNull] CMatchParser.ParameterListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameterList([NotNull] CMatchParser.ParameterListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.returnStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturnStatement([NotNull] CMatchParser.ReturnStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.returnStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturnStatement([NotNull] CMatchParser.ReturnStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] CMatchParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] CMatchParser.ExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.multOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultOp([NotNull] CMatchParser.MultOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.multOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultOp([NotNull] CMatchParser.MultOpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.addOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddOp([NotNull] CMatchParser.AddOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.addOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddOp([NotNull] CMatchParser.AddOpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.compareOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompareOp([NotNull] CMatchParser.CompareOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.compareOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompareOp([NotNull] CMatchParser.CompareOpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.boolOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolOp([NotNull] CMatchParser.BoolOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.boolOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolOp([NotNull] CMatchParser.BoolOpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstant([NotNull] CMatchParser.ConstantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstant([NotNull] CMatchParser.ConstantContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] CMatchParser.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] CMatchParser.BlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.constantPattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstantPattern([NotNull] CMatchParser.ConstantPatternContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.constantPattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstantPattern([NotNull] CMatchParser.ConstantPatternContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.decimalNumbersTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDecimalNumbersTail([NotNull] CMatchParser.DecimalNumbersTailContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.decimalNumbersTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDecimalNumbersTail([NotNull] CMatchParser.DecimalNumbersTailContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.decimalNumbersHead"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDecimalNumbersHead([NotNull] CMatchParser.DecimalNumbersHeadContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.decimalNumbersHead"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDecimalNumbersHead([NotNull] CMatchParser.DecimalNumbersHeadContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.touplePattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTouplePattern([NotNull] CMatchParser.TouplePatternContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.touplePattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTouplePattern([NotNull] CMatchParser.TouplePatternContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="CMatchParser.wildcardPattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWildcardPattern([NotNull] CMatchParser.WildcardPatternContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CMatchParser.wildcardPattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWildcardPattern([NotNull] CMatchParser.WildcardPatternContext context);
}
} // namespace CMatch.Content
