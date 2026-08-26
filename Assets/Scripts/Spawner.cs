using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] 
    private List<GameObject> spawnableObjs;
    [SerializeField] 
    private float initialSpawnTime;
    [SerializeField] 
    private float speedPercentDecrease;

    public float currentSpawnTime;
    public float timer;
    private void Start()
    {
        currentSpawnTime = initialSpawnTime;
    }
    private void Update()
    {
        if (timer < currentSpawnTime) 
        { 
            timer += Time.deltaTime; 
        }
        else 
        {
            Spawn();
            //ReduceTime();
            timer -= currentSpawnTime; 
        }
    }

    public void Spawn()
    {
        int randInd = Random.Range(0, spawnableObjs.Count);
        GameObject newObj = Instantiate(spawnableObjs[randInd]);
        newObj.transform.position = transform.position;

    }
    public void ReduceTime()
    {
        currentSpawnTime -= currentSpawnTime * speedPercentDecrease;
    }
}
