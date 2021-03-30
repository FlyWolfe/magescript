using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mirth.MageLang
{
    public class Parser
    {
        static TokenList tokens;
        static Block currentBlock;
        static Stack<Block> blockstack;
        static List<Statement> actionTree;
        static bool running;

        /// <summary>
        /// Parser constructor that parses the TokenList it is given when called
        /// </summary>
        /// <param name="tokenList">The TokenList to be parsed</param>
        public Parser(TokenList tokenList)
        {
            tokens = tokenList;
            currentBlock = null;
            blockstack = new Stack<Block>();
            Token token = null;
            actionTree = new List<Statement>();
            running = true;

            while (running)
            {
                // TODO: Add things here
                // Get the next token 
                try
                {
                    token = tokens.GetNextToken();
                }
                catch { }

                if (token.Type == Token.TokenType.Import)
                {
                    // TODO: Create the program file and then uncomment this
                    Program.imports.Add(ParseImport());
                }
            }
        }

        static string ParseImport()
        {
            string value = "";
            Token token = tokens.GetNextToken();

            if (token.Type == Token.TokenType.Identifier)
            {
                value = token.Value;
            }

            return value;
        }
    }
}
