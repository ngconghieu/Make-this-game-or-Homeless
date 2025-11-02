using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerCtrl : AutoAssignBase
{
    [SerializeField][AutoAssign] protected Rigidbody2D rb;
    [SerializeField][AutoAssign] protected BoxCollider2D boxCollider;
    [SerializeField][AutoAssign] protected Animator animator;
}
