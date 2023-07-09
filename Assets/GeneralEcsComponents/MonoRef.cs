using UnityEngine;

namespace GeneralEcsComponents
{
    public struct MonoRef<T> where T : Object
    {
        public T Mono;
    }
}