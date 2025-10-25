using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using TMPro;

public class TorchBeforeEnter : MonoBehaviour
{
    public bool HasTorch; //Detects whether or not the character has visited Grandpa
    [SerializeField] BoxCollider entrance;
    void Start()
    {
        HasTorch = false;
    }
    void Update()
    {
        if (HasTorch)
        {
            entrance.enabled = false; //Disables the collider blocking the way into the deeper caves
            //Player can now enter
        }
    }
}
