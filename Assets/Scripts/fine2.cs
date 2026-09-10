using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fine2 : MonoBehaviour
{
    public GameObject messagePanel;
    public Text messageText;
    public string targetScene = "Z";
    public float detectionRadius = 1.5f;
    public Transform player;
    public Transform duck;
    private bool questActive = true;

    void Start()
    {
        ShowQuestMessage();
    }

    void ShowQuestMessage()
    {
        messageText.text = "Find the duck!";
        messagePanel.SetActive(true);
    }

    void Update()
    {
        if (questActive && Vector3.Distance(player.position, duck.position) <= detectionRadius)
        {
            CompleteQuest();
        }
    }

    void CompleteQuest()
    {
        messagePanel.SetActive(false);
        questActive = false;
        SceneManager.LoadScene(targetScene);
    }
}

