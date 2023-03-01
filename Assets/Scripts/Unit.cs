using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int team;
    public TileCube standingOn;
    public bool isMoving { get; set; } = false;
    public bool isChosen { get; set; } = false;

    // TODO: MAKE SPAWN METHOD TO SPAWN A UNIT
    // Start is called before the first frame update
    private void Awake()
    {
    }

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}