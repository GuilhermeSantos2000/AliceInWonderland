using UnityEngine;

public class Paralaxe : MonoBehaviour
{
    [SerializeField] private Transform _playerCamera;
    
    [SerializeField] private ParalaxeSprite[] _paralaxeSprites;


    void LateUpdate()
    {
        for (int i = 0; i < _paralaxeSprites.Length; i++)
        {
            Vector2 newPos = _playerCamera.transform.position;
            newPos = _playerCamera.transform.position / _paralaxeSprites[i].SpeedDiv;

            newPos.y = _paralaxeSprites[i].TargetTransform.transform.position.y;
            _paralaxeSprites[i].TargetTransform.transform.position = newPos;
        }
    }

    [System.Serializable]

    public class ParalaxeSprite
    {
        [SerializeField] private float _speedDiv = 2f;
        [SerializeField] private Transform _targetTransform;

        public float SpeedDiv => _speedDiv;
        public Transform TargetTransform => _targetTransform;
    }
}
