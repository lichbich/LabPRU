using UnityEngine;

public class FollowAirplaneCamera : MonoBehaviour
{
    [Header("Target (máy bay)")]
    public Transform target;

    [Header("Cài đặt vị trí camera")]
    public Vector3 offset = new Vector3(0f, 2f, -5f); // vị trí camera so với máy bay
    public float followSpeed = 10f;                     // tốc độ bám theo

    [Header("Cài đặt xoay mượt")]
    public float rotationSmoothSpeed = 3f;             // độ mượt khi xoay theo

    void LateUpdate()
    {
        if (target == null)
            return;

        // --- Tính vị trí mong muốn ---
        Vector3 desiredPosition = target.TransformPoint(offset);

        // --- Di chuyển mượt đến vị trí mong muốn ---
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // --- Xoay camera nhìn về máy bay ---
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothSpeed * Time.deltaTime);
    }
}
