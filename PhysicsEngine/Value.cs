using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicsEngine {
	class Value {
		private enum numberType { integer, deci, fractional, imaginary, exponent }
		private numberType primaryNumType { get; set; }
		/// <summary>Decimal value</summary>
		public Value(double val) {
			setDecimalValue(val);
			this.primaryNumType = numberType.deci;
		}

		private void setDecimalValue(double val) {
			this.deciValue = val;
			if (val == Math.Floor(val)) {
				//this is done to avoid the accumulation of miniscule errors:
				deciValue = Math.Floor(val);
				primaryNumType = numberType.integer;
				Factorize((int)deciValue);
			}
		}

		/// <summary>Imaginary number</summary>
		public Value(double realPart, double imaginaryPart) {
			this.realPart = new Value(realPart);
			this.imaginaryPart = new Value(imaginaryPart);
			setDecimalValue(realPart);
			this.primaryNumType = numberType.imaginary;
		}
		
		/// <summary>Fraction</summary>
		public Value(double numerator, double denominator) {
			this.numerator = new Value(numerator);
			this.denominator = new Value(denominator);
			setDecimalValue(numerator / denominator);
			this.primaryNumType = numberType.fractional;
		}

		public Value(double expBase, double expPower) {
			this.ExpBase = new Value(expBase);
			this.ExpPower = new Value(expPower);
			setDecimalValue(Math.Pow(expBase, expPower));
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
	}
}
