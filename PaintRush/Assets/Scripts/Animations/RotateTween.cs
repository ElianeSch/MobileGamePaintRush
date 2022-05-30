using UnityEngine;

public class RotateTween : MonoBehaviour
{
    public float animationTime;
    public float delayTime;

    public iTween.EaseType easeType;
    public iTween.LoopType loopType;

    public Vector3 rotateAmount;

    public bool isDestroyOnComplete;

    public void OnEnable()
    {
        iTween.RotateBy(gameObject, iTween.Hash("z", rotateAmount.z, "time", animationTime, "delay", delayTime, "looptype", loopType, "easetype", easeType, "oncomplete", "OnComplete"));
    }

    public void OnComplete()
    {
        if (isDestroyOnComplete)
            Destroy(gameObject);
    }




}
