using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace magelang
{
    /// <summary>
    /// Converts a string of characters into a list of tokens
    /// </summary>
    public class Lexer
    {
        private readonly Dictionary<Token.TokenType, string> m_Tokens;
        private readonly Dictionary<Token.TokenType, MatchCollection> m_RegexDictionary;
        private string m_InputString;
        private int m_Index;

        public string InputString
        {
            set
            {
                m_InputString = value;
                PrepareRegex();
            }
        }

        public Lexer ()
        {
            m_Tokens = new Dictionary<Token.TokenType, string>();
            m_RegexDictionary = new Dictionary<Token.TokenType, MatchCollection>();
            m_Index = 0;
            m_InputString = string.Empty;

            m_Tokens.Add(Token.TokenType.Import,        "import");
            m_Tokens.Add(Token.TokenType.Function,      "function");
            m_Tokens.Add(Token.TokenType.Repeater,      "repeater");
            m_Tokens.Add(Token.TokenType.ElseIf,        "else if");
            m_Tokens.Add(Token.TokenType.If,            "if");
            m_Tokens.Add(Token.TokenType.Else,          "else");
            m_Tokens.Add(Token.TokenType.Return,        "return");
            m_Tokens.Add(Token.TokenType.StringLiteral, "\".*?\"");
            m_Tokens.Add(Token.TokenType.IntLiteral,    "[0-9][0-9]*");
            m_Tokens.Add(Token.TokenType.Whitespace,    "[ \\t]+");
            m_Tokens.Add(Token.TokenType.NewLine,       "\\n");
            m_Tokens.Add(Token.TokenType.Add,           "\\+");
            m_Tokens.Add(Token.TokenType.Sub,           "\\-");
            m_Tokens.Add(Token.TokenType.Mul,           "\\*");
            m_Tokens.Add(Token.TokenType.Div,           "\\/");
            m_Tokens.Add(Token.TokenType.DoubleEqual,   "\\==");
            m_Tokens.Add(Token.TokenType.NotEqual,       "\\!=");
            m_Tokens.Add(Token.TokenType.Equal,         "\\=");
            m_Tokens.Add(Token.TokenType.LeftParen,     "\\(");
            m_Tokens.Add(Token.TokenType.RightParen,    "\\)");
            m_Tokens.Add(Token.TokenType.LeftBrace,     "\\{");
            m_Tokens.Add(Token.TokenType.RightBrace,    "\\}");
            m_Tokens.Add(Token.TokenType.Comma,         "\\,");
            m_Tokens.Add(Token.TokenType.Period,        "\\.");
        }

        /// <summary>
        /// Adds the TokenType,string pairs into the m_RegexDictionary to prepare for lexing the InputString
        /// with the added regex pairs
        /// </summary>
        private void PrepareRegex()
        {
            m_RegexDictionary.Clear();
            foreach (KeyValuePair<Token.TokenType, string> pair in m_Tokens)
            {
                m_RegexDictionary.Add(pair.Key, Regex.Matches(m_InputString, pair.Value));
            }
        }

        /// <summary>
        /// Clears the InputString, empties the m_RegexDictionary, and resets the m_Index position
        /// </summary>
        public void ClearLexer()
        {
            m_Index = 0;
            m_InputString = string.Empty;
            m_RegexDictionary.Clear();
        }



        // TODO: Everything after this point needs to be redone. I don't really know what it's supposed to do...


        public Token GetToken()
        {
            if (m_Index >= m_InputString.Length)
                return null;

            foreach (KeyValuePair<Token.TokenType, MatchCollection> pair in m_RegexDictionary)
            {
                foreach (Match match in pair.Value)
                {
                    if (match.Index == m_Index)
                    {
                        m_Index += match.Length;
                        return new Token(pair.Key, match.Value);
                    }

                    if (match.Index > m_Index)
                    {
                        break;
                    }
                }
            }

            m_Index++;
            
            return new Token(Token.TokenType.Undefined, string.Empty);
        }

        public PeekToken Peek()
        {
            return Peek(new PeekToken(m_Index, new Token(Token.TokenType.Undefined, string.Empty)));
        }

        public PeekToken Peek(PeekToken peekToken)
        {
            int oldIndex = m_Index;

            m_Index = peekToken.TokenIndex;

            if (m_Index >= m_InputString.Length)
            {
                m_Index = oldIndex;
                return null;
            }

            foreach (KeyValuePair<Token.TokenType, string> pair in m_Tokens)
            {
                Regex r = new Regex(pair.Value);
                Match m = r.Match(m_InputString, m_Index);

                if (m.Success && m.Index == m_Index)
                {
                    m_Index += m.Length;
                    PeekToken pt = new PeekToken(m_Index, new Token(pair.Key, m.Value));
                    m_Index = oldIndex;
                    return pt;
                }
            }
            PeekToken pt2 = new PeekToken(m_Index + 1, new Token(Token.TokenType.Undefined, string.Empty));
            m_Index = oldIndex;
            return pt2;
        }
    }

}