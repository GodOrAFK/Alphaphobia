using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonsterController : MonoBehaviour
{
    public Monster[] PlayerMonster;

    private void Awake()
    {
        GameObject existingController = GameObject.FindGameObjectWithTag("PlayerMonsterController");
        if(existingController != null && existingController.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
