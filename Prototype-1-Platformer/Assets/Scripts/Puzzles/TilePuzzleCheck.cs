using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePuzzleCheck : MonoBehaviour
{
    public GameObject[] tiles = new GameObject[14];
    public DoorManager doorManager;

    //Iterates through each tile in the puzzle to check if it's correct
    public void CheckComplete()
    {
        int solvedTiles = 0;

        for (int i = 0; i < 14; i++)
        {
            if (tiles[i].gameObject.GetComponent<TileScript>().solved == false)
            {
                Debug.Log("Puzzle incorrect.");
                return;
            }
            else
            {
                solvedTiles += 1;
            }

            if (solvedTiles == 14)
            {
                doorManager.tilePuzzleComplete = true;
                Debug.Log("Puzzle solved!");
            }
        }
    }
}
