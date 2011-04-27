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
			origionalNumber = factorMe;
			for (int i = 2; i < factorMe + 1; i++) {
				while (factorMe % i == 0) {
					factors.Add(i);
					if (i == lastFactor || i == 2)
						consecutiveFactorCounter++;
					else {
						FactorsAsExponents.Add(new Value((double)lastFactor, (double)consecutiveFactorCounter, NumberType.exponent, Restrictions.dontFactorDontSetFraction));
						consecutiveFactorCounter = 0; 
					}
					lastFactor = i;
					factorMe /= i;
				}
			}
			FactorsAsExponents.Add(new Value((double)lastFactor, (double)consecutiveFactorCounter + 1, NumberType.exponent, Restrictions.dontFactorDontSetFraction));
			Count = factors.Count();
		}

		//TODO: Make a common factors class to bulid these two lists
		//Use the latter public list for extracting the greatest common factors in the case of multiplication

		internal string Visualize() {
			string output = string.Empty;
			if (factors.Count > 0)
				output += "(";
			if (factors.Count == 1) {
				output += "Prime number";
			} else {
				for (int i = 0; i < factors.Count(); i++ ) {
					output += factors[i].ToString();
					if (i != factors.Count() - 1)
						output += " ";
				}
			}
			output += ")";
			return output;
		}
	}
}
