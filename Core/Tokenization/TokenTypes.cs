using System;

namespace Orchids.Core.Tokenization;

public enum TokenTypes
{
    /*未定义*/
    UNDEFINED = 0,

    /* 关键字 */
    KW_VAR,     // var关键字
    KW_CONST,   // const关键字
    KW_FUNC,    // func关键字
    KW_TYPE,    // type关键字
    KW_FOR,     // for关键字
    KW_WHILE,   // while关键字
    KW_IF,      // if关键字
    KW_ELSE,    // else关键字
    KW_RETURN,  // return关键字
    KW_END,  // end关键字
    KW_TRUE,    // true关键字
    KW_FALSE,   // false关键字

    /* 运算符 */
    OP_ADD,    // +加号
    OP_MIN,   // -减号
    OP_MUL,    // *乘号
    OP_DIV,	// /除号
    OP_MOD, // %取余号
	OP_ASSIGN,  // =赋值运算符
    OP_EQ,      // ==等于号
    OP_LT,      // <小于号
    OP_LEQ,     // <=小于等于号
    OP_GT,      // >大于号
    OP_GEQ,     // >=大于等于号
    OP_ACCESS,     // .访问运算符

    /* 分隔符 */
    SEP_LPA,            // (左圆括号
    SEP_RPA,            // )右圆括号
    SEP_LBR,            // [左中括号
    SEP_RBR,            // ]右中括号
    SEP_COMMA,          // ,逗号
    SEP_SEMICOLON,      //;分号
    SEP_COLON,          //:冒号

    /* 字面量 */
    LIT_STR,    // 字符串字面量
    LIT_NUM,    // 数字字面量

    /* 标识符 */
    IDENTIFIER
}
