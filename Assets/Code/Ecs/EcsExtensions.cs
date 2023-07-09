using System;
using Leopotam.EcsLite;

namespace Code.Ecs
{
    public static class EcsExtensions
    {
        public static ref T Get<T>(this int entity, EcsWorld world) where T : struct
        {
            return ref world.GetPool<T>().Get(entity);
        }

        public static ref T Get<T>(this EcsPackedEntity entity, EcsWorld world) where T : struct
        {
            if (!entity.Unpack(world, out int entityID)) throw new Exception("Entity isn't alive");
            return ref world.GetPool<T>().Get(entityID);
        }

        public static ref T GetOrAdd<T>(this int entity, EcsWorld world) where T : struct
        {
            if (world.GetPool<T>().Has(entity) == false)
                return ref entity.Add<T>(world);

            return ref entity.Get<T>(world);
        }

        public static void Del<T>(this int entity, EcsWorld world) where T : struct
        {
            world.GetPool<T>().Del(entity);
        }

        public static void Del<T>(this EcsPackedEntity entity, EcsWorld world) where T : struct
        {
            if (!entity.Unpack(world, out int entityID)) throw new Exception("Entity isn't alive");
            world.GetPool<T>().Del(entityID);
        }

        public static ref T Add<T>(this int entity, EcsWorld world) where T : struct
        {
            return ref world.GetPool<T>().Add(entity);
        }

        public static ref T Add<T>(this EcsPackedEntity entity, EcsWorld world) where T : struct
        {
            if (!entity.Unpack(world, out int entityID)) throw new Exception("Entity isn't alive");
            return ref entity.Add<T>(world);
        }

        public static ref T GetOrAdd<T>(this EcsPackedEntity entity, EcsWorld world) where T : struct
        {
            if (!entity.Unpack(world, out int entityID)) throw new Exception("Entity isn't alive");
            return ref entity.GetOrAdd<T>(world);
        }
    }
}