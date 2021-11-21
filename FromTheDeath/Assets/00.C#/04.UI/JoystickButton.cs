using UnityEngine;

public class JoystickButton : Singleton<JoystickButton>
{
    [SerializeField] bool _isMoveLeft, _isMoveRight;


    public bool isMoveRight => _isMoveRight;
    public bool isMoveLeft => _isMoveLeft;

    public void SetMoveLeft(bool left)
    {
        _isMoveLeft = left;
    }

    public void SetMoveRight(bool right)
    {
        _isMoveRight = right;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector2 MovingVector()
    {
        if (_isMoveLeft == true)
        {
            return Vector2.left;
        }

        else if (_isMoveRight == true)
            return Vector2.right;

        return Vector2.zero;
    }


}
