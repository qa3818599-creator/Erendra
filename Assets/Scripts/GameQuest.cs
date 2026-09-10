using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameQuest : MonoBehaviour
{
    public Transform player;
    public Transform treePosition;
    public GameObject birdNPC;
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;
    public Button nextButton;
    private int messageIndex = 0;
    private string[] messages = {
        "...",
        "The sparrow : Ah… Help me… I'm so thirsty but the water in this town… I can't drink it. It's dirty and has a strange smell…",
        "Take the water bottle from your inventory and give it to the little bird to drink.",
        "The sparrow : Thank you so much… This clean water really helps me. But I hope you can do more…",
        "The sparrow : This place… This town was once beautiful, but now… everything is ruined by pollution. Do you want to see this town come to life again?",
        "I'm happy to help, but why is the town in this state?",
        "The sparrow : Irresponsibility, selfishness, and human greed… have destroyed everything. Even 'Erendra', the tree of life, is weakening…",
        "The sparrow : Follow me, I'll take you to the tree of life called Erendra."
    };

    void Start()
    {
        messageText.text = "Quest 1: Help the little bird";
        messagePanel.SetActive(true);
        birdNPC.SetActive(true);
        nextButton.onClick.AddListener(OnNextButtonClicked);
    }

    void Update()
    {
        if (Vector3.Distance(player.position, birdNPC.transform.position) < 3f && Input.GetMouseButtonDown(0))
        {
            messagePanel.SetActive(true);
            messageText.text = messages[messageIndex];
        }
    }

    void OnNextButtonClicked()
    {
        if (messageIndex < messages.Length - 1)
        {
            messageIndex++;
            messageText.text = messages[messageIndex];
        }
        else
        {
            SceneManager.LoadScene("DuckScene");
        }
    }
}


