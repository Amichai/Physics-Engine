using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PhysicsEngine.Numbers {
	public enum Restrictions { dontFactorMe, dontSetToFraction, dontFactorDontSetFraction, none };
	class Value {
		private enum numberType { integer, deci, fractional, imaginary, exponent };
		private numberType primaryNumType { get; set; }

		/// <summary>Decimal value</summary>
		public void InitDouble(double val, Restrictions restrictions) {
			this.deciValue = val;
			if (val == Math.Floor(val)) {
				//this is done to avoid the accumulation of miniscule errors:
				deciValue = Math.Floor(val);
				primaryNumType = numberType.integer;
				if (restrictions != Restrictions.dontFactorMe && restrictions != Restrictions.dontFactorDontSetFraction) {
					factors = new Factors((int)deciValue);
				}
			}else if (restrictions != Restrictions.dontSetToFraction && restrictions != Restrictions.dontFactorDontSetFraction) {
				asAFraction = decimalToFraction(deciValue);
			}			
			this.primaryNumType = numberType.deci;
		}
		Factors factors;

		//TODO: Imaginary numbers

		/// <summary>Fraction</summary>
		public void InitFraction(int numerator, int denominator) {
			Value value = new Value();
			value.InitDouble(numerator, Restrictions.dontSetToFraction);
			this.numerator = value;
			value = new Value();
			value.InitDouble(denominator, Restrictions.dontSetToFraction);
			this.denominator = value;
			this.deciValue = ((double)numerator / denominator);
			this.primaryNumType = numberType.fractional;
		}

		/// <summary>Exponent</summary>
		public void InitExp(double expBase, double expPower, Restrictions restrictionsToPass) {
			Value value = new Value();
			value.InitDouble(expBase, restrictionsToPass);
			this.ExpBase = value;
			value = new Value();
			value.InitDouble(expPower, restrictionsToPass);
			this.ExpPower = value;
			this.deciValue = (Math.Pow(expBase, expPower));
			primaryNumType = numberType.exponent;
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
			output += factors.Visualize();
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
			Value value = new Value();
			if (Decimal == Math.Floor(Decimal)) {
				fractionNumerator = (int)Decimal * decimalSign;
				fractionDenominator = 1;
				value.InitFraction(fractionNumerator, fractionDenominator);
				return value; //Pass a restriction to not factorize (since its been done already)
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
			value = new Value();
			value.InitFraction(fractionNumerator, fractionDenominator);
			return value;
		}
	}
}
