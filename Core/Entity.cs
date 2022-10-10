﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeoTheLegion.Core
{
    public abstract class Entity
    {
        protected Vector2 _position;
        protected int sort = -1;
        protected bool _active;

        public delegate void OnDestroy(Entity e);
        public event OnDestroy _OnDestroy;
        protected Entity()
        {
            _active = true;
            EntityManagementSystem.Register(this);
        }

        public abstract void Start();

        public abstract void Update(GameTime gameTime);
        public abstract void Render(SpriteBatch _spriteBatch);
        public virtual void Destroy()
        {
            _OnDestroy?.Invoke(this);
            EntityManagementSystem.Unregister(this);
        }

        public virtual Entity SetSort(int x) {
            sort = x;
            return this;
        }

        public virtual int GetSort() { return sort; } 
        public virtual void SetActive(bool active) => _active = active;
        public virtual bool GetActive() { return _active; }

        public void SetPosition(Vector2 position) => this._position = position;

        public Vector2 GetPosition()
        {
            return this._position;
        }
    }
}
