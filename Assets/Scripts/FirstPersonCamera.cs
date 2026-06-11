using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform playerinputTransform;

    [SerializeField] private float xSensitivity;
    [SerializeField] private float ySensitivity;

    private PlayerInputScript mouseInput;

    private float xRotation;
    private float yRotation;
    private float xAxisMouseInput;
    private float yAxisMouseInput;

    private void Start() {

        mouseInput = playerinputTransform.GetComponent<PlayerInputScript>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {

        MouseInputWithDeltaTime();
        MoveCamera();
    }

    private void MoveCamera() {

        yRotation += xAxisMouseInput;
        xRotation -= yAxisMouseInput;

        xRotation = Mathf.Clamp(xRotation, -90f, 70f);
        yRotation = Mathf.Clamp(yRotation, -70f, 70f);

        //playerVisual.rotation = Quaternion.Euler(-90f, yRotation, 0f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    private void MouseInputWithDeltaTime() {

        xAxisMouseInput = mouseInput.GetMouseXAxis() * xSensitivity * Time.deltaTime;
        yAxisMouseInput = mouseInput.GetMouseYAxis() * ySensitivity * Time.deltaTime;
    }
}
