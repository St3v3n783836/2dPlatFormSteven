using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float Cherrynum;
    public GameObject Cherry;
    public float WinCherrynum;
    public GameObject WinCherry;
    private PlayerController pc;
    private GhostScript gs;
    public GameObject Ghost;
    public bool deads1;

    // Start is called before the first frame update
    void Start()
    {
        Cherrynum = 1;
        WinCherrynum = 1;
        pc = FindObjectOfType<PlayerController>();
        Instantiate(Cherry, GenerateSpawnPosition(), Cherry.transform.rotation);
        Instantiate(WinCherry, new Vector2(754, 198), Cherry.transform.rotation);
        gs = FindObjectOfType<GhostScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.deads == true)
        {
            Restart();
        }
    }
    Vector2 GenerateSpawnPosition()
    {
        if (pc.CheckPoint == 1)
        {
            return new Vector2(67.29f, 3.88f);
        }
        if (pc.CheckPoint == 2)
        {
            return new Vector2(145.6f, 0.3f);
        }
        if (pc.CheckPoint == 3)
        {
            return new Vector2(267.6f, 1.58f);
        }
        if (pc.CheckPoint == 4)
        {
            return new Vector2(500.5f, 15.3f);
        }
        else
        {
            return new Vector2(67.29f, 3.88f);
        }
    }

    public void Restart()
    {
        if (Cherrynum < 1)
        {
            Cherrynum = 1;
            Instantiate(Cherry, GenerateSpawnPosition(), Cherry.transform.rotation);
        }
        if (WinCherrynum < 1)
        {
            WinCherrynum = 1;
            Instantiate(WinCherry, new Vector2(754, 198), Cherry.transform.rotation);
        }
        StartCoroutine(deads2());
        
    }
    private IEnumerator deads2()
    { if (pc.deads == true)
        {
            if (pc.Sanity > 0)
            {
                deads1 = true;
            }
            yield return new WaitForSeconds(0.001f);
            Instantiate(Ghost, new Vector2(2.9f, 0.74f), Ghost.transform.rotation);
            pc.deads = false;
        }
    }
}
