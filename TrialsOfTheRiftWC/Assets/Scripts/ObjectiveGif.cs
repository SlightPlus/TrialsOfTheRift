using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveGif : MonoBehaviour {

    [SerializeField] Image im_image;
    [SerializeField] Sprite[] spr_sprites;
    private float f_startTime;
    private float changeInterval = 0.33f;

    void Update() {
        Debug.Log(f_startTime);
        Debug.Log(Time.realtimeSinceStartup);
        int index = Mathf.FloorToInt((Time.realtimeSinceStartup - f_startTime) / changeInterval);
        Debug.Log(index);
        index = index % spr_sprites.Length;
        im_image.sprite = spr_sprites[index];
    }

    void OnEnable() {
        f_startTime = Time.realtimeSinceStartup;
    }
}
