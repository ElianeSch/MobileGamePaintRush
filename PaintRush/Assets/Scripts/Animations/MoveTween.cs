using UnityEngine;

public class MoveTween : MonoBehaviour
{
    public float animationTime;
    public float delayTime;

    public iTween.EaseType easeType;
    public iTween.LoopType loopType;


    public Vector3 moveAmount;

    public bool isDestroyOnComplete;

    public void OnEnable()
    {
        iTween.MoveBy(gameObject, iTween.Hash("x", moveAmount.x, "y", moveAmount.y, "islocal", true, "time", animationTime, "looptype", loopType, "easetype", easeType, "oncomplete", "OnComplete"));
    }

    public void OnComplete()
    {
        if (isDestroyOnComplete)
            Destroy(gameObject);
    }
}
