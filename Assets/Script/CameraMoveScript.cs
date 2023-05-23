using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private float _maxMove = 23f, _minMove = -23f;

    void Start()
    {

    }

    void LateUpdate()
    {
        if(_player ==null)
        {
            return;
        } // if player hasnt attach or destroy other codes not working

        var CamPosition = transform.position;
        CamPosition.x = _player.position.x;

        if (CamPosition.x > _maxMove)
        {
            CamPosition.x = _maxMove;
        }
        if(CamPosition.x<_minMove)
        {
            CamPosition.x = _minMove;
        }

        transform.position = CamPosition;
    }
}
