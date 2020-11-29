using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalStats : MonoBehaviour
{
    //stats
    public TextMeshProUGUI itemCountText;
    private float itemCount;
    //private float finishTime;

    //used to display time
    private float msec;
    private float sec;
    private float min;

    private float msec2;
    private float sec2;
    private float min2;

    private float finalTime1;
    private float finalTime2;
    private float totalTime;

    private float msecTotal;
    private float secTotal;
    private float minTotal;

    void Start()
    {
        itemCount = CharacterController.numMasks;
        msec = CharacterController.msecFinal;
        sec = CharacterController.secFinal;
        min = CharacterController.minFinal;
        //finishTime = CharacterController.finalTime;

        msec2 = CharacterController.msecFinal2;
        sec2 = CharacterController.secFinal2;
        min2 = CharacterController.minFinal2;

        finalTime1 = CharacterController.finalTime;
        finalTime2 = CharacterController.finalTime2;
    }

    void Update()
    {
        calcTotalTime();

        itemCountText.text = "Item Count: " + itemCount.ToString() + "\n"
            + "Level 1 Finish Time: " + string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec) + "\n"
            + "Level 2 Finish Time: " + string.Format("{0:00}:{1:00}:{2:00}", min2, sec2, msec2) + "\n"
            + "Total Finish Time: " + string.Format("{0:00}:{1:00}:{2:00}", minTotal, secTotal, msecTotal);
    }

    void calcTotalTime()
    {
        totalTime = finalTime1 + finalTime2;

        msecTotal = (int)((totalTime - (int)totalTime) * 100);
        secTotal = (int)(totalTime % 60);
        minTotal = (int)(totalTime / 60 % 60);

    }
}
