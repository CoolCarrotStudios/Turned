using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AIController : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private enum Behaviour
    {
        human,
        zombie,
        police,
        army
    }

    [SerializeField] private Behaviour _behaviour = Behaviour.human;
    [SerializeField] private float attackRange;
    [SerializeField] [Range(0,100)] private int infectionRate = 50;
    [SerializeField] private GameObject ZombiePrefab;
    [SerializeField] private bool canWander = true;
    [SerializeField] private bool attackZombie = false;
    float deathTimer = 6f;
    private float startingDeathTimer = 0f;
    private GameManager _gameManager;
    [SerializeField] private AISounds sound;
    
    
    

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        canWander = true;
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        sound = GetComponent<AISounds>();
        if (_behaviour == Behaviour.zombie && sound != null) 
        {
            sound.PlayZombieSound();
        }
        startingDeathTimer = deathTimer;
        if(FindObjectOfType<PlayerController>() != null)
        {
            target = FindObjectOfType<PlayerController>().transform;

        };
        if (target == null)
        {
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (agent == null) return;
        switch (_behaviour)
            {
                case Behaviour.human:
                    agent.speed = 3f;
                    if (canWander)
                    {
                        StartCoroutine(Wander());
                    }

                    // if (agent != null)
                    // {
                    //     RunFrom(target);
                    // }
                
                    break;
                case Behaviour.zombie:
                    agent.speed = 3.2f;
                    if (canWander)
                    {
                        StartCoroutine(Wander());
                    }
                    break;
                case Behaviour.police:
                    agent.speed = 4f;
                    ChasePlayer();
                    break;
                case Behaviour.army:
                    agent.speed = 4.2f;
                    if (!attackZombie)
                    {
                        ChasePlayer();
                    }
                
                    break;
                default:
                    ChasePlayer();
                    break;
            
        }
        
        
        
        
        
    }

    private void ChasePlayer()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
        
    }

    private IEnumerator Wander()
    {
        canWander = false;
        Vector3 randomDestination = new Vector3(Random.Range(-7, 7), 0, Random.Range(-7, 7));
        agent.SetDestination(transform.position + randomDestination);
        yield return new WaitForSeconds(3);
        canWander = true;
    }
    private void RunFrom(Transform runAwayTarget)
    {
        if (runAwayTarget != null && agent != null)
        {
            var startTransform = transform;
            var multiplyBy = 5;
        
            transform.rotation = Quaternion.LookRotation(transform.position - runAwayTarget.position);
        
            Vector3 runTo = transform.position + transform.forward * multiplyBy;

            NavMeshHit hit;  
        
            NavMesh.SamplePosition(runTo, out hit, 5, 1 << NavMesh.GetAreaFromName("Walkable"));

            transform.position = startTransform.position;
            transform.rotation = startTransform.rotation;

            if (agent.gameObject != null)
            {
                agent.SetDestination(hit.position);
            }

        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (_behaviour == Behaviour.human && other.CompareTag("Zombie"))
        {
            RunFrom(other.transform);
        }

        if (_behaviour == Behaviour.human && other.CompareTag("Player"))
        {
            RunFrom(other.transform);
        }
        
        if (_behaviour == Behaviour.zombie && other.CompareTag("Human"))
        {
            canWander = false;
            StopCoroutine(Wander());
            agent.SetDestination(other.transform.position);

            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance < attackRange)
            {
                int randomNumber = Random.Range(0, 100);
                if (randomNumber > infectionRate)
                {
                    Instantiate(ZombiePrefab, transform.position, Quaternion.identity);
                }
                _gameManager.UpdateScoreText(1);
                Destroy(other.gameObject);
                
                agent.ResetPath();
            }

            canWander = true;
        }
        if (_behaviour == Behaviour.army && other.CompareTag("Zombie"))
        {
            attackZombie = true;
            agent.SetDestination(other.transform.position);

            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance < attackRange)
            {
                other.GetComponent<AISounds>().PlayDeadSound();
                Destroy(other.gameObject);
                agent.ResetPath();
            }

            attackZombie = false;
        }

        if (_behaviour == Behaviour.army && other.CompareTag("Player") && agent != null)
        {
            _gameManager.TakeDamage(Time.deltaTime);
            agent.SetDestination(other.transform.position);
            sound.PlayHurtSound();
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_behaviour == Behaviour.army && other.CompareTag("Zombie"))
        {
            int randomRoll = Random.Range(0, 100);
            if (randomRoll < 5)
            {
                
                Destroy(this.gameObject);
            }
        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     StopCoroutine("DeathTimer");
    //     deathTimer = startingDeathTimer;
    //     attackZombie = false;
    // }

    /*private IEnumerator DeathTimer(Collider player)
    {
        
        deathTimer -= Time.deltaTime;
        Debug.Log(deathTimer);
        if (deathTimer <= 0)
        {
            Destroy(player.gameObject);
            _gameManager.GameOver();
            agent.SetDestination(new Vector3(0, 0, 0));
        }

        
        attackZombie = true;

        yield return null;
    }*/
}
