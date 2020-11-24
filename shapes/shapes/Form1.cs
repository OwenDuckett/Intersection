using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace shapes
{
    public partial class Form1 : Form
    {
        public List<Shape> shapes = new List<Shape>();

        public Form1()
        {
            InitializeComponent();

            // Rectangle one
            shapes.Add(new Rectangle(2, new Point(80, 70), new Point(400, 70), new Point(80, 170), new Point(400, 170)));

            // Rectangle two
            shapes.Add(new Rectangle(3, new Point(130, 120), new Point(150, 120), new Point(130, 1000), new Point(150, 1000)));

            // Cirlce
            Point[] center = { new Point(70, 70) };
            Circle circle = new Circle(1, center, 60);
            shapes.Add(circle);

            // Cirlce
            Point[] center2 = { new Point(420, 140) };
            Circle circle2 = new Circle(4, center2, 30);
            shapes.Add(circle2);


            this.Paint += this.Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red, 10);

            Rectangle r1 = (Rectangle)shapes[0];
            System.Drawing.Point[] rectangleTwo = r1.GetSystemPoints();
            g.DrawPolygon(p, rectangleTwo);

            Rectangle r2 = (Rectangle)shapes[1];
            System.Drawing.Point[] rectanleThree = r2.GetSystemPoints();
            g.DrawPolygon(p, rectanleThree);
            //System.Drawing.Rectangle r = new System.Drawing.Rectangle();
            //g.DrawRectangle(p, );

            Circle circle = (Circle)shapes[2];
            //Create location and size of ellipse.
            int x = circle.GetCoordinates()[0]._x;
            int y = circle.GetCoordinates()[0]._y;
            int radius = circle._radius;

            // Draw ellipse to screen.
            e.Graphics.DrawCircle(p, x, y, radius);

            Circle circle1 = (Circle)shapes[3];
            //Create location and size of ellipse.
            int x1 = circle1.GetCoordinates()[0]._x;
            int y1 = circle1.GetCoordinates()[0]._y;
            int radius1 = circle1._radius;

            // Draw ellipse to screen.
            e.Graphics.DrawCircle(p, x1, y1, radius1);

            g.Dispose();

            FindIntersections(shapes);
        }

        public Dictionary<int, List<int>> FindIntersections(List<Shape> shapes)
        {
            Dictionary<int, List<int>> intersectingShapes = new Dictionary<int, List<int>>();

            foreach (Shape shape in shapes)
            {
                List<int> shapeIds = shape.GetIntersectingShapes(shapes);
                intersectingShapes.Add(shape._id, shapeIds);
            }
       
            return intersectingShapes;
        }

        
    }
}

public static class GraphicsExtensions
{
    // Created to draw a circle with a radius simply.
    public static void DrawCircle(this Graphics g, Pen pen,
                                  float centerX, float centerY, float radius)
    {
        g.DrawEllipse(pen, centerX - radius, centerY - radius,
                      radius + radius, radius + radius);
    }
}
