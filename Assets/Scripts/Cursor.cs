using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private TileCube tileCube;
    // Start is called before the first frame update
    void Start()
    {
        tileCube = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetFocusedTile(TileCube tileCube)
    {
        this.tileCube = tileCube;
    }
    public TileCube GetFocusedTile()
    {
        return this.tileCube;
    }
}
