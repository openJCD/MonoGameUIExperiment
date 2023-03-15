using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Serialization;

namespace gameExperiment
{
    [DataContract]
    public class ScreenManager : IDrawable
    {
        [DataMember]
        List<screenWidget> screenWidgets { get; set; }
        public ScreenManager ()
        {
            screenWidgets = new List<screenWidget>();
        }

        public void LoadFromJson(string path, ScreenManager manager)
        {
            manager = new ScreenManager();
            string document = File.ReadAllText(path);
            //manager.screenWidgets = JsonSerializer.Deserialize<List<screenWidget>>(document);

        }

        public void LoadContent (ContentManager contentManager)
        {
            foreach (screenWidget screenWidget in screenWidgets)
            {
                screenWidget.LoadContent(contentManager);
            }
        }
        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (screenWidget screenWidget in screenWidgets)
            {
                screenWidget.Draw(spriteBatch);
            }
            
            spriteBatch.End();
        }

        public void Update()
        {
            foreach (screenWidget screenWidget in screenWidgets)
            {
                screenWidget.Update();
            }
        }
    }
}
