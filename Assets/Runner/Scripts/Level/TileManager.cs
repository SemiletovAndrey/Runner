using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class TileManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tilePrefabs;
    [SerializeField] private List<GameObject> _activeTiles = new List<GameObject>();
    [SerializeField] private float _zSpawn = 0;
    [SerializeField] private float _lengthTile = 10;
    [SerializeField] private float _numberOfTiles = 10;
    [SerializeField] private float _timeforSpawnObstacleTiles = 10;
    [SerializeField] private Transform _parentTransform;

    private float _timeRunSafeObstacle = 5f;
    private float _distanceForDeleteTile = 20f;

    private int _initialCountTile = 3;

    private TilesObjectPool _poolTiles;

    [Inject(Id = "PlayerTransform")] private Transform _playerTransform;

    private void Start()
    {
        _poolTiles = new TilesObjectPool(_tilePrefabs, _parentTransform);
        SpawnSafeTiles();

        for (int i = 0; i < _numberOfTiles; i++)
        {
            SpawnTile(Random.Range(0, _tilePrefabs.Count));
        }
    }

    private void Update()
    {
        if (_playerTransform.position.z - _distanceForDeleteTile > _zSpawn - (_numberOfTiles * _lengthTile))
        {
            SpawnTile(Random.Range(0, _tilePrefabs.Count));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject tile = _poolTiles.Get(tileIndex);

        tile.transform.position = new Vector3(0, 0, _zSpawn);
        _zSpawn += _lengthTile;

        tile.SetActive(true);
        _activeTiles.Add(tile);
    }

    private void SpawnSafeTiles()
    {
        int countSafeTile = (int)(_timeforSpawnObstacleTiles / _timeRunSafeObstacle);
        for (int i = 0; i < countSafeTile; i++)
        {
            SpawnTile(0);
        }
    }

    private void DeleteTile()
    {
        _poolTiles.Release(_activeTiles[0]);
        _activeTiles.RemoveAt(0);
    }
}
