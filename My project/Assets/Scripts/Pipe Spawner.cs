using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
    
{
    public GameObject pipeprefab;
    public float spawntime = 2f;
    private float timer = 0f;
    public float heightoffset = 10f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    private void SpawnPipe()
    {
        float minheight = transform.position.y - heightoffset;
        float maxheight = transform.position.y + heightoffset;
        float randomy = UnityEngine.Random.Range(minheight, maxheight);
        Vector3 spawnposition = new Vector3(transform.position.x,  randomy, transform.position.z);
        Instantiate(pipeprefab, spawnposition, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawntime)
        {
            timer += Time.deltaTime;
        }
        else
        { SpawnPipe();
            timer = 0;
        }
    }
}
