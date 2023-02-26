using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCube : MonoBehaviour
{
    public int G;
    public int H;

    public int F {get {return G+H;}}
    public Unit unit {get; set;}
    public TileCube previous;
    public Vector3Int gridLocation;
    public Material hoverMaterial;
    public Material defaultMaterial;
    public Material clickedMaterial;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Tile");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Hover"))
        {
            gameObject.GetComponent<MeshRenderer> ().material = hoverMaterial;
        }
        if (gameObject.layer == LayerMask.NameToLayer("Tile"))
        {
            gameObject.GetComponent<MeshRenderer> ().material = defaultMaterial;
        }
        if (gameObject.layer == LayerMask.NameToLayer("Clicked"))
        {
            gameObject.GetComponent<MeshRenderer> ().material = clickedMaterial;
        }
    }
}
