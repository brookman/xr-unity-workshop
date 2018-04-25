using UnityEngine;
using System.Collections;

namespace Solution
{
    public class SolutionCameraController : MonoBehaviour {

        public GameObject player;
        private Vector3 offset;

        void Start () {
            offset = transform.position - player.transform.position;
        }

        void LateUpdate () {
            transform.position = player.transform.position + offset;
        }
    }
}

