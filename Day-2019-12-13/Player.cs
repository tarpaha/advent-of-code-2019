using System;

namespace Day_2019_12_13
{
    public class Player
    {
        private readonly ArcadeCabinet _arcadeCabinet;

        public Player(ArcadeCabinet arcadeCabinet)
        {
            _arcadeCabinet = arcadeCabinet;
        }

        public int Play(int quartersAmount, Action<int> onStepComplete)
        {
            var step = 0;
            
            _arcadeCabinet.Reset();
            _arcadeCabinet.InsertQuarters(quartersAmount);
            _arcadeCabinet.Run();
            onStepComplete(step++);

            // wait for ball to land on the paddle
            while (_arcadeCabinet.BallPosition.x != _arcadeCabinet.PaddlePosition.x)
            {
                _arcadeCabinet.Input(0);
                _arcadeCabinet.Run();
                onStepComplete(step++);
            }

            var ballPrevPosition = _arcadeCabinet.BallPosition;
            
            // one step waiting ball to fly out
            _arcadeCabinet.Input(0);
            _arcadeCabinet.Run();
            onStepComplete(step++);
            
            while(!_arcadeCabinet.GameComplete)
            {
                var ballPosition = _arcadeCabinet.BallPosition;
                _arcadeCabinet.Input(ballPosition.x - ballPrevPosition.x);
                _arcadeCabinet.Run();
                onStepComplete(step++);
                ballPrevPosition = ballPosition;
            }

            return _arcadeCabinet.Score;
        }
    }
}