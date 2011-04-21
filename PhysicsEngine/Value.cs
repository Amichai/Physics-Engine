using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicsEngine {
	class Value {
		private enum numberType { deci, fractional, imaginary, }
		private numberType numType;
		public Value(double val) {
			deciValue = val;
			numType = numberType.deci;
		}

		public Value(double realPart, double imaginaryPart) {
			deciValue = realPart;
			this.imaginaryPart = imaginaryPart;
			numType = numberType.imaginary;
		}

		public Value(int numerator, int denominator) {
			this.numerator = numerator;
			this.denominator = denominator;
			deciValue = (double)numerator / (double)denominator;
			numType = numberType.fractional;
		}

		public string GetValueToString() {
			if (numType == numberType.deci) {
				return deciValue.ToString();
			} else if (numType == numberType.fractional) {
				return numerator.ToString() + "/" + denominator.ToString();
			} else if (numType == numberType.imaginary) {
				return deciValue.ToString() + " " + imaginaryPart.ToString() + "i";
			}
			throw new Exception("Unkonwn number type");
		}

		public double GetDeciValue() {
			if (numType == numberType.deci) {
				return deciValue;
			} else if (numType == numberType.fractional) {
				return (double) numerator / (double)denominator;
			} 
			throw new Exception("Number type cannot be returned");
		}

		public double deciValue;
		public double imaginaryPart;
		public int numerator, denominator;
	}
}
