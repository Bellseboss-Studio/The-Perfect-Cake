using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Game.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SystemOfExtras
{
    public class IngredientsInventory : MonoBehaviour , IIngredientsInventory
    {
        private PlayerExtended _player;
        private PlayerReferences _playerReferences;
        private GameObject _mainCamera;
        [SerializeField] private GameObject ingredientsHoja, panelIngredients;
        [SerializeField] private List<MissionDetail> ingredientsDetails;
        [SerializeField] private IngredientImage ingredientImageTemplate;
        private List<IngredientImage> _ingredients;
        [SerializeField] private float moveInY, animationDuration;
        private bool _ingredientsShowed, _movingHojaIngredients;
        private IMediatorPlayer _mediatorPlayer;
        private float _timeToWait = 0.5f;
        [SerializeField] private GameObject pointToStart, pointToEnd;
        [SerializeField] private MissionControlUIView missionControlUIView;

        private void Awake()
        {
            _ingredients = new List<IngredientImage>();
        }

        private void ConfigurePlayer(Transform playerCapsule, IMediatorPlayer mediatorPlayer)
        {
            var rotation = playerCapsule.rotation;
            playerCapsule.rotation = new Quaternion(0,0,0,0);
            //ingredientsHoja.transform.SetParent(_playerReferences.PlayerCameraRoot);
            //ingredientsHoja.transform.position = _playerReferences.HojaPosition.position;
            //Destroy(_playerReferences.HojaPosition.gameObject);
            playerCapsule.rotation = rotation;
            _player.OnItemPressed += OnClickFromPlayer;
            _mediatorPlayer = mediatorPlayer;
            ShowOrHideIngredients();
            _mediatorPlayer.SetListOfMission(ingredientsDetails);
        }

        private void Start()
        {
            foreach (var ingredient in ingredientsDetails)
            {
                var ingredientInstance = Instantiate(ingredientImageTemplate, panelIngredients.transform);
                ingredientInstance.Configure(ingredient.ingredientName);
                _ingredients.Add(ingredientInstance);
            }
        }

        private void OnClickFromPlayer()
        {
            //Debug.Log("simn, hizo click");
            var ingredient = RayCastHelper.CompareIngredient(_mainCamera);
        }

        public void CrossOutIngredient(string id)
        {
            foreach (var ingredient in _ingredients.Where(ingredient => ingredient.ID == id))
            {
                ingredient.CrossOut();
            }

            foreach (var missionDetail in ingredientsDetails.Where(missionDetail => missionDetail.ingredientName == id))
            {
                missionDetail.IsCompleted = true;
            }
        }

        private void Update()
        {
            //Adding a bit cool down to the inventory
            if (_timeToWait > 0)
            {
                _timeToWait -= Time.deltaTime;
                return;
            }
            if (_mediatorPlayer.GetInput().PressInventoryButton())
            {
                ShowOrHideIngredients();
                _timeToWait = 0.5f;
            }
        }

        private void ShowOrHideIngredients()
        {
            if (!_movingHojaIngredients)
            {
                if (_ingredientsShowed)
                {
                    _ingredientsShowed = false;
                    _movingHojaIngredients = true;
                    var sequence = DOTween.Sequence();
                    sequence.Insert(0,
                        ingredientsHoja.transform.DOLocalMove(
                            pointToEnd.transform.localPosition, animationDuration).SetEase(Ease.InBack));
                    sequence.onComplete = () =>
                    {
                        _movingHojaIngredients = false;
                    };
                }
                else
                {
                    _ingredientsShowed = true;
                    _movingHojaIngredients = true;
                    var sequence = DOTween.Sequence();
                    sequence.Insert(0,
                        ingredientsHoja.transform.DOLocalMove(
                            pointToStart.transform.localPosition, animationDuration).SetEase(Ease.OutBack));
                    sequence.onComplete = () =>
                    {
                        _movingHojaIngredients = false;
                    };
                }
                missionControlUIView.OpenMissionsTab();
            }
        }

        public void Configure(PlayerExtended playerExtended, PlayerReferences playerReferences, GameObject mainCamera, Transform playerCapsule, IMediatorPlayer mediatorPlayer)
        {
            _player = playerExtended;
            _playerReferences = playerReferences;
            _mainCamera = mainCamera;
            ConfigurePlayer(playerCapsule, mediatorPlayer);
        }
    }
}