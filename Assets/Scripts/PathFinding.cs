using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinding : MonoBehaviour
{

    public List<TileCube> FindPath(TileCube start, TileCube end)
    {
        List<TileCube> openList = new List<TileCube>();
        List<TileCube> closedList = new List<TileCube>();

        openList.Add(start);
        while(openList.Count > 0)
        {
            TileCube currentTile = openList.OrderBy(x => x.F).First();

            openList.Remove(currentTile);
            closedList.Add(currentTile);

            if(currentTile == end)
            {
                return GetFinishedList(start, end);
            }

            var neighbourTiles = GetNeighbourTiles(currentTile);

            foreach (var neighbour in neighbourTiles)
            {
                if(neighbour.unit != null || 
                closedList.Contains(neighbour) || 
                Mathf.Abs(currentTile.gridLocation.y - neighbour.gridLocation.y) > 1)
                    {
                        continue;
                    }
                neighbour.G = GetBlockDistance(start, neighbour);
                neighbour.H = GetBlockDistance(end, neighbour);

                neighbour.previous = currentTile;

                if (!openList.Contains(neighbour))
                {
                    openList.Add(neighbour);
                }
            }
        }
        return new List<TileCube>();
    }

    private List<TileCube> GetFinishedList(TileCube start, TileCube end)
    {
        List<TileCube> finishedList = new List<TileCube>();

        TileCube currentTile = end;
        while(currentTile != start)
        {
            finishedList.Add(currentTile);
            currentTile = currentTile.previous;
        }
        finishedList.Reverse();
        return finishedList;
    }

    private int GetBlockDistance(TileCube start, TileCube neighbour)
    {
        return Mathf.Abs(start.gridLocation.x - neighbour.gridLocation.x) + Mathf.Abs(start.gridLocation.z - neighbour.gridLocation.z);
    }

    private List<TileCube> GetNeighbourTiles(TileCube currentTile)
    {
        var map = Board.instance.map; 
        List<TileCube> neighbours = new List<TileCube>();

        // TOP
        Vector2Int locationToCheck = new Vector2Int(currentTile.gridLocation.x, currentTile.gridLocation.y + 1);

        if(map.ContainsKey(locationToCheck))
        {
            neighbours.Add(map[locationToCheck]);
        }

        // BOTTOM
        locationToCheck = new Vector2Int(currentTile.gridLocation.x, currentTile.gridLocation.y - 1);

        if(map.ContainsKey(locationToCheck))
        {
            neighbours.Add(map[locationToCheck]);
        }

        // RIGHT
        locationToCheck = new Vector2Int(currentTile.gridLocation.x + 1, currentTile.gridLocation.y);

        if(map.ContainsKey(locationToCheck))
        {
            neighbours.Add(map[locationToCheck]);
        }

        // LEFT
        locationToCheck = new Vector2Int(currentTile.gridLocation.x - 1, currentTile.gridLocation.y);

        if(map.ContainsKey(locationToCheck))
        {
            neighbours.Add(map[locationToCheck]);
        }

        return neighbours;
    }
}
