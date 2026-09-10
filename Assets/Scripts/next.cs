using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class next : MonoBehaviour
{
    public Transform player;              // ตำแหน่งของผู้เล่น
    public Transform treePosition;        // ตำแหน่งของต้นไม้ (ใช้ได้ในภายหลัง)
    public GameObject birdNPC;            // ตัวละครเป็ด (NPC)
    public GameObject messagePanel;       // พาเนลสำหรับแสดงข้อความ
    public TextMeshProUGUI messageText;   // ข้อความที่จะแสดงในพาเนล
    public Button nextButton;             // ปุ่มสำหรับไปยังข้อความถัดไป

    private int messageIndex = 0;         // ตัวนับข้อความปัจจุบัน
    private string[] messages =           // ชุดข้อความของเป็ด
    {
        " ",
        "Duck: Hey, human! Do you see all this trash? This place used to be beautiful, but humans ruined it...",
        "Duck: I can’t clean it all by myself. If you help, I’ll gather the remaining villagers to help purify the polluted water.",
        "Sure, I'll help clean up the trash.",
        "Is there anything I should be careful of?",
        "Duck: There’s nothing more dangerous than the indifference of people. Remember... ",
        "Even small efforts to clean up might seem insignificant, but every piece of trash matters for the future of the Great Tree!"
    };

    void Start()
    {
        messagePanel.SetActive(false);  // ซ่อนพาเนลตอนเริ่มเกม
        birdNPC.SetActive(true);        // แสดง NPC เป็ด
        nextButton.onClick.AddListener(OnNextButtonClicked);  // เชื่อมฟังก์ชันกับปุ่ม
    }

    void Update()
    {
        // ตรวจสอบว่าผู้เล่นเข้าใกล้เป็ดในระยะ 3 หน่วย และคลิกซ้าย
        if (Vector3.Distance(player.position, birdNPC.transform.position) < 3f && Input.GetMouseButtonDown(0))
        {
            if (!messagePanel.activeSelf)  // เปิดพาเนลหากยังไม่เปิด
            {
                messageIndex = 0;  // รีเซ็ตข้อความไปที่ข้อความแรก
                messagePanel.SetActive(true);
                messageText.text = messages[messageIndex];
            }
        }
    }

    void OnNextButtonClicked()
    {
        if (messageIndex < messages.Length - 1)  // ถ้ายังมีข้อความถัดไป
        {
            messageIndex++;  // ขยับไปข้อความถัดไป
            messageText.text = messages[messageIndex];
        }
        else  // ถ้าข้อความหมดแล้ว
        {
            SceneManager.LoadScene("SQD");  // เปลี่ยนไปยังซีน "SQD"
        }
    }
}
