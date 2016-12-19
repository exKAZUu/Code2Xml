#region License

// Copyright (C) 2011-2016 Kazunori Sakamoto
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;
using Code2Xml.Core.Generators.ANTLRv4;
using Code2Xml.Core.Generators.ANTLRv4.Swift;

public class SwiftSupport {
    /* TODO
    There is one caveat to the rules above. If the ! or ? predefined operator
     has no whitespace on the left, it is treated as a postfix operator,
     regardless of whether it has whitespace on the right. To use the ? as
     the optional-chaining operator, it must not have whitespace on the left.
      To use it in the ternary conditional (? :) operator, it must have
      whitespace around both sides.
    */

    /*
    operator-head : /  =  -  +  !  *  %  <  >  &  |  ^  ~  ?
      | [\u00A1-\u00A7]
      | [\u00A9\u00AB]
      | [\u00AC\u00AE]
      | [\u00B0-\u00B1\u00B6\u00BB\u00BF\u00D7\u00F7]
      | [\u2016-\u2017\u2020-\u2027]
      | [\u2030-\u203E]
      | [\u2041-\u2053]
      | [\u2055-\u205E]
      | [\u2190-\u23FF]
      | [\u2500-\u2775]
      | [\u2794-\u2BFF]
      | [\u2E00-\u2E7F]
      | [\u3001-\u3003]
      | [\u3008-\u3030]
      ;
     */
    public static readonly BitSet operatorHead = new BitSet(0x3100); // costs about 2k

    public static readonly BitSet leftWS = new BitSet(255);
    public static readonly BitSet rightWS = new BitSet(255);

    static SwiftSupport() {
        operatorHead.Set(SwiftParser.BANG);
        operatorHead.Set(SwiftParser.LT);
        operatorHead.Set(SwiftParser.GT);
        operatorHead.Set(SwiftParser.AND);
        operatorHead.Set(SwiftParser.OR);
        operatorHead.Set(SwiftParser.SUB);
        operatorHead.Set(SwiftParser.ADD);
        operatorHead.Set(SwiftParser.MUL);
        operatorHead.Set(SwiftParser.DIV);
        operatorHead.Set(SwiftParser.MOD);
        operatorHead.Set(SwiftParser.EQUAL);
        operatorHead.Set(SwiftParser.CARET);
        operatorHead.Set(SwiftParser.TILDE);
        operatorHead.Set(SwiftParser.QUESTION);
        operatorHead.Set(0xA1, 0xA7 + 1);
        operatorHead.Set(0xA9, 0xAB + 1);
        operatorHead.Set(0xAC, 0xAE + 1);
        operatorHead.Set(0xB0, 0xB1 + 1);
        operatorHead.Set(0xB6);
        operatorHead.Set(0xBB);
        operatorHead.Set(0xBF);
        operatorHead.Set(0xD7);
        operatorHead.Set(0xF7);
        operatorHead.Set(0x2016, 0x2017 + 1);
        operatorHead.Set(0x2020, 0x2027 + 1);
        operatorHead.Set(0x2030, 0x203E + 1);
        operatorHead.Set(0x2041, 0x2053 + 1);
        operatorHead.Set(0x2055, 0x205E + 1);
        operatorHead.Set(0x2190, 0x23FF + 1);
        operatorHead.Set(0x2500, 0x2775 + 1);
        operatorHead.Set(0x2794, 0x2BFF + 1);
        operatorHead.Set(0x2E00, 0x2E7F + 1);
        operatorHead.Set(0x3001, 0x3003 + 1);
        operatorHead.Set(0x3008, 0x3030 + 1);

        leftWS.Set(SwiftParser.WS);
        leftWS.Set(SwiftParser.LPAREN);
        leftWS.Set(SwiftParser.LBRACK);
        leftWS.Set(SwiftParser.LCURLY);
        leftWS.Set(SwiftParser.COMMA);
        leftWS.Set(SwiftParser.COLON);
        leftWS.Set(SwiftParser.SEMI);

        rightWS.Set(SwiftParser.WS);
        rightWS.Set(SwiftParser.RPAREN);
        rightWS.Set(SwiftParser.RBRACK);
        rightWS.Set(SwiftParser.RCURLY);
        rightWS.Set(SwiftParser.COMMA);
        rightWS.Set(SwiftParser.COLON);
        rightWS.Set(SwiftParser.SEMI);
        rightWS.Set(SwiftParser.Line_comment);
        rightWS.Set(SwiftParser.Block_comment);
    }

    public static boolean isOperatorHead(int ttype) {
        return operatorHead.Get(ttype);
    }

    /*
    Operator_character
      : Operator_head
      | [\u0300–\u036F]
      | [\u1DC0–\u1DFF]
      | [\u20D0–\u20FF]
      | [\uFE00–\uFE0F]
      | [\uFE20–\uFE2F]
      //| [\uE0100–\uE01EF]  ANTLR can't do >16bit char
      ;
     */

    public static boolean isOperatorChar(int ttype) {
        return
                operatorHead.Get(ttype) ||
                ttype >= 0x0300 && ttype <= 0x036F ||
                ttype >= 0x1DC0 && ttype <= 0x1DFF ||
                ttype >= 0x20D0 && ttype <= 0x20FF ||
                ttype >= 0xFE00 && ttype <= 0xFE0F ||
                ttype >= 0xFE20 && ttype <= 0xFE2F;
    }

