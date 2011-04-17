using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhysicsEngine;
using UserInterface;


namespace PhysicsEngine.Expression {
	class Expression {
		Tokens tokens;
		public Expression(string input) {
			tokens = new Tokenizer(input).Scan()	.AddToLog(LogType.allTokens);
			new PostfixedTokens(tokens.tokens)		.AddToLog(LogType.postFixedTokens)
									.BuildParseTree().AddToLog(LogType.parseTree);

			UI.DisplayLog(LogType.allTokens);
			UI.DisplayLog(LogType.postFixedTokens);
			UI.DisplayLog(LogType.output);
			UI.DisplayLog(LogType.parseTree);
		}
		

		//Define variables 
		//Allow the resolution of one variable from the context
		//Figure out function derivations
		//graph
		//solve
		//Render - eq visualizer
		//Handle infinite series
		//Sums
		//Calc
	}
}
