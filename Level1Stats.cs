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
    private float finishTime;

    void Start()
    {
        itemCount = CharacterController.numMasks;
        finishTime = CharacterController.finalTime;
    }

    void Update()
    {
        itemCountText.text = "Item Count: " + itemCount.ToString() + "\n" + finishTime.ToString();   
    }


}
