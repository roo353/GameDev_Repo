using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteBehavior : MonoBehaviour
{
    private SpriteRenderer rendererObj;

    private void Start()
    {
        rendererObj = GetComponent<SpriteRenderer>();
    }

    public void ChangeRendererColor (ColorID obj)
    {
        if(rendererObj != null)
            rendererObj.color = obj.value;
        else
            Debug.LogError("SpriteRenderer component not found.");
    }
}
