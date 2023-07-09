using UnityEngine;

namespace Code.GeneralEcsComponents
{
    public struct UnityRef<T> where T : Object
    {
        public T Value;
    }
}