using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchids.Core.Tokenization;

namespace Orchids.Core.Lexical;

public static class LexicalAnalyzer
{
    public static void Analyze(string code)
    {
        var tokens = new List<Token>();

        var scanner = new TextScanner(code); // 扫描源代码的扫描器

        for (int i = 0; i < scanner.Content.Length;)
        {
            void Next()
            {
                scanner.Next();
                i++;
            }

            // 忽略空格、Tab和换行
            if (scanner.CurrentChar == ' ' || scanner.CurrentChar == '\t' || scanner.CurrentChar == '\n')
            {
                Next();
                continue;
            }
            // 字母开头一定是标识符或关键字
            else if (TextScanner.IsLetter(scanner.CurrentChar))
            {
                var tokenValue = string.Empty; // token的值

                // 非字母非数字时退出，将内容存储在tokenValue中
                while (TextScanner.IsLetter(scanner.CurrentChar) || TextScanner.IsDigit(scanner.CurrentChar))
                {
                    // 将读取的字符ch存入token中
                    tokenValue += scanner.CurrentChar;
                    // 获取下一个字符
                    Next();
                }

                if (Token.KEYWORDS.Contains(tokenValue))
                    tokens.Add(new Token(Token.TOKEN_TYPE_MAPPINGS[tokenValue], tokenValue));
                else
                    tokens.Add(new Token(TokenTypes.IDENTIFIER, tokenValue));
            }
            // 数字开头则是数字字面量
            else if (TextScanner.IsDigit(scanner.CurrentChar))
            {
                var tokenValue = string.Empty;
                var dotted = false;

                // 当前获取到的字符不为数字时退出
                while (TextScanner.IsDigit(scanner.CurrentChar))
                {
                    //读取数字，将其存入token中
                    tokenValue += scanner.CurrentChar;
                    Next();
                    //该单词中第一次出现小数点
                    if (scanner.CurrentChar == '.' && !dotted)
                    {
                        //小数点下一位是数字
                        if (TextScanner.IsDigit(scanner.NextChar))
                        {
                            //标记该常数中已经出现过小数点
                            dotted = true;
                            //将小数点入token中
                            tokenValue += scanner.LastChar;
                            Next();
                        }
                    }
                }

                tokens.Add(new Token(TokenTypes.LIT_NUM, tokenValue));
            }
            
            switch (scanner.CurrentChar)
            {
                case '+':
                    tokens.Add(new Token(TokenTypes.OP_ADD, "+"));
                    break;
                case '-':
                    tokens.Add(new Token(TokenTypes.OP_MIN, "-"));
                    break;
                case '*':
                    tokens.Add(new Token(TokenTypes.OP_MUL, "*"));
                    break;
                case '/':
                    tokens.Add(new Token(TokenTypes.OP_DIV, "/"));
                    break;
                case '=':
                    {
                         if (scanner.NextChar.Equals('='))
                         {
                            tokens.Add(new Token(TokenTypes.OP_EQ, "=="));
                            Next();
                         }
                         else
                           tokens.Add(new Token(TokenTypes.OP_ASSIGN, "="));

                         break;
                    }
                case '<':
                    {
                        if (scanner.NextChar.Equals('='))
                        {
                            tokens.Add(new Token(TokenTypes.OP_LEQ, "<="));
                            Next();
                        }
                        else
                            tokens.Add(new Token(TokenTypes.OP_LT, "<"));

                        break;
                    }
                case '>':
                    {
                        if (scanner.NextChar.Equals('='))
                        {
                            tokens.Add(new Token(TokenTypes.OP_GEQ, ">="));
                            Next();
                        }
                        else
                            tokens.Add(new Token(TokenTypes.OP_GT, ">"));

                        break;
                    }
                case '\'': 
                    {
                        Next();
                        var stringContent = string.Empty;

                        while (!scanner.CurrentChar.Equals('\''))
                        {
                            stringContent += scanner.CurrentChar;
                            Next();
                        }

                        tokens.Add(new Token(TokenTypes.LIT_STR, stringContent));
                        // Next();
                        break;
                    }
                case ':':
                    tokens.Add(new Token(TokenTypes.SEP_COLON, ":"));
                    break;
                case ';':
                    tokens.Add(new Token(TokenTypes.SEP_SEMICOLON, ";"));
                    break;
                case '(':
                    tokens.Add(new Token(TokenTypes.SEP_LPA, "("));
                    break;
                case ')':
                    tokens.Add(new Token(TokenTypes.SEP_RPA, ")"));
                    break;
                case '.':
                    tokens.Add(new Token(TokenTypes.OP_ACCESS, "."));
                    break;
                case '[':
                    tokens.Add(new Token(TokenTypes.SEP_LBR, "["));
                    break;
                case ']':
                    tokens.Add(new Token(TokenTypes.SEP_RBR, "]"));
                    break;
                case ',':
                    tokens.Add(new Token(TokenTypes.SEP_COMMA, ","));
                    break;
                case ' ': break;
                default:
                    tokens.Add(new Token(TokenTypes.UNDEFINED, scanner.CurrentChar.ToString()));
                    break;
            }

            Next();
        }
        // tokens.RemoveAll((token) => token.TokenType == TokenTypes.UNDEFINED && token.TokenValue.Equals(string.Empty));
        tokens.ForEach(Console.WriteLine);
    }
}
