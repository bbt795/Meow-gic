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
    public float horizontalSpacing = 32f; // Horizontal spacing between prefabs
    public float verticalSpacing = 23f; 
    public GameObject bossLevel;
    void Start()
    {
        GenerateLevel();
        //UpdateDoorsAfterPrefabInstantiation();
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

                    Tilemap doorTop = obj.transform.GetChild(3).GetComponent<Tilemap>();
                    Tilemap doorRight = obj.transform.Find("DoorRight").GetComponent<Tilemap>();

                    // doorTop.GetComponent<TilemapRenderer>().enabled=false;
                    // doorRight.GetComponent<TilemapRenderer>().enabled=false;

                    //doorTop.GetComponent<TilemapCollider2D>().enabled=false;
                    //doorRight.GetComponent<TilemapCollider2D>().enabled=false;
                    
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
                    }
                    if(row == rows - 1){
                        doorTop.GetComponent<TilemapRenderer>().enabled=false;
                    }
                    if(col == 0){
                        doorLeft.GetComponent<TilemapRenderer>().enabled=false;
                    }
                    if(col == columns - 1){
                        doorBottom.GetComponent<TilemapRenderer>().enabled=false;
                    }
                
                    // Make sure the instantiated object is in the same Z-plane as the Level Generator
                    obj.transform.SetParent(transform);

                    instantiatedPrefabs.Add(obj);
                } 
            }
        }
    }

    void UpdateDoorsAfterPrefabInstantiation()
    {
        foreach (GameObject prefab in instantiatedPrefabs)
        {
            // Get the position of the prefab in the array
            int prefabRow = Mathf.RoundToInt(prefab.transform.position.y / verticalSpacing);
            int prefabCol = Mathf.RoundToInt(prefab.transform.position.x / horizontalSpacing);

            // Check for adjacent prefabs and hide corresponding doors
            CheckAndHideDoors(prefabRow, prefabCol, prefab);
        }
    }

    void CheckAndHideDoors(int row, int col, GameObject prefab)
    {
        if (col > 0)
        {
            Vector2 rayOrigin = new Vector2((col - 1) * horizontalSpacing, row * verticalSpacing);

            // Cast a ray to the left
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.left, horizontalSpacing);

            if (hit.collider == null)
            {
                // No object to the left, hide the left door
                HideDoor(prefab, 4);
            }
        }

        // Check right
        if (col < columns - 1)
        {
            Vector2 rayOrigin = new Vector2((col + 1) * horizontalSpacing, row * verticalSpacing);

            // Cast a ray to the right
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right, horizontalSpacing);

            if (hit.collider == null)
            {
                // No object to the right, hide the right door
                HideDoor(prefab, 5);
            }
        }

        // Check below
        if (row > 0)
        {
            Vector2 rayOrigin = new Vector2(col * horizontalSpacing, (row - 1) * verticalSpacing);

            // Cast a ray downwards
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, verticalSpacing);

            if (hit.collider == null)
            {
                // No object below, hide the bottom door
                HideDoor(prefab, 6);
            }
        }

        // Check above
        if (row < rows - 1)
        {
            Vector2 rayOrigin = new Vector2(col * horizontalSpacing, (row + 1) * verticalSpacing);

            // Cast a ray upwards
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, verticalSpacing);

            if (hit.collider == null)
            {
                // No object above, hide the top door
                HideDoor(prefab, 3);
            }
        }
    }

    void HideDoor(GameObject prefab, int num){
        Tilemap door = prefab.transform.GetChild(num).GetComponent<Tilemap>();
        door.GetComponent<TilemapRenderer>().enabled=false;
        door.GetComponent<TilemapCollider2D>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
