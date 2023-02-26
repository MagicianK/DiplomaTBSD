using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float speed;
    // public GameObject cursor;
    public GameObject currentHover {get; private set; } 
    public GameObject currentClicked {get; private set; } 
    private PathFinding pathfinder;
    
    [SerializeField] private Unit unitPrefab;
    private Unit unit;
    private List<TileCube> path = new List<TileCube>();
    // Start is called before the first frame update
    void Start()
    {
        currentHover = null;
        currentClicked = null;
        pathfinder = new PathFinding();
    }
    void LateUpdate() {
        var focusedTileHit = GetFocusedTile();

        if (focusedTileHit.HasValue)
        {
            TileCube tileCube = focusedTileHit.Value.collider.gameObject.GetComponent<TileCube>();
            GameObject tileObj = focusedTileHit.Value.collider.gameObject;
            // cursor.transform.position = tileCube.transform.position;
            // cursor.gameObject.GetComponent<MeshRenderer>().sortingOrder = tileCube.GetComponent<MeshRenderer>().sortingOrder;

            if(Input.GetMouseButton(0))
            {
                tileObj.layer = LayerMask.NameToLayer("Clicked");
                
                if(unit == null)
                {
                    unit = Instantiate(unitPrefab).GetComponent<Unit>();
                    PositionCharacterOnTile(tileCube);
                }
                else
                {
                    path = pathfinder.FindPath(unit.standingOn, tileCube);

                }
            }
        }  
        if (path.Count > 0)
        {
            MoveAlongPath();
        }
    }

    private void MoveAlongPath()
    {
        var step = speed * Time.deltaTime;
        
        var yIndex = path[0].transform.position.y;

        unit.transform.position = Vector2.MoveTowards(unit.transform.position, path[0].transform.position, step);
        unit.transform.position = new Vector3(unit.transform.position.x, yIndex, unit.transform.position.z);

        if(Vector2.Distance(unit.transform.position, path[0].transform.position) < 0.00001f)
        {
            PositionCharacterOnTile(path[0]);
            path.RemoveAt(0);
        }
    }

    private void PositionCharacterOnTile(TileCube tile)
    {
        unit.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y + 1.5f, tile.transform.position.z+0.0001f);
        unit.GetComponent<MeshRenderer>().sortingOrder = tile.GetComponent<MeshRenderer>().sortingOrder;
        unit.standingOn = tile;
    }
    // Update is called once per frame
    void Update()
    {   
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Tile")))
        {
            if (currentHover == null)
            {
                currentHover = hit.collider.gameObject;
                hit.collider.gameObject.layer = LayerMask.NameToLayer("Hover");
            }
            if (currentHover != hit.collider.gameObject)
            {
                currentHover.layer = LayerMask.NameToLayer("Tile");
                currentHover = hit.collider.gameObject;
                hit.collider.gameObject.layer = LayerMask.NameToLayer("Hover");
            }
            
        }
        else
        {
            if (currentHover != null && currentHover.layer == LayerMask.NameToLayer("Hover"))
            {
                currentHover.layer = LayerMask.NameToLayer("Tile");
                currentHover = null;
            }
        }
    }
    public RaycastHit? GetFocusedTile()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Hover")))
        {
            return hit;
        }
        return null;
    }
}
    

