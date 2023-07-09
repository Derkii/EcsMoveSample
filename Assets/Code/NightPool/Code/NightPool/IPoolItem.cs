// ----------------------------------------------------------------------------
// The MIT License
// NightPool is an object pool for Unity https://github.com/MeeXaSiK/NightPool
// Copyright (c) 2021-2022 Night Train Code
// ----------------------------------------------------------------------------

namespace Code.NightPool.Code.NightPool
{
    public interface IPoolItem
    {
        public void OnSpawn();
        public void OnDespawn();
    }
}