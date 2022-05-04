using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lives : MonoBehaviour
{
    private PlayerController2 pc2;
    public GameObject bruh;
    public TextMeshProUGUI lives1;
    public string liveCount1;


    public float globalLives;
    // Start is called before the first frame update
    void Start()
    {
        pc2 = FindObjectOfType<PlayerController2>();
        bruh.SetActive(false);
        globalLives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (pc2.good == 1)
        {
            bruh.SetActive(true);
        }
        liveCount1 = " " + pc2.Lives;
        lives1.text = liveCount1;
    }
}
