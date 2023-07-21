using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerLogic : MonoBehaviour
{
    public static GameManagerLogic gameManager;

    public int TotalitemCount;
    public int stage;
    public int life;

    public TMP_Text stageTotalCountText;
    public TMP_Text PlayerCountText;
    public TMP_Text stageText;
    public TMP_Text lifeText;

    void Awake()
    {
       
        stageTotalCountText.text = TotalitemCount.ToString();
        stageText.text = stage.ToString();
        gameManager = GetComponent<GameManagerLogic>();
        lifeText.text = life.ToString();
    }

    public void GetItem(int count)
    {
        PlayerCountText.text = count.ToString();
    }

    public void LifeDown()
    {
        --life;
        lifeText.text = life.ToString();


    }

}
