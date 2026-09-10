using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player; // อ้างอิงถึงผู้เล่น
    public float distance = 5.0f; // ระยะห่างจากผู้เล่น
    public float height = 2.0f; // ความสูงเหนือผู้เล่น
    public float rotationSpeed = 5.0f; // ความเร็วในการหมุนกล้อง
    public float minYAngle = -30.0f; // มุมต่ำสุดของกล้อง
    public float maxYAngle = 60.0f; // มุมสูงสุดของกล้อง
    public LayerMask collisionLayers; // เลเยอร์ของสิ่งที่กล้องอาจชน

    private float currentX = 0.0f; // การหมุนแกน X
    private float currentY = 0.0f; // การหมุนแกน Y
    private float currentDistance; // ระยะห่างจากผู้เล่นปัจจุบัน

    void Start()
    {
        currentDistance = distance;
    }

    void LateUpdate()
    {
        // รับค่าการหมุนจากเมาส์
        if (Input.GetMouseButton(1)) // ใช้ปุ่มขวาของเมาส์ในการหมุน
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed; // ใช้ค่าลบเพื่อให้หมุนขึ้นลงถูกทิศทาง
            currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle); // จำกัดมุมกล้องให้อยู่ในช่วงที่กำหนด
        }

        // คำนวณการหมุนของกล้อง
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // คำนวณตำแหน่งกล้องที่ต้องการ
        Vector3 offset = new Vector3(0, height, -currentDistance);
        Vector3 desiredPosition = player.position + rotation * offset;

        // ตรวจสอบการชนเพื่อป้องกันกล้องทะลุสิ่งกีดขวาง
        RaycastHit hit;
        if (Physics.Raycast(player.position, (desiredPosition - player.position).normalized, out hit, distance, collisionLayers))
        {
            currentDistance = hit.distance; // ปรับระยะห่างตามการชน
        }
        else
        {
            currentDistance = distance; // คืนค่าระยะห่างปกติถ้าไม่มีการชน
        }

        // คำนวณตำแหน่งกล้องใหม่ตามระยะห่างที่ปรับปรุง
        offset = new Vector3(0, height, -currentDistance);
        desiredPosition = player.position + rotation * offset;

        // ตั้งตำแหน่งกล้อง
        transform.position = desiredPosition;

        // ให้กล้องมองไปที่ผู้เล่น
        transform.LookAt(player.position + Vector3.up * height);
    }
}