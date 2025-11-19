using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody rb;
    public int points = 0;
    public GameObject prefab;
    public GameObject currentPrefab;
    public GameObject enemy;
    private List<GameObject> currentEnemies = new List<GameObject>();
    public bool start_game = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (start_game)
        {
            currentPrefab = respown_obj(prefab, -3, 2);
            // currentEnemy = respown_obj(enemy, -3, 0);
            start_game = false;
        }
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

 void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = 0;

        if (Input.GetKey("space")) {y += 20;}
        rb.AddForce(new Vector3(x*speed, y, z*speed));
        //transform.position = transform.position + new Vector3(x*speed, 0, z*speed);
    }
        

   GameObject  respown_obj(GameObject obj, float x = 100.0f, float z = 100.0f)
    {
        float y = 0.5f;
        if (x == 100.0f && z == 100.0f)
        {
            x = Random.Range(-38.0f, 2.0f);
            z = Random.Range(-21.0f, 28.0f);
        }
        return Instantiate(obj, new Vector3(x,y,z), Quaternion.identity);
    }

    void DestroyAllEnemies()
    {
        foreach (GameObject enemyInstance in currentEnemies)
        {
            if (enemyInstance != null)
            {
                Destroy(enemyInstance);
            }
        }
        currentEnemies.Clear(); 
    } 

    void SpawnEnemiesByPoints()
    {
        int enemiesToSpawn = points; 
        
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject newEnemy = respown_obj(enemy); 
            currentEnemies.Add(newEnemy);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Collectible"){
            Destroy(collision.gameObject);
            points++;
            Debug.Log(points);
            currentPrefab = respown_obj(prefab);
            // Instantiate(prefab, new Vector3(Random.Range(-38.0f, 2.0f),0.5f,Random.Range(-21.0f, 28.0f)), Quaternion.identity);

            DestroyAllEnemies();
            SpawnEnemiesByPoints();
        }

        if(collision.gameObject.tag == "Enemy"){
            Destroy(collision.gameObject);
            points--;
            Debug.Log(points);
            // currentEnemy = respown_obj(enemy);
            if (currentPrefab != null)
            {
                Destroy(currentPrefab);
                currentPrefab = respown_obj(prefab);
            }
        }
    }
}

// +----------------------------+
// | kordinationsystem (x,z)    |  
// | (-38, -21)      (-38, 28)  |  
// | (2,   -21)      (2,   28)  |
// | x = [-38, 2]               |
// | z = [-21, 28]              |
// +----------------------------+