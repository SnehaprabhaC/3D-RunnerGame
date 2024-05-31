using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private GroundSpawner groundspawner;

    public GameObject starPrefab;

    public GameObject[] obstaclePrefabs;
    public Transform[] spawnpoints;

    private void Awake()
    {
        groundspawner = GameObject.FindObjectOfType<GroundSpawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnObs();
        SpawnStar();

    }

    private void OnTriggerExit(Collider other)
    {
        groundspawner.spawnTile();

        Destroy(gameObject, 5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObs()
    {
        int ChooseSpawnPoint = Random.Range(0, spawnpoints.Length);
        int SpawnPrefab = Random.Range(0, obstaclePrefabs.Length);

        Instantiate(obstaclePrefabs[SpawnPrefab], spawnpoints[ChooseSpawnPoint].transform.position, Quaternion.identity, transform);
    }

    public void SpawnStar()
    {
        int spawnAmount = 3;
        for(int i =0; i<spawnAmount;i++)
        {
            GameObject tempStar = Instantiate(starPrefab);
            tempStar.transform.position = SpawnRandomPoint(GetComponent<Collider>());
        }
    }
    Vector3 SpawnRandomPoint(Collider col)
    {
        Vector3 point = new Vector3 (Random.Range(col.bounds.min.x, col.bounds.max.x), Random.Range(col.bounds.min.y, col.bounds.max.y), Random.Range(col.bounds.min.z, col.bounds.max.z));
        point.y = 1;
        return point;
    }
}


