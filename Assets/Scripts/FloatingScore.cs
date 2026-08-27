using System.Collections;
using TMPro;
using UnityEngine;

public class FloatingScore : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private float speed;
    [SerializeField] private AnimationCurve fadeCurve;
    [SerializeField] private Color[] flashingColors;

    public int value { private get; set; }
    private string txt;
    private TextMeshProUGUI tmp;
    private float timer;
    private void Start()
    {
        // Sets the worldspace camera to the main camera at spawn
        GetComponent<Canvas>().worldCamera = Camera.main;

        // Adds a '+' symbol to positive points, but negative points already have '-'
        if (value >= 0)
            txt = "+" + value;
        else
            txt = value.ToString();
        
        // Get the TMPro component and set the text value
        tmp = GetComponentInChildren<TextMeshProUGUI>();

        if (tmp != null)
            tmp.text = txt;
        else
            Debug.LogError("No TextMeshProUGUI found!");

        // Start the floating and flashing sequence
        StartCoroutine(FloatAway());
    }
    
    private IEnumerator FloatAway()
    {
        while (timer < lifetime)
        {
            // Determine the interpolation percentage
            float interpolation = timer / lifetime;

            // Pick a random flashing color
            int randNumb = Random.Range(0, flashingColors.Length);
            Color randCol = flashingColors[randNumb];
            // Set the transparency based on interpolation
            randCol.a = fadeCurve.Evaluate(interpolation);
            tmp.color = randCol;

            // Translate the numbers up over time based on interpolation
            Vector3 translation = Vector3.up * fadeCurve.Evaluate(interpolation) * speed;
            transform.Translate(translation);

            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
