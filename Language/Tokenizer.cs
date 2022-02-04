using Utils.Debug;

namespace Lang.Tokens
{
    public static class Tokenizer
    {
        private const char SEMICOLON = ';';

        public static Token[] GetTokens(string line, uint lineIndex)
        {   
            // Null check
            if (string.IsNullOrEmpty(line))
            {
                if (line == null)
                    Log.Error("Line is null!");
                
                return Array.Empty<Token>();
            }

            // Semicolon check
            if (line[line.Length - 1] != SEMICOLON)
            {
                Log.Error($"'{SEMICOLON}' is expected in line {lineIndex}.");

                return Array.Empty<Token>();
            }

            List<Token> result = new();
            
            var currentToken = line[0];
            for (int i = 1; i < line.Length; i++)
            {
                char item = line[i];
            }

            result.Add(new Token(TokenType.Semicolon, result.Count - 1));
        }
    }
}