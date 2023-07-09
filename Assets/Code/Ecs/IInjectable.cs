using Leopotam.EcsLite;

namespace Code.Ecs
{
    public interface IInjectable
    {
        public void Inject(EcsSystems systems);
    }
}