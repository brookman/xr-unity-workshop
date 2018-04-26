using UnityEngine;
using System.Collections;

namespace Solution {
    public class SolutionRotator : MonoBehaviour {
        void Update () {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
    }
}
