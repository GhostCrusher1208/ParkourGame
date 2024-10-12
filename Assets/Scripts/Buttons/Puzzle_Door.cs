using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Door : MonoBehaviour
{
    private MeshRenderer r;
    public GameObject Door;
    public int[] correctSequence;

    private int currentIndex = 0;

    public void ButttonPressed(int buttonIndex)
    {
        if (correctSequence[currentIndex] == buttonIndex)
        {
            currentIndex++;


            if(currentIndex == correctSequence.Length)
            {
                OpenDoor();
                Reset();
                
            }
        }
        else
        {
            Reset();
        }
    }

     void OpenDoor()
    {
        r=Door.gameObject.GetComponent<MeshRenderer>();
        r.enabled = true;
    }

    void Reset()
    {
        currentIndex = 0;
        Debug.Log("Sýralama sýfýrlandý");
    }
}
