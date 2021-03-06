using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float playerRange = 2f;
    [SerializeField] [Range(0, 100)] private int difficulty = 50;
    [SerializeField] private float healthGainPerKill = 2f;
    [SerializeField] private GameObject ZombiePrefab;
    private GameManager _gameManager;
    private Rigidbody rb;
    private AISounds _sounds;

    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
        _sounds = GetComponent<AISounds>();
        _gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        if (ZombiePrefab == null)
        {
            Debug.Log("You forgot to assign the zombie prefab to the player");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //rb.velocity = (transform.forward * (movementSpeed * Time.deltaTime));
            transform.Translate(Vector3.forward * (movementSpeed * Time.deltaTime));
       
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            //rb.velocity = (-transform.forward * (movementSpeed * Time.deltaTime));
            transform.Translate(-Vector3.forward * (movementSpeed * Time.deltaTime));
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * (rotationSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            float distanceToHuman = Vector3.Distance(transform.position, other.transform.position);
            if (distanceToHuman < playerRange)
            {
                _gameManager.GainHealth(healthGainPerKill);
                if (Infect() && _gameManager.CanSpawnZombie())
                {
                    SpawnZombie(other.transform);
                }
                _gameManager.UpdateScoreText(2);
                Destroy(other.gameObject);
                _sounds.PlayHurtSound();
            }
            

        }
    }

    private bool Infect()
    {
        int randomNumber = Random.Range(0, 100);
        
        if (randomNumber >= difficulty)
        {
            return true;
        }

        return false;
    }

    private void SpawnZombie(Transform positionToSpawn)
    {
        Instantiate(ZombiePrefab, positionToSpawn.position, Quaternion.identity);
    }
}
