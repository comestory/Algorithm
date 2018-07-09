using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour , IDropHandler{

    public GameManager gameMgr;
    GameObject playerbox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnDrop(PointerEventData eventData)
    {
        playerbox = Instantiate(DragItem.boxitem);
        playerbox.transform.SetParent(transform);
        gameMgr.AddMotion(playerbox.GetComponent<buttonState>().state);
        playerbox.transform.localScale = Vector3.one;
        Image image = gameObject.GetComponent<Image>();
        image.color = Color.white;
        //testmode 이미지가 없어서 임시로
        if (playerbox.GetComponent<buttonState>().state == buttonstatus.roop)
        {
            playerbox.transform.localScale = Vector3.one *0.3f;
        }
        
    }
}