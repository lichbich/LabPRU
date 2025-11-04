using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [Header("Flight Settings")]
    [SerializeField] private float speed = 50f;             // Tốc độ bay tiến
    [SerializeField] private float rotationSpeed = 70f;     // Tốc độ xoay máy bay
    [SerializeField] private float liftForce = 10f;         // Lực nâng (để bay mượt hơn)

    private float yaw;     // Xoay trái/phải (trục Y)
    private float pitch;   // Ngẩng/cúi (trục X)
    private float roll;    // Nghiêng (trục Z)

    void Update()
    {
        // --- Lấy input ---
        float horizontal = Input.GetAxis("Horizontal"); // A/D → roll
        float vertical = Input.GetAxis("Vertical");     // W/S → pitch
        float yawInput = 0f;
        if (Input.GetKey(KeyCode.Q)) yawInput = -1f;    // Q → xoay trái
        if (Input.GetKey(KeyCode.E)) yawInput = 1f;     // E → xoay phải

        // --- Xoay máy bay ---
        roll = -horizontal * rotationSpeed * Time.deltaTime; // Nghiêng
        pitch = vertical * rotationSpeed * Time.deltaTime;   // Ngẩng/Cúi
        yaw = yawInput * rotationSpeed * Time.deltaTime;     // Xoay hướng

        transform.Rotate(pitch, yaw, roll, Space.Self);

        // --- Di chuyển tiến ---
        if (Input.GetKey(KeyCode.LeftShift))
            transform.Translate(Vector3.forward * speed * 1.5f * Time.deltaTime); // tăng tốc
        else if (Input.GetKey(KeyCode.LeftControl))
            transform.Translate(Vector3.forward * speed * 0.5f * Time.deltaTime); // giảm tốc
        else
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // --- Giả lập lực nâng để bay mượt hơn ---
        transform.position += transform.up * liftForce * Time.deltaTime;
    }
}
