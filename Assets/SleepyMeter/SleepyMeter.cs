using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SleepyMeter : MonoBehaviour
{
    //public floats, sleepy is current sleepy value. MaxSleepy is the max the value can reach
    public float sleepy, MaxSleep;
    public float coffeeDrink;

    [SerializeField]
    private SleepyMeterBarUI sleepybar;
    public GameObject GameOverUISP;
    public GameObject GameOverUIHA;

    public GameObject CoffeeButton;


    void Start()
    {

        GameOverUISP.SetActive(false);
        GameOverUIHA.SetActive(false);
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

        if (sleepy <= 0f) 
        {
            GameOverScreenSP();
        }

        if (sleepy >= 120f)
        {
            GameOverScreenHA();
        }

    }

    public void DrinkCoffee()
    {
        sleepy += coffeeDrink;

    }

    private void tiredTime()
    {
        if (sleepy < 120 && sleepy > 0f)
        {
            sleepy -= 5 * Time.deltaTime;
        }
    }

    private void GameOverScreenSP() 
    {
        GameOverUISP.SetActive(true);
        CoffeeButton.SetActive(false);
    }

    private void GameOverScreenHA()
    {
        GameOverUIHA.SetActive(true);
        CoffeeButton.SetActive(false);
    }

}
