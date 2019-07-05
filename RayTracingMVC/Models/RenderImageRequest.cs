using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RayTracingLib;

namespace RayTracingMVC.Models
{
    public class RenderImageRequest
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Geometry.Geometry.Vec3f Origin { get; set; }
        public List<Sphere> Spheres { get; set; }
        public List<CheckerBoard> CheckerBoard { get; set; }
        public string PathBack { get; set; }
        public List<Light> Lights { get; set; }
    };
}