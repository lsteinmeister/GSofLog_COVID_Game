using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> spawnList;
    public List<int> spawnCounts;
    public GameObject spawnArea;
    //public GameObject GameManager;
    
    private int spawnSum;
    // Start is called before the first frame update
    void Start()
    {
        spawnSum = 0;
        for(int i = 0; i< spawnCounts.Count;i++) 
        {
            spawnSum += spawnCounts[i];
        }
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn()
    {
        MeshCollider spwn_c = spawnArea.GetComponent<MeshCollider>();

        // Define spawn points & Instanciate
        //List<Vector3> rnd_pts;
        int spwn_count = 0;
        int unit_count = 0;
        Vector3 pos = new Vector3(0,0,0);
        for(int i = 0; i < spawnSum; i++)
        {
            bool validPos = false;
            RaycastHit hit;
             while(!validPos)
             {
                 pos = new Vector3(Random.Range(spwn_c.bounds.min.x, spwn_c.bounds.max.x),
                                    0,
                                    Random.Range(spwn_c.bounds.min.z, spwn_c.bounds.max.z));
                if (Physics.Raycast(pos + new Vector3(0,50,0), -Vector3.up, out hit, 100.0f))
                {
                    print("Found an object - distance: " + hit.distance);
                    if(hit.collider.gameObject.tag == "Floor") validPos = true;
                }
            
             }
        
            
            if(spwn_count >= spawnCounts[unit_count])
            {
                Debug.Log("Spawning next unit");
                unit_count++;
                spwn_count = 0;
            }
            Instantiate(spawnList[unit_count], pos, new Quaternion());
            spwn_count++;
        }
    }
}
