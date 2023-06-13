using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInputs : MonoBehaviour
{
    public static ButtonInputs instance;

    GameObject activeBlock;
    TetrisBlock activeTetris;

    void Awake()
    {
        instance = this;
    }

    public void SetActiveBlock(GameObject block, TetrisBlock tetris)
    {
        activeBlock = block;
        activeTetris = tetris;
    }

    public void SetHighSpeed()
    {
        activeTetris.SetSpeed();
    }
}
