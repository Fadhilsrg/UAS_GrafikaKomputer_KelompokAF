using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 1f;
    public float distanceFromTarget = 3f; // Jarak antara kamera dan karakter

    void LateUpdate()
    {
        if (target != null)
        {
            // Mendapatkan rotasi karakter
            float characterRotation = target.eulerAngles.y;

            // Menghitung posisi kamera berdasarkan rotasi karakter
            float wantedRotationAngle = characterRotation;
            float wantedHeight = target.position.y + distanceFromTarget;

            // Menghitung posisi kamera
            Vector3 wantedPosition = target.position;
            wantedPosition.y = Mathf.Lerp(transform.position.y, wantedHeight, Time.deltaTime * 5f);

            // Mengatur rotasi kamera
            transform.rotation = Quaternion.Euler(0f, wantedRotationAngle, 0f);

            // Mengatur posisi kamera
            transform.position = wantedPosition - transform.forward * distanceFromTarget;
        }
    }
}
