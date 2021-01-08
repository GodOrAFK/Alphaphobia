using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public string ControllerTag;

    private void Awake()
    {
        //GameObject existingController = GameObject.FindGameObjectWithTag(ControllerTag);
        //if (existingController != null && existingController.GetInstanceID() != this.gameObject.GetInstanceID())
        //{
        //    Destroy(this.gameObject);
        //}

        //DontDestroyOnLoad(this.gameObject);
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
