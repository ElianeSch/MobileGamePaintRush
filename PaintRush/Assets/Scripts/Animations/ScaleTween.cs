using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    public float animationTime;
    public float delayTime;
    public iTween.EaseType easeType;

    public void OnEnable()
    {
        iTween.PunchScale(gameObject, iTween.Hash("amount", new Vector3(1.5f,1.5f,1.5f), "time", animationTime, "delay", delayTime, "easetype", easeType, "oncomplete", "OnComplete"));

    }


    public void OnComplete()
    {
        
    }

}
