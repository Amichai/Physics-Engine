using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicsEngine.Compiler {
	abstract class ParseTree {
		public enum nodeType { number, function, operation, variable }
		public bool numericalEvaluation;
		public Stack<TreeNode> children = new Stack<TreeNode>();
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
		internal void Push(double tokenVal) {
			TreeNode child = new TreeNode();
			child.type = nodeType.number;
			child.val = new Value(tokenVal);
			child.name = tokenVal.ToString();
			child.numericalEvaluation = true;
			children.Push(child);
		}

		internal void Push(string tokenString) {
			TreeNode child = new TreeNode();
			child.type = nodeType.operation;
			child.name = tokenString;
			TreeNode node1 = children.Pop();
			TreeNode node2 = children.Pop();
			//We're assuming two children per operation:
			child.children.Push(node1);
			child.children.Push(node2);
			if (node1.numericalEvaluation && node2.numericalEvaluation) {
				child.numericalEvaluation = true;
				child.val = new Value(postFixedOperatorEvaluator(node1.val.GetDeciValue(), node2.val.GetDeciValue(), tokenString));
			}
			children.Push(child);
		}

		double postFixedOperatorEvaluator(double val1, double val2, string tokenString) {
			//TODO: Solve these problems in cases that cannot be evaluated numerically.
			//Possibly extend the Value type for non-numerical evaluation.
			double returnVal = int.MinValue;
			switch (tokenString) {
				case "+":
					returnVal = val2 + val1;
					break;
				case "-":
					returnVal = val2 - val1;
					break;
				case "*":
					returnVal = val2 * val1;
					break;
				case "/":
					returnVal = val2 / val1;
					break;
				case "%":
					returnVal = val2 / val1;
					break;
				case "^":
					returnVal = Math.Pow(val2, val1);
					break;
				default:
					throw new Exception("unknown operator");
			}
			if (returnVal == int.MinValue)
				throw new Exception("No evaluation happened");
			return returnVal;
		}
	}
}
