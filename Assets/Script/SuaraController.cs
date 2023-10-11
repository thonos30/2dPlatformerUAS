using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuaraController : MonoBehaviour
{
    public AudioSource suara;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void suaraMati()
    {
        suara.volume = 0;
    }
    public void suaraNyala()
    {
       suara.volume = 1;
    }
}
