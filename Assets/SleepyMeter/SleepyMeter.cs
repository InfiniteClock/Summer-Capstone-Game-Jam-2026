using UnityEngine;

public class SleepyMeter : MonoBehaviour
{
    //public floats, sleepy is current sleepy value. MaxSleepy is the max the value can reach
    public float sleepy, MaxSleep;
    public float coffeeDrink;

    [SerializeField]
    private SleepyMeterBarUI sleepybar;

    void Start()
    {
        coffeeDrink = 20;
        sleepybar.setMaxSleepy(MaxSleep);

    }

    // Update is called once per frame
    void Update()
    {
        //Sleepybar sets the current blue bars progress over the sleepy bar
        //tired time ticks down the players full sleepy meter over time
        //input key space increases the players sleepybar AKA drinks the coffee
        sleepybar.SetSleepy(sleepy);
        tiredTime();

        if (Input.GetKeyDown("space"))
        {
            SetPlayerSleepy();
            
        }


    }

    public void SetPlayerSleepy()
    {
        sleepy += coffeeDrink;

    }

    private void tiredTime()
    {
        sleepy -= 5 * Time.deltaTime;
    }



}
