using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {
    public GameObject gameObject;
    private float alpha = 0;
    private float time = 0;
    private bool state = false;
    public string name;

	// Use this for initialization
	void Start () {
        foreach(Transform child in transform)
        {
            hide(child);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void hide(Transform child)
    {
        child.GetComponent<Renderer>().enabled = false;
    }

    private void show(Transform child)
    {
        child.GetComponent<Renderer>().enabled = true;
    }

    public void showPics()
    {
        foreach (Transform child in transform)
        {
            show(child);
        }
        PlayerPrefs.SetInt(name, 1);
    }
}
