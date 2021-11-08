using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawnPoint;
    private void LateUpdate()
    {
        if(player.transform.position.y <= -100)
        {
            player.transform.position = respawnPoint.position;
            Debug.Log("Hello World");
        }
    }
}