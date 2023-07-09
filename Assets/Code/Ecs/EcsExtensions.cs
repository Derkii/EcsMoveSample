using Leopotam.EcsLite;

namespace Code.Ecs
{
    public static class EcsExtensions
    {
        public static ref T Get<T>(this int entityIndex, EcsWorld world) where T : struct
        {
            return ref world.GetPool<T>().Get(entityIndex);
        }

        public static ref T Get<T>(this EcsPackedEntity entity, EcsWorld world) where T : struct
        {
            entity.Unpack(world, out int entityIndex);
            return ref world.GetPool<T>().Get(entityIndex);
        }

        public static ref T GetOrAdd<T>(this int entityIndex, EcsWorld world) where T : struct
        {
            if (world.GetPool<T>().Has(entityIndex) == false)
                return ref entityIndex.Add<T>(world);

            return ref entityIndex.Get<T>(world);
        }

        public static void Del<T>(this int entityIndex, EcsWorld world) where T : struct
        {
            world.GetPool<T>().Del(entityIndex);
        }

        public static void Del<T>(this EcsPackedEntity entity, EcsWorld world) where T : struct
        {
            entity.Unpack(world, out int entityIndex);
            world.GetPool<T>().Del(entityIndex);
        }

        public static ref T Add<T>(this int entityIndex, EcsWorld world) where T : struct
        {
            return ref world.GetPool<T>().Add(entityIndex);
        }

        public static ref T Add<T>(this EcsPackedEntity entity, EcsWorld world) where T : struct
        {
            entity.Unpack(world, out int entityIndex);
            return ref entityIndex.Add<T>(world);
        }

        public static ref T GetOrAdd<T>(this EcsPackedEntity entity, EcsWorld world) where T : struct
        {
            entity.Unpack(world, out int entityIndex);
            return ref entityIndex.GetOrAdd<T>(world);
        }
    }
}