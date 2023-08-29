using System.Collections.Generic;
using UnityEngine;

namespace GameJamEntry.Utils {
	public static class RandomUtils {
		public static T GetRandomElementInList<T>(List<T> values) {
			if ( values.Count == 0 ) {
				return default;
			}
			var randomIndex = Random.Range(0, values.Count);
			return values[randomIndex];
		}
	}
}