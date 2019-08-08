using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{
    protected int damage;
    [SerializeField] protected float speed;

    [SerializeField] private Weapon weapon;
    [SerializeField] private PlayerStats playerStats;

    // Use this for initialization
    protected void Start()
    {
        damage = CalculateDamage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected int CalculateDamage()
    {
        int finalDamage;
        finalDamage = (weapon.Damage + playerStats.Damage);

        if (finalDamage >= 6 && playerStats.Level > 0 && weapon.Level > 0)
        {
            finalDamage = Random.Range(finalDamage - 5, finalDamage + 5) * (playerStats.Level + weapon.Level);
        }
        else
        {
            return finalDamage;
        }

        return finalDamage;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Monster>())
        {
            Debug.Log(other.gameObject.name + "Took " + damage + " damage");
            other.GetComponent<Monster>().TakeDamage(damage);
        }
    }
}
