using System.Collections.Generic;
using System.IO;

namespace Mirth.MageLang
{
    public class Program
    {
        // TODO: I feel like this could be placed somewhere better
        public static List<string> imports;

        static void Main(string[] args)
        {
            imports = new List<string>();

            StreamReader sr = new StreamReader(args[0]);
            string code = sr.ReadToEnd();

            // TODO: I don't really know what this is supposed to do yet. Working on it
            //Lexer lexer = new MageCompiler.Lexer();
            //lexer.InputString = code;

            List<Token> tokens = new List<Token>();

            while (true)
            {
                try
                {
                    //Token t = lexer.GetToken();

                    //if (t.TokenName.ToString() != "Whitespace" && t.TokenName.ToString() != "NewLine" && t.TokenName.ToString() != "Undefined")
                    //{
                    //    tokens.Add(t);
                    //}
                }
                catch
                {
                    break;
                }
            }

            Token token = new Token(Token.TokenType.EOF, "EOF");
            tokens.Add(token);

            TokenList tokenlist = new TokenList(tokens);

            Parser parser = new Parser(tokenlist);
            // TODO: GetTree has yet to be implemented
            //List<Statement> tree = parser.GetTree();

            // TODO: Create the compiler class
            //Compiler compiler = new Compiler(tree);
            //string c = compiler.GetCode();

            string path = Path.GetDirectoryName(args[0]);

            foreach (string p in imports)
            {
                StreamReader s = new StreamReader(path + "\\" + p + ".txt");
                // TODO: Uncomment this when compiler class is created
                //c += "\n" + s.ReadToEnd();
            }

            // TODO: The way this works is entirely incorrect. We don't want to compile to a .mage file,
            // TODO: We want to compile to machine code. But this is what I'm working from right now
            FileStream fs = new FileStream(Path.GetFileNameWithoutExtension(args[0]) + ".mage", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            // TODO: Uncomment this when compiler class is created
            //bw.Write(c);
        }
    }
}