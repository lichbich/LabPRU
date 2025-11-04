using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BearPhysics : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Hướng random ban đầu
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        rb.linearVelocity = randomDir * moveSpeed;
    }

    // Khi va chạm vật lý (không dùng trigger)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bear"))
        {
            // Gọi GameManager giảm 1 con (mỗi con gọi riêng)
            if (GameManager.Instance != null)
                GameManager.Instance.BearDied();

            // Có thể chơi hiệu ứng ở đây trước khi hủy
            Destroy(gameObject);
        }
    }
}
