using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ActualWin : MonoBehaviour
{
    private PlayerController pc;
    private float timer;
    private string time;
    private string death;
    private string jump;
    public TextMeshProUGUI deathCount;
    public TextMeshProUGUI TimeCounter;
    public TextMeshProUGUI JumpCounter;
    public GameObject d1;
    public GameObject t1;
    public GameObject j1;
    public GameObject Restart;
    public GameObject Reset;
    public bool Active;
    private bool Timers;

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        Active = true;
        timer = 0;
        Timers = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Active == true)
        {
            death = " " + pc.deaths;
            deathCount.text = death;
            time = " " + timer;
            TimeCounter.text = time;
            jump = " " + pc.jumps;
            JumpCounter.text = jump;
            if (Active == true && Timers == true)
            {
                StartCoroutine(StartTimer());
                Timers = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Active = false;
            d1.gameObject.SetActive(true);
            t1.gameObject.SetActive(true);
            j1.gameObject.SetActive(true);
            Restart.gameObject.SetActive(true);
            Reset.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
       
    }
    private IEnumerator StartTimer()
    {
        timer = timer + 1;
        yield return new WaitForSeconds(1f);
        Timers = true;
    }

}
