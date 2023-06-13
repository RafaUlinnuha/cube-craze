using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    float prevTime;
    float fallTime = 1f;
    
    void Start()
    {
        ButtonInputs.instance.SetActiveBlock(gameObject, this);
        fallTime = GameManager.instance.ReadFallSpeed();
        if (!CheckValidMove())
        {
            GameManager.instance.SetGameIsOver();
        }
    }

    
    void Update()
    {
        if(Time.time - prevTime > fallTime)
        {
            transform.position += Vector3.down;


            if (!CheckValidMove())
            {
                transform.position += Vector3.up;
                
                //DELETE LAYER IF POSSIBLE
                Playfield.instance.DeleteLayer();
                enabled = false;

                //CREATE A NEW TETRIS BLOCK
                if (!GameManager.instance.ReadGameIsOver())
                {
                    Playfield.instance.SpawnNewBlock();
                }                
            }
            else
            {
                //UPDATE THE GRID
                Playfield.instance.UpdateGrid(this);
            }

            prevTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetInput(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetInput(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetInput(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetInput(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SetRotationInput(new Vector3(90, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SetRotationInput(new Vector3(-90, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SetRotationInput(new Vector3(0, 90, 0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetRotationInput(new Vector3(0, -90, 0));
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetRotationInput(new Vector3(0, 0, 90));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetRotationInput(new Vector3(0, 0, -90));
        }
    }

    public void SetInput(Vector3 direction)
    {
        transform.position += direction;
        if (!CheckValidMove())
        {
            transform.position -= direction;
        }
        else
        {
            Playfield.instance.UpdateGrid(this);
        }
    }

    public void SetRotationInput(Vector3 rotation)
    {
        transform.Rotate(rotation, Space.World);
        if (!CheckValidMove())
        {
            transform.Rotate(rotation, Space.World);
        }
        else
        {
            Playfield.instance.UpdateGrid(this);
        }
    }

    bool CheckValidMove()
    {
        foreach(Transform child in transform)
        {
            Vector3 pos = Playfield.instance.Round(child.position);
            if (!Playfield.instance.CheckInsideGrid(pos))
            {
                return false;
            }
        }

        foreach (Transform child in transform)
        {
            Vector3 pos = Playfield.instance.Round(child.position);
            Transform t = Playfield.instance.GetTransformOnGridPos(pos);
            if(t!=null && t.parent != transform)
            {
                return false;
            }
        }

        return true;
    }

    public void SetSpeed()
    {
        fallTime = 0.1f;
    }
}