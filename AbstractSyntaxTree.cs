using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mirth.MageLang
{
    /// <summary>
    /// Super class for statements (function blocks, if blocks, variable assignments, etc.)
    /// </summary>
    abstract class Statement { }
    /// <summary>
    /// Super class for expression nodes (int literals, string literals, identifiers, etc.)
    /// </summary>
    abstract class Expression { }

    /// <summary>
    /// Mathematical symbols used in conditional blocks and mathematical expressions
    /// </summary>
    enum Symbol
    {
        add = 0,
        sub = 1,
        mul = 2,
        div = 3,
        equal = 4,
        doubleEqual = 5,
        notEqual = 6,
        leftParen = 7,
        rightParen = 8
    }

    /// <summary>
    /// Super class for all blocks of nodes. Contains all the statements within that block.
    /// Essentially, a block is a list of statements that may or may not be executed (as in a set of If/Else statement blocks)
    /// </summary>
    class Block : Statement
    {
        public List<Statement> statements;

        public Block()
        {
            statements = new List<Statement>();
        }

        public void AddSatement(Statement statement)
        {
            statements.Add(statement);
        }
    }

    /// <summary>
    /// The function block. Stores a function's identifier and the values it can be called with
    /// </summary>
    class Function : Block
    {
        public string identifier;
        public List<string> vars;

        public Function(string identifier, List<string> vars)
        {
            this.identifier = identifier;
            this.vars = vars;
        }
    }

    /// <summary>
    /// The repeater block. Stores a repeater's identifier and the values it can be called with
    /// </summary>
    class Repeater : Block
    {
        public string identifier;
        public List<string> vars;

        public Repeater(string identifier, List<string> vars)
        {
            this.identifier = identifier;
            this.vars = vars;
        }
    }

    /// <summary>
    /// If block. Stores the left and right sides of a conditional expression as well as the operation performed within
    /// </summary>
    class IfBlock : Block
    {
        public Expression leftExpr;
        public Symbol operation;
        public Expression rightExpr;

        public IfBlock(Expression leftExpr, Symbol operation, Expression rightExpr)
        {
            this.leftExpr = leftExpr;
            this.operation = operation;
            this.rightExpr = rightExpr;
        }
    }

    /// <summary>
    /// ElseIf block. Stores the left and right sides of a conditional expression as well as the operation performed within
    /// </summary>
    class ElseIfBlock : Block
    {
        public Expression leftExpr;
        public Symbol operation;
        public Expression rightExpr;

        public ElseIfBlock(Expression leftExpr, Symbol operation, Expression rightExpr)
        {
            this.leftExpr = leftExpr;
            this.operation = operation;
            this.rightExpr = rightExpr;
        }
    }

    /// <summary>
    /// Else block. Stores nothing else beyond what its super class stores. Else's don't have any expressions to evaluate
    /// </summary>
    class ElseBlock : Block { }

    /// <summary>
    /// EndIf block. Stores nothing else beyond what its super class stores. EndIf's just close the If block
    /// </summary>
    class EndIf : Block { }

    /// <summary>
    /// Assignment statement. Stores the identifier to assign a value to. The value to be assigned is given as an expression
    /// </summary>
    class Assignment : Statement
    {
        public string identifier;
        public Expression value;

        public Assignment(string identifier, Expression value)
        {
            this.identifier = identifier;
            this.value = value;
        }
    }

    /// <summary>
    /// Call statement. Stores the identifier of the function to call as well as the arguments to call it with
    /// </summary>
    class Call : Statement
    {
        public string identifier;
        public List<Expression> args;

        public Call(string identifier, List<Expression> args)
        {
            this.identifier = identifier;
            this.args = args;
        }
    }

    /// <summary>
    /// Return statement. Stores the expression to be returned from a function
    /// </summary>
    class Return : Statement
    {
        public Expression expression;

        public Return(Expression expression)
        {
            this.expression = expression;
        }
    }

    /// <summary>
    /// Int literal expression. Stores the value of an integer that has been written in code as its value
    /// i.e. in:    a = 2
    /// "2" is the int literal
    /// </summary>
    class IntLiteral : Expression
    {
        public int value;

        public IntLiteral(int value)
        {
            this.value = value;
        }
    }

    /// <summary>
    /// String literal expression. Stores the value of a string explicitly written in code
    /// </summary>
    class StringLiteral : Expression
    {
        public string value;

        public StringLiteral(string value)
        {
            this.value = value;
        }
    }

    /// <summary>
    /// Identifier expression. Stores the identifiying name of a variable, function, etc.
    /// </summary>
    class Identifier : Expression
    {
        public string value;

        public Identifier(string value)
        {
            this.value = value;
        }
    }

    /// <summary>
    /// Math expression. Stores the operation to be performed and the left and right expressions of the operation
    /// </summary>
    class MathExpression : Expression
    {
        public Expression leftExpression;
        public Symbol operation;
        public Expression rightExpression;

        public MathExpression(Expression leftExpression, Symbol operation, Expression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.operation = operation;
            this.rightExpression = rightExpression;
        }
    }

    /// <summary>
    /// Parenthesis expression. Stores the expression value within a set of parenthesis
    /// </summary>
    class ParenExpression : Expression
    {
        public Expression value;

        public ParenExpression(Expression value)
        {
            this.value = value;
        }
    }

    // TODO: I'm not quite sure why we need a call expression and a call statement, but I guess I'll figure that out later
    /// <summary>
    /// Call expression. Stores the identifier of the expression being called as well as the arguments to call it with
    /// </summary>
    class CallExpression : Expression
    {
        public string identifier;
        public List<Expression> args;

        public CallExpression(string identifier, List<Expression> args)
        {
            this.identifier = identifier;
            this.args = args;
        }
    }
}
