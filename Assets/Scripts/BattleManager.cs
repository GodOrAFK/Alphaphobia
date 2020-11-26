using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Monster playerMonster { get; set; }
    public Monster enemyMonster { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        playerMonster = new Monster()
        {
            monsterName = "Schiggy",
            health = 20,
            attacks = new Attacks[4]
        };
        playerMonster.attacks[0] = new Attacks 
        {
            attackName = "Watergun",
            damage = 5
        };

        enemyMonster = new Monster()
        {
            monsterName = "Glumanda",
            health = 20,
            attacks = new Attacks[4]
        };
        enemyMonster.attacks[0] = new Attacks
        {
            attackName = "Ember",
            damage = 5
        };
    }

    // Update is called once per frame
    void Update()
    {
        while (playerMonster.health > 0 && enemyMonster.health > 0)
        {
            //Player attack
            enemyMonster.health -= playerMonster.attacks[waitForKeyPress()].damage;
            Debug.Log(enemyMonster.health);

            //Enemy attack
            playerMonster.health -= enemyMonster.attacks[0].damage;
            Debug.Log(playerMonster.health);
        }
        //Debug.Log("End");
    }

    private int waitForKeyPress()
    {
        bool done = false;
        int attackNumber = 0;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                attackNumber = 1;
                done = true; // breaks the loop
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                attackNumber = 2;
                done = true; // breaks the loop
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                attackNumber = 3;
                done = true; // breaks the loop
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                attackNumber = 4;
                done = true; // breaks the loop
            }
        }

        return attackNumber;
    }
}
