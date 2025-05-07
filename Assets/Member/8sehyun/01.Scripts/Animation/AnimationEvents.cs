using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField]private ParticleSystem slash1;
    [SerializeField]private ParticleSystem slash2;

    [SerializeField] private Animator animator;

    public void Effect1()
    {
        slash1.Play();
    }

    public void Effect2()
    {
        slash2.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            animator.SetTrigger("0");
        }else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetTrigger("1");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetTrigger("2");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetTrigger("3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.SetTrigger("4");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            animator.SetTrigger("5");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            animator.SetTrigger("6");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            animator.SetTrigger("7");
        }
    }
}
