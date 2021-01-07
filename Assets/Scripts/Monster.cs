using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Monster
{
    public Attacks[] attacks;
    public string monsterName;
    public int level;
    public int exp;
    public int maxHealth;
    public double health;
    public int strength;
    public int defense;
    public int speed;
    public string monsterType;

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
