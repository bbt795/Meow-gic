using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] levelPrefabs; // Array of prebuilt level structures
    public int rows = 5; // Number of rows in the level
    public int columns = 5; // Number of columns in the level
    public float horizontalSpacing = 32f; // Horizontal spacing between prefabs
    public float verticalSpacing = 23f; 
    public GameObject bossLevel;
    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel(){
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Randomly choose a prefab from the array
                GameObject prefab = levelPrefabs[Random.Range(0, levelPrefabs.Length)];

                // Calculate position based on row and column
                float xPos = col * horizontalSpacing;
                float yPos = row * verticalSpacing;

                // Instantiate the prefab at the calculated position
                GameObject obj = Instantiate(prefab, new Vector3(xPos, yPos, 0f), Quaternion.identity);
                
                // Make sure the instantiated object is in the same Z-plane as the Level Generator
                obj.transform.SetParent(transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
