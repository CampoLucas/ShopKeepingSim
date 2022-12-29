using UnityEngine;

public class CmdMove : ICommand
{
    private Transform _transform;
    private Vector3 _direction;
    private float _speed;
    
    public CmdMove(Transform transform, Vector3 direction, float speed)
    {
        _transform = transform;
        _direction = direction;
        _speed = speed;
    }
    
    public void Do()
    {
        _transform.position += _direction * (_speed * Time.deltaTime);
    }

    public void Undo()
    {
        _transform.position -= _direction * (_speed * Time.deltaTime);
    }
}