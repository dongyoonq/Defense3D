using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    Vector3 moveDir;
    private float zoomScroll;
    [SerializeField] float moveSpeed;
    [SerializeField] float zoomSpeed;
    [SerializeField] float padding;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void LateUpdate()
    {
        Move();
        Zoom();
    }

    private void OnPointer(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();

        if (mousePos.x <= padding)
            moveDir.x = -1;
        else if (mousePos.x >= Screen.width - padding)
            moveDir.x = 1;
        else
            moveDir.x = 0;

        if (mousePos.y <= padding)
            moveDir.y = -1;
        else if (mousePos.y >= Screen.height - padding)
            moveDir.y = 1;
        else
            moveDir.y = 0;
    }

    private void Move()
    {
        transform.Translate(moveDir.y * Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(moveDir.x * Vector3.right * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnZoom(InputValue value)
    {
        zoomScroll = value.Get<Vector2>().y;
    }

    private void Zoom()
    {
        transform.Translate(Vector3.forward * zoomScroll * Time.deltaTime, Space.Self);
    }
}
