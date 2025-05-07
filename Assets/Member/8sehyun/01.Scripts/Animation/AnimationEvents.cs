using TMPro;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField]private ParticleSystem slash1;
    [SerializeField]private ParticleSystem slash2;
    [SerializeField]private ParticleSystem slash3;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Animator animator;

    public void Effect1()
    {
        slash1.Play();
    }

    public void Effect2()
    {
        slash2.Play();
    }
    public void Effect3()
    {
        slash3.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            animator.SetTrigger("0");
            text.text = "Idle";
        }else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetTrigger("1");
            text.text = "Walk";

        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetTrigger("2");
            text.text = "Dash_Walk";

        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetTrigger("3");
            text.text = "Dash_Idle";

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.SetTrigger("4");
            text.text = "Attack_1";

        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            animator.SetTrigger("5");
            text.text = "Attack_2";

        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            animator.SetTrigger("6");
            text.text = "Charging";

        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            animator.SetTrigger("7");
            text.text = "Charging_Attack";

        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            animator.SetTrigger("8");
            text.text = "Damaged";
        }
    }
}
