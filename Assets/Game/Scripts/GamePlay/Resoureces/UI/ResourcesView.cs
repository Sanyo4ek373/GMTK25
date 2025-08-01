using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game
{
    public class ResourcesView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        private ResourcesModel _resourcesModel;
        private PlayerModelRef _playerModelRef;
        
        [Inject]
        public void Construct(PlayerModelRef playerModelRef)
        {
            _playerModelRef = playerModelRef;
        }

        private void Start()
        {
            _resourcesModel = _playerModelRef.PlayerModel.Resources;
            
            _resourcesModel.OnChangeResource += OnChangeResourcesAmount;

            OnChangeResourcesAmount(null);
        }

        private void OnDestroy()
        {
            _resourcesModel.OnChangeResource -= OnChangeResourcesAmount;
        }

        private void OnChangeResourcesAmount(Resource _)
        {
            _label.text = string.Join("\n",
                _resourcesModel.Resources.Select(r => $"{r.Resource.Name}: {r.Amount}"));
        }
    }
}