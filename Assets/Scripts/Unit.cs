using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int team;
    public TileCube standingOn;
    public bool isMoving {get; set;}
    // TODO: MAKE SPAWN METHOD TO SPAWN A UNIT
    // Start is called before the first frame update
    private void Awake() {
        isMoving = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
