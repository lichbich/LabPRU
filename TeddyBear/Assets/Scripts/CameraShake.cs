using UnityEngine;
using System.Collections; // Cần dùng cho Coroutine

public class CameraShake : MonoBehaviour
{
    // Biến điều chỉnh hiệu ứng
    public float shakeDuration = 0.15f; // Thời gian rung
    public float shakeMagnitude = 0.1f; // Độ mạnh của rung

    private Vector3 originalPos;

    void Awake()
    {
        // Lưu vị trí ban đầu của camera
        originalPos = transform.localPosition;
    }

    // Hàm public để gọi từ script của nhân vật (gấu)
    public void TriggerShake()
    {
        // Tránh bị rung liên tục
        StopAllCoroutines();
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            // Tính toán vị trí ngẫu nhiên trong biên độ (magnitude)
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            // Di chuyển camera từ vị trí ban đầu
            transform.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;

            yield return null; // Chờ frame tiếp theo
        }

        // Đảm bảo camera trở về vị trí ban đầu khi kết thúc
        transform.localPosition = originalPos;
    }
}