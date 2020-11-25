using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level1Stats : MonoBehaviour
{
    //stats
    public TextMeshProUGUI itemCountText;
    private float itemCount;
    //private float finishTime;

    //used to display time
    private float msec;
    private float sec;
    private float min;

    void Start()
    {
        itemCount = CharacterController.numMasks;
        msec = CharacterController.msecFinal;
        sec = CharacterController.secFinal;
        min = CharacterController.minFinal;
        //finishTime = CharacterController.finalTime;
    }

    void Update()
    {
        itemCountText.text = "Item Count: " + itemCount.ToString() + "\n"
            + "Finish Time: " + string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);   
    }


}
