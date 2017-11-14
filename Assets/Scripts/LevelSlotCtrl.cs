using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlotCtrl : MonoBehaviour {

    public bool isActive;
    public int lv;

    private void Start()
    {
    }
    void Update () {
        if (isActive)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
	}

    public void ActiveButton()
    {
        isActive = true;
    }

    public void DesactiveButotn()
    {
        isActive = false;
    }
}
