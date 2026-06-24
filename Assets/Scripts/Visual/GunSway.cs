using UnityEngine;

public class GunSway : MonoBehaviour
{
    [SerializeField] private Transform playerInputTransform;

    [SerializeField] private float smoothFactor;
    [SerializeField] private float swayMultiplier;

    PlayerInputScript mouseInput;

    private void Start() {

        mouseInput = playerInputTransform.GetComponent<PlayerInputScript>();
    }

    void Update()
    {
        float mouseX = mouseInput.GetMouseXAxis() * swayMultiplier;
        float mouseY = mouseInput.GetMouseYAxis() * swayMultiplier;

        Quaternion xRotation = Quaternion.AngleAxis(mouseY, Vector3.right);
        Quaternion yRotation = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = xRotation * yRotation;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoothFactor * Time.deltaTime);
    }
}
