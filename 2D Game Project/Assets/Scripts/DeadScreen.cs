using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadScreen : MonoBehaviour
{
    public Transform Light;
    public GameObject Light1;
    public GameObject button;
    public bool lightDone = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dead1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator dead1()
    {
        Light1.gameObject.SetActive(true);
        lightDone = false;
        Vector3 local = Light.transform.localScale;
        Light.transform.localScale = new Vector3(20.51f, 15, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(19.01f, 15, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(18.01f, 15, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(17.01f, 15, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(16.01f, 15, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(15.01f, 15, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(14.1f, 15, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(13.01f, 15, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(12.51f, 15, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(11.01f, 15, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(10.51f, 15, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(9.01f, 15, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(7.51f, 15, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(6.01f, 15, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(5.51f, 15, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(4.01f, 15, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(3.01f, 15, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(2.01f, 15, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(1.01f, 15, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(0.01f, 15, 0);
        yield return new WaitForSeconds(0.05f);
        button.gameObject.SetActive(true);
        Light1.gameObject.SetActive(false);
        lightDone = true;
    }
}
