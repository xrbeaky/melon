using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] EnemyManager enemies;
    [SerializeField] List<Transform> blocks = new List<Transform>();

    [SerializeField] Transform blockPrefab;
    [SerializeField] float blockSpacing = 1.0f;
    private Transform furthestBlock;
    [SerializeField] float renderDistance = 10f;

    private void Start()
    {
        InitializeBlocks();
    }

    private void Update()
    {
        if((furthestBlock.position.z - playerMovement.playerPosition.z) < renderDistance * 30)
        {
            Transform b = Instantiate(blockPrefab, new Vector3(furthestBlock.position.x, furthestBlock.position.y, furthestBlock.position.z + blockSpacing), Quaternion.identity);
            blocks.Add(b);
            furthestBlock = b;
        }
        if ((blocks[0].transform.position.z - playerMovement.playerPosition.z) < -30f)
        {
            Destroy(blocks[0].gameObject);
            blocks.RemoveAt(0);
        }
    }

    void InitializeBlocks()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            blocks.Add(transform.GetChild(i));
        }

        int n = blocks.Count;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (blocks[j].position.z < blocks[minIndex].position.z)
                {
                    minIndex = j;
                }
            }
            Transform temp = blocks[i];
            blocks[i] = blocks[minIndex];
            blocks[minIndex] = temp;  
        }
        furthestBlock = blocks[blocks.Count - 1];
    }
}
