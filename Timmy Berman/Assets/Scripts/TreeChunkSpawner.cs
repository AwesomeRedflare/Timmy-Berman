using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChunkSpawner : MonoBehaviour
{

    public GameObject[] treeChunks;

    private int treeChunkOffSet = 1;

    private void Start()
    {
        
    }

    private void Update()
    {
        int lastTreeChunk = gameObject.transform.childCount - 1;

        if (transform.childCount < 10)
        {
            Vector2 treeChunkPositon = new Vector2(transform.position.x, transform.position.y + treeChunkOffSet);

            if (gameObject.transform.GetChild(lastTreeChunk).gameObject.CompareTag("No Branch"))
            {
                Instantiate(treeChunks[Random.Range(0, 3)], treeChunkPositon, Quaternion.identity, gameObject.transform);
            }

            if (gameObject.transform.GetChild(lastTreeChunk).gameObject.CompareTag("Left Branch"))
            {
                Instantiate(treeChunks[Random.Range(0, 2)], treeChunkPositon, Quaternion.identity, gameObject.transform);
            }

            if (gameObject.transform.GetChild(lastTreeChunk).gameObject.CompareTag("Right Branch"))
            {
                Instantiate(treeChunks[Random.Range(3, 4)], treeChunkPositon, Quaternion.identity, gameObject.transform);
            }

            treeChunkOffSet += 1;
        }
    }
}
