using System.Collections.Generic;
using UnityEngine;

public class TilesObjectPool
{
    private readonly List<GameObject>[] _tilePools;
    private readonly List<GameObject> _tilePrefabs;
    private readonly Transform _parentTransform;

    public TilesObjectPool(List<GameObject> tilePrefabs, Transform parentTransform)
    {
        _tilePrefabs = tilePrefabs;
        _parentTransform = parentTransform;
        _tilePools = new List<GameObject>[tilePrefabs.Count];

        for (int i = 0; i < _tilePools.Length; i++)
        {
            _tilePools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int tileIndex)
    {
        if (tileIndex < 0 || tileIndex >= _tilePools.Length)
        {
            Debug.LogError("Invalid tile index!");
            return null;
        }

        if (_tilePools[tileIndex].Count > 0)
        {
            GameObject tile = _tilePools[tileIndex][0];
            _tilePools[tileIndex].RemoveAt(0);
            return tile;
        }

        GameObject newTile = Object.Instantiate(_tilePrefabs[tileIndex], _parentTransform);
        var pooledTile = newTile.AddComponent<PooledTile>();
        pooledTile.TileIndex = tileIndex;

        return newTile;
    }

    public void Release(GameObject tile)
    {
        PooledTile pooledTile = tile.GetComponent<PooledTile>();
        if (pooledTile != null)
        {
            int tileIndex = pooledTile.TileIndex;
            tile.SetActive(false);
            _tilePools[tileIndex].Add(tile);
        }
        else
        {
            Debug.LogError("Tile does not have PooledTile component!");
        }
    }
}
