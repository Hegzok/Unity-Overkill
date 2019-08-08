using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCount : Singleton<MonsterCount>
{
    public static int MonsterCounter;
    public static int MonstersKilledCounter;
    [SerializeField] private Text monsterCountText;
    [SerializeField] private Text monstersKilledText;

    // Update is called once per frame
    void Update()
    {
        monsterCountText.text = "Monster count: " + MonsterCounter.ToString();
        monstersKilledText.text = MonstersKilledCounter.ToString();
    }

    public static void AddMonsterCount(int monsterCount)
    {
        MonsterCounter += monsterCount;
    }

    public static void AddMonsterKilled(int monstersKilled)
    {
        MonstersKilledCounter += monstersKilled;
    }

}
