/*  Player Controller - Sam Caulker
 * 
 *  Desc:   Facilitates player interactions
 * 
 */

using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class CTF_PlayerController : PlayerController
{

    // for testing

    public void TurnOnInteractCollider()
    {
        go_interactCollider.SetActive(true);
    }

    public void Interact()
    {
        if (go_flagObj)
        {
            DropFlag();
        }
        else
        {
            go_interactCollider.SetActive(true);
        }
        Invoke("TurnOffInteractCollider", 0.05f);
    }


    protected override void Start()
    {}

    protected override void FixedUpdate()
    {}
}
