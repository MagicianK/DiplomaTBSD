using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    private static Board _instance;
    public static Board instance {get {return _instance;}}
    private Camera currentCamera;
    public TileCube tileCubePrefab;
    public GameObject groundTilesContainer;
    //[SerializeField] private Tilemap tilemap;
    private Vector2Int currentHover;
    public Dictionary<Vector2Int, TileCube> map;
    private void Awake() {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    void Start()
    {
        map = new Dictionary<Vector2Int, TileCube>();
        var tileMap = gameObject.GetComponentInChildren<Tilemap>();
        BoundsInt bounds = tileMap.cellBounds;
        Debug.Log(bounds);
        for(int y = bounds.max.y; y > bounds.min.y; y--)
        {
            for (int z = bounds.min.z; z < bounds.max.z; z++)
            {
                for (int x = bounds.min.x; x < bounds.max.x; x++)
                {
                    var tileLocation = new Vector3Int(x, y, z);
                    var tilePosition = new Vector2Int(x, y);
                    if (tileMap.HasTile(tileLocation) && !map.ContainsKey(tilePosition))
                    {
                        var tileCube = Instantiate(tileCubePrefab, groundTilesContainer.transform);
                        var cellWorldPosition = tileMap.GetCellCenterWorld(tileLocation);

                        tileCube.transform.position = new Vector3(cellWorldPosition.x, cellWorldPosition.y, cellWorldPosition.z);
                        tileCube.GetComponent<MeshRenderer>().sortingOrder = tileMap.GetComponent<TilemapRenderer>().sortingOrder;
                        tileCube.gridLocation = tileLocation;
                        map.Add(tilePosition, tileCube);
                    }
                }
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(!currentCamera)
        {
            currentCamera = Camera.current;
            return;
        }
    }

}
