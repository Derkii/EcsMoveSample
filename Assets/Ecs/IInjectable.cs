using Leopotam.Ecs;

namespace Ecs
{
    public interface IInjectable
    {
        public void Inject(EcsSystems systems);
    }
}