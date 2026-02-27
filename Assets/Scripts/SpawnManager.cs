using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] obstaclePrefab;
    
    public PlayerController player;



    
    void Start()
    {
        
        InvokeRepeating("Spawn", 0, 2.0f);
        
    }

    void Spawn()
    {
        int obIndex = Random.Range(0, obstaclePrefab.Length);
        Debug.Log(obIndex);
        if (!player.isGameOver)
        {
            
            Instantiate(obstaclePrefab[obIndex], spawnPoint.position, obstaclePrefab[obIndex].transform.rotation);
        }

    }
}
