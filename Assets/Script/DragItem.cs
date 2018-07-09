using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour , IDragHandler, IBeginDragHandler, IEndDragHandler
{

    private Image image;
    private Vector3 boxpos;
    public static GameObject boxitem;


    [SerializeField]
    BoxCollider2D boxcol;

	// Use this for initialization
	void Start () {
        image = gameObject.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnDrag(PointerEventData eventData)
    {
#if UNITY_ANDROID
        if (Input.touchCount > 1)
            return;
#endif
        transform.position = eventData.position;
        //boxrect.position = new Vector3(eventData.position.x, eventData.position.y,0);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
#if UNITY_ANDROID
        if (Input.touchCount > 1)
            return;
#endif
        boxitem = gameObject;
        boxpos = transform.position;
        image.color = Color.green;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        image.color = Color.white;
        transform.position = boxpos;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
