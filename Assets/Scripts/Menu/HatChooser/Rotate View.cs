using UnityEngine.EventSystems;
using UnityEngine;

public class RotateView : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Transform target;
    public float rotationSpeed = 0.5f;
    public float inertiaDamping = 5f;
    public float minimumInertiaSpeed = 30f;

    private float angularVelocity;
    private bool isDragging;

    private void Update()
    {
        if (isDragging || Mathf.Approximately(angularVelocity, 0f))
        {
            return;
        }

        float deltaTime = Time.unscaledDeltaTime;
        target.Rotate(Vector3.up, angularVelocity * deltaTime, Space.World);
        angularVelocity *= Mathf.Exp(-Mathf.Max(0f, inertiaDamping) * deltaTime);
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
        float rotationDelta = -eventData.delta.x * rotationSpeed;
        target.Rotate(Vector3.up, rotationDelta, Space.World);

        float deltaTime = Time.unscaledDeltaTime;
        if (deltaTime > 0f)
        {
            angularVelocity = rotationDelta / deltaTime;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        if (Mathf.Abs(angularVelocity) < minimumInertiaSpeed)
        {
            angularVelocity = 0f;
        }
    }
}
