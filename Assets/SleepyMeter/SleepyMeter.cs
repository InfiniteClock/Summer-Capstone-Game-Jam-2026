using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using FMODUnity;

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
    private bool drinkingCoffee;
    public float timeToDrink;
    float incrementOfSleepy;
    float SleepyBeforeCoffee;
    public GameObject coffeeOverlay;

    [SerializeField] private EventReference grabMug;
    [SerializeField] private EventReference swallowCoffee;


    void Start()
    {

        GameOverUISP.SetActive(false);
        GameOverUIHA.SetActive(false);
        coffeeDrink = 40;
        sleepybar.setMaxSleepy(MaxSleep);
        drinkingCoffee = false; 

    }

    // Update is called once per frame
    void Update()
    {
        //Sleepybar sets the current blue bars progress over the sleepy bar
        //tired time ticks down the players full sleepy meter over time
        //input key space increases the players sleepybar AKA drinks the coffee
        if (drinkingCoffee)
        {
            coffeeOverlay.SetActive(true);
            if (sleepy  < coffeeDrink + SleepyBeforeCoffee)
            {
                incrementOfSleepy = coffeeDrink / timeToDrink;
                sleepy += incrementOfSleepy * Time.deltaTime;
            } else
            {
                drinkingCoffee = false; 
            }
             
        } else if (!drinkingCoffee)
        {
            coffeeOverlay.SetActive(false);
            tiredTime();
        }
        sleepybar.SetSleepy(sleepy);
        

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
        RuntimeManager.PlayOneShot(grabMug, transform.position);
        drinkingCoffee = true;
        SleepyBeforeCoffee = sleepy;
        RuntimeManager.PlayOneShot(swallowCoffee, transform.position);
        GameplayManager.Instance.RankUp();
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
