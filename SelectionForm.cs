using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace expTool
{
    public partial class SelectionForm : Form
    {
        private Point startPoint;
        private Point endPoint;
        private bool isSelecting = false;
        public Rectangle SelectedArea { get; private set; }

        public SelectionForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;
            this.Opacity = 0.3;
            this.Cursor = Cursors.Cross;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            isSelecting = true;
            startPoint = e.Location;
            endPoint = e.Location;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isSelecting)
            {
                endPoint = e.Location;
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isSelecting = false;
            SelectedArea = GetRectangle(startPoint, endPoint);
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (isSelecting)
            {
                Rectangle rect = GetRectangle(startPoint, endPoint);
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y)
            );
        }
    }
}
