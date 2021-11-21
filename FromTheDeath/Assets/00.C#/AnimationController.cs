using UnityEngine;

public class AnimationController : MonoBehaviour
{


    public enum PlayerState
    {
        Idle,
        Run,
        Jump,
        Attack1,
        Attack2,
        TakeHit,
        Fall,
        Death,
        len
    }


    public enum EnemyState
    {
        Idle,
        Walk,
        Attack,
        Hurt,
        Death,
        len,
    }

    public enum BossState
    {
        Idle,
        Walk,
        Attack,
        Hurt,
        Death,
        Cast,
        len,
    }

}
