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
    public double health { get; set; }
    public int strength { get; set; }
    public int defense { get; set; }
    public int speed { get; set; }
    public string monsterType { get; set; }

    public double attacking(int attackNumber)
    {
        double damage = 0;
        damage = attacks[attackNumber].attackType == this.monsterType ? (attacks[attackNumber].damage * strength) / 100 * 1.25 : (attacks[attackNumber].damage * strength) / 100;
        return damage;
    }

    public void defending(double damage)
    {
        health -= damage * 100 / (defense * 2);
    }
}
