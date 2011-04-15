using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhysicsEngine.Functions;
using UserInterface;

namespace PhysicsEngine {
    class Program {
        static void Main(string[] args) {
			new Function("5(3+1)1");
			UI.DisplayLog(LogType.allTokens);
        }
    }
}
