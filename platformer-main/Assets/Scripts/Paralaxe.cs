using UnityEngine;

public class Paralaxe : MonoBehaviour
{
    [SerializeField] private Transform _backgroundGround;
    [SerializeField] private Transform _middleGround;
    [SerializeField] private Transform _playerCamera;
    
    [SerializeField] private ParalaxeSprite[] _paralaxeSprites;


    void Update()
    {
        for (int i = 0; 1 < _paralaxeSprites.Length; i++)
        {
            _paralaxeSprites[i].TargetSprite.transform.position =
                _playerCamera.transform.position / _paralaxeSprites[i].SpeedDiv;
                _paralaxeSprites[i].TargetSprite.sortingOrder = i;
        }
    }

    [System.Serializable]

    public class ParalaxeSprite
    {
        [SerializeField] private float _speedDiv = 2f;
        [SerializeField] private SpriteRenderer _targetsprite;

        public float SpeedDiv => _speedDiv;
        public SpriteRenderer TargetSprite => _targetsprite;
    }
}