    public static boolean isOpNext(ITokenStream tokens) {
        var start = tokens.Index;
        var lt = tokens.Get(start);
        var stop = getLastOpTokenIndex(tokens);
        if (stop == -1) return false;
        Console.WriteLine("isOpNext: i={0} t='{1}'", start, lt.getText());
        Console.WriteLine(", op='{0}'\n", tokens.GetText(Interval.Of(start, stop)));
        return true;
    }

    /** Find stop token index of next operator; return -1 if not operator. */

    public static int getLastOpTokenIndex(ITokenStream tokens) {
        var i = tokens.Index; // current on-channel lookahead token index
        var lt = tokens.Get(i);
        if (lt.getType() == SwiftParser.DOT && tokens.get(i + 1).getType() == SwiftParser.DOT) {
            // dot-operator
            i += 2; // point at token after ".."
            lt = tokens.get(i);
            while (lt.getType() != Token.EOF &&
                   (lt.getType() == SwiftParser.DOT || isOperatorChar(lt.getType()))) {
                i++;
                lt = tokens.get(i);
            }
            return i - 1;
        }
        // Is it regular operator?
        if (!isOperatorHead(lt.getType())) {
            return -1;
        }
        i++;
        lt = tokens.get(i);
        while (lt.getType() != Token.EOF && isOperatorChar(lt.getType())) {
            i++;
            lt = tokens.get(i);
        }
        int stop = i - 1;
        return stop;
    }

    /**
     "If an operator has whitespace around both sides or around neither side,
     it is treated as a binary operator. As an example, the + operator in a+b
     and a + b is treated as a binary operator."
     */

    public static boolean isBinaryOp(ITokenStream tokens) {
        var stop = getLastOpTokenIndex(tokens);
        if (stop == -1) return false;

        var start = tokens.Index;
        var prevToken = tokens.get(start - 1); // includes hidden-channel tokens
        var nextToken = tokens.get(stop + 1);
        var prevIsWS = isLeftOperatorWS(prevToken);
        var nextIsWS = isRightOperatorWS(nextToken);
        var result = prevIsWS && nextIsWS || (!prevIsWS && !nextIsWS);
        var text = tokens.GetText(Interval.Of(start, stop));
        //System.out.println("isBinaryOp: '"+prevToken+"','"+text+"','"+nextToken+"' is "+result);
        return result;
    }

    /**
     "If an operator has whitespace on the left side only, it is treated as a
     prefix unary operator. As an example, the ++ operator in a ++b is treated
     as a prefix unary operator."
    */

    public static boolean isPrefixOp(ITokenStream tokens) {
        int stop = getLastOpTokenIndex(tokens);
        if (stop == -1) return false;

        var start = tokens.Index;
        var prevToken = tokens.get(start - 1); // includes hidden-channel tokens
        var nextToken = tokens.get(stop + 1);
        var prevIsWS = isLeftOperatorWS(prevToken);
        var nextIsWS = isRightOperatorWS(nextToken);
        var result = prevIsWS && !nextIsWS;
        var text = tokens.GetText(Interval.Of(start, stop));
        //System.out.println("isPrefixOp: '"+prevToken+"','"+text+"','"+nextToken+"' is "+result);
        return result;
    }

    /**
     "If an operator has whitespace on the right side only, it is treated as a
     postfix unary operator. As an example, the ++ operator in a++ b is treated
     as a postfix unary operator."

     "If an operator has no whitespace on the left but is followed immediately
     by a dot (.), it is treated as a postfix unary operator. As an example,
     the ++ operator in a++.b is treated as a postfix unary operator (a++ .b
     rather than a ++ .b)."
     */

    public static boolean isPostfixOp(ITokenStream tokens) {
        int stop = getLastOpTokenIndex(tokens);
        if (stop == -1) return false;

        int start = tokens.Index;
        var prevToken = tokens.get(start - 1); // includes hidden-channel tokens
        var nextToken = tokens.get(stop + 1);
        var prevIsWS = isLeftOperatorWS(prevToken);
        var nextIsWS = isRightOperatorWS(nextToken);
        var result =
                !prevIsWS && nextIsWS ||
                !prevIsWS && nextToken.getType() == SwiftParser.DOT;
        var text = tokens.GetText(Interval.Of(start, stop));
        //System.out.println("isPostfixOp: '"+prevToken+"','"+text+"','"+nextToken+"' is "+result);
        return result;
    }

    public static boolean isOperator(ITokenStream tokens, String op) {
        var stop = getLastOpTokenIndex(tokens);
        if (stop == -1) return false;

        var start = tokens.Index;
        var text = tokens.GetText(Interval.Of(start, stop));
        return text.Equals(op);
    }

    /** Return two booleans packed into lowest 2 bits for left (high) and right (low)
     *  whitespace.
     */

    public static int getLeftRightWS(ITokenStream tokens, ParserRuleContext ctx) {
        var left = ctx.start.getTokenIndex();
        var right = ctx.stop.getTokenIndex();
        var prevToken = tokens.get(left - 1); // includes hidden-channel tokens
        var nextToken = tokens.get(right + 1);
        var prevIsWS = isLeftOperatorWS(prevToken);
        var nextIsWS = isRightOperatorWS(nextToken);
        var b = (prevIsWS ? 1 : 0) << 1 | (nextIsWS ? 1 : 0);
        return b;
    }

    public static boolean isLeftOperatorWS(IToken t) {
        return leftWS.Get(t.getType());
    }

    public static boolean isRightOperatorWS(IToken t) {
        return rightWS.Get(t.getType()) || t.getType() == Token.EOF;
    }
}