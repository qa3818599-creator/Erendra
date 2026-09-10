using UnityEngine;
using UnityEngine.SceneManagement;  // ใช้ SceneManager สำหรับเปลี่ยนซีน

public class Playehe : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        Debug.Log("Play Button Clicked!");  // ตรวจสอบว่าปุ่มถูกกด
        SceneManager.LoadScene("OpeningScence");  // เปลี่ยนไปยังซีน OpeningScene
    }
}

