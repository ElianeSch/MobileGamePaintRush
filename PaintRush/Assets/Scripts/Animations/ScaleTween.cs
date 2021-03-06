using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    public float animationTime;
    public float delayTime;

    public iTween.EaseType easeType;
    public iTween.LoopType loopType;

    public Vector3 scaleAmount;

    public bool isDestroyOnComplete;

    public void OnEnable()
    {
        iTween.ScaleBy(gameObject, iTween.Hash("amount", scaleAmount, "time", animationTime, "delay", delayTime, "looptype", loopType, "easetype", easeType, "oncomplete", "OnComplete"));
    }

    public void OnComplete()
    {
        if (isDestroyOnComplete)
            Destroy(gameObject);
    }




}
