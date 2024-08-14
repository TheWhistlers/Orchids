namespace Orchids.Core.Tokenization;

public class Token
{
    // Keywords
    public const string KW_VAR = "var";
    public const string KW_CONST = "const";
    public const string KW_FUNC = "func";
    public const string KW_TYPE = "type";
    public const string KW_TRUE = "true";
    public const string KW_FALSE = "false";
    public const string KW_IF = "if";
    public const string KW_ELSE = "else";
    public const string KW_FOR = "for";
    public const string KW_END = "end";
    public const string KW_WHILE = "while";
    public const string KW_RETURN = "return";

    public static readonly Dictionary<string, TokenTypes> TOKEN_TYPE_MAPPINGS = new Dictionary<string, TokenTypes>()
    {
        { KW_VAR, TokenTypes.KW_VAR },
        { KW_CONST, TokenTypes.KW_CONST },
        { KW_FUNC, TokenTypes.KW_FUNC },
        { KW_TYPE, TokenTypes.KW_TYPE },
        { KW_TRUE, TokenTypes.KW_TRUE },
        { KW_FALSE, TokenTypes.KW_FALSE },
        { KW_IF, TokenTypes.KW_IF },
        { KW_ELSE, TokenTypes.KW_ELSE },
        { KW_WHILE, TokenTypes.KW_WHILE },
        { KW_FOR, TokenTypes.KW_FOR },
        { KW_RETURN, TokenTypes.KW_RETURN },
        { KW_END, TokenTypes.KW_END }
    };

    public static readonly List<string> KEYWORDS = new List<string>()
    {
        KW_VAR,
        KW_CONST,
        KW_FUNC,
        KW_TYPE,
        KW_TRUE,
        KW_FALSE,
        KW_IF,
        KW_ELSE,
        KW_END,
        KW_FOR,
        KW_WHILE,
        KW_RETURN
    };

    public const string SEMICOLON = ";";
    public const string COLON = ":";
    public const string EQUALS = "=";
    public const string L_PARENTHESIS = "(";
    public const string R_PARENTHESIS = ")";
    public const string L_BRACKET = "[";
    public const string R_BRACKET = "]";
    public const string OPERATOR_ADD = "+";
    public const string OPERATOR_MINUS = "-";
    public const string OPERATOR_MULTIPLY = "*";
    public const string OPERATOR_DEVIDE = "/";
    public const string OPERATOR_MODULE = "%";
    public const char QUOTATION = '\'';

    public static readonly List<string> SYMBOLS = new List<string>()
    {
        SEMICOLON,
        COLON,
        EQUALS,
        L_PARENTHESIS,
        R_PARENTHESIS,
        L_BRACKET,
        R_BRACKET,
        OPERATOR_ADD,
        OPERATOR_MINUS,
        OPERATOR_MULTIPLY,
        OPERATOR_DEVIDE,
        OPERATOR_MODULE,
    };

    public TokenTypes TokenType { get; set; }
    public string TokenValue { get; set; }

    public Token(TokenTypes type, string value)
    {
        this.TokenType = type;
        this.TokenValue = value;
    }

    public int GetTokenCode() => Convert.ToInt32(TokenType);

    public override string ToString()
    {
        return
            $"{{ " +
            $"TokenType: " +
            $"{this.TokenType}, " +
            $"TokenValue: {(this.TokenValue != null ? this.TokenValue.ToString() : "null")}" +
            $" }}";
    }
}
