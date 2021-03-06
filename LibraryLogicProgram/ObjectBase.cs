﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry;
using static Geometry.Geometry;

namespace RayTracingLib
{
    public class ObjectBase : IObjectBase
    {
        public virtual bool IsRayIntersect(Vec3f orig, Vec3f dir, ref Vec3f hit, ref Vec3f N,
            ref Material material)
        {
            return false;

        }
        public virtual bool IsRayIntersect(Vec3f orig, Vec3f dir, ref Vec3f hit, ref Vec3f N,
            ref Material material, Color color1, Color color2)
        {
            return false;

        }
    }
}
