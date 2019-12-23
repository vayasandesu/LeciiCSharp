namespace Slime.CSharp {
	public interface IPool<T> {
		bool IsReusable();
		T GetObject();
		void ReturnObject(T obj);
	}
}
