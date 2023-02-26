using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int team;
    public TileCube standingOn;
    // TODO: MAKE SPAWN METHOD TO SPAWN A UNIT
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(Vector3 position)
    {
        GameObject obj = Instantiate(gameObject, position, Quaternion.identity);
    }
}
