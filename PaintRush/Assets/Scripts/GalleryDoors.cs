using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryDoors : MonoBehaviour
{
    public void LoadGalllery(int index)
    {
        GameManager.instance.LoadGallery(index);
    }

}
