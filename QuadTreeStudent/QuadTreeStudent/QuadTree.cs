﻿using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace QuadTreeStudent
{
	class QuadTreeNode
	{
		#region Constants
		// The maximum number of objects in a quad
		// before a subdivision occurs
		private const int MAX_OBJECTS_BEFORE_SUBDIVIDE = 3;
		#endregion

		#region Variables
		// The game objects held at this level of the tree
		private List<GameObject> _objects;

		// This quad's rectangle area
		private Rectangle _rect;

		// This quad's divisions
		private QuadTreeNode[] _divisions;
		#endregion

		#region Properties
		/// <summary>
		/// The divisions of this quad
		/// </summary>
		public QuadTreeNode[] Divisions { get { return _divisions; } }

		/// <summary>
		/// This quad's rectangle
		/// </summary>
		public Rectangle Rectangle { get { return _rect; } }

		/// <summary>
		/// The game objects inside this quad
		/// </summary>
		public List<GameObject> GameObjects { get { return _objects; } }
		#endregion

		#region Constructor
		/// <summary>
		/// Creates a new Quad Tree
		/// </summary>
		/// <param name="x">This quad's x position</param>
		/// <param name="y">This quad's y position</param>
		/// <param name="width">This quad's width</param>
		/// <param name="height">This quad's height</param>
		public QuadTreeNode(int x, int y, int width, int height)
		{
			// Save the rectangle
			_rect = new Rectangle(x, y, width, height);

			// Create the object list
			_objects = new List<GameObject>();

			// No divisions yet
			_divisions = null;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Adds a game object to the quad.  If the quad has too many
		/// objects in it, and hasn't been divided already, it should
		/// be divided
		/// </summary>
		/// <param name="gameObj">The object to add</param>
		public bool AddObject(GameObject gameObj)
		{
            if (_rect.Contains(gameObj.Rectangle))
            {
                if (_divisions != null)
                    foreach (QuadTreeNode sub in _divisions)
                    {
                        if (sub.AddObject(gameObj)) return true;
                    }
                _objects.Add(gameObj);
                if (_objects.Count > MAX_OBJECTS_BEFORE_SUBDIVIDE) Divide();
                return true;
            }
            else return false;
		}

		/// <summary>
		/// Divides this quad into 4 smaller quads.  Moves any game objects
		/// that are completely contained within the new smaller quads into
		/// those quads and removes them from this one.
		/// </summary>
		public void Divide()
		{
            _divisions = new QuadTreeNode[4];
            _divisions[0] = new QuadTreeNode(_rect.X + _rect.Width / 2, _rect.Y, _rect.Width / 2, _rect.Height / 2);
            _divisions[1] = new QuadTreeNode(_rect.X, _rect.Y, _rect.Width / 2, _rect.Height / 2);
            _divisions[2] = new QuadTreeNode(_rect.X, _rect.Y + _rect.Height / 2, _rect.Width / 2, _rect.Height / 2);
            _divisions[3] = new QuadTreeNode(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2, _rect.Width / 2, _rect.Height / 2);
            for(int i = 0; i < _objects.Count; i++)
            {
                foreach (QuadTreeNode sub in _divisions)
                {
                    if (sub.AddObject(_objects[i]))
                    {
                        _objects.Remove(_objects[i]);
                        i--;
                        break;
                    }
                }
            }
        }

		/// <summary>
		/// Recursively populates a list with all of the rectangles in this
		/// quad and any subdivision quads.  Use the "AddRange" method of
		/// the list class to add the elements from one list to another.
		/// </summary>
		/// <returns>A list of rectangles</returns>
		public List<Rectangle> GetAllRectangles()
		{
			List<Rectangle> rects = new List<Rectangle>();
            rects.Add(_rect);
            if(_divisions != null)
                foreach (QuadTreeNode sub in _divisions)
                    rects.AddRange(sub.GetAllRectangles());
			return rects;
		}

		/// <summary>
		/// A possibly recursive method that returns the
		/// smallest quad that contains the specified rectangle
		/// </summary>
		/// <param name="rect">The rectangle to check</param>
		/// <returns>The smallest quad that contains the rectangle</returns>
		public QuadTreeNode GetContainingQuad(Rectangle rect)
		{
            QuadTreeNode result = null;
            if (_rect.Contains(rect))
            {
                result = this;
                if (_divisions != null)
                    foreach (QuadTreeNode sub in _divisions)
                    {
                        result = sub.GetContainingQuad(rect) ?? result;
                    }
            }
            return result;
		}
		#endregion
	}
}
