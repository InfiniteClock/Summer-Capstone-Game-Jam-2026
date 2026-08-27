using TMPro;
using UnityEngine;


public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;
    [field: SerializeField]
    public TheHand hand { get; private set; }

    [field: SerializeField]
    public bool useHandCursor { get; private set; }

    public static int currentScore;
    [field: SerializeField]
    public int sortCorrectScore { get; private set; }
    [field: SerializeField]
    public int sortWrongScore { get; private set; }

    [SerializeField]
    private TextMeshProUGUI scoreDisplay;
    [SerializeField]
    private GameObject floatingScorePrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }
    private void OnValidate()
    {
        hand.UseHandCursor = useHandCursor;
    }

    public static void UpdateScore(int addScore, Vector3 position)
    {
        currentScore = Mathf.Max(0, currentScore + addScore);
        Instance.scoreDisplay.text = "Score: " + currentScore;

        GameObject floatScore = Instantiate(Instance.floatingScorePrefab);
        floatScore.transform.position = position;
        floatScore.GetComponent<FloatingScore>().value = addScore;
    }
}
