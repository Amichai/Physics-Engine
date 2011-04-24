using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicsEngine.Numbers {
	class Factors {
		public List<int> factors = new List<int>();
		public List<Value> FactorsAsExponents = new List<Value>();
		public int origionalNumber;
		public int Count;
		private int lastFactor = int.MinValue;
		private int consecutiveFactorCounter = 0; 
		public Factors(int factorMe) {
			//Run a sanity test to make sure this won't take forever
			//Run this on a seperate thread
			origionalNumber = factorMe;
			for (int i = 2; i < factorMe + 1; i++) {
				while (factorMe % i == 0) {
					factors.Add(i);
					if (i == lastFactor || i == 2)
						consecutiveFactorCounter++;
					else {
						FactorsAsExponents.Add(new Value((double)lastFactor, (double)consecutiveFactorCounter, Restrictions.dontFactorDontSetFraction));
						consecutiveFactorCounter = 0; 
					}
					lastFactor = i;
					factorMe /= i;
				}
			}
			FactorsAsExponents.Add(new Value((double)lastFactor, (double)consecutiveFactorCounter + 1, Restrictions.dontFactorDontSetFraction));
			Count = factors.Count();
		}

		//TODO: Make a common factors class to bulid these two lists
		//Use the latter public list for extracting the greatest common factors in the case of multiplication

		internal string Visualize() {
			string output = string.Empty;
			if (factors.Count > 0)
				output += "Factors: ";
			foreach (int i in factors) {
				output += i.ToString() + " ";
			}
			return output;
		}
	}
}
