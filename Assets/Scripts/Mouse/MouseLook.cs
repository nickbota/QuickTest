using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensitivityX = 8;
    [SerializeField] private float sensitivityY = 0.5f;
    private float mouseX;
    private float mouseY;

    [SerializeField] private Camera playerCamera;
    [SerializeField] private float xClamp = 85f;
    private float currentXRotation;

    private void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        currentXRotation -= mouseY;
        currentXRotation = Mathf.Clamp(currentXRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = currentXRotation;
        playerCamera.transform.eulerAngles = targetRotation;
    }

    #region Input Events
    private void OnMouseX(InputValue value)
    {
        mouseX = value.Get<float>() * sensitivityX;
    }
    private void OnMouseY(InputValue value)
    {
        mouseY = value.Get<float>() * sensitivityY;
    }
    #endregion
}