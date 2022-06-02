using UnityEngine;

public class MoveTween : MonoBehaviour
{
    public float animationTime;
    public float delayTime;

    public iTween.EaseType easeType;
    public iTween.LoopType loopType;


    public Vector3 moveAmount;

    public bool isDestroyOnComplete;
    public bool moveBackToInitial;
    public bool isDesactivateOnComplete;
    public float delayBeforeMovingBack;

    public void OnEnable()
    {
        iTween.MoveBy(gameObject, iTween.Hash("x", moveAmount.x, "y", moveAmount.y, "islocal", true, "delay", delayTime, "time", animationTime, "looptype", loopType, "easetype", easeType, "oncomplete", "OnComplete"));
    }

    public void OnComplete()
    {
        if (isDestroyOnComplete)
            Destroy(gameObject);

        if (moveBackToInitial && isDesactivateOnComplete)
            MoveBackToInitialAndDesactivate();
        else if (moveBackToInitial)
            MoveBackToInitial();

    }




    public void MoveBackToInitial()
    {

        iTween.MoveBy(gameObject, iTween.Hash("x", -moveAmount.x, "y", -moveAmount.y, "islocal", true, "delay", delayBeforeMovingBack, "time", animationTime, "looptype", loopType, "easetype", easeType));
    }

    public void MoveBackToInitialAndDesactivate()
    {
        iTween.MoveBy(gameObject, iTween.Hash("x", -moveAmount.x, "y", -moveAmount.y, "islocal", true, "delay", delayBeforeMovingBack, "time", animationTime, "looptype", loopType, "easetype", easeType, "oncomplete", "Desactivate"));
    }
    public void Desactivate()
    {
        gameObject.SetActive(false);
    }


    

}
