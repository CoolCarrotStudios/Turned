using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    public enum enemyType
    {
        human,
        police,
        army,
        zombie
    };

    [SerializeField] private GameObject humanPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timerAmount = 5f;
    private float startingTimerAmount = 5f;
    private int armyCounter;
    private GameManager _gameManager;
    private int humanCounter;
    private int zombieCounter;
    [SerializeField] private int humanChance = 90;
    [SerializeField] private int enemyChance = 10;
    private int totalProbability;
    private bool timerStarted;

    // Start is called before the first frame update
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        startingTimerAmount = timerAmount;
        totalProbability = humanChance + enemyChance;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("TimerStart");

        
    }

    private IEnumerator TimerStart()
    {
        timerAmount -= Time.deltaTime;
        Debug.Log(timerAmount);
        if (timerAmount <= 0)
        {
            int randomNumber = Random.Range(0, totalProbability);
            if (randomNumber <= humanChance && _gameManager.CanSpawnHuman())
            {
                Spawn(enemyType.human);
            }
            else if (randomNumber > humanChance && _gameManager.CanSpawnEnemy())
            {
                Spawn(enemyType.army);
            }
            
            timerAmount = Random.Range(10,20);
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
            case enemyType.army:
                enemyPrefabToSpawn = enemyPrefab;
                break;
            default:
                enemyPrefabToSpawn = humanPrefab;
                break;
        }
        GameObject enemyInstance = Instantiate(enemyPrefabToSpawn, transform.position, Quaternion.identity);

    }
}
