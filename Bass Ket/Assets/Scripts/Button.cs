using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{   
    private Animator anim;

    private void Awake() 
    {
        anim = GetComponent<Animator>();    
    }
    
    public void PlayAnimation()
    {   anim.SetBool("isSelected", true);
    }

    public void StopAnimation()
    {   anim.SetBool("isSelected", false);
    }
}
