using StarterAssets;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private StarterAssetsInputs inputs;
    private Animator anim;
    private int move;
    private bool attacking;
    private bool blocking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputs = GetComponent<StarterAssetsInputs>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputs.attack && !attacking)
        {
            inputs.block = false;
            blocking = false;
            inputs.attack = false;
            attacking = true;
            move = Random.Range(0, 3);
            anim.SetFloat("Attack_Move", move);
            anim.SetTrigger("Attack");
            StartCoroutine(ResetAttack());
        }

        if(inputs.sprint) 
        { 
            inputs.block = false;
            blocking = false;
        }

        if (inputs.block)
        {
            blocking = true;
            anim.SetBool("Blocking", blocking);
        }
        else
        {
            blocking = false;
            anim.SetBool("Blocking", blocking);
        }
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1);
        attacking = false;
    }
}
