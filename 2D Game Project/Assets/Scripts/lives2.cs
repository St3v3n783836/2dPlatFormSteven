using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lives2 : MonoBehaviour
{
    private PlayerController pc;
    public GameObject bruh;
    public TextMeshProUGUI lives1;
    public string liveCount1;
    public int words;
    private bool wordsDone;
    public float globalLives;

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        globalLives = 3;
        wordsDone = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.Sanity == 0)
        {
            if (pc.Lives > -1)
            {
                liveCount1 = " " + pc.Lives;
                lives1.text = liveCount1;
            }
            else
            {
                if (pc.Lives < 0)
                {
                    lives1.text = "0";
                }

            }
        }
    }

}
