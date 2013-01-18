using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code2Xml.Core.Antlr;

partial class CParser {
    private bool changed = false; 
    partial void EnterRule_declarator_suffix()
    {
        if (declaration_stack.size() > 0 && declaration_stack.Peek().isTypedef)
        {
            declaration_stack.Peek().isTypedef = false;
            changed = true;
        }
    }

    partial void LeaveRule_declarator_suffix()
    {
        if (changed) {
            changed = false;
            declaration_stack.Peek().isTypedef = true;
        }
    }
}
