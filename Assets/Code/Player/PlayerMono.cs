using UnityEngine;

namespace Code.Player
{
    public class PlayerMono : MonoBehaviour
    {
        [SerializeField]
        private Transform _cameraParent;

        public Transform CameraParent => _cameraParent;
    }
}