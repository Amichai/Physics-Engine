using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicsEngine.Compiler {
	class Node {
		enum nodeType { number, function, operation, variable }
		bool numericalEvaluation;
		public Stack<Node> children = new Stack<Node>();
		string name = string.Empty;
		double val = int.MinValue;
		nodeType type;

		internal void Push(int tokenVal) {
			Node child = new Node();
			child.type = nodeType.number;
			child.val = tokenVal;
			child.name = tokenVal.ToString();
			child.numericalEvaluation = true;
			children.Push(child);
		}

		internal void Push(string tokenString) {
			Node child = new Node();
			child.type = nodeType.operation;
			child.name = tokenString;
			Node node1 = children.Pop();
			Node node2 = children.Pop();
			//We're assuming two children per operation:
			child.children.Push(node1);
			child.children.Push(node2);
			if (node1.numericalEvaluation && node2.numericalEvaluation) {
				child.numericalEvaluation = true;
				child.val = postFixedOperatorEvaluator(node1.val, node2.val, tokenString);
			}
			children.Push(child);
		}

		double postFixedOperatorEvaluator(double val1, double val2, string tokenString) {
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
			output += name + ": " + val.ToString() + "\n";

			int i = 0;
			foreach (Node c in children) {
				c.Visualize(indent, i == children.Count - 1);
				i++;
			}
			return output;
		}
	}
}
