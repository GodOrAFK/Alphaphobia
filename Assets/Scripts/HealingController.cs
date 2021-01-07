using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerMonsterController playerMonsterScript = GameObject.FindGameObjectWithTag("PlayerMonsterController").GetComponent<PlayerMonsterController>();

            playerMonsterScript.HealAll();
        }
        Debug.Log(collision.gameObject);
    }
}
