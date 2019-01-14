using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour,IPointerClickHandler {
    public GameObject gameObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        string scene_name = this.name.Substring(7) + "Scene";
        SceneManager.LoadScene(scene_name);
    }
}
