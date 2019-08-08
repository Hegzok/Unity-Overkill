using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsters;
    [SerializeField] private float spawnTimer;

    // Delete later
    public GameObject MonsterParent;

    // Use this for initialization
    void Start()
    {
        ResetSpawnTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Flags.Instance.GamePlaying)
        {
            SpawnMonster();
        }
    }

    private void ResetSpawnTimer()
    {
        spawnTimer = Random.Range(0.5f, 2.5f);
    }

    private void SpawnMonster()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            int randomMonster = Random.Range(0, monsters.Length);

            GameObject monster = Instantiate(monsters[randomMonster], transform.position, Quaternion.identity);
            monster.transform.SetParent(MonsterParent.transform, true);

            // Delete VV
            MonsterCount.AddMonsterCount(1);
            ResetSpawnTimer();
        }
    }
}
