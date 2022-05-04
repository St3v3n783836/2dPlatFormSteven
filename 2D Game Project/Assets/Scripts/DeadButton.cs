using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadButton : MonoBehaviour
{
    private Button button;
    private float press;

    // Start is called before the first frame update
    void Start()
    {
    //this.SetActive(false);
    button = GetComponent<Button>();
    button.onClick.AddListener(Awake);
        
}

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {

        if (press > 1)
        {
            SceneManager.LoadScene(0);
            Debug.Log("bruh");
        }
        else
        {
            press = press + 3;
        }


    }
}
