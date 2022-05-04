using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinButton1 : MonoBehaviour
{
    private Button button;
    private ActualWin win;
    private bool good;
    private float press;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Awake);
        win = GetComponent<ActualWin>();
}

    // Update is called once per frame
    void Update()
    {
        good = win.Active;
    }
    public void Awake()
    {
        if(press > 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            press = press + 3;
        }
    }
}
