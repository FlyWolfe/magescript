using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace magelang
{
    class Parser
    {
        static TokenList tokens;
        static Block currentBlock;
        static Stack<Block> blockstack;
        static List<Statement> actionTree;
        static bool running;

        public Parser(TokenList t)
        {
            tokens = t;
            currentBlock = null;
            blockstack = new Stack<Block>();
            Token tok = null;
            actionTree = new List<Statement>();
            running = true;

            while (running)
            {
                // TODO: Add things here
            }
        }
    }
}
