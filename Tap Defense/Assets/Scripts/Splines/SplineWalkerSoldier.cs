using UnityEngine;
using System.Collections;

public class SplineWalkerSoldier : MonoBehaviour
{
    public BezierSpline spline;

    public float duration;

    public bool lookForward;

    public SplineWalkerMode mode;

    private float progress;
    private bool goingForward = true;
    private int done;
    private float rando1;
    private float rando2;

    private void Start()
    {
        BezierSpline Bspline = (BezierSpline)FindObjectOfType(typeof(BezierSpline));
        spline = Bspline;
        rando1 = Random.Range(-1f, 1f);
        rando2 = Random.Range(-1f, 1f);
    }

    private void Update()
    {
        if (goingForward)
        {
            progress += Time.deltaTime / duration;

            if (progress > 0f)
            {
                if (mode == SplineWalkerMode.Once)
                {
                    progress -= 1f;
                    done++;
                    DoneWalking();
                }
                else if (mode == SplineWalkerMode.Loop)
                {
                    progress -= 1f;
                }
                else
                {
                    progress = 2f - progress;
                    goingForward = false;
                }
            }
        }
        else
        {
            progress -= Time.deltaTime / duration;

            if (progress < 0f)
            {
                progress = -progress;
                goingForward = true;
            }
        }

        Vector3 position = spline.GetPoint(-progress) + new Vector3(0f, 0f, rando2);
        transform.localPosition = position;

        if (lookForward)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
    }

    private void DoneWalking()
    {
        if (done > 0 && done < 2)
        {
            gameObject.GetComponent<DefaultEnemy>().attacking = true;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Wall")
        {
            Debug.Log("Boom");
            done = 1;
            DoneWalking();
        }
    }
}
