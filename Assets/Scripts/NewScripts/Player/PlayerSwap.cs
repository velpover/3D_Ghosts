using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(ButtonInput))]
public class PlayerSwap : MonoBehaviour
{
    [SerializeField] private GameObject _redPlayer;
    [SerializeField] private GameObject _yellowPlayer;
    [SerializeField] private GameObject _blackPlayer;

    [SerializeField] private ButtonInput _buttonInput;

    public static Vector3 _playerPos=Vector3.zero;
    public static Quaternion _playerRot=Quaternion.identity;


    void Awake()
    {
        _buttonInput.yellowPlayerClick += SetActiveYellowPlayer;

        _buttonInput.blackPlayerClick += SetActiveBlackPlayer;

        _buttonInput.redPlayerClick += SetActiveRedPlayer;
    }

    void OnDestroy()
    {
        _buttonInput.yellowPlayerClick -= SetActiveYellowPlayer;

        _buttonInput.blackPlayerClick -= SetActiveBlackPlayer;

        _buttonInput.redPlayerClick -= SetActiveRedPlayer;
    }

    private void SetActiveRedPlayer()
    {
  
        _yellowPlayer.SetActive(false);
        _blackPlayer.SetActive(false);
        _redPlayer.SetActive(true);
    }
    private void SetActiveYellowPlayer()
    {
        _redPlayer.SetActive(false);
        _blackPlayer.SetActive(false);
        _yellowPlayer.SetActive(true);
    }
    private void SetActiveBlackPlayer()
    {
        _redPlayer.SetActive(false);
        _yellowPlayer.SetActive(false);
        _blackPlayer.SetActive(true);
    }

    public static void SetActivePos(Transform player)
    {
        player.position = _playerPos;
        player.rotation = _playerRot;
    }
    public static void TakeTransformPos(Transform target)
    {
        _playerPos = target.position;
        _playerRot= target.rotation;

    }

    



}
