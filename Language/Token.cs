namespace Lang.Tokens
{
    public struct Token
    {
        public bool IsNull => Type == TokenType.NULL;
        public readonly TokenType Type;

        public readonly int TokenIndexInLine;

        public Token(TokenType type, int indexInLine)
        {
            Type = type;
            TokenIndexInLine = indexInLine;
        }
    }

    public enum TokenType
    {
        NULL, Comment, Semicolon
    }
}