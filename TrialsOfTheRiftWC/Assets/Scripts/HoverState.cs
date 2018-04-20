using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverState : MonoBehaviour, ISelectHandler, IDeselectHandler  {

    [SerializeField] private GameObject img_backing;

    public void OnSelect(BaseEventData eventData) {
        img_backing.SetActive(true);
    }
    
    public void OnDeselect(BaseEventData eventData) {
        img_backing.SetActive(false);
    }

}
