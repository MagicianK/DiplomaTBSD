using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlacementSystem : MonoBehaviour
{

    public static PlacementSystem current;

    public MouseController mouseController;
    public GridLayout gridLayout;
    private Grid grid;
    [SerializeField] private Tilemap MainTilemap;
  //  [SerializeField] private TileBase whiteTile;

    public GameObject prefab1;
    public GameObject prefab2;

    private PlaceableObject objectToPlace;
    private Unit unit;
    #region Unity methods

    private void Awake() {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    } 

    private void Update() {
        if(Input.GetKeyDown(KeyCode.A)){
            GameObject tile = mouseController.currentHover;
            Debug.Log("Current Hover: ", tile);
            if(tile != null && tile.layer == LayerMask.NameToLayer("Hover"))
            {
                Debug.Log(" Hover: ", tile);
                Vector3 newpos = new Vector3(tile.transform.position.x, tile.transform.position.y + 1.5f,tile.transform.position.z);
                // TODO: INSTEAD OF CALLING INSTANTIATE WE SHALL CALL SPAWN METHOD OF UNIT CLASS 
                
                GameObject obj = Instantiate(prefab1, newpos, Quaternion.identity);
               // tile.GetComponent<UnitableObject>().unit = obj;
            }
        }
    }
    #endregion

    // #region Utils

    // public static Vector3 GetMouseWorldPosition()
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     if (Physics.Raycast(ray, out RaycastHit raycastHit))
    //     {
    //         return raycastHit.point;
    //     }
    //     else
    //     {
    //         return Vector3.zero;
    //     }
    // }

    // public Vector3 SnapCoordinateToGrid(Vector3 position)
    // {
    //     Vector3Int cellPos = gridLayout.WorldToCell(position);
    //     Debug.Log("position: " + position + " cellPoss: " + cellPos);
    //     position = grid.GetCellCenterWorld(cellPos);
    //     return position;
    // }

    // #endregion

    // #region Placing Placement
    // public void InitializeWithObject(GameObject prefab)
    // {
    //     Vector3 position = SnapCoordinateToGrid(Vector3.zero);
    //     Debug.Log("fdslj " + Vector3.zero);
    //     GameObject obj = Instantiate(prefab, position, Quaternion.identity);
    //     objectToPlace = obj.GetComponent<PlaceableObject>();
    //    // obj.AddComponent<DragObject>();
    // }

    // #endregion
}
