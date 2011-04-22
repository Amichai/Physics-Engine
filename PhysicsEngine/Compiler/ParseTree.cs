using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicsEngine.Compiler {
	abstract class ParseTree {
		public enum nodeType { number, function, operation, variable }
		public bool numericalEvaluation;
		public List<TreeNode> children = new List<TreeNode>();
		public string name = string.Empty;
		//public double val = int.MinValue;
		public Value val;
		public nodeType type;
		private static string output = "\n";
		public string Visualize(string indent, bool last) {
			output += indent;
			if (last) {
				output += "\\ ";
				indent += "  ";
			} else {
				output += "| ";
				indent += "| ";
			}
			output += name + ": " + val.GetValueToString() + "\n";

			int i = 0;
			foreach (TreeNode c in children) {
				c.Visualize(indent, i == children.Count - 1);
				i++;
			}
			return output;
		}
	}

	class TreeNode : ParseTree{
		internal void AppendNumber(double tokenVal) {
			TreeNode child = new TreeNode();
			child.type = nodeType.number;
			child.val = new Value(tokenVal);
			child.name = tokenVal.ToString();
			child.numericalEvaluation = true;
			children.Insert(0, child);
		}

		/// <summary>
		/// Take each token string from the list of postfixedtokens and build a parse tree
		/// with each node evaluated when possible. 
		/// </summary>
		/// <param name="tokenString"></param>
		internal void AppendOperator(string tokenString) {
			//Will always take an operation and append two numbers as children
			//This is necessitated by the postfixed token construction
			const int numberOfChildLeafs = 2; //For primitive operations, this number is 2. For functions its variable
			TreeNode child = new TreeNode();
			child.type = nodeType.operation;
			child.name = tokenString;
			TreeNode[] childLeafNodes = new TreeNode[numberOfChildLeafs];
			for (int i = 0; i < numberOfChildLeafs; i++) {
				childLeafNodes[i] = children[0];
				children.RemoveAt(0);
				child.children.Insert(0, childLeafNodes[i]);
			}
			if (childLeafNodes.All(i => i.numericalEvaluation)) {
				child.numericalEvaluation = true;
				child.val = 
					new Value(postFixedOperatorEvaluator(
							childLeafNodes.Select(i=>i.val.deciValue).ToList(), 
							tokenString));
			}
			children.Insert(0, child);
		}

		double postFixedOperatorEvaluator(List<double> values, string tokenString) {
			//TODO: Solve these problems in cases that cannot be evaluated numerically.
			//Possibly extend the Value type for non-numerical evaluation.
			double returnVal = values.Last();
			for (int i = values.Count() - 2; i >= 0; i--) 
				switch (tokenString) {
				case "+":
					returnVal += values[i];
					break;
				case "-":
					returnVal -= values[i];
					break;
				case "*":
					returnVal *= values[i];
					break;
				case "/":
					returnVal /= values[i];
					break;
				case "%":
					returnVal %= values[i];
					break;
				case "^":
					returnVal = Math.Pow(returnVal, values[i]);
					if (values.Count() > 2)
						throw new Exception("Can't have more than two parameters for the power method.");
					break;
				default:
					throw new Exception("unknown operator");
			}
			if (returnVal == int.MinValue)
				throw new Exception("No evaluation happened");
			return returnVal;
		}

		#region ParseTree manipulation methods
		internal void FlattenTeiredAddition() {
			//if the child of a + is ever a plus:
			//eliminate the second plus, and append to children to the first +
			for (int i = 0; i < children.Count(); i++) {
				if (name == "+" && children.First().name == "+") {
					
				}
				if (name == "+" && children.Last().name == "+") { }
			}
		}
		#endregion
	}
		
	//ParseTreeManipulationMethods
	//Flatten out teired addition
	//Find common factors over an addition problem
	//Distribute multiplication over addition
	//Addition and multiplication can be rearranged (commutative)
	//Build fractions instead of evaluation
	

}
