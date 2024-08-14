using Orchids.Core.Lexical;
using Orchids.Runtime;

namespace Orchids;

public class Program
{
    static void Main(string[] args)
    {
        /*
         * 测试项目：创建变量
         * 测试序号：TEST_OVM_001
         * 测试方法：通过检测GlobalObjectPool来判断变量是否被创建
         */
        var code = "const stdio = import('@std/io');\nconst str = 'Hello World!';\nstdio.out(str);\n";
        Console.WriteLine(code);
        RuntimeManager.Run(code);
    }
}
