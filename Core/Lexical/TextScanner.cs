using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchids.Core.Lexical;

public class TextScanner
{
    public string Content { get; protected set; }
    public char CurrentChar { get; set; }
    public char LastChar { get; set; }
    public char NextChar { get; set; }

    private int curr_index = 0;

    public TextScanner(string content)
    {
        this.Content = content;
        this.LastChar = Char.MinValue;
        this.CurrentChar = this.Content[0];
        this.NextChar = this.Content[1];
    }

    public void Next()
    {
        this.LastChar = this.Content[curr_index];

        if (curr_index + 1 < this.Content.Length)
        {
            curr_index++;
            this.CurrentChar = this.Content[curr_index];

            if (curr_index + 2 < this.Content.Length)
                this.NextChar = this.Content[curr_index + 1];
            else
                this.NextChar = Char.MinValue;
        }
        else
        {
            this.NextChar = Char.MinValue;
        }
    }

    public void JumpTo(int index)
    {
        this.curr_index = index - 1;
        Next();
    }

    public static bool IsLetter(char letter)
    {
        if ((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z'))
            return true;
        return false;

    }

    public static bool IsDigit(char digit)
    {
        if (digit >= '0' && digit <= '9')
            return true;

        return false;
    }
}
