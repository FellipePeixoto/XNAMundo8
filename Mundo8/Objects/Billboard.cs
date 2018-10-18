#region using
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Mundo8.SetRec;
#endregion

namespace Mundo8.Objects
{
    class Billboard : Quad
    {
        public float distance = 0;

        public Billboard(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, String textureName, String snowTextureName = "") : 
            base(p1,p2,p3,p4,textureName,snowTextureName)
        { }

        public void Update(Camera cam)
        {
            world = Matrix.Identity;
            world = Matrix.CreateRotationY(MathHelper.ToRadians((cam as CameraFree).angleY));
            world *= Matrix.CreateTranslation(center);
            distance = Vector3.Distance(cam.GetPosition(), center);
            Console.WriteLine(distance);
        }
    }
}
