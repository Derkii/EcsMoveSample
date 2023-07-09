namespace Code.EcsFactory
{
    public struct FactoryComponent
    {
        public IUnityEntityFactory Factory;
        public IPackedUnityEntityFactory PackedFactory;
    }
}