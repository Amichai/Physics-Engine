using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicsEngine.Compiler {
	class ConstructedTree : ParseTree {
		public ParseTree tree;
		public ConstructedTree(ParseTree inputTree) {
			tree = inputTree;
			//This is to contain all the parse tree manipulation methods
			//Flatten out teired addition
			//Find common factors over an addition problem
			//Distribute multiplication over addition
			//Addition and multiplication can be rearranged (commutative)
			//Build fractions instead of evaluation
		}
	}
}
