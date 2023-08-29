using System;

namespace GameJamEntry.Utils {
	public class ReactiveValue<T> {
		T _value;

		public T Value {
			get => _value;
			set {
				_value = value;
				OnValueChanged?.Invoke(value);
			}
		}

		public event Action<T> OnValueChanged;
	}
}