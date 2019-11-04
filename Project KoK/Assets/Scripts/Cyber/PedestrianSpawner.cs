using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{

    [SerializeField]
    public GameObject[] pedestrianPrefab;

    public int pedestrianToSpawn;

    private int randomPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int count = 0;
        while(count < pedestrianToSpawn)
        {

            randomPrefab = Random.Range(0, 1);
            GameObject obj = Instantiate(pedestrianPrefab[randomPrefab]);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;

            yield return new WaitForEndOfFrame();

            count++;



        }
    }
}
