using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public 
    class Spawner : MonoBehaviour
{
    [SerializeField] GameObject humanPrefab;
    [SerializeField] GameObject policePrefab;
    [SerializeField] GameObject armyPrefab;
    [SerializeField] GameObject zombiePrefab;
    public enum enemyType { human,police,army,zombie};

    [SerializeField] private float timerAmount = 5f;
    private float startingTimerAmount = 5f;
    private GameManager _gameManager;
    [SerializeField] private int maxArmy = 10;
    [SerializeField] private int maxHumans = 20;
    [SerializeField] private int maxZombies = 30;
        
    // Start is called before the first frame update
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        startingTimerAmount = timerAmount;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("TimerStart");
    }

    private IEnumerator TimerStart()
    {
     
        timerAmount -= Time.deltaTime;
        if(timerAmount <= 0)
        {
            Spawn(enemyType.human);
            
            timerAmount = startingTimerAmount;
        }
        yield return null;
    }
        

    private void Spawn(enemyType enemyToSpawn)
    {
        GameObject enemyPrefabToSpawn;

        switch (enemyToSpawn)
        {
            case enemyType.human:
                enemyPrefabToSpawn = humanPrefab;
                break;
            case enemyType.police:
                enemyPrefabToSpawn = policePrefab;
                break;
            case enemyType.army:
                enemyPrefabToSpawn = armyPrefab;
                break;
            case enemyType.zombie:
                enemyPrefabToSpawn = zombiePrefab;
                break;
            default:
                enemyPrefabToSpawn = humanPrefab;
                break;
        }
        GameObject enemyInstance = Instantiate(enemyPrefabToSpawn, transform.position, Quaternion.identity);

    }

 
}
