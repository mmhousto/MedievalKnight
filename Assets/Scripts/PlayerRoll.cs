using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : MonoBehaviour
{

    private StarterAssetsInputs inputs;
    private Animator anim;
    private bool rolling;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputs = GetComponent<StarterAssetsInputs>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inputs.rolling && !rolling && inputs.move != Vector2.zero)
        {
            inputs.block = false;
            StartCoroutine(PlayAnimationAndReset());
        }
    }

    private IEnumerator PlayAnimationAndReset()
    {
        // 1. Set the boolean to true to start the animation
        rolling = true;
        anim.SetTrigger("Roll");

        // 2. Wait until the next frame so the animator transitions to the new state
        yield return null;

        // 3. Grab the duration of the currently playing animation clip
        float animationLength = anim.GetCurrentAnimatorStateInfo(0).length;

        // 4. Wait for the animation to finish playing
        yield return new WaitForSeconds(animationLength);

        // 5. Reset it
        rolling = false;
    }
}
