﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Game Controller Object for controlling the game")]
    public GameController gameController;
    [Header("Default Velocity")]
    public float velocity = 1;
    private Rigidbody2D rb;
    private float objectHeight;
    void Start()
    {
        gameController = GetComponent<GameController>();
      Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        //objectHeight = transform.GetComponent<SpriteRenderee>
    

    }

    // Update is called once per frame
    void Update()
    {

    }
}
