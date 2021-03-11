#region Token
public class Token
{
    public enum TokenType {
        Undefined = 0,
        Import = 1,
        Function = 2,
        If = 3,
        ElseIf = 4,
        Else = 5,
        While = 6,
        Repeat = 7,
        Return = 8,
        IntLiteral = 9,
        StringLiteral = 10,
        Whitespace = 11,
        NewLine = 12,
        Add = 13,
        Sub = 14,
        Mul = 15,
        Div = 16,
        Equal = 17,
        DoubleEqual = 18,
        NotEqual = 19,
        LeftParen = 20,
        RightParen = 21,
        LeftBrace = 22,
        RightBrace = 23,
        Comma = 24,
        Period = 25,
        EOF = 26
    }

    public Tokens Type { get; set; }

    public string Value { get; set; }

    public Token(Lexer.Tokens name, string value)
    {
        Type = name;
        Value = value;
    }
}
#endregion Token

#region TokenList
public class TokenList
{
    public List<Token> Tokens;
    public int pos = 0;

    public TokenList(List<Token> tokens)
    {
        Tokens = tokens;
    }

    public Token GetToken()
    {
        Token ret = Tokens[pos];
        pos++;
        return ret;
    }

    public Token Peek()
    {
        return Tokens[pos];
    }
}
#endregion TokenList