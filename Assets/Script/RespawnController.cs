using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public PlayerController Player;
    public GameObject Spawn;
    public Transform positionSpawn;
    public float respawnTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            Invoke("Respawn", respawnTime);
        }
    }
    void Respawn()
    {
        Instantiate(Spawn, positionSpawn.position, Quaternion.identity);
    }

}
