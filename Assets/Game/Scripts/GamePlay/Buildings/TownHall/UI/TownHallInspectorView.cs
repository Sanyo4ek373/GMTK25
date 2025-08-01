using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game {
    public class TownHallInspectorView : View
    {
        [SerializeField] private WorkerInspectorView _workerPrefab;
        
        [SerializeField] private Transform _workersPanel;
        
        private readonly List<WorkerInspectorView> _workers = new();
        private TownHallModel _model;
        
        [Inject]
        public void Construct(TownHallModel model) {
            _model = model;    
        }
        
        public override void Show()
        {
            base.Show();
            
            var capacity =_model.Config.Levels[_model.Level].CapacityOfWorkers;
            var workers = _model.Workers;

            for (var i = 0; i < capacity; ++i)
            {
                if (i >= _workers.Count)
                {
                    var panel = Instantiate(_workerPrefab, _workersPanel);
                    _workers.Add(panel);
                }

                _workers[i].SetAvailable(i < workers);
            }
        }
    }
}