namespace Slime.Standard {
	
	public static class GeneratorUtility {

		public static TValue[] GenerateCollection<TValue>(int quantity, Func<TValue> Creation) {
			TValue[] array = new TValue[quantity];
			for(int i = 0; i < quantity; i++) {
				array[i] = Creation();
			}
			return array;
		}

	}

}