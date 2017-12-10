﻿using Roro.Activities;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Roro.Workflow
{
    public sealed class LoopStartNode : Node
    {
        public LoopStartNode()
        {
            this.Ports.Add(new NextPort());
        }

        public override GraphicsPath Render(Graphics g, Rectangle r, NodeStyle o)
        {
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddPolygon(new Point[]
            {
                new Point(r.X + PageRenderOptions.GridSize, r.Y),
                new Point(r.Right - PageRenderOptions.GridSize, r.Y),
                new Point(r.Right, r.Y + PageRenderOptions.GridSize),
                new Point(r.Right, r.Bottom),
                new Point(r.X, r.Bottom),
                new Point(r.X, r.Y + PageRenderOptions.GridSize)
            });
            path.CloseFigure();
            //
            g.FillPath(o.BackBrush, path);
            g.DrawPath(o.BorderPen, path);
            return path;
        }

        public override Size GetSize() => new Size(4, 2);
    }
}