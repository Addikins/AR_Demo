using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterController : MonoBehaviour
{

    float speed = .1f;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        if (!horizontal.Equals(0) && !vertical.Equals(0))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }

        if (!horizontal.Equals(0) || !vertical.Equals(0))
        {
            Vector3 movement = new Vector3(horizontal, 0, vertical);
            transform.position += transform.forward * Time.deltaTime * speed;
            animator.SetTrigger("walk");
        }
        else { animator.SetTrigger("idle"); }
    }

    public void PlaceCharacter()
    {
        transform.localPosition = Vector3.zero;
    }
}
