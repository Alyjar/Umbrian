using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public int weightCount;
    public bool puzzleOneComplete;
    public bool tilePuzzleComplete;
    public GameObject crystalOne;
    public GameObject crystalTwo;

    // Update is called once per frame
    void Update()
    {
        if (puzzleOneComplete)
        {
            crystalOne.SetActive(false);
        }

        if (crystalTwo.activeSelf)
        {
            if (weightCount == 6)
            {
                crystalTwo.SetActive(false);
                Debug.Log("Crystal 2 Done");
            }
        }

        if(!crystalTwo.activeSelf && puzzleOneComplete && tilePuzzleComplete)
        {
            Debug.Log("Door Open!");
        }
    }
}
