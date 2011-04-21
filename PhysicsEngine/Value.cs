using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicsEngine {
	class Value {
		private enum numberType { deci, fractional, imaginary, }
		private numberType numType;
		public Value(double val) {
			value = val;
			numType = numberType.deci;
		}

		public Value(double realPart, double imaginaryPart) {
			value = realPart;
			this.imaginaryPart = imaginaryPart;
			numType = numberType.imaginary;
		}

		public Value(int numerator, int denominator) {
			this.numerator = numerator;
			this.denominator = denominator;
			value = (double)numerator / (double)denominator;
			numType = numberType.fractional;
		}

		public double value;
		public double imaginaryPart;
		public int numerator, denominator;
	}
}
