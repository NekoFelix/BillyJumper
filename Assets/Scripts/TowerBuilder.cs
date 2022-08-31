using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _lvlCount;
    [SerializeField] private float _scaleModifier;
    [SerializeField] private float _distanceBtvPlatforms = 2f;
    [SerializeField] private Vector3 _platformOffset;
    [SerializeField] private GameObject _dick;
    [SerializeField] private GameObject _endOfDick;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private List<Platform> _platforms;
    [SerializeField] private FinishPlatform _finishPlatform;

    private void Start()
    {
        _scaleModifier = _lvlCount / 2f;
        BuildTower();
    }

    private void BuildTower()
    {
        GameObject dick = Instantiate(_dick, transform);
        dick.transform.localScale = new Vector3(1, _lvlCount / 2f, 1);
        
        Vector3 spawnPosition = dick.transform.position;
        spawnPosition.y += dick.transform.localScale.y * 2f + _platformOffset.y;
        
        SpawnPlatform(_startPlatform, ref spawnPosition, dick.transform);
        for (int i = 0; i < _lvlCount - 2; i++)
        {
            SpawnPlatform(_platforms[UnityEngine.Random.Range(0,_platforms.Count)], ref spawnPosition, dick.transform);
        }
        SpawnPlatform(_finishPlatform, ref spawnPosition, dick.transform);

        GameObject endOfDick = Instantiate(_endOfDick, transform);
        endOfDick.transform.position = spawnPosition;
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Platform pltfrm = Instantiate(platform, spawnPosition, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0), parent);
        pltfrm.transform.localScale = new Vector3(1, pltfrm.transform.localScale.y / _scaleModifier , 1);
        spawnPosition.y -= _distanceBtvPlatforms;
    }
}
