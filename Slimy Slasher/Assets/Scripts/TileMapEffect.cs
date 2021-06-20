using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapEffect : MonoBehaviour
{
    public GameObject player;
    Tilemap tilemap;
    Vector3 cellPosition;

    void Start()
    {
        player = GameObject.Find("Player");
        tilemap = GetComponent<Tilemap>();
        cellPosition = tilemap.GetCellCenterWorld(Vector3Int.FloorToInt(transform.position));
    }

    void Update()
    {

        if (Vector3.Distance(player.transform.position, cellPosition) >= 6.5)
        {
            tilemap.SetColor(Vector3Int.FloorToInt(cellPosition), new Color(1f, 1f, 1f, 0f));
        }
        else
        {
            tilemap.SetColor(Vector3Int.FloorToInt(cellPosition), new Color(1f, 1f, 1f, 1f));
        }
    }
}
