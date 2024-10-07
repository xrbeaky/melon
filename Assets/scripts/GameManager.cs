using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
    [SerializeField] PlayerShoot playerAttack;

    public int civiliansSaved = 0;
    public float respawnDelay = 5f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }

    public void Respawn()
    {
        playerAttack.onPlayerDeath();
        Invoke("RespawnPlayer", respawnDelay);
    }

    public void RespawnPlayer ()
    {
        playerAttack.onPlayerRespawn();
    }

    public void SaveCivilian()
    {
        civiliansSaved++;
    }
}
