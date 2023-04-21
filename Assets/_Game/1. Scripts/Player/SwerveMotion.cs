using Unity.VisualScripting;
using UnityEngine;

public class SwerveMotion : MonoBehaviour
{
    private Vector2 touchStartPosition;
    private Vector2 touchCurrentPosition;
    private Vector2 dragStartPosition;
    private float dragDistance;

    public float dragSpeed = 2.0f;
    public float dragThreshold = 10.0f;
    public float minXPosition = -5.0f;
    public float maxXPosition = 5.0f;
    public float lerpSpeed = 5.0f;

    private Vector3 targetPosition;

    void Update()
    {
        if (!Input.GetMouseButton(0)) return;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
                dragStartPosition = transform.localPosition;

                if (Mathf.Abs(touchStartPosition.x - dragStartPosition.x) < dragThreshold)
                {
                    targetPosition = transform.localPosition;
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                touchCurrentPosition = touch.position;
                dragDistance = touchCurrentPosition.x - touchStartPosition.x;

                float newXPosition = dragStartPosition.x + (dragDistance * dragSpeed * Time.fixedDeltaTime);
                newXPosition = Mathf.Clamp(newXPosition, minXPosition, maxXPosition);

                targetPosition = new Vector3(newXPosition, transform.localPosition.y, transform.localPosition.z);
            }
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, lerpSpeed * Time.fixedDeltaTime);
    }
}
