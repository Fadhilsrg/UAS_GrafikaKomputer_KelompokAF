using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 5f; // Kecepatan mobil
    public float rotationSpeed = 2f; // Kecepatan rotasi mobil
    public Transform[] waypoints; // Titik-titik yang harus dilewati mobil
    private int currentWaypointIndex = 0; // Indeks waypoint saat ini

    private void Update()
    {
        MoveCar();
    }

    private void MoveCar()
    {
        // Periksa apakah mobil telah mencapai semua waypoint
        if (currentWaypointIndex < waypoints.Length)
        {
            // Tentukan arah menuju waypoint saat ini
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
            direction.y = 0f;

            // Rotasi mobil menuju arah waypoint
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Pindahkan mobil maju
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // Periksa apakah mobil telah mencapai waypoint saat ini
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.5f)
            {
                // Pindah ke waypoint berikutnya
                currentWaypointIndex++;

                // Jika sudah mencapai waypoint terakhir, kembali ke waypoint pertama
                if (currentWaypointIndex == waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
        }
    }
}
