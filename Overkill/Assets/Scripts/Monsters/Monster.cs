using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [SerializeField] private float movementSpeed = 10f;

    [SerializeField] private GameObject DestinationPoint;
    [SerializeField] private PlayerStats playerStats;

    private bool alreadyKilled;

    // Use this for initialization
    void Start()
    {
        HandleEvents(true);

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToDestination();
    }

    private void OnDestroy()
    {
        HandleEvents(false);
    }

    protected void HandleEvents(bool switcher)
    {
        if (switcher)
        {
            EventsManager.OnGameStateChange += KillAllMonsters;
        }
        else
        {
            EventsManager.OnGameStateChange -= KillAllMonsters;
        }
    }

    protected void KillAllMonsters(bool playGame)
    {
        if (!playGame)
        {
            alreadyKilled = true;
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Delete consider VV

        if (!alreadyKilled)
        {
            playerStats.AddGold(1);
            playerStats.GrantExperience(1);
            MonsterCount.AddMonsterCount(-1);
            MonsterCount.AddMonsterKilled(1);
            alreadyKilled = true;
        }

        Destroy(this.gameObject);
    }

    private void MoveToDestination()
    {
        transform.LookAt(DestinationPoint.transform.position);

        transform.position += transform.forward * movementSpeed * Time.deltaTime;

        if (Vector3.Distance(this.transform.position, DestinationPoint.transform.position) <= 2f)
        {
            // Delete VV
            if (!alreadyKilled)
            {
                MonsterCount.AddMonsterCount(-1);
                MonsterCount.AddMonsterKilled(1);
                alreadyKilled = true;
                Destroy(this.gameObject);
            }
        }
    }
}
