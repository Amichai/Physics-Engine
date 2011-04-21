using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicsEngine {
	class SingleParticle {
		
	}
	class Formula {

	}
	class Wave {

	}
	class Vector {
		private int dimensions = 2;
		private List<double> coordinates;
		public Vector(List<double> coordinates){
			this.dimensions = coordinates.Count;
			this.coordinates = coordinates;
		}
	}


}
