using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace magelang
{
    class Parser
    {
        static TokenList tokens;
        // TODO: static Block currentBlock;
        // TODO: static Stack<Block> blockstack;
        // TODO: static List<Stmt> tree;
        static bool running;

        public Parser(TokenList t)
        {
            tokens = t;
            // TODO: currentBlock = null;
            // TODO: blockstack = new Stack<Block>();
            Token tok = null;
            // TODO: tree = new List<Stmt>();
            running = true;

            while (running)
            {
                // TODO: Add things here
            }
        }
    }
}
