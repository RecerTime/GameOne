using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemeOne
{
    public class Character : Collider
    {
        const float gravity = 0.05f;

        public Vector2 position;
        public Vector2 force = new Vector2(0, 0);
        public Vector2 velocity = new Vector2(0, 0);
        public bool grounded = false;

        public float radius;
        public float mass = 5f;

        public Vector2[] UpdatePhysics()
        {
            velocity.y += gravity;
            velocity = velocity.add(force.multiply(1 / mass));

            return GenerateCollider(position.add(velocity), radius);
        }
    }
}
