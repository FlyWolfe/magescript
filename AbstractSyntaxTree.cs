using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace magelang
{
    abstract class Statement { }
    abstract class Expression { }

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

    class IfBlock : Block
    {
        public Expression leftExpr;
        // TODO: public Symbol op;
        public Expression rightExpr;

        public IfBlock(Expression leftExpr, /* TODO: Symbol o,*/ Expression rightExpr)
        {
            this.leftExpr = leftExpr;
            // TODO: op = o;
            this.rightExpr = rightExpr;
        }
    }

    class ElseIfBlock : Block
    {
        public Expression leftExpr;
        // TODO: public Symbol op;
        public Expression rightExpr;

        public ElseIfBlock(Expression leftExpr, /* TODO: Symbol o,*/ Expression rightExpr)
        {
            this.leftExpr = leftExpr;
            // TODO: op = o;
            this.rightExpr = rightExpr;
        }
    }

    class ElseBlock : Block { }

    class EndIf : Block { }

    class Assign : Statement
    {
        public string identifier;
        public Expression value;

        public Assign(string identifier, Expression value)
        {
            this.identifier = identifier;
            this.value = value;
        }
    }
}
