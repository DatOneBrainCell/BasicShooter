using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject cameraHolder;

    [SerializeField] private float moveDistance;
    [SerializeField] private float moveSpeed;

    private float horizontalInput;

    private const string HORIZONTAL = "Horizontal";

    private void Update() {
        PlayerInput();
        MovePlayer();
    }

    private void MovePlayer() {

        if (horizontalInput != 0) {

            if (transform.position.x > moveDistance) {

                transform.position = new Vector3(moveDistance, transform.position.y, transform.position.z);
            }

            if(transform.position.x < -moveDistance) {

                transform.position = new Vector3(-moveDistance, transform.position.y, transform.position.z);
            }

            transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
        }
    }

    private void PlayerInput() {

        horizontalInput = Input.GetAxis(HORIZONTAL);
    }
}
