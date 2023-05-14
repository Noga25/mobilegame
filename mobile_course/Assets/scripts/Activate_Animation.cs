using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Activate_Animation : MonoBehaviour
{
    [SerializeField] GameObject Ground;
    [SerializeField] Button Button;
    [SerializeField] GameObject Ball;
    [SerializeField] GameObject TargetTransform;
    [SerializeField] Rigidbody2D Rb;

    private float Duration_Ball;
    private float Duration_Button;
    private float Delay;

    private Vector3 _originalScale;
    private Vector3 _scaleTo;

    private void Start()
    {
        Duration_Ball = 7.0f;

        Duration_Button = 2.0f;

        Delay = 7.0f;

        _scaleTo = _originalScale / 2;
    }

    //Method to activate the animation when you click on the activate button
    public void Rooling()
    {
        //Change rigidbody from static to Dynmic
        Rb.bodyType = RigidbodyType2D.Dynamic;

        //Rotate the ground
        Ground.transform.DORotate(new Vector3(360.0f, 360.0f, 0.0f), 5.0f, RotateMode.FastBeyond360).
        SetLoops(1).SetRelative().SetEase(Ease.Linear);

        //Rotate the ball
        Ball.transform.DORotate(new Vector3(0, 0, -360.0f), 5.0f, RotateMode.FastBeyond360).
        SetLoops(-1).SetEase(Ease.Linear);

        //Destroy the button because he doesn't useful
        Destroy(Button);

        //Afterwards shrink the button 
        transform.DOScale(_scaleTo, Duration_Button).OnStart(() => Debug.Log("The button started to shrink"));

        //Activate the method MoveBall with time delay
        Invoke("MoveBall", Delay);
    }

    //Moving the ball to the other side of the ground 
    public void MoveBall()
    {
        Ball.transform.DOMove(TargetTransform.transform.position, Duration_Ball).SetEase(Ease.Flash).OnComplete(() => Debug.Log("The ball arrive to the finish line"));
    }
}
