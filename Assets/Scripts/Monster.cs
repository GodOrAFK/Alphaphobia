using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    public Attacks[] attacks;
    public string monsterName { get; set; }
    public int level { get; set; }
    public int exp { get; set; }
    public int maxHealth { get; set; }
    public int health { get; set; }
    public int strength { get; set; }
    public int defense { get; set; }
    public int speed { get; set; }

    public int attacking(int attackNumber)
    {
        int damage = 0;
        damage = (attacks[attackNumber].damage * strength) / 100;
        return damage;
    }

    public void defending(int damage)
    {
        health -= damage * 100 / (defense * 2);
    }
}
