//Script para movimento com mouse e animações de personagem no meu projeto da unity.

using UnityEngine;
using System.Collections;

public class GotoMouse : MonoBehaviour
{
    public Animator animator;
    public Vector3 target = new Vector3();
    public Vector3 direction = new Vector3();
    public Vector3 position = new Vector3();
    public float speed = 2.0f;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        position = gameObject.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
        }
        if (target != Vector3.zero && (target - position).magnitude >= .06)
        {
            direction = (target - position).normalized;
            gameObject.transform.position += direction * speed * Time.deltaTime;
            animator.SetFloat("Walk", 1);
            animator.SetFloat("PositionX", direction.x);
            animator.SetFloat("PositionY", direction.y);
        }
        else
        {
            direction = direction.normalized;
            animator.SetFloat("Walk",-1);
            animator.SetFloat("StopX", direction.x);
            animator.SetFloat("StopY", direction.y);
        }
    }
}
