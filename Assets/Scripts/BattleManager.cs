using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Monster playerMonster { get; set; }
    public Monster enemyMonster { get; set; }

    public Text PlayerHealth;
    public Text EnemyHealth;
    public Button PlayerAttackOne, PlayerAttackTwo, PlayerAttackThree, PlayerAttackFour;
    public Text PlayerAttackOneName, PlayerAttackTwoName, PlayerAttackThreeName, PlayerAttackFourName;
    public HealthBar PlayerHealthBar;

    private readonly System.Random random = new System.Random();
    private int playerAttack = -1;
    
    void Start()
    {
        Debug.Log("Creating Monsters");
        playerMonster = new Monster()
        {
            monsterName = "Schiggy",
            maxHealth = 25,
            health = 25,
            level = 5,
            strength = 10,
            speed = 10,
            defense = 12,
            attacks = new Attacks[4],
            monsterType = "Water"
        };
        playerMonster.attacks[0] = new Attacks 
        {
            attackName = "Watergun",
            damage = 20,
            attackType = "Water"
        };
        playerMonster.attacks[1] = new Attacks
        {
            attackName = "Squirt",
            damage = 40,
            attackType = "Water"
        }; 
        playerMonster.attacks[2] = new Attacks
        {
            attackName = "Hydropump",
            damage = 60,
            attackType = "Water"
        }; 
        playerMonster.attacks[3] = new Attacks
        {
            attackName = "Tackle",
            damage = 20,
            attackType = "Normal"
        };

        PlayerHealthBar.SetMaxHealth(playerMonster.maxHealth);

        enemyMonster = new Monster()
        {
            monsterName = "Glumanda",
            maxHealth = 24,
            health = 24,
            level = 5,
            strength = 12,
            speed = 10,
            defense = 10,
            attacks = new Attacks[4],
            monsterType = "Fire"
        };
        enemyMonster.attacks[0] = new Attacks
        {
            attackName = "Ember",
            damage = 20,
            attackType = "Fire"
        };
        enemyMonster.attacks[1] = new Attacks
        {
            attackName = "Fireball",
            damage = 40,
            attackType = "Fire"
        };
        enemyMonster.attacks[2] = new Attacks
        {
            attackName = "Flamethrower",
            damage = 60,
            attackType = "Fire"
        };
        enemyMonster.attacks[3] = new Attacks
        {
            attackName = "Scratch",
            damage = 20,
            attackType = "Normal"
        };

        PlayerAttackOne.onClick.AddListener(OnFirstButtonClick);
        PlayerAttackTwo.onClick.AddListener(OnSecondButtonClick);
        PlayerAttackThree.onClick.AddListener(OnThirdButtonClick);
        PlayerAttackFour.onClick.AddListener(OnFourthButtonClick);

        Debug.Log("Created Monsters");
        WriteAttacks();
        WriteHealth();

        StartCoroutine(Fight());
    }

    void WriteAttacks()
    {
        PlayerAttackOneName.text = WriteAttackText(playerMonster.attacks[0]);
        PlayerAttackTwoName.text = WriteAttackText(playerMonster.attacks[1]);
        PlayerAttackThreeName.text = WriteAttackText(playerMonster.attacks[2]);
        PlayerAttackFourName.text = WriteAttackText(playerMonster.attacks[3]);
    }

    private string WriteAttackText(Attacks attack)
    {
        return $"{attack.attackName} ({attack.damage}) {attack.attackType}";
    }

    void WriteHealth()
    {
        PlayerHealthBar.SetHealth(playerMonster.health);
        PlayerHealth.text = $"{playerMonster.monsterName} {(int)(playerMonster.health)} / {(int)(playerMonster.maxHealth)}";
        EnemyHealth.text = $"{enemyMonster.monsterName} {(int)(enemyMonster.health)} / {(int)(enemyMonster.maxHealth)}";
    }
    
    void OnFirstButtonClick()
    {
        playerAttack = 0;
    }

    void OnSecondButtonClick()
    {
        playerAttack = 1;
    }

    void OnThirdButtonClick()
    {
        playerAttack = 2;
    }

    void OnFourthButtonClick()
    {
        playerAttack = 3;
    }


    IEnumerator PlayerAttack()
    {
        Debug.Log("Player Attacking");
        if (playerMonster.health > 0 && enemyMonster.health > 0)
        {
            yield return StartCoroutine(waitForButtonPress());
            enemyMonster.defending(playerMonster.attacking(playerAttack));
        }
        playerAttack = -1;
    }

    void EnemyAttack()
    {
        Debug.Log("Enemy Attacking");
        if (playerMonster.health > 0 && enemyMonster.health > 0)
        {
            playerMonster.defending(enemyMonster.attacking(random.Next(enemyMonster.attacks.Length)));
        }
    }

    IEnumerator Fight()
    {
        while (playerMonster.health > 0 || enemyMonster.health > 0)
        {
            if (playerMonster.health > 0 && enemyMonster.health > 0)
            {
                if (playerMonster.speed > enemyMonster.speed)
                {
                    Debug.Log("Player faster");
                    yield return StartCoroutine(PlayerAttack());
                    EnemyAttack();   
                }
                else if (enemyMonster.speed > playerMonster.speed)
                {
                    Debug.Log("Enemy faster");
                    EnemyAttack();
                    yield return StartCoroutine(PlayerAttack());
                }
                else
                {
                    Debug.Log("Same speed");
                    yield return StartCoroutine(PlayerAttack());
                    EnemyAttack();
                }
            }
            else
            {
                break;
            }
            
            WriteHealth();
        }

        if (playerMonster.health > 0)
        {
            enemyMonster.health = 0;
            Debug.Log("Player Monster Wins!");
        }
        else
        {
            playerMonster.health = 0;
            Debug.Log("Enemy Monster Wins!");
        }
        yield return null;


        WriteHealth();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator waitForButtonPress()
    {
        Debug.Log("Waiting for player input");
        bool done = false;
        while (!done)
        {
            if (playerAttack != -1)
            {
                done = true;
            }

            yield return null;
        }
    }
}
