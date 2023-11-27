using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] levelPrefabs; // Array of prebuilt level structures
    public int numberOfStructures = 10; // Number of structures to generate
    public float structureSpacing = 30f; // Spacing between structures
    // Start is called before the first frame update
    public GameObject initialPrefab;
    void Start()
    {
        initialPrefab = levelPrefabs[Random.Range(0, levelPrefabs.Length)];
        GenerateLevel();
    }

    void GenerateLevel(){

        Instantiate(initialPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, transform);

        for (int i = 0; i < numberOfStructures; i++)
        {
            // Randomly select a prebuilt level structure from the array
            GameObject prefabToInstantiate = levelPrefabs[Random.Range(0, levelPrefabs.Length)];

            // Generate random position
            Vector2 position = new Vector2(Random.Range(-30f, 30f), Random.Range(-30f, 30f));

            // Calculate random offset for placing structures around each other
            Vector2 offset = new Vector2(Random.Range(-structureSpacing, structureSpacing), Random.Range(-structureSpacing, structureSpacing));

            // Apply the offset to the position
            position += offset;

            // Instantiate the prebuilt level structure at the calculated position
            GameObject obj = Instantiate(prefabToInstantiate, position, Quaternion.identity);

            // Optional: Parent the instantiated object to a container
            obj.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
