using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] levelPrefabs; // Array of prebuilt level structures
    private List<GameObject> instantiatedPrefabs = new List<GameObject>();
    public int rows = 3; // Number of rows in the level
    public int columns = 4; // Number of columns in the level
    public float horizontalSpacing = 40f; // Horizontal spacing between prefabs
    public float verticalSpacing = 23f; 
    public GameObject initalRoom;
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
                if (row == rows - 1 && col == columns - 1)
                {
                    // Instantiate a specific prefab for the top-right spot
                    float xPos = col * horizontalSpacing;
                    float yPos = row * verticalSpacing;
                    GameObject obj = Instantiate(bossLevel, new Vector3(xPos, yPos, 0f), Quaternion.identity);
                    
                }
                if(row == 0 && col == 0){
                    float xPos = col * horizontalSpacing;
                    float yPos = row * verticalSpacing;
                    GameObject obj = Instantiate(initalRoom, new Vector3(xPos, yPos, 0f), Quaternion.identity);

                    Tilemap doorLeft = obj.transform.GetChild(4).GetComponent<Tilemap>();
                    Tilemap doorBottom = obj.transform.GetChild(6).GetComponent<Tilemap>();

                    doorLeft.GetComponent<TilemapRenderer>().enabled=false;
                    doorLeft.GetComponent<TilemapCollider2D>().enabled=false;

                    doorBottom.GetComponent<TilemapRenderer>().enabled=false;
                    doorBottom.GetComponent<TilemapCollider2D>().enabled=false;
                }
                else {
                    // Randomly choose a prefab from the array
                    GameObject prefab = levelPrefabs[Random.Range(0, levelPrefabs.Length)];

                    // Calculate position based on row and column
                    float xPos = col * horizontalSpacing;
                    float yPos = row * verticalSpacing;

                    // Instantiate the prefab at the calculated position
                    GameObject obj = Instantiate(prefab, new Vector3(xPos, yPos, 0f), Quaternion.identity);

                    Tilemap doorTop = obj.transform.GetChild(3).GetComponent<Tilemap>();
                    Tilemap doorLeft = obj.transform.GetChild(4).GetComponent<Tilemap>();
                    Tilemap doorRight = obj.transform.GetChild(5).GetComponent<Tilemap>();
                    Tilemap doorBottom = obj.transform.GetChild(6).GetComponent<Tilemap>();

                    if(row == 0){
                        doorBottom.GetComponent<TilemapRenderer>().enabled=false;
                        doorBottom.GetComponent<TilemapCollider2D>().enabled=false;
                    }
                    if(row == rows - 1){
                        doorTop.GetComponent<TilemapRenderer>().enabled=false;
                        doorTop.GetComponent<TilemapCollider2D>().enabled=false;
                    }
                    if(col == 0){
                        doorLeft.GetComponent<TilemapRenderer>().enabled=false;
                        doorLeft.GetComponent<TilemapCollider2D>().enabled=false;
                    }
                    if(col == columns - 1){
                        doorRight.GetComponent<TilemapRenderer>().enabled=false;
                        doorRight.GetComponent<TilemapCollider2D>().enabled=false;
                    }
                
                    // Make sure the instantiated object is in the same Z-plane as the Level Generator
                    obj.transform.SetParent(transform);

                    instantiatedPrefabs.Add(obj);
                } 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
