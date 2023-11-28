using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] levelPrefabs; // Array of prebuilt level structures
    public GameObject initialPrefab;
    public int maxBranches = 3;
    public int maxBranchLength = 2;
    public GameObject bossLevel;
    void Start()
    {
        initialPrefab = levelPrefabs[Random.Range(0, levelPrefabs.Length)];
        Instantiate(initialPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, transform);
        GenerateLevel(initialPrefab.transform.position, 0);
    }

    void GenerateLevel(Vector2 position, int depth){

        if (depth >= maxBranchLength)
        {
            return;
        }

        Vector2[] offsetPositions = new Vector2[]
        {
            position + new Vector2(35f, 0f), //Right
            position + new Vector2(-35f, 0f), //Left
            position + new Vector2(0f, 23f), //Up
            position + new Vector2(0f, -23f) //Down
        };   

        for (int i = 0; i < Mathf.Min(maxBranches, offsetPositions.Length); i++)
        {
            bool collisionDetected = Physics2D.OverlapCircle(offsetPositions[i], 0.1f);

            if(!collisionDetected){
                // Instantiate a random prefab variant at the predefined position
                int randSet = Random.Range(0, 4);
                GameObject randomPrefab = levelPrefabs[Random.Range(0, levelPrefabs.Length)];
                GameObject newPrefab = Instantiate(randomPrefab, offsetPositions[i], Quaternion.identity);

                // Recursively generate branches from the newly placed prefab
                GenerateLevel(offsetPositions[i], depth + 1);
            }
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
