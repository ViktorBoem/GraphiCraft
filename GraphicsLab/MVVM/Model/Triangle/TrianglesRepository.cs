using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsLab.MVVM.Model.Triangle
{
    public class TrianglesRepository
    {
        private List<DrawingTriangleParameters> triangles = new List<DrawingTriangleParameters>();

        public void AddTriangle(DrawingTriangleParameters triangle)
        {
            triangles.Add(triangle);
        }

        public IReadOnlyList<DrawingTriangleParameters> GetAllTriangles()
        {
            return triangles.AsReadOnly();
        }
    }
}
