using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // ความเร็วในการเคลื่อนที่
    public float jumpForce = 5.0f; // แรงกระโดด
    public Camera mainCamera; // อ้างอิงถึงกล้องหลัก
    private Rigidbody rb; // อ้างอิงถึง Rigidbody
    private bool isGrounded; // เช็คว่าผู้เล่นอยู่บนพื้นหรือไม่

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // รับ Rigidbody
    }

    void FixedUpdate()
    {
        MovePlayer();

        // ตรวจสอบการกระโดด
        if (isGrounded && Input.GetButtonDown("Jump")) // กด Spacebar
        {
            Jump();
        }
    }

    void MovePlayer()
    {
        Animator animator = GetComponent<Animator>();

        // รับค่าการเคลื่อนที่
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D หรือ Left/Right
        float verticalInput = Input.GetAxis("Vertical"); // W/S หรือ Up/Down

        // รับทิศทางจากกล้อง
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        // ทำให้ทิศทางกล้องเป็นแนวนอน
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        if (horizontalInput == 0 && verticalInput == 0)
        {
            animator.SetBool("is_walk", false);
        }
        else
        {
            animator.SetBool("is_walk", true);
        }

        // คำนวณทิศทางการเคลื่อนที่
        Vector3 moveDirection = (right * horizontalInput + forward * verticalInput).normalized;

        // ทำให้ตัวละครหันไปในทิศทางที่เดิน
        if (moveDirection != Vector3.zero) // ตรวจสอบว่ามีการเคลื่อนที่
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // หมุนตัวละครอย่างนุ่มนวล
        }

        // ใช้ MovePosition ในการเคลื่อนที่
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        // กระโดด
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // เช็คว่าอยู่บนพื้น
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // เช็คว่าออกจากพื้น
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}