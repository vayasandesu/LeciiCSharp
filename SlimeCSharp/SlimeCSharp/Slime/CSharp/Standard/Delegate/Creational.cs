namespace Slime.Standard {

	public delegate T CreationEventHandler<T>();
	public delegate Tout CreationEventHandler<Tin, Tout>(Tin recieve);
}
