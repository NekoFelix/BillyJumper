using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltBuilder : MonoBehaviour
{
    private float _boltHeight = 5f;
    [SerializeField] private int _boltCount = 1;
    [SerializeField] private GameObject _bolt;
    [SerializeField] private GameObject _endOfBolt;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Vector3 _boltOffset;
    [SerializeField] private Vector3 _platformOffset;
    private Vector3 _boltPosition;

    private void Start()
    {
        BuildBolt();
    }

    

    private void BuildBolt()
    {
        Vector3 _toBuildPosition = new Vector3(0, _boltHeight, 0);
        _boltPosition = transform.position;
        //SpawnFinishPlatform(_finishPlatform, _boltPosition);
        GameObject endOfBolt = Instantiate(_endOfBolt, _boltPosition - _boltOffset, Quaternion.identity);
        for (int i = 0; i < _boltCount; i++)
        {
            GameObject bolt = Instantiate(_bolt, _boltPosition + _boltOffset, Quaternion.identity);
            SpawnPlatform(_platforms[UnityEngine.Random.Range(0,_platforms.Length)], _boltPosition);
            _boltPosition += _toBuildPosition;
        }
        
    }

    private void SpawnFinishPlatform(FinishPlatform finishPlatform, Vector3 spawnPosition)
    {
        Instantiate(finishPlatform, spawnPosition, Quaternion.identity);
    }

    private void SpawnPlatform(Platform platform, Vector3 spawnPosition)
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(platform, spawnPosition + _platformOffset, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0));
            spawnPosition += new Vector3(0, 1.66f, 0);
        }
    }
}
