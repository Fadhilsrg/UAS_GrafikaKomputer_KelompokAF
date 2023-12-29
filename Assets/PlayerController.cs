using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public float normalSpeed = 2f;
    public float sprintSpeed = 5f;  // Kecepatan ketika lari
    public float rotationSpeed = 100f;  // Sensitivitas rotasi kamera

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Mendapatkan input dari pemain
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Mendapatkan input dari mouse untuk rotasi
        float mouseX = Input.GetAxis("Mouse X");

        // Mendapatkan input dari tombol Shift
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        // Mengatur parameter animator berdasarkan input
        bool isWalking = (horizontalInput != 0f || verticalInput != 0f);
        animator.SetBool("isWalking", isWalking);

        // Mengatur parameter animator untuk animasi lari
        bool isRunning = isSprinting && isWalking;
        animator.SetBool("isRun", isRunning);

        // Menggerakkan karakter
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        float speed = isSprinting ? sprintSpeed : normalSpeed;
        movement *= speed * Time.deltaTime;

        transform.Translate(movement, Space.Self);

        // Mengatur rotasi karakter sesuai dengan arah pandang kamera
        RotateWithCamera(mouseX);
    }

    void RotateWithCamera(float mouseX)
    {
        // Mendapatkan rotasi karakter saat ini
        Vector3 characterRotation = transform.eulerAngles;

        // Menambahkan rotasi dari input mouse
        characterRotation.y += mouseX * rotationSpeed * Time.deltaTime;

        // Mengatur rotasi karakter
        transform.eulerAngles = characterRotation;
    }
}
