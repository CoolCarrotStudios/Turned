using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        private List<GameObject> humans = new List<GameObject>();
        [SerializeField] private Text scoreText;
        [SerializeField] private Text gameOverScore;
        [SerializeField] private Text levelUpText;
        [SerializeField] private GameObject gameOverUIPanel;
        [SerializeField] private Slider healthBar;
        [SerializeField] private Image healthPanel;
        private Color healthPanelColor;
        private int score;
        private float health = 50f;
        [SerializeField] private int maxEnemies;
        [SerializeField] private int maxZombies;
        [SerializeField] private int maxHumans;

        [SerializeField] private Color halfHealth;
        [SerializeField] private Color quarterHealth;

        private float difficultyTimer = 60f;
        private int zombieCounter;
        private int humanCounter;
        private int enemyCounter;

        private void Start()
        {
            healthPanelColor = healthPanel.color;
            healthBar.maxValue = health;
            healthBar.value = health;
        }

        private void Update()
        {
            StartCoroutine(DifficultyTimer());
        }

        private IEnumerator DifficultyTimer()
        {
            difficultyTimer -= Time.deltaTime;
            if (difficultyTimer <= 0)
            {
                IncreaseMaxEnemies(2);
                levelUpText.enabled = true;
                yield return new WaitForSeconds(4f);
                levelUpText.enabled = false;
                difficultyTimer = 20f;
            }
        }

        private void IncreaseMaxEnemies(int amountToIncrease)
        {
            maxEnemies += amountToIncrease;
        }
        
        private int GetScore()
        {
            return score;
        }

        private void AddScore(int pointsToAdd)
        {
            score += pointsToAdd;
        }

        public void UpdateScoreText(int pointsToAdd)
        {
            AddScore(pointsToAdd);
            int newScore = GetScore();
            string newScoreText = $"Score: {newScore}";
            scoreText.text = newScoreText;

        }

        public void TakeDamage(float damageToTake)
        {
            health -= damageToTake;
            healthBar.value = health;
            if (health <= healthBar.maxValue / 2 && health > healthBar.maxValue / 4)
            {
                healthPanel.GetComponent<Image>().color = halfHealth;
            }

            if (health <= healthBar.maxValue / 4 && health > 0)
            {
                healthPanel.GetComponent<Image>().color = quarterHealth;
            }
            if (health <= 0)
            {
                healthPanel.GetComponent<Image>().color = Color.black;
                GameOver();
            }
        }

        public void GainHealth(float healthToGain)
        {
            health += healthToGain;
            if (health > healthBar.maxValue)
            {
                health = healthBar.maxValue;
            }

            if (health > healthBar.maxValue / 2)
            {
                healthPanel.GetComponent<Image>().color = Color.clear;
            }
            if (health <= healthBar.maxValue / 2 && health > healthBar.maxValue / 4)
            {
                healthPanel.GetComponent<Image>().color = halfHealth;
            }

            if (health <= healthBar.maxValue / 4 && health > 0)
            {
                healthPanel.GetComponent<Image>().color = quarterHealth;
            }
            healthBar.value = health;
        }
        

        public void GameOver()
        {
            gameOverUIPanel.SetActive(true);
            gameOverScore.text = GetScore().ToString();
            Time.timeScale = 0;
        }

        public void ResetGame()
        {
            SceneManager.LoadScene(1);
        }

        public bool CanSpawnZombie()
        {
            if (zombieCounter > maxZombies)
            {
                return false;
            }
            zombieCounter++;
            return true;
            
        }
        public bool CanSpawnHuman()
        {
            if (humanCounter >= maxHumans)
            {
                return false;
            }
            humanCounter++;
            return true;
        }
        public bool CanSpawnEnemy()
        {
            if (enemyCounter >= maxEnemies)
            {
                return false;
            }

            enemyCounter++;
            return true;
        }

        public void RemoveHuman()
        {
            humanCounter--;
        }
        public void RemoveZombie()
        {
            zombieCounter--;
        }
        public void RemoveEnemy()
        {
            enemyCounter--;
        }
    }
