namespace Game
{
    public class UnitStateMachine
    {
        private IState _currentState;
        
        public IState CurrentState => _currentState;

        public void EnterState(IState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
    }
}