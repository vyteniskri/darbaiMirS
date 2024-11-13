grammar CMatch;

program: line* EOF;

line: statement | statementif | statementfor | statmentmatch | functionDeclare | functionalCall | returnStatement ;

statement: (assigment | functionCall) ';';

//It represents how the if statment looks like.
statementif: 'if' '(' expression ')' block ('or' statmentelseif)?;

statmentelseif: block | statementif;

//It represents how the for statment looks like.
statementfor: 'for' '('assigment ';' expression ';' assigment ')' '{' block '}';

///////////////////////////////////////////////////////////////////////////////////////////////

statmentmatch: 'match' '(' identifierPattern ')' '{' ('case' pattern ':' '{' block '}')+  '}';

identifierPattern
    : constant                                           
    | IDENTIFIER                                         
    ;

primaryPattern: decimalNumbersHead
    | decimalNumbersTail
    | touplePattern
    | constantPattern
    | wildcardPattern;

pattern: primaryPattern ('when' expression)?;

///////////////////////////////////////////////////////////////////////////////////////////////


assigment: IDENTIFIER '=' expression;

functionCall: IDENTIFIER '(' (expression (',' expression)*)? ')';

functionalCall: IDENTIFIER '(' expressionList? ')' ';';
expressionList : expression (',' expression)* ;

functionDeclare: 'func' IDENTIFIER '(' parameterList? ')'  block  ;
parameterList : IDENTIFIER (',' IDENTIFIER)* ;

returnStatement : 'return' expression? ';';

expression
    : constant                                           #constantExpression
    | IDENTIFIER                                         #identifierExpression
    | statmentmatch                                      #statmentmatchExpression
    | statementif                                        #statementifExpression
    | statementfor                                       #statementforExpression
    | functionCall                                       #functionCallExpression
    | functionalCall                                     #functionalCallExpression
    | '(' expression ')'                                 #parentsizedExpression
    | '!' expression                                     #notExpression
    | expression multOp expression                       #multiplicativeExpression
    | expression addOp expression                        #additiveExpression
    | expression compareOp expression                    #comparisonExpression
    | expression boolOp expression                       #booleanExpression
    ;

multOp: '*' | '/' | '%';
addOp: '+' | '-';
compareOp: '==' | '!=' | '>' | '<' | '>=' | '<=';
boolOp: BOOL_OP;

BOOL_OP: '&&' | '||';

constant: INTEGER | DOUBLE | STRING | BOOL | NULL | TOUPLE;

INTEGER: [-]?[0-9]+ ;
TOUPLE : '(' INTEGER ',' INTEGER ')' | '(' STRING ',' INTEGER ')' | '(' INTEGER ',' STRING ')';
DOUBLE: [-]?[0-9]+ '.' [0-9]+;
STRING: ('"' ~'"'* '"') | ('\'' ~'\''* '\'');
//SYMBOL: ('\''[a-zA-z]'\'');
BOOL: 'true' | 'false';
NULL: 'Null';

POSITIVE: [0-9]+;
//This shows what the task block will look like, which will list what will happen if the condition holds true.
block: '{' line* '}';

WS: [ \t\r\n]+ -> skip;
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9]*;

constantPattern : 'constint' | 'conststring' | 'constdouble' | 'constbool' | constant;
decimalNumbersTail : ( '#.'POSITIVE | '##.'POSITIVE | '###.'POSITIVE | '####.'POSITIVE )
                     | ( '-#.'POSITIVE | '-##.'POSITIVE | '-###.'POSITIVE | '-####.'POSITIVE );
decimalNumbersHead : (INTEGER'.#' | INTEGER'.##' | INTEGER'.###' | INTEGER'.####');
touplePattern : '(' '#' ',' INTEGER ')' | '(' INTEGER ',' '#' ')' | '(' '#' ',' STRING ')' | '(' STRING ',' '#' ')' ;
wildcardPattern : '_';