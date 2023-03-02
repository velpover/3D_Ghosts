using System;
using UnityEngine;
using TMPro;

namespace NewScene
{
    public class Score : MonoBehaviour
    {
       
        [SerializeField]  private TextMeshProUGUI _scoreText;

        private static float _score = 0;

        public static event Action change;
        private void Awake()
        {
            change += DrawScore;
        }
        private void OnDestroy()
        {
            change -= DrawScore;
        }

        public static void PlusScore(float amount)
        {
            _score += amount;
            change?.Invoke();
        }

        private void DrawScore()
        {
            _scoreText.SetText("Score = {0}", _score);
        }
    }
}

