using System;
using System.Collections.Generic;
using SplashKitSDK;
using NUnit.Framework;
using System.Net.NetworkInformation;

namespace Option2
{
    [TestFixture()]
    public class DrawingTest
    {
        [Test()]
        public void TestDefaultInitialization()
        {
            Drawing myDrawing = new Drawing();
            Assert.AreEqual(myDrawing.Background, Color.White);
        }

        [Test()]
        public void TestInitialiseWithColor()
        {
            Drawing myDrawing = new Drawing(Color.Green);
            Assert.AreEqual(myDrawing.Background, Color.Green);
        }

        [Test()]
        public void TestAddShape()
        {
            Drawing myDrawing = new Drawing();
            int count = myDrawing.ShapeCount;

            Assert.AreEqual(0, count);
            
            myDrawing.AddShape(new Rectangle1());
            myDrawing.AddShape(new Rectangle1());

            count = myDrawing.ShapeCount;

            Assert.AreEqual(2, count);
        }

        [Test()]
        public void TestSelectShape()
        {
            Drawing myDrawing  = new Drawing();
            Shape[] testShapes =
            {
                new Rectangle1(Color.Red, 25, 25, 50, 50),
                new Rectangle1(Color.Green, 25, 10, 50, 50),
                new Rectangle1(Color.Blue, 10, 25, 50, 50)
            };

            foreach(Shape s in testShapes)
            {
                myDrawing.AddShape(s);
            }

            List<Shape> selected;
            Point2D point;

            point = SplashKit.PointAt(70, 70);
            myDrawing.SelectShapeAt(point);
            selected = myDrawing.SelectedShapes;
            CollectionAssert.Contains(selected, testShapes[0]);
            Assert.AreEqual(1, selected.Count);

            point = SplashKit.PointAt(70, 50);
            myDrawing.SelectShapeAt(point);
            selected = myDrawing.SelectedShapes;
            CollectionAssert.Contains(selected, testShapes[0]);
            CollectionAssert.Contains(selected, testShapes[1]);
            Assert.AreEqual(2, selected.Count);
         }

         [Test()]
         public void TestRemoveShape()
        {
            Drawing myDrawing = new Drawing();
            Shape[] testShapes =
            {
                new Rectangle1(Color.Red, 25, 25, 50, 50),
                new Rectangle1(Color.Green, 25, 10, 50, 50),
                new Rectangle1(Color.Blue, 10, 25, 50, 50)
            };

            foreach (Shape s in testShapes)
            {
                myDrawing.AddShape(s);
            }

            List<Shape> selected;
            Point2D point;

            point = SplashKit.PointAt(70, 70);
            myDrawing.SelectShapeAt(point);
            selected = myDrawing.SelectedShapes;
            CollectionAssert.Contains(selected, testShapes[0]);
            Assert.AreEqual(1, selected.Count);

            myDrawing.RemoveShape(testShapes[0]);
            selected = myDrawing.SelectedShapes;
            CollectionAssert.DoesNotContain(selected, testShapes[0]);   
            Assert.AreEqual(0, selected.Count);
        }
    }
}
