using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Antlr.Runtime;

namespace Code2Xml.Languages.ANTLRv3
{
    public partial class JavaLexer
    {
		public Antlr3Listener Listener {
			get; set;
		}

	    private int depth = 0;

	    partial void EnterRule(string ruleName, int ruleIndex) {
		    depth++;
		    Console.WriteLine("Enter: " + ruleName);
	    }

	    partial void LeaveRule(string ruleName, int ruleIndex) {
		    if (--depth == 0) {
			    Listener.VisitTerminalNode(Text, ruleIndex, state.channel);
		    }
		    Console.WriteLine("Levave: " + ruleName);
	    }
    }
}
