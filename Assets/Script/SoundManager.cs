using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    // Start is called before the first frame update
    private void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
        if(instance == null )
        {
            instance = this; 
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
