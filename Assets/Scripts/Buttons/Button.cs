using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Puzzle_Door puzzleD;
    public int buttonIndex;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        puzzleD.ButttonPressed(buttonIndex);
        Debug.Log(buttonIndex);
    }
}
