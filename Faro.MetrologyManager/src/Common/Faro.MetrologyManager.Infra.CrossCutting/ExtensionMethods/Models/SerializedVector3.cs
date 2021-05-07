using System;
using System.Numerics;

namespace Faro.MetrologyManager.Infra.CrossCutting.ExtensionMethods.Models
{
    [Serializable]
    public class SerializedVector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public SerializedVector3()
        {

        }

        public SerializedVector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public SerializedVector3(Vector3 vector3)
        {
            X = vector3.X;
            Y = vector3.Y;
            Z = vector3.Z;
        }
    }
}
