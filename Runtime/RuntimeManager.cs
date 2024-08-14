using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orchids.Core.Lexical;
using Orchids.Core.Tokenization;

namespace Orchids.Runtime;

// 管理代码运行的工具类
public static class RuntimeManager
{
    // 运行源代码文本
    public static void Run(string code)
    {
        // Tokenization
        // 逐字扫描源代码，分词出一个个的Token
        LexicalAnalyzer.Analyze(code);
    }
}
