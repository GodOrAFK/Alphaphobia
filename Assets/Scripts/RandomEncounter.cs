using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncounter : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        int rand = Random.Range(1, 100);

        if (rand <= 10)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            PlayerPrefs.SetFloat("posX", playerObj.transform.position.x);
            PlayerPrefs.SetFloat("posY", playerObj.transform.position.y);
            SceneManager.LoadScene("Combat");
        }
    }
}
