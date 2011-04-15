using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compiler;
using UserInterface;

namespace PhysicsEngine.Functions {
	class Function {
		AllTokens tokens;
		public Function(string input) {
			tokens = new Tokenizer(input).Scan().AddToLog(LogType.allTokens);
		}
		

		//Define variables 
		//Allow the resolution of one variable from the context
		//Figure out function derivations

	}
}
