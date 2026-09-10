using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class DuckTalk : MonoBehaviour
{
    public Transform player;
    public GameObject birdNPC;           // ตัวเป็ด
    public GameObject messagePanel;      // แผงข้อความสำหรับแสดงบทสนทนา
    public TextMeshProUGUI messageText;  // ข้อความแสดงบทสนทนา
    public Button nextButton;            // ปุ่ม Next สำหรับเปลี่ยนข้อความ
    private int messageIndex = 0;        // ตัวชี้ข้อความปัจจุบัน
    public string[] messages = {
        "Can you help us clean up the city?"
    };

    void Start()
    {
        // เริ่มต้นแสดงบทสนทนาแรก
        messageText.text = messages[messageIndex];
        messagePanel.SetActive(true);  // เปิดแผงข้อความ
        birdNPC.SetActive(true);       // แสดงตัวเป็ด
        nextButton.onClick.AddListener(OnNextButtonClicked);  // ตั้งให้ปุ่ม Next เรียกฟังก์ชันเมื่อคลิก
    }

    void OnNextButtonClicked()
    {
        if (messageIndex < messages.Length - 1)
        {
            // ถ้ายังไม่ถึงข้อความสุดท้าย ให้เปลี่ยนไปข้อความถัดไป
            messageIndex++;
            messageText.text = messages[messageIndex];
        }
        else
        {
            // ถ้าถึงข้อความสุดท้ายแล้ว ให้เปลี่ยนซีนเป็น SQD
            SceneManager.LoadScene("SQD");
        }
    }

    void Update()
    {
        // ถ้าผู้เล่นเข้าใกล้เป็ดและกดคลิกเมาส์ซ้าย ให้แสดงบทสนทนา
        if (Vector3.Distance(player.position, birdNPC.transform.position) < 3f && Input.GetMouseButtonDown(0))
        {
            messagePanel.SetActive(true);
            messageText.text = messages[messageIndex];
        }
    }
}





