using UnityEngine;
using UnityEngine.SceneManagement;

public class treed : MonoBehaviour
{
    private GameObject[] trashObjects;  // เก็บขยะทั้งหมดในฉาก

    void Start()
    {
        // ค้นหาทุก GameObject ที่มี tag เป็น "Trash"
        trashObjects = GameObject.FindGameObjectsWithTag("Tree");
        Debug.Log("Total Tree: " + trashObjects.Length);
    }

    void Update()
    {
        // ตรวจสอบว่ามีขยะหลงเหลือในฉากหรือไม่
        if (AllTrashCollected())
        {
            Debug.Log("All Tree collected! Loading next scene...");
            SceneManager.LoadScene("de");  // เปลี่ยนซีนเมื่อขยะหายหมด
        }
    }

    // ฟังก์ชันสำหรับตรวจสอบว่าขยะทั้งหมดถูกเก็บหรือไม่
    bool AllTrashCollected()
    {
        // ลูปตรวจสอบว่ามีขยะชิ้นใดยังไม่ถูกทำลายหรือไม่
        foreach (GameObject Tree in trashObjects)
        {
            if (Tree != null)  // ถ้ามีขยะที่ยังไม่ถูกลบ
            {
                return false;  // ยังเก็บไม่ครบ
            }
        }
        return true;  // เก็บขยะครบแล้ว
    }
}
