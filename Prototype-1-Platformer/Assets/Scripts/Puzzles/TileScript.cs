using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public TilePuzzleCheck tilePuzzleCheck;
    public int targetRotations;
    public bool solved;
    private int currentRotations = 0;

    public void RotateTile()
    {
        this.transform.Rotate(0, 0, 90);
        currentRotations += 1;
        Debug.Log("Rotating!");

        if (currentRotations == 4)
        {
            currentRotations = 0;
        }

        if (currentRotations == targetRotations)
        {
            solved = true;
            Debug.Log("Tile correct.");
            tilePuzzleCheck.CheckComplete();
        }
        else
        {
            solved = false;
            Debug.Log("Tile incorrect.");
        }
    }
}
