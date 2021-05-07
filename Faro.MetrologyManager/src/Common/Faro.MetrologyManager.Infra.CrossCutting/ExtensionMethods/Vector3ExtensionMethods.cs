using Faro.MetrologyManager.Infra.CrossCutting.ExtensionMethods.Models;
using System.Numerics;

namespace Faro.MetrologyManager.Infra.CrossCutting.ExtensionMethods
{
    public static class Vector3ExtensionsMethods
    {
        public static Vector3 ToVector3(this SerializedVector3 serializedVector3)
        {
            return new Vector3(serializedVector3.X, serializedVector3.Y, serializedVector3.Z);
        }

        public static SerializedVector3 FromVector3(this Vector3 vector3)
        {
            return new SerializedVector3(vector3);
        }
    }
}
