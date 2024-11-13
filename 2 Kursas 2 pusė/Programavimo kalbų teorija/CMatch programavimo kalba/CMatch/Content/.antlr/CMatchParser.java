// Generated from c:\Users\Labas\Desktop\Cmatch aruno\CMatch\CMatch\Content\CMatch.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class CMatchParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		T__24=25, T__25=26, T__26=27, T__27=28, T__28=29, T__29=30, T__30=31, 
		T__31=32, T__32=33, T__33=34, T__34=35, T__35=36, T__36=37, T__37=38, 
		T__38=39, T__39=40, T__40=41, T__41=42, T__42=43, T__43=44, T__44=45, 
		T__45=46, BOOL_OP=47, INTEGER=48, TOUPLE=49, DOUBLE=50, STRING=51, BOOL=52, 
		NULL=53, POSITIVE=54, WS=55, IDENTIFIER=56;
	public static final int
		RULE_program = 0, RULE_line = 1, RULE_statement = 2, RULE_statementif = 3, 
		RULE_statmentelseif = 4, RULE_statementfor = 5, RULE_statmentmatch = 6, 
		RULE_identifierPattern = 7, RULE_primaryPattern = 8, RULE_pattern = 9, 
		RULE_assigment = 10, RULE_functionCall = 11, RULE_functionalCall = 12, 
		RULE_expressionList = 13, RULE_functionDeclare = 14, RULE_parameterList = 15, 
		RULE_returnStatement = 16, RULE_expression = 17, RULE_multOp = 18, RULE_addOp = 19, 
		RULE_compareOp = 20, RULE_boolOp = 21, RULE_constant = 22, RULE_block = 23, 
		RULE_constantPattern = 24, RULE_decimalNumbersTail = 25, RULE_decimalNumbersHead = 26, 
		RULE_touplePattern = 27, RULE_wildcardPattern = 28;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "line", "statement", "statementif", "statmentelseif", "statementfor", 
			"statmentmatch", "identifierPattern", "primaryPattern", "pattern", "assigment", 
			"functionCall", "functionalCall", "expressionList", "functionDeclare", 
			"parameterList", "returnStatement", "expression", "multOp", "addOp", 
			"compareOp", "boolOp", "constant", "block", "constantPattern", "decimalNumbersTail", 
			"decimalNumbersHead", "touplePattern", "wildcardPattern"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "';'", "'if'", "'('", "')'", "'or'", "'for'", "'{'", "'}'", "'match'", 
			"'case'", "':'", "'when'", "'='", "','", "'func'", "'return'", "'!'", 
			"'*'", "'/'", "'%'", "'+'", "'-'", "'=='", "'!='", "'>'", "'<'", "'>='", 
			"'<='", "'constint'", "'conststring'", "'constdouble'", "'constbool'", 
			"'#.'", "'##.'", "'###.'", "'####.'", "'-#.'", "'-##.'", "'-###.'", "'-####.'", 
			"'.#'", "'.##'", "'.###'", "'.####'", "'#'", "'_'", null, null, null, 
			null, null, null, "'Null'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, "BOOL_OP", 
			"INTEGER", "TOUPLE", "DOUBLE", "STRING", "BOOL", "NULL", "POSITIVE", 
			"WS", "IDENTIFIER"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "CMatch.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public CMatchParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ProgramContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(CMatchParser.EOF, 0); }
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(61);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__1) | (1L << T__5) | (1L << T__8) | (1L << T__14) | (1L << T__15) | (1L << IDENTIFIER))) != 0)) {
				{
				{
				setState(58);
				line();
				}
				}
				setState(63);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(64);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LineContext extends ParserRuleContext {
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public StatementifContext statementif() {
			return getRuleContext(StatementifContext.class,0);
		}
		public StatementforContext statementfor() {
			return getRuleContext(StatementforContext.class,0);
		}
		public StatmentmatchContext statmentmatch() {
			return getRuleContext(StatmentmatchContext.class,0);
		}
		public FunctionDeclareContext functionDeclare() {
			return getRuleContext(FunctionDeclareContext.class,0);
		}
		public FunctionalCallContext functionalCall() {
			return getRuleContext(FunctionalCallContext.class,0);
		}
		public ReturnStatementContext returnStatement() {
			return getRuleContext(ReturnStatementContext.class,0);
		}
		public LineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_line; }
	}

	public final LineContext line() throws RecognitionException {
		LineContext _localctx = new LineContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_line);
		try {
			setState(73);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(66);
				statement();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(67);
				statementif();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(68);
				statementfor();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(69);
				statmentmatch();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(70);
				functionDeclare();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(71);
				functionalCall();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(72);
				returnStatement();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementContext extends ParserRuleContext {
		public AssigmentContext assigment() {
			return getRuleContext(AssigmentContext.class,0);
		}
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(77);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				{
				setState(75);
				assigment();
				}
				break;
			case 2:
				{
				setState(76);
				functionCall();
				}
				break;
			}
			setState(79);
			match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementifContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public StatmentelseifContext statmentelseif() {
			return getRuleContext(StatmentelseifContext.class,0);
		}
		public StatementifContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statementif; }
	}

	public final StatementifContext statementif() throws RecognitionException {
		StatementifContext _localctx = new StatementifContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_statementif);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(81);
			match(T__1);
			setState(82);
			match(T__2);
			setState(83);
			expression(0);
			setState(84);
			match(T__3);
			setState(85);
			block();
			setState(88);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				{
				setState(86);
				match(T__4);
				setState(87);
				statmentelseif();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatmentelseifContext extends ParserRuleContext {
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public StatementifContext statementif() {
			return getRuleContext(StatementifContext.class,0);
		}
		public StatmentelseifContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statmentelseif; }
	}

	public final StatmentelseifContext statmentelseif() throws RecognitionException {
		StatmentelseifContext _localctx = new StatmentelseifContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_statmentelseif);
		try {
			setState(92);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__6:
				enterOuterAlt(_localctx, 1);
				{
				setState(90);
				block();
				}
				break;
			case T__1:
				enterOuterAlt(_localctx, 2);
				{
				setState(91);
				statementif();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementforContext extends ParserRuleContext {
		public List<AssigmentContext> assigment() {
			return getRuleContexts(AssigmentContext.class);
		}
		public AssigmentContext assigment(int i) {
			return getRuleContext(AssigmentContext.class,i);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public StatementforContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statementfor; }
	}

	public final StatementforContext statementfor() throws RecognitionException {
		StatementforContext _localctx = new StatementforContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_statementfor);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(94);
			match(T__5);
			setState(95);
			match(T__2);
			setState(96);
			assigment();
			setState(97);
			match(T__0);
			setState(98);
			expression(0);
			setState(99);
			match(T__0);
			setState(100);
			assigment();
			setState(101);
			match(T__3);
			setState(102);
			match(T__6);
			setState(103);
			block();
			setState(104);
			match(T__7);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatmentmatchContext extends ParserRuleContext {
		public IdentifierPatternContext identifierPattern() {
			return getRuleContext(IdentifierPatternContext.class,0);
		}
		public List<PatternContext> pattern() {
			return getRuleContexts(PatternContext.class);
		}
		public PatternContext pattern(int i) {
			return getRuleContext(PatternContext.class,i);
		}
		public List<BlockContext> block() {
			return getRuleContexts(BlockContext.class);
		}
		public BlockContext block(int i) {
			return getRuleContext(BlockContext.class,i);
		}
		public StatmentmatchContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statmentmatch; }
	}

	public final StatmentmatchContext statmentmatch() throws RecognitionException {
		StatmentmatchContext _localctx = new StatmentmatchContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_statmentmatch);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(106);
			match(T__8);
			setState(107);
			match(T__2);
			setState(108);
			identifierPattern();
			setState(109);
			match(T__3);
			setState(110);
			match(T__6);
			setState(118); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(111);
				match(T__9);
				setState(112);
				pattern();
				setState(113);
				match(T__10);
				setState(114);
				match(T__6);
				setState(115);
				block();
				setState(116);
				match(T__7);
				}
				}
				setState(120); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==T__9 );
			setState(122);
			match(T__7);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IdentifierPatternContext extends ParserRuleContext {
		public ConstantContext constant() {
			return getRuleContext(ConstantContext.class,0);
		}
		public TerminalNode IDENTIFIER() { return getToken(CMatchParser.IDENTIFIER, 0); }
		public IdentifierPatternContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_identifierPattern; }
	}

	public final IdentifierPatternContext identifierPattern() throws RecognitionException {
		IdentifierPatternContext _localctx = new IdentifierPatternContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_identifierPattern);
		try {
			setState(126);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INTEGER:
			case TOUPLE:
			case DOUBLE:
			case STRING:
			case BOOL:
			case NULL:
				enterOuterAlt(_localctx, 1);
				{
				setState(124);
				constant();
				}
				break;
			case IDENTIFIER:
				enterOuterAlt(_localctx, 2);
				{
				setState(125);
				match(IDENTIFIER);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PrimaryPatternContext extends ParserRuleContext {
		public DecimalNumbersHeadContext decimalNumbersHead() {
			return getRuleContext(DecimalNumbersHeadContext.class,0);
		}
		public DecimalNumbersTailContext decimalNumbersTail() {
			return getRuleContext(DecimalNumbersTailContext.class,0);
		}
		public TouplePatternContext touplePattern() {
			return getRuleContext(TouplePatternContext.class,0);
		}
		public ConstantPatternContext constantPattern() {
			return getRuleContext(ConstantPatternContext.class,0);
		}
		public WildcardPatternContext wildcardPattern() {
			return getRuleContext(WildcardPatternContext.class,0);
		}
		public PrimaryPatternContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_primaryPattern; }
	}

	public final PrimaryPatternContext primaryPattern() throws RecognitionException {
		PrimaryPatternContext _localctx = new PrimaryPatternContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_primaryPattern);
		try {
			setState(133);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(128);
				decimalNumbersHead();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(129);
				decimalNumbersTail();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(130);
				touplePattern();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(131);
				constantPattern();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(132);
				wildcardPattern();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PatternContext extends ParserRuleContext {
		public PrimaryPatternContext primaryPattern() {
			return getRuleContext(PrimaryPatternContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public PatternContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pattern; }
	}

	public final PatternContext pattern() throws RecognitionException {
		PatternContext _localctx = new PatternContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_pattern);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(135);
			primaryPattern();
			setState(138);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__11) {
				{
				setState(136);
				match(T__11);
				setState(137);
				expression(0);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssigmentContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(CMatchParser.IDENTIFIER, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public AssigmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assigment; }
	}

	public final AssigmentContext assigment() throws RecognitionException {
		AssigmentContext _localctx = new AssigmentContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_assigment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(140);
			match(IDENTIFIER);
			setState(141);
			match(T__12);
			setState(142);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionCallContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(CMatchParser.IDENTIFIER, 0); }
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public FunctionCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionCall; }
	}

	public final FunctionCallContext functionCall() throws RecognitionException {
		FunctionCallContext _localctx = new FunctionCallContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_functionCall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(144);
			match(IDENTIFIER);
			setState(145);
			match(T__2);
			setState(154);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__1) | (1L << T__2) | (1L << T__5) | (1L << T__8) | (1L << T__16) | (1L << INTEGER) | (1L << TOUPLE) | (1L << DOUBLE) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(146);
				expression(0);
				setState(151);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__13) {
					{
					{
					setState(147);
					match(T__13);
					setState(148);
					expression(0);
					}
					}
					setState(153);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(156);
			match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionalCallContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(CMatchParser.IDENTIFIER, 0); }
		public ExpressionListContext expressionList() {
			return getRuleContext(ExpressionListContext.class,0);
		}
		public FunctionalCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionalCall; }
	}

	public final FunctionalCallContext functionalCall() throws RecognitionException {
		FunctionalCallContext _localctx = new FunctionalCallContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_functionalCall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(158);
			match(IDENTIFIER);
			setState(159);
			match(T__2);
			setState(161);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__1) | (1L << T__2) | (1L << T__5) | (1L << T__8) | (1L << T__16) | (1L << INTEGER) | (1L << TOUPLE) | (1L << DOUBLE) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(160);
				expressionList();
				}
			}

			setState(163);
			match(T__3);
			setState(164);
			match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExpressionListContext extends ParserRuleContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public ExpressionListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expressionList; }
	}

	public final ExpressionListContext expressionList() throws RecognitionException {
		ExpressionListContext _localctx = new ExpressionListContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_expressionList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(166);
			expression(0);
			setState(171);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__13) {
				{
				{
				setState(167);
				match(T__13);
				setState(168);
				expression(0);
				}
				}
				setState(173);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionDeclareContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(CMatchParser.IDENTIFIER, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ParameterListContext parameterList() {
			return getRuleContext(ParameterListContext.class,0);
		}
		public FunctionDeclareContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionDeclare; }
	}

	public final FunctionDeclareContext functionDeclare() throws RecognitionException {
		FunctionDeclareContext _localctx = new FunctionDeclareContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_functionDeclare);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(174);
			match(T__14);
			setState(175);
			match(IDENTIFIER);
			setState(176);
			match(T__2);
			setState(178);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==IDENTIFIER) {
				{
				setState(177);
				parameterList();
				}
			}

			setState(180);
			match(T__3);
			setState(181);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParameterListContext extends ParserRuleContext {
		public List<TerminalNode> IDENTIFIER() { return getTokens(CMatchParser.IDENTIFIER); }
		public TerminalNode IDENTIFIER(int i) {
			return getToken(CMatchParser.IDENTIFIER, i);
		}
		public ParameterListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameterList; }
	}

	public final ParameterListContext parameterList() throws RecognitionException {
		ParameterListContext _localctx = new ParameterListContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_parameterList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(183);
			match(IDENTIFIER);
			setState(188);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__13) {
				{
				{
				setState(184);
				match(T__13);
				setState(185);
				match(IDENTIFIER);
				}
				}
				setState(190);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ReturnStatementContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ReturnStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_returnStatement; }
	}

	public final ReturnStatementContext returnStatement() throws RecognitionException {
		ReturnStatementContext _localctx = new ReturnStatementContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_returnStatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(191);
			match(T__15);
			setState(193);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__1) | (1L << T__2) | (1L << T__5) | (1L << T__8) | (1L << T__16) | (1L << INTEGER) | (1L << TOUPLE) | (1L << DOUBLE) | (1L << STRING) | (1L << BOOL) | (1L << NULL) | (1L << IDENTIFIER))) != 0)) {
				{
				setState(192);
				expression(0);
				}
			}

			setState(195);
			match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExpressionContext extends ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	 
		public ExpressionContext() { }
		public void copyFrom(ExpressionContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class ConstantExpressionContext extends ExpressionContext {
		public ConstantContext constant() {
			return getRuleContext(ConstantContext.class,0);
		}
		public ConstantExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class ParentsizedExpressionContext extends ExpressionContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ParentsizedExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class AdditiveExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public AddOpContext addOp() {
			return getRuleContext(AddOpContext.class,0);
		}
		public AdditiveExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class FunctionalCallExpressionContext extends ExpressionContext {
		public FunctionalCallContext functionalCall() {
			return getRuleContext(FunctionalCallContext.class,0);
		}
		public FunctionalCallExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class IdentifierExpressionContext extends ExpressionContext {
		public TerminalNode IDENTIFIER() { return getToken(CMatchParser.IDENTIFIER, 0); }
		public IdentifierExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class NotExpressionContext extends ExpressionContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public NotExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class ComparisonExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public CompareOpContext compareOp() {
			return getRuleContext(CompareOpContext.class,0);
		}
		public ComparisonExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class MultiplicativeExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public MultOpContext multOp() {
			return getRuleContext(MultOpContext.class,0);
		}
		public MultiplicativeExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class StatementforExpressionContext extends ExpressionContext {
		public StatementforContext statementfor() {
			return getRuleContext(StatementforContext.class,0);
		}
		public StatementforExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class BooleanExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public BoolOpContext boolOp() {
			return getRuleContext(BoolOpContext.class,0);
		}
		public BooleanExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class FunctionCallExpressionContext extends ExpressionContext {
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public FunctionCallExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class StatmentmatchExpressionContext extends ExpressionContext {
		public StatmentmatchContext statmentmatch() {
			return getRuleContext(StatmentmatchContext.class,0);
		}
		public StatmentmatchExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class StatementifExpressionContext extends ExpressionContext {
		public StatementifContext statementif() {
			return getRuleContext(StatementifContext.class,0);
		}
		public StatementifExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 34;
		enterRecursionRule(_localctx, 34, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(211);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,16,_ctx) ) {
			case 1:
				{
				_localctx = new ConstantExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(198);
				constant();
				}
				break;
			case 2:
				{
				_localctx = new IdentifierExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(199);
				match(IDENTIFIER);
				}
				break;
			case 3:
				{
				_localctx = new StatmentmatchExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(200);
				statmentmatch();
				}
				break;
			case 4:
				{
				_localctx = new StatementifExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(201);
				statementif();
				}
				break;
			case 5:
				{
				_localctx = new StatementforExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(202);
				statementfor();
				}
				break;
			case 6:
				{
				_localctx = new FunctionCallExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(203);
				functionCall();
				}
				break;
			case 7:
				{
				_localctx = new FunctionalCallExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(204);
				functionalCall();
				}
				break;
			case 8:
				{
				_localctx = new ParentsizedExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(205);
				match(T__2);
				setState(206);
				expression(0);
				setState(207);
				match(T__3);
				}
				break;
			case 9:
				{
				_localctx = new NotExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(209);
				match(T__16);
				setState(210);
				expression(5);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(231);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,18,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(229);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
					case 1:
						{
						_localctx = new MultiplicativeExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(213);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(214);
						multOp();
						setState(215);
						expression(5);
						}
						break;
					case 2:
						{
						_localctx = new AdditiveExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(217);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(218);
						addOp();
						setState(219);
						expression(4);
						}
						break;
					case 3:
						{
						_localctx = new ComparisonExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(221);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(222);
						compareOp();
						setState(223);
						expression(3);
						}
						break;
					case 4:
						{
						_localctx = new BooleanExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(225);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(226);
						boolOp();
						setState(227);
						expression(2);
						}
						break;
					}
					} 
				}
				setState(233);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,18,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class MultOpContext extends ParserRuleContext {
		public MultOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_multOp; }
	}

	public final MultOpContext multOp() throws RecognitionException {
		MultOpContext _localctx = new MultOpContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_multOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(234);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__17) | (1L << T__18) | (1L << T__19))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AddOpContext extends ParserRuleContext {
		public AddOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addOp; }
	}

	public final AddOpContext addOp() throws RecognitionException {
		AddOpContext _localctx = new AddOpContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_addOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(236);
			_la = _input.LA(1);
			if ( !(_la==T__20 || _la==T__21) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CompareOpContext extends ParserRuleContext {
		public CompareOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compareOp; }
	}

	public final CompareOpContext compareOp() throws RecognitionException {
		CompareOpContext _localctx = new CompareOpContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_compareOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(238);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__22) | (1L << T__23) | (1L << T__24) | (1L << T__25) | (1L << T__26) | (1L << T__27))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BoolOpContext extends ParserRuleContext {
		public TerminalNode BOOL_OP() { return getToken(CMatchParser.BOOL_OP, 0); }
		public BoolOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolOp; }
	}

	public final BoolOpContext boolOp() throws RecognitionException {
		BoolOpContext _localctx = new BoolOpContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_boolOp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(240);
			match(BOOL_OP);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ConstantContext extends ParserRuleContext {
		public TerminalNode INTEGER() { return getToken(CMatchParser.INTEGER, 0); }
		public TerminalNode DOUBLE() { return getToken(CMatchParser.DOUBLE, 0); }
		public TerminalNode STRING() { return getToken(CMatchParser.STRING, 0); }
		public TerminalNode BOOL() { return getToken(CMatchParser.BOOL, 0); }
		public TerminalNode NULL() { return getToken(CMatchParser.NULL, 0); }
		public TerminalNode TOUPLE() { return getToken(CMatchParser.TOUPLE, 0); }
		public ConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constant; }
	}

	public final ConstantContext constant() throws RecognitionException {
		ConstantContext _localctx = new ConstantContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_constant);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(242);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INTEGER) | (1L << TOUPLE) | (1L << DOUBLE) | (1L << STRING) | (1L << BOOL) | (1L << NULL))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BlockContext extends ParserRuleContext {
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public BlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_block; }
	}

	public final BlockContext block() throws RecognitionException {
		BlockContext _localctx = new BlockContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_block);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(244);
			match(T__6);
			setState(248);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__1) | (1L << T__5) | (1L << T__8) | (1L << T__14) | (1L << T__15) | (1L << IDENTIFIER))) != 0)) {
				{
				{
				setState(245);
				line();
				}
				}
				setState(250);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(251);
			match(T__7);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ConstantPatternContext extends ParserRuleContext {
		public ConstantContext constant() {
			return getRuleContext(ConstantContext.class,0);
		}
		public ConstantPatternContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constantPattern; }
	}

	public final ConstantPatternContext constantPattern() throws RecognitionException {
		ConstantPatternContext _localctx = new ConstantPatternContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_constantPattern);
		try {
			setState(258);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__28:
				enterOuterAlt(_localctx, 1);
				{
				setState(253);
				match(T__28);
				}
				break;
			case T__29:
				enterOuterAlt(_localctx, 2);
				{
				setState(254);
				match(T__29);
				}
				break;
			case T__30:
				enterOuterAlt(_localctx, 3);
				{
				setState(255);
				match(T__30);
				}
				break;
			case T__31:
				enterOuterAlt(_localctx, 4);
				{
				setState(256);
				match(T__31);
				}
				break;
			case INTEGER:
			case TOUPLE:
			case DOUBLE:
			case STRING:
			case BOOL:
			case NULL:
				enterOuterAlt(_localctx, 5);
				{
				setState(257);
				constant();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DecimalNumbersTailContext extends ParserRuleContext {
		public TerminalNode POSITIVE() { return getToken(CMatchParser.POSITIVE, 0); }
		public DecimalNumbersTailContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_decimalNumbersTail; }
	}

	public final DecimalNumbersTailContext decimalNumbersTail() throws RecognitionException {
		DecimalNumbersTailContext _localctx = new DecimalNumbersTailContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_decimalNumbersTail);
		try {
			setState(280);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__32:
			case T__33:
			case T__34:
			case T__35:
				enterOuterAlt(_localctx, 1);
				{
				setState(268);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case T__32:
					{
					setState(260);
					match(T__32);
					setState(261);
					match(POSITIVE);
					}
					break;
				case T__33:
					{
					setState(262);
					match(T__33);
					setState(263);
					match(POSITIVE);
					}
					break;
				case T__34:
					{
					setState(264);
					match(T__34);
					setState(265);
					match(POSITIVE);
					}
					break;
				case T__35:
					{
					setState(266);
					match(T__35);
					setState(267);
					match(POSITIVE);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				break;
			case T__36:
			case T__37:
			case T__38:
			case T__39:
				enterOuterAlt(_localctx, 2);
				{
				setState(278);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case T__36:
					{
					setState(270);
					match(T__36);
					setState(271);
					match(POSITIVE);
					}
					break;
				case T__37:
					{
					setState(272);
					match(T__37);
					setState(273);
					match(POSITIVE);
					}
					break;
				case T__38:
					{
					setState(274);
					match(T__38);
					setState(275);
					match(POSITIVE);
					}
					break;
				case T__39:
					{
					setState(276);
					match(T__39);
					setState(277);
					match(POSITIVE);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DecimalNumbersHeadContext extends ParserRuleContext {
		public TerminalNode INTEGER() { return getToken(CMatchParser.INTEGER, 0); }
		public DecimalNumbersHeadContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_decimalNumbersHead; }
	}

	public final DecimalNumbersHeadContext decimalNumbersHead() throws RecognitionException {
		DecimalNumbersHeadContext _localctx = new DecimalNumbersHeadContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_decimalNumbersHead);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(290);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,24,_ctx) ) {
			case 1:
				{
				setState(282);
				match(INTEGER);
				setState(283);
				match(T__40);
				}
				break;
			case 2:
				{
				setState(284);
				match(INTEGER);
				setState(285);
				match(T__41);
				}
				break;
			case 3:
				{
				setState(286);
				match(INTEGER);
				setState(287);
				match(T__42);
				}
				break;
			case 4:
				{
				setState(288);
				match(INTEGER);
				setState(289);
				match(T__43);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TouplePatternContext extends ParserRuleContext {
		public TerminalNode INTEGER() { return getToken(CMatchParser.INTEGER, 0); }
		public TerminalNode STRING() { return getToken(CMatchParser.STRING, 0); }
		public TouplePatternContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_touplePattern; }
	}

	public final TouplePatternContext touplePattern() throws RecognitionException {
		TouplePatternContext _localctx = new TouplePatternContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_touplePattern);
		try {
			setState(312);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,25,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(292);
				match(T__2);
				setState(293);
				match(T__44);
				setState(294);
				match(T__13);
				setState(295);
				match(INTEGER);
				setState(296);
				match(T__3);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(297);
				match(T__2);
				setState(298);
				match(INTEGER);
				setState(299);
				match(T__13);
				setState(300);
				match(T__44);
				setState(301);
				match(T__3);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(302);
				match(T__2);
				setState(303);
				match(T__44);
				setState(304);
				match(T__13);
				setState(305);
				match(STRING);
				setState(306);
				match(T__3);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(307);
				match(T__2);
				setState(308);
				match(STRING);
				setState(309);
				match(T__13);
				setState(310);
				match(T__44);
				setState(311);
				match(T__3);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class WildcardPatternContext extends ParserRuleContext {
		public WildcardPatternContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_wildcardPattern; }
	}

	public final WildcardPatternContext wildcardPattern() throws RecognitionException {
		WildcardPatternContext _localctx = new WildcardPatternContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_wildcardPattern);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(314);
			match(T__45);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 17:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 4);
		case 1:
			return precpred(_ctx, 3);
		case 2:
			return precpred(_ctx, 2);
		case 3:
			return precpred(_ctx, 1);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3:\u013f\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\3\2\7\2>\n\2\f\2\16"+
		"\2A\13\2\3\2\3\2\3\3\3\3\3\3\3\3\3\3\3\3\3\3\5\3L\n\3\3\4\3\4\5\4P\n\4"+
		"\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3\5\3\5\5\5[\n\5\3\6\3\6\5\6_\n\6\3\7\3\7"+
		"\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3"+
		"\b\3\b\3\b\3\b\3\b\6\by\n\b\r\b\16\bz\3\b\3\b\3\t\3\t\5\t\u0081\n\t\3"+
		"\n\3\n\3\n\3\n\3\n\5\n\u0088\n\n\3\13\3\13\3\13\5\13\u008d\n\13\3\f\3"+
		"\f\3\f\3\f\3\r\3\r\3\r\3\r\3\r\7\r\u0098\n\r\f\r\16\r\u009b\13\r\5\r\u009d"+
		"\n\r\3\r\3\r\3\16\3\16\3\16\5\16\u00a4\n\16\3\16\3\16\3\16\3\17\3\17\3"+
		"\17\7\17\u00ac\n\17\f\17\16\17\u00af\13\17\3\20\3\20\3\20\3\20\5\20\u00b5"+
		"\n\20\3\20\3\20\3\20\3\21\3\21\3\21\7\21\u00bd\n\21\f\21\16\21\u00c0\13"+
		"\21\3\22\3\22\5\22\u00c4\n\22\3\22\3\22\3\23\3\23\3\23\3\23\3\23\3\23"+
		"\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\5\23\u00d6\n\23\3\23\3\23\3\23"+
		"\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\7\23"+
		"\u00e8\n\23\f\23\16\23\u00eb\13\23\3\24\3\24\3\25\3\25\3\26\3\26\3\27"+
		"\3\27\3\30\3\30\3\31\3\31\7\31\u00f9\n\31\f\31\16\31\u00fc\13\31\3\31"+
		"\3\31\3\32\3\32\3\32\3\32\3\32\5\32\u0105\n\32\3\33\3\33\3\33\3\33\3\33"+
		"\3\33\3\33\3\33\5\33\u010f\n\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33"+
		"\5\33\u0119\n\33\5\33\u011b\n\33\3\34\3\34\3\34\3\34\3\34\3\34\3\34\3"+
		"\34\5\34\u0125\n\34\3\35\3\35\3\35\3\35\3\35\3\35\3\35\3\35\3\35\3\35"+
		"\3\35\3\35\3\35\3\35\3\35\3\35\3\35\3\35\3\35\3\35\5\35\u013b\n\35\3\36"+
		"\3\36\3\36\2\3$\37\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60"+
		"\62\64\668:\2\6\3\2\24\26\3\2\27\30\3\2\31\36\3\2\62\67\2\u0157\2?\3\2"+
		"\2\2\4K\3\2\2\2\6O\3\2\2\2\bS\3\2\2\2\n^\3\2\2\2\f`\3\2\2\2\16l\3\2\2"+
		"\2\20\u0080\3\2\2\2\22\u0087\3\2\2\2\24\u0089\3\2\2\2\26\u008e\3\2\2\2"+
		"\30\u0092\3\2\2\2\32\u00a0\3\2\2\2\34\u00a8\3\2\2\2\36\u00b0\3\2\2\2 "+
		"\u00b9\3\2\2\2\"\u00c1\3\2\2\2$\u00d5\3\2\2\2&\u00ec\3\2\2\2(\u00ee\3"+
		"\2\2\2*\u00f0\3\2\2\2,\u00f2\3\2\2\2.\u00f4\3\2\2\2\60\u00f6\3\2\2\2\62"+
		"\u0104\3\2\2\2\64\u011a\3\2\2\2\66\u0124\3\2\2\28\u013a\3\2\2\2:\u013c"+
		"\3\2\2\2<>\5\4\3\2=<\3\2\2\2>A\3\2\2\2?=\3\2\2\2?@\3\2\2\2@B\3\2\2\2A"+
		"?\3\2\2\2BC\7\2\2\3C\3\3\2\2\2DL\5\6\4\2EL\5\b\5\2FL\5\f\7\2GL\5\16\b"+
		"\2HL\5\36\20\2IL\5\32\16\2JL\5\"\22\2KD\3\2\2\2KE\3\2\2\2KF\3\2\2\2KG"+
		"\3\2\2\2KH\3\2\2\2KI\3\2\2\2KJ\3\2\2\2L\5\3\2\2\2MP\5\26\f\2NP\5\30\r"+
		"\2OM\3\2\2\2ON\3\2\2\2PQ\3\2\2\2QR\7\3\2\2R\7\3\2\2\2ST\7\4\2\2TU\7\5"+
		"\2\2UV\5$\23\2VW\7\6\2\2WZ\5\60\31\2XY\7\7\2\2Y[\5\n\6\2ZX\3\2\2\2Z[\3"+
		"\2\2\2[\t\3\2\2\2\\_\5\60\31\2]_\5\b\5\2^\\\3\2\2\2^]\3\2\2\2_\13\3\2"+
		"\2\2`a\7\b\2\2ab\7\5\2\2bc\5\26\f\2cd\7\3\2\2de\5$\23\2ef\7\3\2\2fg\5"+
		"\26\f\2gh\7\6\2\2hi\7\t\2\2ij\5\60\31\2jk\7\n\2\2k\r\3\2\2\2lm\7\13\2"+
		"\2mn\7\5\2\2no\5\20\t\2op\7\6\2\2px\7\t\2\2qr\7\f\2\2rs\5\24\13\2st\7"+
		"\r\2\2tu\7\t\2\2uv\5\60\31\2vw\7\n\2\2wy\3\2\2\2xq\3\2\2\2yz\3\2\2\2z"+
		"x\3\2\2\2z{\3\2\2\2{|\3\2\2\2|}\7\n\2\2}\17\3\2\2\2~\u0081\5.\30\2\177"+
		"\u0081\7:\2\2\u0080~\3\2\2\2\u0080\177\3\2\2\2\u0081\21\3\2\2\2\u0082"+
		"\u0088\5\66\34\2\u0083\u0088\5\64\33\2\u0084\u0088\58\35\2\u0085\u0088"+
		"\5\62\32\2\u0086\u0088\5:\36\2\u0087\u0082\3\2\2\2\u0087\u0083\3\2\2\2"+
		"\u0087\u0084\3\2\2\2\u0087\u0085\3\2\2\2\u0087\u0086\3\2\2\2\u0088\23"+
		"\3\2\2\2\u0089\u008c\5\22\n\2\u008a\u008b\7\16\2\2\u008b\u008d\5$\23\2"+
		"\u008c\u008a\3\2\2\2\u008c\u008d\3\2\2\2\u008d\25\3\2\2\2\u008e\u008f"+
		"\7:\2\2\u008f\u0090\7\17\2\2\u0090\u0091\5$\23\2\u0091\27\3\2\2\2\u0092"+
		"\u0093\7:\2\2\u0093\u009c\7\5\2\2\u0094\u0099\5$\23\2\u0095\u0096\7\20"+
		"\2\2\u0096\u0098\5$\23\2\u0097\u0095\3\2\2\2\u0098\u009b\3\2\2\2\u0099"+
		"\u0097\3\2\2\2\u0099\u009a\3\2\2\2\u009a\u009d\3\2\2\2\u009b\u0099\3\2"+
		"\2\2\u009c\u0094\3\2\2\2\u009c\u009d\3\2\2\2\u009d\u009e\3\2\2\2\u009e"+
		"\u009f\7\6\2\2\u009f\31\3\2\2\2\u00a0\u00a1\7:\2\2\u00a1\u00a3\7\5\2\2"+
		"\u00a2\u00a4\5\34\17\2\u00a3\u00a2\3\2\2\2\u00a3\u00a4\3\2\2\2\u00a4\u00a5"+
		"\3\2\2\2\u00a5\u00a6\7\6\2\2\u00a6\u00a7\7\3\2\2\u00a7\33\3\2\2\2\u00a8"+
		"\u00ad\5$\23\2\u00a9\u00aa\7\20\2\2\u00aa\u00ac\5$\23\2\u00ab\u00a9\3"+
		"\2\2\2\u00ac\u00af\3\2\2\2\u00ad\u00ab\3\2\2\2\u00ad\u00ae\3\2\2\2\u00ae"+
		"\35\3\2\2\2\u00af\u00ad\3\2\2\2\u00b0\u00b1\7\21\2\2\u00b1\u00b2\7:\2"+
		"\2\u00b2\u00b4\7\5\2\2\u00b3\u00b5\5 \21\2\u00b4\u00b3\3\2\2\2\u00b4\u00b5"+
		"\3\2\2\2\u00b5\u00b6\3\2\2\2\u00b6\u00b7\7\6\2\2\u00b7\u00b8\5\60\31\2"+
		"\u00b8\37\3\2\2\2\u00b9\u00be\7:\2\2\u00ba\u00bb\7\20\2\2\u00bb\u00bd"+
		"\7:\2\2\u00bc\u00ba\3\2\2\2\u00bd\u00c0\3\2\2\2\u00be\u00bc\3\2\2\2\u00be"+
		"\u00bf\3\2\2\2\u00bf!\3\2\2\2\u00c0\u00be\3\2\2\2\u00c1\u00c3\7\22\2\2"+
		"\u00c2\u00c4\5$\23\2\u00c3\u00c2\3\2\2\2\u00c3\u00c4\3\2\2\2\u00c4\u00c5"+
		"\3\2\2\2\u00c5\u00c6\7\3\2\2\u00c6#\3\2\2\2\u00c7\u00c8\b\23\1\2\u00c8"+
		"\u00d6\5.\30\2\u00c9\u00d6\7:\2\2\u00ca\u00d6\5\16\b\2\u00cb\u00d6\5\b"+
		"\5\2\u00cc\u00d6\5\f\7\2\u00cd\u00d6\5\30\r\2\u00ce\u00d6\5\32\16\2\u00cf"+
		"\u00d0\7\5\2\2\u00d0\u00d1\5$\23\2\u00d1\u00d2\7\6\2\2\u00d2\u00d6\3\2"+
		"\2\2\u00d3\u00d4\7\23\2\2\u00d4\u00d6\5$\23\7\u00d5\u00c7\3\2\2\2\u00d5"+
		"\u00c9\3\2\2\2\u00d5\u00ca\3\2\2\2\u00d5\u00cb\3\2\2\2\u00d5\u00cc\3\2"+
		"\2\2\u00d5\u00cd\3\2\2\2\u00d5\u00ce\3\2\2\2\u00d5\u00cf\3\2\2\2\u00d5"+
		"\u00d3\3\2\2\2\u00d6\u00e9\3\2\2\2\u00d7\u00d8\f\6\2\2\u00d8\u00d9\5&"+
		"\24\2\u00d9\u00da\5$\23\7\u00da\u00e8\3\2\2\2\u00db\u00dc\f\5\2\2\u00dc"+
		"\u00dd\5(\25\2\u00dd\u00de\5$\23\6\u00de\u00e8\3\2\2\2\u00df\u00e0\f\4"+
		"\2\2\u00e0\u00e1\5*\26\2\u00e1\u00e2\5$\23\5\u00e2\u00e8\3\2\2\2\u00e3"+
		"\u00e4\f\3\2\2\u00e4\u00e5\5,\27\2\u00e5\u00e6\5$\23\4\u00e6\u00e8\3\2"+
		"\2\2\u00e7\u00d7\3\2\2\2\u00e7\u00db\3\2\2\2\u00e7\u00df\3\2\2\2\u00e7"+
		"\u00e3\3\2\2\2\u00e8\u00eb\3\2\2\2\u00e9\u00e7\3\2\2\2\u00e9\u00ea\3\2"+
		"\2\2\u00ea%\3\2\2\2\u00eb\u00e9\3\2\2\2\u00ec\u00ed\t\2\2\2\u00ed\'\3"+
		"\2\2\2\u00ee\u00ef\t\3\2\2\u00ef)\3\2\2\2\u00f0\u00f1\t\4\2\2\u00f1+\3"+
		"\2\2\2\u00f2\u00f3\7\61\2\2\u00f3-\3\2\2\2\u00f4\u00f5\t\5\2\2\u00f5/"+
		"\3\2\2\2\u00f6\u00fa\7\t\2\2\u00f7\u00f9\5\4\3\2\u00f8\u00f7\3\2\2\2\u00f9"+
		"\u00fc\3\2\2\2\u00fa\u00f8\3\2\2\2\u00fa\u00fb\3\2\2\2\u00fb\u00fd\3\2"+
		"\2\2\u00fc\u00fa\3\2\2\2\u00fd\u00fe\7\n\2\2\u00fe\61\3\2\2\2\u00ff\u0105"+
		"\7\37\2\2\u0100\u0105\7 \2\2\u0101\u0105\7!\2\2\u0102\u0105\7\"\2\2\u0103"+
		"\u0105\5.\30\2\u0104\u00ff\3\2\2\2\u0104\u0100\3\2\2\2\u0104\u0101\3\2"+
		"\2\2\u0104\u0102\3\2\2\2\u0104\u0103\3\2\2\2\u0105\63\3\2\2\2\u0106\u0107"+
		"\7#\2\2\u0107\u010f\78\2\2\u0108\u0109\7$\2\2\u0109\u010f\78\2\2\u010a"+
		"\u010b\7%\2\2\u010b\u010f\78\2\2\u010c\u010d\7&\2\2\u010d\u010f\78\2\2"+
		"\u010e\u0106\3\2\2\2\u010e\u0108\3\2\2\2\u010e\u010a\3\2\2\2\u010e\u010c"+
		"\3\2\2\2\u010f\u011b\3\2\2\2\u0110\u0111\7\'\2\2\u0111\u0119\78\2\2\u0112"+
		"\u0113\7(\2\2\u0113\u0119\78\2\2\u0114\u0115\7)\2\2\u0115\u0119\78\2\2"+
		"\u0116\u0117\7*\2\2\u0117\u0119\78\2\2\u0118\u0110\3\2\2\2\u0118\u0112"+
		"\3\2\2\2\u0118\u0114\3\2\2\2\u0118\u0116\3\2\2\2\u0119\u011b\3\2\2\2\u011a"+
		"\u010e\3\2\2\2\u011a\u0118\3\2\2\2\u011b\65\3\2\2\2\u011c\u011d\7\62\2"+
		"\2\u011d\u0125\7+\2\2\u011e\u011f\7\62\2\2\u011f\u0125\7,\2\2\u0120\u0121"+
		"\7\62\2\2\u0121\u0125\7-\2\2\u0122\u0123\7\62\2\2\u0123\u0125\7.\2\2\u0124"+
		"\u011c\3\2\2\2\u0124\u011e\3\2\2\2\u0124\u0120\3\2\2\2\u0124\u0122\3\2"+
		"\2\2\u0125\67\3\2\2\2\u0126\u0127\7\5\2\2\u0127\u0128\7/\2\2\u0128\u0129"+
		"\7\20\2\2\u0129\u012a\7\62\2\2\u012a\u013b\7\6\2\2\u012b\u012c\7\5\2\2"+
		"\u012c\u012d\7\62\2\2\u012d\u012e\7\20\2\2\u012e\u012f\7/\2\2\u012f\u013b"+
		"\7\6\2\2\u0130\u0131\7\5\2\2\u0131\u0132\7/\2\2\u0132\u0133\7\20\2\2\u0133"+
		"\u0134\7\65\2\2\u0134\u013b\7\6\2\2\u0135\u0136\7\5\2\2\u0136\u0137\7"+
		"\65\2\2\u0137\u0138\7\20\2\2\u0138\u0139\7/\2\2\u0139\u013b\7\6\2\2\u013a"+
		"\u0126\3\2\2\2\u013a\u012b\3\2\2\2\u013a\u0130\3\2\2\2\u013a\u0135\3\2"+
		"\2\2\u013b9\3\2\2\2\u013c\u013d\7\60\2\2\u013d;\3\2\2\2\34?KOZ^z\u0080"+
		"\u0087\u008c\u0099\u009c\u00a3\u00ad\u00b4\u00be\u00c3\u00d5\u00e7\u00e9"+
		"\u00fa\u0104\u010e\u0118\u011a\u0124\u013a";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}