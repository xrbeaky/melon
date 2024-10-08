using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [SerializeField] Transform leftNumbers;
    [SerializeField] Transform rightNumbers;

    int totalScore = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdatePlayerScore()
    {
        totalScore++;
        AddToRandomNumber();
    }

    public void UpdatePlayerScore(int score)
    {
        totalScore += score;
        for(int i = 0; i < score; i++)
        {
            AddToRandomNumber();
        }
    }

    private void AddToRandomNumber()
    {
        if (Random.Range(0f, 1.0f) < 5.0f)
        {
            TextMeshProUGUI text = leftNumbers.GetChild(Random.Range(0, leftNumbers.childCount)).GetComponent<TextMeshProUGUI>();
            text.text = (int.Parse(text.text) + 1).ToString();
        }
    }
}
