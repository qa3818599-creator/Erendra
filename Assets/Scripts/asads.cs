using UnityEngine;
using UnityEngine.SceneManagement;

public class asads : MonoBehaviour
{
    // ฟังก์ชันที่ถูกเรียกเมื่อกดปุ่ม
    public void OnEndButtonClicked()
    {
        // เปลี่ยนซีนไปยังซีนที่กำหนด (แทนที่ "YourSceneName" ด้วยชื่อซีนที่คุณต้องการ)
        SceneManager.LoadScene("SQD");
    }
}
