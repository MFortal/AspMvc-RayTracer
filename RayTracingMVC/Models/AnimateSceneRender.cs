using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RayTracingLib;

namespace RayTracingMVC.Models
{
    public class AnimateSceneRender : RenderImageRequest
    {
        public int KolCadr { get; set; }
        public Geometry.Geometry.Vec3f DisVec { get; set; }
        public float RaduisOkr { get; set; }
        public Geometry.Geometry.Vec3f CenterOkr { get; set; }
    }
}