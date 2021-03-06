﻿using System;

namespace Geometry
{
    public class Geometry
    {
        public class Vec3f : IGeometry
        {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }

            public Vec3f(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public Vec3f()
            {
            }

            public float this[int i]
            {
                get { return i <= 0 ? x : (i == 1 ? y : z); }
            }

            public float Norm()
            {
                return (float)Math.Sqrt(x * x + y * y + z * z);
            }

            public Vec3f Normalize()
            {
                return this / Norm();
            }

            public float[] ToArray()
            {
                return new[] { x, y, z };
            }

            public static Vec3f operator +(Vec3f self, Vec3f other)
            {
                return new Vec3f(self.x + other.x, self.y + other.y, self.z + other.z);
            }

            public static Vec3f operator -(Vec3f self, Vec3f other)
            {
                return new Vec3f(self.x - other.x, self.y - other.y, self.z - other.z);
            }

            public static float operator *(Vec3f self, Vec3f other)
            {
                return self.x * other.x + self.y * other.y + self.z * other.z;
            }

            public static Vec3f operator *(Vec3f self, float value)
            {
                return new Vec3f(self.x * value, self.y * value, self.z * value);
            }

            public static Vec3f operator /(Vec3f self, float value)
            {
                return self * (1f / value);
            }

            public static Vec3f operator -(Vec3f self)
            {
                return self * -1f;
            }

            public static Vec3f Cross(Vec3f self, Vec3f other)
            {
                return new Vec3f(self.y * other.z - self.z * other.y, self.z * other.x - self.x * other.z, self.x * other.y - self.y * other.x);
            }
        }
    }
}


