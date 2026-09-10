using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneManagerScript : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public Button readyButton;
    private int storyIndex = 0;  // ใช้ติดตามข้อความที่แสดงปัจจุบัน

    private string[] storyMessages =  // ข้อความตามลำดับ
    {
        "Verdelon City\n\n\nOnce, this city was a dreamland where people lived in harmony with nature...\n\nLush green leaves, rivers as clear as glass, and pure winds blew all year long.\n\nBut over time, this city changed and became a place no one wished to live in.",
        "Your mission begins here...\n\nExplore the city, help the townspeople, and find a way to heal the city from its core.\n\nAre you ready to bring this city back to life?"
    };

    void Start()
    {
        storyText.text = storyMessages[storyIndex];  // แสดงข้อความแรก
        readyButton.gameObject.SetActive(false);  // ซ่อนปุ่ม Ready ตอนเริ่มต้น
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // ตรวจจับคลิกซ้ายของเมาส์
        {
            ShowNextMessage();
        }
    }

    void ShowNextMessage()
    {
        storyIndex++;  // ไปยังข้อความถัดไป

        if (storyIndex < storyMessages.Length)
        {
            storyText.text = storyMessages[storyIndex];  // แสดงข้อความใหม่
        }
        else
        {
            readyButton.gameObject.SetActive(true);  // แสดงปุ่ม Ready เมื่อข้อความจบ
        }
    }

    public void OnReadyButtonClicked()
    {
        Debug.Log("Ready Button Clicked!");  // ตรวจสอบว่าฟังก์ชันถูกเรียก
        SceneManager.LoadScene("GameScene");
    }

}
