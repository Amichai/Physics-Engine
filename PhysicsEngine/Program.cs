using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhysicsEngine.Expression;
using UserInterface;
using System.Diagnostics;
using PhysicsEngine.Numbers;

namespace PhysicsEngine {
    class Program {
        static void Main(string[] args) {
			new Expression.Expression("10*20*10");

			//Debug.Print(new Value(56).FullVisualization());
        }
    }
}
