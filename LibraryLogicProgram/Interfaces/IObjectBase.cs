﻿using System.Drawing;
using static Geometry.Geometry;
namespace RayTracingLib
{
    public interface IObjectBase
    {
        bool IsRayIntersect(Vec3f orig, Vec3f dir, ref Vec3f hit, ref Vec3f N, ref Material material);

        bool IsRayIntersect(Vec3f orig, Vec3f dir, ref Vec3f hit, ref Vec3f N,
            ref Material material, Color color1, Color color2);
    }
}