namespace Lecii.Standard {
	public interface IPool<T> {
		bool IsReusable();
		T GetObject();
		void ReturnObject(T obj);
	}
}
