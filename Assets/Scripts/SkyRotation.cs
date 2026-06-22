using Unity.Mathematics;
using UnityEngine;

public class SkyRotation : MonoBehaviour
{
    [SerializeField] private float rotateSpd;

    private void Update() {

        transform.Rotate(Vector3.up * rotateSpd * Time.deltaTime);
    }
}
