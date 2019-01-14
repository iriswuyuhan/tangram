using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour {
    public GameObject gameObject;
    private float destination_y = 0;
    private bool over = false;
    private int wait = 50;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!over) {
            float current = this.transform.localPosition.y;
            if (current -destination_y>0) {
                over = true;
            }
            else
            {
                Vector3 vector = new Vector3(0, current + 0.1f, 0);
                this.transform.localPosition = vector;
            }
        }
        else
        {
            if (--wait == 0)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
        
	}
}
