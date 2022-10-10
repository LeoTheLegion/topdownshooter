using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LeoTheLegion.Core
{
    public class EntityManagementSystem
    {
        private List<Entity> _entities = new List<Entity>();
        private static EntityManagementSystem _INSTANCE;
        private bool hasStarted = false;

        public delegate void OnRegister(Entity e);
        public event OnRegister _OnRegister;

        public delegate void OnUnregister(Entity e);
        public event OnUnregister _OnUnregister;

        public EntityManagementSystem()
        {
            _INSTANCE = this;
        }

        public static void Register(Entity e)
        {
            _INSTANCE._entities.Add(e);

            if(_INSTANCE.hasStarted)
                e.Start();

            _INSTANCE._OnRegister?.Invoke(e);
        }
        public static void Unregister(Entity e)
        {
            _INSTANCE._entities.Remove(e);
            _INSTANCE._OnUnregister?.Invoke(e);
        }

        public void Start()
        {
            for (int i = 0; i < _entities.Count; i++)
            {
                 _entities[i].Start();
            }

            hasStarted = true;
        }

        public void Update(GameTime _gameTime)
        {
            _entities.Sort(
                (x, y) => x.GetSort().CompareTo(y.GetSort())
                );

            for (int i = 0; i < _entities.Count; i++)
            {
                if (_entities[i].GetActive())
                    _entities[i].Update(_gameTime);
            }
        }

        public void Render(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < _entities.Count; i++)
            {
                if (_entities[i].GetActive())
                    _entities[i].Render(_spriteBatch);
            }
        }


    }
}
