using UnityEngine;

public class TeddyBear : MonoBehaviour
{
    // Kéo thả Main Camera (đã có script CameraShake) vào biến này trong Inspector
    public CameraShake cameraShake;

    // Hàm xử lý va chạm
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra xem đối tượng va chạm có phải là Tường (Walls) không
        // (Giả sử tường có Tag là "Wall")
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Kiểm tra xem cameraShake có được gán chưa
            if (cameraShake != null)
            {
                cameraShake.TriggerShake();
            }
        }
    }
}