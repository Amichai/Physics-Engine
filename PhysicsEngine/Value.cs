using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PhysicsEngine {
	class Value {
		private enum numberType { integer, deci, fractional, imaginary, exponent }
		private numberType primaryNumType { get; set; }
		
		/// <summary>Decimal value</summary>
		public Value(double val) {
			setDecimalValue(val);
			asAFraction = decimalToFraction(deciValue);
		}

		/// <summary>Decimal value</summary>
		private Value(double val, bool setToFraction) {
			setDecimalValue(val);
			if (setToFraction) {
				asAFraction = decimalToFraction(deciValue);
			}
		}
		private List<int> factors = new List<int>();

		private void setDecimalValue(double val) {
			this.deciValue = val;
			if (val == Math.Floor(val)) {
				//this is done to avoid the accumulation of miniscule errors:
				deciValue = Math.Floor(val);
				primaryNumType = numberType.integer;
				factors = Factorize((int)deciValue);
			}
			this.primaryNumType = numberType.deci;
		}

		//TODO: Imaginary numbers
		
		/// <summary>Fraction</summary>
		public Value(int numerator, int denominator) {
			this.numerator = new Value(numerator, false);
			this.denominator = new Value(denominator, false);
			this.deciValue = ((double)numerator / denominator);
			this.primaryNumType = numberType.fractional;
		}

		/// <summary>Exponent</summary>
		public Value(double expBase, double expPower) {
			this.ExpBase = new Value(expBase);
			this.ExpPower = new Value(expPower);
			this.deciValue = (Math.Pow(expBase, expPower));
			primaryNumType = numberType.exponent;
		}

		private List<int> Factorize(int factorMe) {
			if (primaryNumType != numberType.integer)
				throw new Exception("Can only factor an integer");
			//Run a sanity test to make sure this won't take forever
			//Run this on a seperate thread
			List<int> factors = new List<int>();
			for (int i = 2; i < factorMe + 1; i++ ){
				while (factorMe % i == 0) {
					factors.Add(i);
					factorMe /= i;
				}
			}
			return factors;
		}
		public double deciValue = double.MinValue;

		public Value asAFraction { get; set; }
		public Value realPart { get; set; }
		public Value imaginaryPart { get; set; }
		public Value numerator{ get; set; }
		public Value denominator{ get; set; }
		public Value ExpBase { get; set; }
		public Value ExpPower { get; set; }

		public string GetValueToString() {
			if (primaryNumType == numberType.deci || primaryNumType == numberType.integer) {
				return deciValue.ToString();
			} else if (primaryNumType == numberType.fractional) {
				return numerator.GetValueToString() + "/" + denominator.GetValueToString();
			} else if (primaryNumType == numberType.imaginary) {
				return realPart.GetValueToString() + " " + imaginaryPart.GetValueToString() + "i";
			} else if (primaryNumType == numberType.exponent) {
				return ExpBase.GetValueToString() + "^" + ExpPower.GetValueToString();
			}
			throw new Exception("Unkonwn number type");
		}

		public string FullVisualization() {
			string output = string.Empty;
			output += "Number: " + GetValueToString() + "\n";
			if(factors.Count > 0)
				output += "Factors: ";
			foreach (int i in factors) {
				output += i.ToString() + " ";
			}
			output += "\n";
			if (asAFraction != null) {
				output += "As a fraction: " + asAFraction.GetValueToString();
				output += "\nFraction evaluation: " + asAFraction.deciValue.ToString();
				output += "\nNumerator: "+ asAFraction.numerator.FullVisualization();
				output += "Denomenator: " + asAFraction.denominator.FullVisualization();
			}
			return output;
		}

		private enum Sign { positive, negative };
		private Value decimalToFraction(double Decimal) {
			int fractionNumerator = int.MaxValue;
			int fractionDenominator = 1;
			double accuracyFactor = .0000001;
			int decimalSign;
			double Z;
			int previousDenominator;
			int scratchValue;

			if (Decimal < 0) {
				decimalSign = -1;
			} else decimalSign = 1;
			Decimal = Math.Abs(Decimal);
			if (Decimal == Math.Floor(Decimal)) {
				fractionNumerator = (int)Decimal * decimalSign;
				fractionDenominator = 1;
			}
			Z = Decimal;
			previousDenominator = 0;
			while (!(Z == Math.Floor(Z)) && (Math.Abs((Decimal - ((double)fractionNumerator / fractionDenominator))) > accuracyFactor )) {
				Z = 1/(Z - (int)Z);
				scratchValue = fractionDenominator;
				fractionDenominator = fractionDenominator*(int)Z + previousDenominator;
				previousDenominator = scratchValue;
				fractionNumerator= (int)Math.Floor(Decimal*fractionDenominator + .5);
			} 
			fractionNumerator  = decimalSign * fractionNumerator;
			
			return new Value(fractionNumerator, fractionDenominator);
		}
	}
}
