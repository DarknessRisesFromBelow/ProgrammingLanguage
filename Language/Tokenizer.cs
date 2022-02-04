using Utils.Debug;
using System.Linq;

namespace Lang.Tokens
{
    public static class Tokenizer
    {
        private const char SEMICOLON = ';';

        public static Token GetToken(string token, int tokenIndexInLine)
        {
            var type = GetType();
            return new Token(type, tokenIndexInLine);

            TokenType GetType()
            {
                return token switch
                {
                    "//" => TokenType.Comment,
                    ";" => TokenType.Semicolon,
                    _ => TokenType.NULL
                };
            }
        }

        public static IEnumerable<Token> GetTokens(string line, uint lineIndex)
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
            
            var currentToken = line[0].ToString();
            for (int i = 1; i < line.Length; i++)
            {
                char item = line[i];
                Log.Info($"Checking token '{currentToken}'");

                // If we have read a complete token
                Token token;
                if ((token = GetToken(currentToken, result.Count)) != TokenType.NULL)
                {
                    result.Add(token);
                    currentToken = string.Empty;

                    // Stop reading if token is a comment
                    if (token == TokenType.Comment)
                        return result;

                    continue;
                }

                currentToken += item;
            }

            // Check if the last token in the line makes sense
            Token lastToken;
            if ((lastToken = GetToken(currentToken, result.Count)) == TokenType.NULL)
            {
                Log.Error($"Invalid token in line {lineIndex}.");
                return Array.Empty<Token>();
            }
            result.Add(lastToken);

            // Add the last token (semicolon)
            result.Add(new Token(TokenType.Semicolon, result.Count));
            
            // Return the result
            return result;
        }
    }
}