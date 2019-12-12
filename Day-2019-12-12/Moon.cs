using System;
using Utils;

namespace Day_2019_12_12
{
    public class Moon
    {
        public Vector3 Position { get; private set; }
        public Vector3 Velocity { get; private set; }
        
        public int TotalEnergy => PotentialEnergy * KineticEnergy;
        private int PotentialEnergy => Math.Abs(Position.x) + Math.Abs(Position.y) + Math.Abs(Position.z);
        private int KineticEnergy => Math.Abs(Velocity.x) + Math.Abs(Velocity.y) + Math.Abs(Velocity.z);

        public Moon(Vector3 position)
        {
            Position = position;
        }

        public void UpdateVelocity(Vector3 acceleration)
        {
            Velocity += acceleration;
        }

        public void UpdatePosition()
        {
            Position += Velocity;
        }
        
    }
}