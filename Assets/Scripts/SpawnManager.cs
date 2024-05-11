using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    RoadSpawner roadSpawner;
    ObjectSpawner objectSpawner;
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        objectSpawner = GetComponent<ObjectSpawner>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnTriggerEntered()
    {
        roadSpawner.MoveRoad();
        objectSpawner.SpawnObjects();
    }
}
