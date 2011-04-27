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
			input										.AddToLog(LogType.input);
			tokens = new Tokenizer(input).Scan()		.AddToLog(LogType.allTokens);
			new PostfixedTokens(tokens.tokens)			.AddToLog(LogType.postFixedTokens)
								.BuildParseTree()		.AddToLog(LogType.parseTree)
								.val.FullVisualization() .AddToLog(LogType.output);

			UI.DisplayLog(LogType.input);
			UI.DisplayLog(LogType.allTokens);
			UI.DisplayLog(LogType.postFixedTokens);
			UI.DisplayLog(LogType.parseTree);
			UI.DisplayLog(LogType.output);
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
