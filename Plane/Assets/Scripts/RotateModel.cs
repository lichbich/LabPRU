using UnityEngine;

public class RotateModel : MonoBehaviour
{
    [Header("Tốc độ quay (độ/giây)")]
    public float rotationSpeed = 50f;

    void Update()
    {
        // Quay quanh trục Z
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
