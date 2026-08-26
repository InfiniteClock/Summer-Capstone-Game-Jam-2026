using UnityEngine;
using UnityEngine.UI;

public class SleepyMeterBarUI : MonoBehaviour
{
    public float Currentsleepiness, Maxsleepiness, Width, Height;

    [SerializeField]
    //changes the rectangle that is the sleepybar blue health over the white sleepybar
    private RectTransform sleepybarRect;

    public void setMaxSleepy(float maxsleepiness) 
    {
        Maxsleepiness = maxsleepiness;
    }

    public void SetSleepy(float sleepy) 
    { 
        Currentsleepiness = sleepy;
        float newWidth = (Currentsleepiness / Maxsleepiness) * Width;

        sleepybarRect.sizeDelta = new Vector2 (newWidth, Height);

    
    }



}
