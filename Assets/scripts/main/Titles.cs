using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titles : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void refresh()
    {
        foreach (Transform child in transform)
        {
            string child_name = child.name.Substring(6);
            if ((!PlayerPrefs.HasKey(child_name)) || (!(PlayerPrefs.GetInt(child_name) == 1)))
            {
                GameObject.Find(child_name).GetComponent<Renderer>().enabled = false;
            }
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        refresh();
    }
}
