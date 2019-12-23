namespace Slime.CSharp {

	public delegate T CreationEventHandler<T>();
	public delegate Tout CreationEventHandler<Tin, Tout>(Tin recieve);
}
