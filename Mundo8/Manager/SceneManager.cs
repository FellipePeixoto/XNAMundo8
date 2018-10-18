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
using Mundo8.Objects;
#endregion

namespace Mundo8.Manager
{
    static class SceneManager
    {
        #region private
        static List<Scene> scenes;
        static Scene actualScene;
        static Screen screen;
        static Camera actualCamera;
        static CameraChopper chopCamera;
        static CameraFree freeCamera;
        #endregion

        #region public
        public static ContentManager staticContent;
        public static GraphicsDevice staticDevice;
        public static Effect staticEffect;
        public static Chopper chooper;
        public static Obj teto;
        public static Grid grid;
        public static Billboard[] bil = new Billboard[8];
        #endregion

        public static void Initialize(GraphicsDevice device, ContentManager content, int screenWidth, int screenHeight)
        {
            staticDevice = device;
            staticContent = content;

            screen = Screen.GetInstance();
            screen.SetWidth(screenWidth);
            screen.SetHeight(screenHeight);

            staticEffect = staticContent.Load<Effect>(@"Effect\effect1");
        }

        public static void LoadContent(ContentManager content)
        {
            freeCamera = new CameraFree(Vector3.Backward * 20, Vector3.Zero);
            chopCamera = new CameraChopper(new Vector3(-1.6f, 3, 4.5f), Vector3.Forward * 10);
            actualCamera = freeCamera;

            //TODO: Create Objects to include on set
            chooper = new Chopper(@"Texture\camo", @"Texture\camo_snow");
            #region set do helicoptero
            List<Quad> heliBody = new List<Quad> 
            {
                #region heli body
                new Quad(new Vector3(-0.50f,-0.00f,1.50f),
new Vector3(-0.50f,0.20f,1.50f),
new Vector3(-0.70f,0.20f,1.50f),
new Vector3(-0.70f,-0.00f,1.50f)
,""),

new Quad(new Vector3(-1.00f,0.60f,-0.50f),
new Vector3(-1.00f,2.60f,-0.50f),
new Vector3(1.00f,2.60f,-0.50f),
new Vector3(1.00f,0.60f,-0.50f)
,""),

new Quad(new Vector3(-0.70f,-0.00f,1.50f),
new Vector3(-0.70f,0.20f,1.50f),
new Vector3(-0.70f,0.20f,-0.50f),
new Vector3(-0.70f,0.00f,-0.50f)
,""),

new Quad(new Vector3(-1.00f,2.60f,0.50f),
new Vector3(1.00f,2.60f,0.50f),
new Vector3(1.00f,2.60f,-0.50f),
new Vector3(-1.00f,2.60f,-0.50f)
,""),

new Quad(new Vector3(-0.50f,0.20f,-0.30f),
new Vector3(-0.70f,0.20f,-0.30f),
new Vector3(-0.70f,0.60f,-0.30f),
new Vector3(-0.50f,0.60f,-0.30f)
,""),

new Quad(new Vector3(-0.70f,0.00f,-0.50f),
new Vector3(-0.70f,0.20f,-0.50f),
new Vector3(-0.50f,0.20f,-0.50f),
new Vector3(-0.50f,0.00f,-0.50f)
,""),

new Quad(new Vector3(-0.50f,0.00f,-0.50f),
new Vector3(-0.50f,-0.00f,1.50f),
new Vector3(-0.70f,-0.00f,1.50f),
new Vector3(-0.70f,0.00f,-0.50f)
,""),

new Quad(new Vector3(-0.50f,-0.00f,1.50f),
new Vector3(-0.50f,0.00f,-0.50f),
new Vector3(-0.50f,0.20f,-0.50f),
new Vector3(-0.50f,0.20f,1.50f)
,""),

new Quad(new Vector3(-0.50f,0.20f,1.50f),
new Vector3(-0.50f,0.20f,-0.50f),
new Vector3(-0.70f,0.20f,-0.50f),
new Vector3(-0.70f,0.20f,1.50f)
,""),

new Quad(new Vector3(-0.70f,0.20f,1.00f),
new Vector3(-0.70f,0.20f,1.30f),
new Vector3(-0.70f,0.60f,1.30f),
new Vector3(-0.70f,0.60f,1.00f)
,""),

new Quad(new Vector3(-0.09f,0.62f,-3.50f),
new Vector3(-0.09f,1.58f,-3.50f),
new Vector3(0.09f,1.58f,-3.50f),
new Vector3(0.09f,0.62f,-3.50f)
,""),

new Quad(new Vector3(0.30f,0.80f,-0.50f),
new Vector3(-0.30f,0.80f,-0.50f),
new Vector3(-0.09f,0.80f,-2.50f),
new Vector3(0.09f,0.80f,-2.50f)
,""),

new Quad(new Vector3(-0.30f,0.80f,-0.50f),
new Vector3(-0.30f,1.40f,-0.50f),
new Vector3(-0.09f,1.40f,-2.50f),
new Vector3(-0.09f,0.80f,-2.50f)
,""),

new Quad(new Vector3(-0.50f,0.20f,1.00f),
new Vector3(-0.70f,0.20f,1.00f),
new Vector3(-0.70f,0.60f,1.00f),
new Vector3(-0.50f,0.60f,1.00f)
,""),

new Quad(new Vector3(-0.50f,0.20f,-0.00f),
new Vector3(-0.50f,0.20f,-0.30f),
new Vector3(-0.50f,0.60f,-0.30f),
new Vector3(-0.50f,0.60f,-0.00f)
,""),

new Quad(new Vector3(-0.70f,0.20f,-0.30f),
new Vector3(-0.70f,0.20f,-0.00f),
new Vector3(-0.70f,0.60f,-0.00f),
new Vector3(-0.70f,0.60f,-0.30f)
,""),

new Quad(new Vector3(-0.50f,0.20f,1.30f),
new Vector3(-0.50f,0.20f,1.00f),
new Vector3(-0.50f,0.60f,1.00f),
new Vector3(-0.50f,0.60f,1.30f)
,""),

new Quad(new Vector3(-0.70f,0.20f,-0.00f),
new Vector3(-0.50f,0.20f,-0.00f),
new Vector3(-0.50f,0.60f,-0.00f),
new Vector3(-0.70f,0.60f,-0.00f)
,""),

new Quad(new Vector3(-0.70f,0.20f,1.30f),
new Vector3(-0.50f,0.20f,1.30f),
new Vector3(-0.50f,0.60f,1.30f),
new Vector3(-0.70f,0.60f,1.30f)
,""),

new Quad(new Vector3(1.00f,0.60f,1.50f),
new Vector3(1.00f,1.50f,1.50f),
new Vector3(-1.00f,1.50f,1.50f),
new Vector3(-1.00f,0.60f,1.50f)
,""),

new Quad(new Vector3(1.00f,0.60f,1.50f),
new Vector3(-1.00f,0.60f,1.50f),
new Vector3(-1.00f,0.60f,-0.50f),
new Vector3(1.00f,0.60f,-0.50f)
,""),

new Quad(new Vector3(-0.09f,1.58f,-2.50f),
new Vector3(0.09f,1.58f,-2.50f),
new Vector3(0.09f,1.58f,-3.50f),
new Vector3(-0.09f,1.58f,-3.50f)
,""),

new Quad(new Vector3(-0.09f,0.62f,-2.50f),
new Vector3(0.09f,0.62f,-2.50f),
new Vector3(0.09f,1.58f,-2.50f),
new Vector3(-0.09f,1.58f,-2.50f)
,""),

new Quad(new Vector3(-0.30f,1.40f,-0.50f),
new Vector3(0.30f,1.40f,-0.50f),
new Vector3(0.09f,1.40f,-2.50f),
new Vector3(-0.09f,1.40f,-2.50f)
,""),

new Quad(new Vector3(-0.09f,0.80f,-3.30f),
new Vector3(-0.09f,0.80f,-2.70f),
new Vector3(0.00f,0.80f,-2.70f),
new Vector3(0.00f,0.80f,-3.30f)
,""),

new Quad(new Vector3(0.09f,0.62f,-2.50f),
new Vector3(-0.09f,0.62f,-2.50f),
new Vector3(-0.09f,0.62f,-3.50f),
new Vector3(0.09f,0.62f,-3.50f)
,""),

new Quad(new Vector3(-0.09f,1.40f,-2.70f),
new Vector3(-0.09f,0.80f,-2.70f),
new Vector3(-0.09f,0.62f,-2.50f),
new Vector3(-0.09f,1.58f,-2.50f)
,""),

new Quad(new Vector3(-0.09f,0.80f,-3.30f),
new Vector3(-0.09f,1.40f,-3.30f),
new Vector3(-0.09f,1.58f,-3.50f),
new Vector3(-0.09f,0.62f,-3.50f)
,""),

new Quad(new Vector3(-0.09f,0.80f,-2.70f),
new Vector3(-0.09f,0.80f,-3.30f),
new Vector3(-0.09f,0.62f,-3.50f),
new Vector3(-0.09f,0.62f,-2.50f)
,""),

new Quad(new Vector3(-0.09f,1.40f,-3.30f),
new Vector3(-0.09f,1.40f,-2.70f),
new Vector3(-0.09f,1.58f,-2.50f),
new Vector3(-0.09f,1.58f,-3.50f)
,""),

new Quad(new Vector3(-0.09f,0.80f,-2.70f),
new Vector3(-0.09f,1.40f,-2.70f),
new Vector3(0.00f,1.40f,-2.70f),
new Vector3(0.00f,0.80f,-2.70f)
,""),

new Quad(new Vector3(-0.09f,1.40f,-2.70f),
new Vector3(-0.09f,1.40f,-3.30f),
new Vector3(0.00f,1.40f,-3.30f),
new Vector3(0.00f,1.40f,-2.70f)
,""),

new Quad(new Vector3(-0.09f,1.40f,-3.30f),
new Vector3(-0.09f,0.80f,-3.30f),
new Vector3(0.00f,0.80f,-3.30f),
new Vector3(0.00f,1.40f,-3.30f)
,""),

new Quad(new Vector3(0.50f,-0.00f,1.50f),
new Vector3(0.70f,-0.00f,1.50f),
new Vector3(0.70f,0.20f,1.50f),
new Vector3(0.50f,0.20f,1.50f)
,""),

new Quad(new Vector3(0.70f,-0.00f,1.50f),
new Vector3(0.70f,0.00f,-0.50f),
new Vector3(0.70f,0.20f,-0.50f),
new Vector3(0.70f,0.20f,1.50f)
,""),

new Quad(new Vector3(0.50f,0.20f,-0.30f),
new Vector3(0.50f,0.60f,-0.30f),
new Vector3(0.70f,0.60f,-0.30f),
new Vector3(0.70f,0.20f,-0.30f)
,""),

new Quad(new Vector3(0.70f,0.00f,-0.50f),
new Vector3(0.50f,0.00f,-0.50f),
new Vector3(0.50f,0.20f,-0.50f),
new Vector3(0.70f,0.20f,-0.50f)
,""),

new Quad(new Vector3(0.50f,0.00f,-0.50f),
new Vector3(0.70f,0.00f,-0.50f),
new Vector3(0.70f,-0.00f,1.50f),
new Vector3(0.50f,-0.00f,1.50f)
,""),

new Quad(new Vector3(0.50f,-0.00f,1.50f),
new Vector3(0.50f,0.20f,1.50f),
new Vector3(0.50f,0.20f,-0.50f),
new Vector3(0.50f,0.00f,-0.50f)
,""),

new Quad(new Vector3(0.50f,0.20f,1.50f),
new Vector3(0.70f,0.20f,1.50f),
new Vector3(0.70f,0.20f,-0.50f),
new Vector3(0.50f,0.20f,-0.50f)
,""),

new Quad(new Vector3(0.70f,0.20f,1.00f),
new Vector3(0.70f,0.60f,1.00f),
new Vector3(0.70f,0.60f,1.30f),
new Vector3(0.70f,0.20f,1.30f)
,""),

new Quad(new Vector3(0.30f,0.80f,-0.50f),
new Vector3(0.09f,0.80f,-2.50f),
new Vector3(0.09f,1.40f,-2.50f),
new Vector3(0.30f,1.40f,-0.50f)
,""),

new Quad(new Vector3(0.50f,0.20f,1.00f),
new Vector3(0.50f,0.60f,1.00f),
new Vector3(0.70f,0.60f,1.00f),
new Vector3(0.70f,0.20f,1.00f)
,""),

new Quad(new Vector3(0.50f,0.20f,0.00f),
new Vector3(0.50f,0.60f,0.00f),
new Vector3(0.50f,0.60f,-0.30f),
new Vector3(0.50f,0.20f,-0.30f)
,""),

new Quad(new Vector3(0.70f,0.20f,-0.30f),
new Vector3(0.70f,0.60f,-0.30f),
new Vector3(0.70f,0.60f,0.00f),
new Vector3(0.70f,0.20f,0.00f)
,""),

new Quad(new Vector3(0.50f,0.20f,1.30f),
new Vector3(0.50f,0.60f,1.30f),
new Vector3(0.50f,0.60f,1.00f),
new Vector3(0.50f,0.20f,1.00f)
,""),

new Quad(new Vector3(0.70f,0.20f,0.00f),
new Vector3(0.70f,0.60f,0.00f),
new Vector3(0.50f,0.60f,0.00f),
new Vector3(0.50f,0.20f,0.00f)
,""),

new Quad(new Vector3(0.70f,0.20f,1.30f),
new Vector3(0.70f,0.60f,1.30f),
new Vector3(0.50f,0.60f,1.30f),
new Vector3(0.50f,0.20f,1.30f)
,""),

new Quad(new Vector3(0.09f,0.80f,-3.30f),
new Vector3(0.00f,0.80f,-3.30f),
new Vector3(0.00f,0.80f,-2.70f),
new Vector3(0.09f,0.80f,-2.70f)
,""),

new Quad(new Vector3(0.09f,1.40f,-2.70f),
new Vector3(0.09f,1.58f,-2.50f),
new Vector3(0.09f,0.62f,-2.50f),
new Vector3(0.09f,0.80f,-2.70f)
,""),

new Quad(new Vector3(0.09f,0.80f,-3.30f),
new Vector3(0.09f,0.62f,-3.50f),
new Vector3(0.09f,1.58f,-3.50f),
new Vector3(0.09f,1.40f,-3.30f)
,""),

new Quad(new Vector3(0.09f,0.80f,-2.70f),
new Vector3(0.09f,0.62f,-2.50f),
new Vector3(0.09f,0.62f,-3.50f),
new Vector3(0.09f,0.80f,-3.30f)
,""),

new Quad(new Vector3(0.09f,1.40f,-3.30f),
new Vector3(0.09f,1.58f,-3.50f),
new Vector3(0.09f,1.58f,-2.50f),
new Vector3(0.09f,1.40f,-2.70f)
,""),

new Quad(new Vector3(0.09f,0.80f,-2.70f),
new Vector3(0.00f,0.80f,-2.70f),
new Vector3(0.00f,1.40f,-2.70f),
new Vector3(0.09f,1.40f,-2.70f)
,""),

new Quad(new Vector3(0.09f,1.40f,-2.70f),
new Vector3(0.00f,1.40f,-2.70f),
new Vector3(0.00f,1.40f,-3.30f),
new Vector3(0.09f,1.40f,-3.30f)
,""),

new Quad(new Vector3(0.09f,1.40f,-3.30f),
new Vector3(0.00f,1.40f,-3.30f),
new Vector3(0.00f,0.80f,-3.30f),
new Vector3(0.09f,0.80f,-3.30f)
,""),

new Quad(new Vector3(-1.00f,0.60f,-0.50f),
new Vector3(-1.00f,0.60f,1.50f),
new Vector3(-1.00f,1.50f,1.50f),
new Vector3(-1.00f,1.50f,-0.50f)
,""),

new Quad(new Vector3(1.00f,1.50f,1.50f),
new Vector3(1.00f,0.60f,1.50f),
new Vector3(1.00f,0.60f,-0.50f),
new Vector3(1.00f,1.50f,-0.50f)
,""),
                #endregion
            };

            List<Quad> glass = new List<Quad>
            {
                #region glass
                new Quad(new Vector3(-1.00f,1.50f,1.50f),
new Vector3(-1.00f,2.60f,0.50f),
new Vector3(-1.00f,2.60f,-0.50f),
new Vector3(-1.00f,1.50f,-0.50f)
,@"Texture\vidro", @"Texture\vidro_snow"),

new Quad(new Vector3(1.00f,2.60f,0.50f),
new Vector3(-1.00f,2.60f,0.50f),
new Vector3(-1.00f,1.50f,1.50f),
new Vector3(1.00f,1.50f,1.50f)
,@"Texture\vidro", @"Texture\vidro_snow"),

new Quad(new Vector3(1.00f,2.60f,-0.50f),
new Vector3(1.00f,2.60f,0.50f),
new Vector3(1.00f,1.50f,1.50f),
new Vector3(1.00f,1.50f,-0.50f)
,@"Texture\vidro", @"Texture\vidro_snow"),
                #endregion
            };

            List<Quad> heliMainBlade = new List<Quad>
            {
                #region main blade
                new Quad(new Vector3(0.06f,0.10f,0.06f),
new Vector3(0.06f,0.10f,-0.06f),
new Vector3(0.06f,0.20f,-0.06f),
new Vector3(0.06f,0.20f,0.06f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.06f,-0.00f,-0.06f),
new Vector3(-0.06f,0.10f,-0.06f),
new Vector3(0.06f,0.10f,-0.06f),
new Vector3(0.06f,-0.00f,-0.06f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.06f,-0.00f,0.06f),
new Vector3(-0.06f,0.10f,0.06f),
new Vector3(-0.06f,0.10f,-0.06f),
new Vector3(-0.06f,-0.00f,-0.06f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(0.06f,-0.00f,0.06f),
new Vector3(0.06f,0.10f,0.06f),
new Vector3(-0.06f,0.10f,0.06f),
new Vector3(-0.06f,-0.00f,0.06f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(0.06f,-0.00f,-0.06f),
new Vector3(0.06f,0.10f,-0.06f),
new Vector3(0.06f,0.10f,0.06f),
new Vector3(0.06f,-0.00f,0.06f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.06f,0.20f,0.06f),
new Vector3(0.06f,0.20f,0.06f),
new Vector3(0.06f,0.20f,-0.06f),
new Vector3(-0.06f,0.20f,-0.06f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(0.06f,0.10f,-0.06f),
new Vector3(-0.06f,0.10f,-0.06f),
new Vector3(-0.06f,0.20f,-0.06f),
new Vector3(0.06f,0.20f,-0.06f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.06f,0.10f,0.06f),
new Vector3(0.06f,0.10f,0.06f),
new Vector3(0.06f,0.20f,0.06f),
new Vector3(-0.06f,0.20f,0.06f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.06f,0.10f,-0.06f),
new Vector3(-0.06f,0.10f,0.06f),
new Vector3(-0.06f,0.20f,0.06f),
new Vector3(-0.06f,0.20f,-0.06f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.06f,0.10f,0.06f),
new Vector3(-0.06f,0.10f,-0.06f),
new Vector3(-3.00f,0.10f,-0.15f),
new Vector3(-3.00f,0.10f,0.15f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.15f,0.10f,-3.00f),
new Vector3(-0.06f,0.10f,-0.06f),
new Vector3(0.06f,0.10f,-0.06f),
new Vector3(0.15f,0.10f,-3.00f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(0.06f,0.10f,-0.06f),
new Vector3(0.06f,0.10f,0.06f),
new Vector3(3.00f,0.10f,0.15f),
new Vector3(3.00f,0.10f,-0.15f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(0.15f,0.10f,3.00f),
new Vector3(0.06f,0.10f,0.06f),
new Vector3(-0.06f,0.10f,0.06f),
new Vector3(-0.15f,0.10f,3.00f)
,@"Texture\blade",@"Texture\blade_snow"),
                #endregion
            };

            List<Quad> heliTailBlade = new List<Quad>()
            {
                #region tail blade
                new Quad(new Vector3(-0.03f,0.02f,-0.02f),
new Vector3(-0.03f,0.02f,0.02f),
new Vector3(-0.03f,0.20f,0.04f),
new Vector3(-0.03f,0.20f,-0.04f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.03f,-0.02f,-0.02f),
new Vector3(-0.03f,0.02f,-0.02f),
new Vector3(-0.03f,0.04f,-0.20f),
new Vector3(-0.03f,-0.04f,-0.20f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(0.00f,0.02f,0.02f),
new Vector3(0.00f,-0.02f,0.02f),
new Vector3(0.00f,-0.02f,-0.02f),
new Vector3(0.00f,0.02f,-0.02f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.03f,0.02f,0.02f),
new Vector3(-0.03f,0.02f,-0.02f),
new Vector3(-0.06f,0.02f,-0.02f),
new Vector3(-0.06f,0.02f,0.02f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(0.00f,-0.02f,-0.02f),
new Vector3(-0.03f,-0.02f,-0.02f),
new Vector3(-0.03f,0.02f,-0.02f),
new Vector3(0.00f,0.02f,-0.02f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(0.00f,-0.02f,0.02f),
new Vector3(-0.03f,-0.02f,0.02f),
new Vector3(-0.03f,-0.02f,-0.02f),
new Vector3(0.00f,-0.02f,-0.02f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(0.00f,0.02f,0.02f),
new Vector3(-0.03f,0.02f,0.02f),
new Vector3(-0.03f,-0.02f,0.02f),
new Vector3(0.00f,-0.02f,0.02f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(0.00f,0.02f,-0.02f),
new Vector3(-0.03f,0.02f,-0.02f),
new Vector3(-0.03f,0.02f,0.02f),
new Vector3(0.00f,0.02f,0.02f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.03f,-0.02f,0.02f),
new Vector3(-0.03f,-0.02f,-0.02f),
new Vector3(-0.03f,-0.20f,-0.04f),
new Vector3(-0.03f,-0.20f,0.04f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.03f,-0.02f,0.02f),
new Vector3(-0.03f,0.02f,0.02f),
new Vector3(-0.03f,0.04f,0.20f),
new Vector3(-0.03f,-0.04f,0.20f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.06f,-0.02f,0.02f),
new Vector3(-0.06f,0.02f,0.02f),
new Vector3(-0.06f,0.02f,-0.02f),
new Vector3(-0.06f,-0.02f,-0.02f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.03f,0.02f,-0.02f),
new Vector3(-0.03f,-0.02f,-0.02f),
new Vector3(-0.06f,-0.02f,-0.02f),
new Vector3(-0.06f,0.02f,-0.02f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.03f,-0.02f,0.02f),
new Vector3(-0.03f,0.02f,0.02f),
new Vector3(-0.06f,0.02f,0.02f),
new Vector3(-0.06f,-0.02f,0.02f)
,@"Texture\blade",@"Texture\blade_snow"),

new Quad(new Vector3(-0.03f,-0.02f,-0.02f),
new Vector3(-0.03f,-0.02f,0.02f),
new Vector3(-0.06f,-0.02f,0.02f),
new Vector3(-0.06f,-0.02f,-0.02f)
,@"Texture\blade",@"Texture\blade_snow"),
                #endregion
            };
            chooper.AddQuads(heliBody); // adicionar a lista de poligonos
            chooper.AddQuads(glass);
            chooper.SetPosition(0, 1.5f, 0.5f); // setar posicao do helicoptero
            chooper.SetMainBlade(0, 4.1f, 0.5f, heliMainBlade); // adicionar helices e setar posicoes
            chooper.SetTailBlade(0, 2.6f, -2.5f, heliTailBlade);
            #endregion


            Obj casa = new Obj(@"Texture\Wall", @"Texture\wall_snow");
            #region set da casa
            List<Quad> parede = new List<Quad>
            {
                #region paredes
                new Quad(new Vector3(-1.50f,1.00f,2.75f),
new Vector3(-1.50f,1.00f,0.75f),
new Vector3(-1.50f,0.00f,0.75f),
new Vector3(-1.50f,0.00f,2.75f)
,@"Texture\wall"),

new Quad(new Vector3(-1.50f,3.00f,-3.75f),
new Vector3(-1.50f,2.00f,-3.75f),
new Vector3(-1.50f,2.00f,3.75f),
new Vector3(-1.50f,3.00f,3.75f)
,@"Texture\wall"),

new Quad(new Vector3(-1.50f,2.00f,-1.10f),
new Vector3(-1.50f,1.30f,-1.10f),
new Vector3(-1.50f,1.30f,0.75f),
new Vector3(-1.50f,2.00f,0.75f)
,@"Texture\wall"),

new Quad(new Vector3(-1.50f,0.00f,-3.75f),
new Vector3(-1.50f,3.00f,-3.75f),
new Vector3(1.30f,3.00f,-3.75f),
new Vector3(1.30f,0.00f,-3.75f)
,@"Texture\wall"),

new Quad(new Vector3(-1.50f,1.30f,-1.80f),
new Vector3(-1.50f,2.00f,-1.80f),
new Vector3(-1.50f,2.00f,-3.75f),
new Vector3(-1.50f,1.30f,-3.75f)
,@"Texture\wall"),

new Quad(new Vector3(-1.50f,2.00f,3.75f),
new Vector3(-1.50f,2.00f,2.75f),
new Vector3(-1.50f,0.00f,2.75f),
new Vector3(-1.50f,0.00f,3.75f)
,@"Texture\wall"),

new Quad(new Vector3(-1.50f,1.30f,0.75f),
new Vector3(-1.50f,1.30f,-3.75f),
new Vector3(-1.50f,0.00f,-3.75f),
new Vector3(-1.50f,0.00f,0.75f)
,@"Texture\wall"),

new Quad(new Vector3(0.51f,2.00f,3.75f),
new Vector3(0.51f,0.00f,3.75f),
new Vector3(1.30f,0.00f,3.75f),
new Vector3(1.30f,2.00f,3.75f)
,@"Texture\wall"),

new Quad(new Vector3(1.30f,3.00f,3.75f),
new Vector3(-1.50f,3.00f,3.75f),
new Vector3(-1.50f,2.00f,3.75f),
new Vector3(1.30f,2.00f,3.75f)
,@"Texture\wall"),

new Quad(new Vector3(-1.50f,0.00f,3.75f),
new Vector3(-0.79f,0.00f,3.75f),
new Vector3(-0.79f,1.99f,3.75f),
new Vector3(-1.50f,2.00f,3.75f)
,@"Texture\wall"),

new Quad(new Vector3(1.30f,1.80f,1.40f),
new Vector3(1.30f,1.80f,-1.10f),
new Vector3(1.30f,2.00f,-1.10f),
new Vector3(1.30f,2.00f,1.40f)
,@"Texture\wall"),

new Quad(new Vector3(1.30f,1.80f,1.40f),
new Vector3(1.30f,0.00f,1.40f),
new Vector3(1.30f,0.00f,-1.80f),
new Vector3(1.30f,1.80f,-1.80f)
,@"Texture\wall"),

new Quad(new Vector3(1.30f,0.00f,2.10f),
new Vector3(1.30f,0.00f,1.40f),
new Vector3(1.30f,1.30f,1.40f),
new Vector3(1.30f,1.30f,2.10f)
,@"Texture\wall"),

new Quad(new Vector3(1.30f,2.00f,-1.80f),
new Vector3(1.30f,0.00f,-1.80f),
new Vector3(1.30f,0.00f,-3.75f),
new Vector3(1.30f,2.00f,-3.75f)
,@"Texture\wall"),

new Quad(new Vector3(1.30f,3.00f,3.75f),
new Vector3(1.30f,2.00f,3.75f),
new Vector3(1.30f,2.00f,-3.75f),
new Vector3(1.30f,3.00f,-3.75f)
,@"Texture\wall"),

new Quad(new Vector3(1.30f,2.00f,2.10f),
new Vector3(1.30f,2.00f,3.75f),
new Vector3(1.30f,0.00f,3.75f),
new Vector3(1.30f,0.00f,2.10f)
,@"Texture\wall"),


                #endregion
            };
            teto = new Obj(new List<Quad>
            {new Quad(new Vector3(1.30f, 3.00f, -3.75f),
            new Vector3(-1.50f, 3.00f, -3.75f),
            new Vector3(-1.50f, 3.00f, 3.75f),
            new Vector3(1.30f, 3.00f, 3.75f)
            , @"Texture\helo",@"Texture\helo_snow")});
            teto.SetPosition(0.005f, -1.5f, 0.02f);
            teto.boundinBox = new BoundingBox(new Vector3(-2.00f, 4.00f, -3.00f), new Vector3(2.00f, 4.00f, 3.00f));

            List<Quad> misc = new List<Quad>
            {
                #region misc
		new Quad(new Vector3(1.30f,1.80f,-1.10f),
new Vector3(1.30f,1.80f,-1.80f),
new Vector3(1.30f,2.00f,-1.80f),
new Vector3(1.30f,2.00f,-1.10f)
,@"Texture\wood",@"Texture\wood_snow"),

new Quad(new Vector3(1.30f,1.30f,2.10f),
new Vector3(1.30f,1.30f,1.40f),
new Vector3(1.30f,2.00f,1.40f),
new Vector3(1.30f,2.00f,2.10f)
,@"Texture\wood",@"Texture\wood_snow"),

new Quad(new Vector3(-1.50f,2.00f,1.75f),
new Vector3(-1.50f,2.00f,0.75f),
new Vector3(-1.50f,1.00f,0.75f),
new Vector3(-1.50f,1.00f,1.75f)
,@"Texture\wood",@"Texture\wood_snow"),

new Quad(new Vector3(-1.50f,2.00f,-1.80f),
new Vector3(-1.50f,1.30f,-1.80f),
new Vector3(-1.50f,1.30f,-1.10f),
new Vector3(-1.50f,2.00f,-1.10f)
,@"Texture\wood",@"Texture\wood_snow"),

new Quad(new Vector3(-1.50f,1.00f,1.75f),
new Vector3(-1.50f,1.00f,2.75f),
new Vector3(-1.50f,2.00f,2.75f),
new Vector3(-1.50f,2.00f,1.75f)
,@"Texture\wood",@"Texture\wood_snow"),

new Quad(new Vector3(-0.79f,1.99f,3.75f),
new Vector3(-0.79f,-0.01f,3.75f),
new Vector3(0.51f,-0.01f,3.75f),
new Vector3(0.51f,1.99f,3.75f)
,@"Texture\wood",@"Texture\wood_snow"), 
	#endregion
            };
            #endregion
            casa.AddQuads(misc);
            casa.AddQuads(parede);
            casa.SetPosition(0, -1.5f, 0);

            grid = new Grid("height map", "Ground_Snow", "Ground");

            Ocean ocean = new Ocean("ocean");
            ocean.SetPosition(0, 0, 0);

            #region bloco
            var x = 0;
            var z = 0;
            bil[0] = new Billboard(
                        new Vector3(1, 3, 0),
                        new Vector3(1, 0, 0),
                        new Vector3(-1, 0, 0),
                        new Vector3(-1, 3, 0),
                        @"Texture\arvre",
                        @"Texture\snow_arvre"
                    );
            bil[0].Translate(new Vector3(x + 5, -1.7505f, z + 5));

            bil[1] = new Billboard(
                    new Vector3(1, 3, 0),
                    new Vector3(1, 0, 0),
                    new Vector3(-1, 0, 0),
                    new Vector3(-1, 3, 0),
                    @"Texture\arvre",
                    @"Texture\snow_arvre"
                );
            bil[1].Translate(new Vector3(x + 5, -1.7505f, z + 5));

            bil[2] = new Billboard(
                    new Vector3(1, 3, 0),
                    new Vector3(1, 0, 0),
                    new Vector3(-1, 0, 0),
                    new Vector3(-1, 3, 0),
                    @"Texture\arvre",
                    @"Texture\snow_arvre"
                );
            bil[2].Translate(new Vector3(x + 5, -1.7505f, z + 10));

            bil[3] = new Billboard(
                    new Vector3(1, 3, 0),
                    new Vector3(1, 0, 0),
                    new Vector3(-1, 0, 0),
                    new Vector3(-1, 3, 0),
                    @"Texture\arvre",
                    @"Texture\snow_arvre"
                );
            bil[3].Translate(new Vector3(x + 5, -1.7505f, z + 15)); 
            #endregion

            #region bloco
            x = 2;
            z = 5;
            bil[4] = new Billboard(
                        new Vector3(1, 3, 0),
                        new Vector3(1, 0, 0),
                        new Vector3(-1, 0, 0),
                        new Vector3(-1, 3, 0),
                        @"Texture\arvre",
                        @"Texture\snow_arvre"
                    );
            bil[4].Translate(new Vector3(x + 5, -1.7505f, z + 5));

            bil[5] = new Billboard(
                    new Vector3(1, 3, 0),
                    new Vector3(1, 0, 0),
                    new Vector3(-1, 0, 0),
                    new Vector3(-1, 3, 0),
                    @"Texture\arvre",
                    @"Texture\snow_arvre"
                );
            bil[5].Translate(new Vector3(x + 5, -1.7505f, z + 5));

            bil[6] = new Billboard(
                    new Vector3(1, 3, 0),
                    new Vector3(1, 0, 0),
                    new Vector3(-1, 0, 0),
                    new Vector3(-1, 3, 0),
                    @"Texture\arvre",
                    @"Texture\snow_arvre"
                );
            bil[6].Translate(new Vector3(x + 5, -1.7505f, z + 10));

            bil[7] = new Billboard(
                    new Vector3(1, 3, 0),
                    new Vector3(1, 0, 0),
                    new Vector3(-1, 0, 0),
                    new Vector3(-1, 3, 0),
                    @"Texture\arvre",
                    @"Texture\snow_arvre"
                );
            bil[7].Translate(new Vector3(x + 5, -1.7505f, z + 15));
            #endregion

            //TODO: Create sets
            //TODO: Include objects on set
            List<Obj> sceneSet = new List<Obj> 
            {
                chooper,
                teto,
                casa,
                grid,
                ocean
            };

            //TODO: Create scenes
            //TODO: Insert the set of objects on scene
            actualScene = new Scene(sceneSet, "Cena 1");

            //TODO: add the scences
            scenes = new List<Scene>();
            scenes.Add(actualScene);
        }

        public static void Update(GameTime gameTime)
        {
            //TODO: Logic to update a scene
            if (actualCamera == freeCamera)
            {
                if ((chooper.GetState() == STATE.parado || chooper.GetState() == STATE.ligado) && teto.GetBoudingBox().Intersects(actualCamera.GetBoundingBox()))
                {
                    actualCamera.SetPosition(actualCamera.GetPosition() + Vector3.Up);
                    actualCamera = chopCamera;
                }
            }
            else
            {
                chooper.SetActualState(STATE.parado);
                chooper.ResetTimer();
                if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) && actualCamera == chopCamera)
                {
                    actualCamera = freeCamera;
                }
            }

            foreach (Billboard b in bil)
            {
                b.Update(actualCamera);
            }

            //TODO: Vou ordenar os billboard


            //TODO: Logic to update a scene
            actualCamera.Update(gameTime);
            actualScene.Update(gameTime);
        }

        public static void Draw()
        {
            //TODO: Logic to draw a scene
            actualScene.Draw(actualCamera);

            SelectionSort(bil);

            foreach (Billboard b in bil)
            {
                b.Draw(actualCamera);
            }
        }

        public static Scene GetActualScene()
        {
            return actualScene;
        }

        static void SelectionSort(Billboard[] vetor)
        {
            for (int indice = 0; indice < vetor.Length; ++indice)
            {
                int indiceMenor = indice;
                for (int indiceSeguinte = indice + 1; indiceSeguinte < vetor.Length; ++indiceSeguinte)
                {
                    if (vetor[indiceSeguinte].distance > vetor[indiceMenor].distance)
                    {
                        indiceMenor = indiceSeguinte;
                    }
                }
                Billboard aux = vetor[indice];
                vetor[indice] = vetor[indiceMenor];
                vetor[indiceMenor] = aux;
            }
        }
    }
}
