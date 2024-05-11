using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    private float zOffSet = 39f;
    // Start is called before the first frame update
    void Start()
    {
        // Order by z position
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveRoad()
    {
        GameObject movedRoad = roads[0];
        // Remove first block to add at the end to create the illusion of infinite roads
        roads.Remove(movedRoad);
        // Getting z of last road object in the list and adding offset to get new block position
        float newZ = roads[roads.Count - 1].transform.position.z + zOffSet;

        // Adding the road object after moving it along the z axis
        movedRoad.transform.position = new Vector3(movedRoad.transform.position.x, movedRoad.transform.position.y, newZ);
        roads.Add(movedRoad);
    }
}
