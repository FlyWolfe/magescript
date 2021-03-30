using System.Collections.Generic;

namespace Mirth.MageLang
{
    /// <summary>
    /// Links a token type to its string representation
    /// Note: The string is usually in a regex format
    /// </summary>
    public class Token
    {
        public enum TokenType
        {
            Undefined =         0,
            Import =            1,
            Function =          2,
            If =                3,
            ElseIf =            4,
            Else =              5,
            While =             6,
            Repeater =          7,
            Return =            8,
            IntLiteral =        9,
            StringLiteral =     10,
            Whitespace =        11,
            NewLine =           12,
            Add =               13,
            Sub =               14,
            Mul =               15,
            Div =               16,
            Equal =             17,
            DoubleEqual =       18,
            NotEqual =          19,
            LeftParen =         20,
            RightParen =        21,
            Then =              22,
            End =               23,
            Comma =             24,
            Period =            25,
            EOF =               26,
            Identifier =        27
            // TODO: Hexadecimal, etc.
        }

        public TokenType Type { get; set; }

        public string Value { get; set; }

        public Token(TokenType name, string value)
        {
            Type = name;
            Value = value;
        }
    }


    /// <summary>
    /// Handles a list of tokens by iterating through them and keeping track of the current position
    /// </summary>
    public class TokenList
    {
        public List<Token> Tokens;
        private int m_Iterator = 0;

        public TokenList(List<Token> tokens)
        {
            Tokens = tokens;
        }

        /// <summary>
        /// Returns the next token in the list and increments the m_Iterator
        /// </summary>
        /// <returns>The next token to be loaded in</returns>
        public Token GetNextToken()
        {
            // TODO: Handle iterator outside bounds of array
            Token ret = Tokens[m_Iterator];
            m_Iterator++;
            return ret;
        }

        /// <summary>
        /// Returns the next token in the list without modifying the m_Iterator
        /// </summary>
        /// <returns>The next token to be loaded in</returns>
        public Token PeekNextToken()
        {
            // TODO: Handle iterator outside bounds of array
            return Tokens[m_Iterator];
        }
    }

    public class PeekToken
    {
        public int TokenIndex { get; set; }

        public Token TokenPeek { get; set; }

        public PeekToken(int index, Token value)
        {
            TokenIndex = index;
            TokenPeek = value;
        }
    }
}
