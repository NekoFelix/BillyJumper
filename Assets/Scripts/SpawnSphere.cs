using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSphere : MonoBehaviour
{
    [SerializeField] private GameObject _spherePrefab;

    private void Awake()
    {
        Instantiate(_spherePrefab, transform.position, Quaternion.identity);
    }
}
