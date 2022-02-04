using System;
using Lang.Tokens;
using Utils.Debug;

namespace Lang
{
    static class Program
    {
        private readonly static string Path = Directory.GetCurrentDirectory() + "/source.ymis";

        static void Main(string[] args)
        {
            var source = File.ReadAllLines(Path);
            var tokens = Tokenizer.GetTokens(source[0], 0).ToArray();

            for (var i = 0; i < tokens.Length; i++)
            {
                Log.Info($"Token in line 0 index {i} - {tokens[i].Type}");
            }
        }
    }
}