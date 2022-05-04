using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    private Button button;
    private PlayerController2 playerController;
    public int ready = 1;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Awake);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Awake()
    {
        playerController = GameObject.Find("Guy").GetComponent<PlayerController2>();
        playerController.good = 1;
    }
}
