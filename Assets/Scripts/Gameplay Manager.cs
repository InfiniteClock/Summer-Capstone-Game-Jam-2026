using System.Collections;
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

    [SerializeField]
    private Conveyor conveyor;
    [SerializeField]
    private Spawner spawner;

    [SerializeField]
    private float maxSlowTime;
    [SerializeField]
    private AnimationCurve slowTimeCurve;
    [SerializeField]
    private float percentRankAdjust;


    private Coroutine slowTimeRoutine;
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

    public void RankUp()
    {
        conveyor.IncreaseConveyorForce(percentRankAdjust);
        spawner.ReduceTime(percentRankAdjust);
        maxSlowTime -= maxSlowTime * percentRankAdjust;
    }
    public void SlowTime()
    {
        if (slowTimeRoutine != null)
            StopCoroutine(slowTimeRoutine);

        slowTimeRoutine ??= StartCoroutine(UnSlowTime());
    }
    private IEnumerator UnSlowTime()
    {
        Time.timeScale = 0.5f;
        float timer = 0;
        while (timer < maxSlowTime)
        {
            Time.timeScale = Mathf.Lerp(0.5f, 1.0f, timer / maxSlowTime);
            timer += Time.deltaTime;
            yield return null;
        }
        Time.timeScale = 1.0f;
    }
}
