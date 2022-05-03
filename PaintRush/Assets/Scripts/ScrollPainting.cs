
using UnityEngine;

public class ScrollPainting : MonoBehaviour
{

    public Animator animator;

    public int indexPreview = -1;


    public void ClickButtonRight()
    {
        if (indexPreview < 3)
        {
            indexPreview += 1;
            animator.SetInteger("indexPreview", indexPreview);
        }

        else
            print("coucou");
     
    }

    public void ClickButtonLeft()
    {
        if (indexPreview > 0)
        {
            indexPreview -= 1;
            animator.SetInteger("indexPreview", indexPreview);
        }
        else
            print("non");
    }

}
