using System.Collections;
using System.Collections.Generic;
using NewScene;
using UnityEngine;

namespace NewScene
{
    [RequireComponent(typeof(KeyInput))]
    public class Lamp : MonoBehaviour
    {

        private float _maxSpotRange=40f;
        private float _minSpotRange=0f;
        private float _maxPointRange=8f;
        private float _minPointRange=2f;

        [SerializeField] private Light _lightPoint;
        [SerializeField] private Light _lightSpot;
        [SerializeField] private LightRange _lightRange;
        [SerializeField] private LightColor _lightColor;
        [SerializeField] private KeyInput _keyInput;
        [SerializeField] private LightAttack _lightAttack;


        void OnEnable()
        {
            _keyInput.KeyEDown += OnColorChangeSpot;
            _keyInput.KeyEDown += _lightAttack.LightSpotAttack;

            _keyInput.KeyEUP += OffColorChangeSpot;
            _keyInput.KeyEUP += _lightAttack.StopAttack;
            

            _keyInput.KeyQDown += OnColorChangePoint;
            _keyInput.KeyQDown += GoToMaxRangePoint;
            _keyInput.KeyQDown += GoToMinRangeSpot;
            _keyInput.KeyQDown += _lightAttack.LightAroundAttack;

            

            _keyInput.KeyQUP += OffColorChangePoint;
            _keyInput.KeyQUP += GoToMinRangePoint;
            _keyInput.KeyQUP += GoToMaxRangeSpot;
            _keyInput.KeyQUP += _lightAttack.StopAttack;
            

        }
        void OnDisable()
        {
            _keyInput.KeyEDown -= OnColorChangeSpot;
            _keyInput.KeyEDown -= _lightAttack.LightSpotAttack;

            _keyInput.KeyEUP -= OffColorChangeSpot;
            _keyInput.KeyEUP -= _lightAttack.StopAttack; 


            _keyInput.KeyQDown -= OnColorChangePoint;
            _keyInput.KeyQDown -= GoToMaxRangePoint;
            _keyInput.KeyQDown -= GoToMinRangeSpot;
            _keyInput.KeyQDown -= _lightAttack.LightAroundAttack;

            _keyInput.KeyQUP -= OffColorChangePoint;
            _keyInput.KeyQUP -= GoToMinRangePoint;
            _keyInput.KeyQUP -= GoToMaxRangeSpot;
            _keyInput.KeyQUP -= _lightAttack.StopAttack;
        }


        private void OnColorChangeSpot() => _lightColor.OnColorChange(_lightSpot);
        private void OffColorChangeSpot() => _lightColor.OffColorChange(_lightSpot);

        private void GoToMaxRangeSpot() => _lightRange.OnRangeChange(_lightSpot, _maxSpotRange);
        private void GoToMinRangeSpot() => _lightRange.OffRangeChange(_lightSpot, _minSpotRange);

        private void OnColorChangePoint() => _lightColor.OnColorChange(_lightPoint);
        private void OffColorChangePoint() => _lightColor.OffColorChange(_lightPoint);

        private void GoToMaxRangePoint() => _lightRange.OnRangeChange(_lightPoint,_maxPointRange);
        private void GoToMinRangePoint() => _lightRange.OffRangeChange(_lightPoint,_minPointRange);


    }

}
