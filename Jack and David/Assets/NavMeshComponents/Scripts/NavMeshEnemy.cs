using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemy : MonoBehaviour
{   
    public List<GameObject> EnemyPrefabs = new List<GameObject>();

    public float SpawnRate = 5;
    private float lastSpawn = 0;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSpawn + SpawnRate < Time.fixedTime){
            GameObject enemy = Instantiate(EnemyPrefabs[0], transform.position, Quaternion.identity);
            enemy.GetComponent<NavMeshAgent>().SetDestination(Target.transform.position);
            lastSpawn = Time.fixedTime;
        }
    }
}
