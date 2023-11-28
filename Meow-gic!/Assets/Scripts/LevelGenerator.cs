using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] levelPrefabs; // Array of prebuilt level structures
    //public int numberOfStructures = 2; // Number of structures to generate
    //public float structureSpacing = 30f; // Spacing between structures
    //public float horizontalSpacing = 30f;
    //public float verticalSpacing = 18f;
    public GameObject initialPrefab;
    public int maxBranches = 3;
    public int maxBranchLength = 2;
    public GameObject bossLevel;
    void Start()
    {
        initialPrefab = levelPrefabs[Random.Range(0, levelPrefabs.Length)];
        Instantiate(initialPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, transform);
        GenerateLevel(initialPrefab.transform.position, 0);
        //GenerateLevel(initialPrefab.transform.position, 0);
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
            // Instantiate a random prefab variant at the predefined position
            GameObject randomPrefab = levelPrefabs[Random.Range(0, levelPrefabs.Length)];
            GameObject newPrefab = Instantiate(randomPrefab, offsetPositions[i], Quaternion.identity);

            // Recursively generate branches from the newly placed prefab
            GenerateLevel(offsetPositions[i], depth + 1);
        }   

        //GameObject obj = Instantiate(prefabToInstantiate, position, Quaternion.identity);

        // for (int i = 0; i < numberOfStructures; i++)
        // {
        //     // Randomly select a prebuilt level structure from the array
        //     GameObject prefabToInstantiate = levelPrefabs[Random.Range(0, levelPrefabs.Length)];

        //     // Generate random position
        //     Vector2 position = new Vector2(Random.Range(-30f, 30f), Random.Range(-30f, 30f));

        //     // Calculate random offset for placing structures around each other
        //     Vector2 offset = new Vector2(Random.Range(-structureSpacing, structureSpacing), Random.Range(-structureSpacing, structureSpacing));

        //     // Apply the offset to the position
        //     position += offset;

        //     // Instantiate the prebuilt level structure at the calculated position
        //     GameObject obj = Instantiate(prefabToInstantiate, position, Quaternion.identity);

        //     // Optional: Parent the instantiated object to a container
        //     obj.transform.parent = transform;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
