using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeField] private Vector3 m_offset = new Vector3(0, 3, -5);
    [SerializeField] private float m_smoothSpeed = 0.125f;

    private Vector3 m_targetPosition;

    public void SetTargetPosition(Vector3 targetPosition)
    {
        m_targetPosition = targetPosition;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = m_targetPosition + m_offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, m_smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(m_target);
    }
}