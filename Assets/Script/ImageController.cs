using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ImageController : MonoBehaviour {

    int childValue = 0;
    RectTransform imageTransform;

    private void Start()
    {
        imageTransform = GetComponent<RectTransform>();
    }

    public void ImageControll(bool sizeUp , float sizeValue)
    {
        if(!sizeUp)
        {
            sizeValue = -sizeValue;
        }
        LeanTween.value(imageTransform.sizeDelta.x, imageTransform.sizeDelta.x + sizeValue, 0.5f);
    }
}
