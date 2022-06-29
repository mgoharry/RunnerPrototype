using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obsPrefabs;

    private Vector3 spawnPos;

    [SerializeField]
    private float xPos = 24;

    private int obsRando;

    private float rando;

    private PlayerController pcScript;
    // Start is called before the first frame update
    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("SpawnObstacles", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    private void SpawnObstacles()
    {
        spawnPos = new Vector3(xPos, 0, 0);
        rando = Random.Range(0.59f, 1.5f);

        obsRando = Random.Range(0, obsPrefabs.Length);

        if (!pcScript.gameOver)
        {

            Instantiate(obsPrefabs[obsRando], spawnPos, obsPrefabs[obsRando].transform.rotation);
        }

        Invoke("SpawnObstacles", rando);

    }
}
