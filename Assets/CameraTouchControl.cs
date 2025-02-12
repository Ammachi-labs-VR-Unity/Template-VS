using UnityEngine;

public class CameraTouchControl : MonoBehaviour
{
    public float rotationSpeed = 0.1f; // Adjust sensitivity

    private Vector2 lastTouchPosition; // Store last touch position

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // When touch begins, store the initial touch position
            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
            }

            // When touch moves, calculate the difference and rotate
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDelta = touch.position - lastTouchPosition;

                // Rotate the camera based on the touch movement
                float rotationX = touchDelta.x * rotationSpeed;
                

                // Apply rotation to camera (optional clamping can be added here)
                transform.Rotate(0, rotationX, 0);

                // Store current touch position for next frame
                lastTouchPosition = touch.position;
            }
        }
    }
}
