using System;
using SplashKitSDK;
using NUnit.Framework;

namespace Option2
{
    [TestFixture()]
    public class ShapeTest
    {
        [Test()]
        public void TestShapeAt()
        {
            Rectangle1 s = new Rectangle1();
            s.X = 25;
            s.Y = 25;
            s.Width = 50;
            s.Height = 50;

            Assert.IsTrue(s.IsAt(SplashKit.PointAt(50, 50)));
            Assert.IsTrue(s.IsAt(SplashKit.PointAt(25, 25)));
            Assert.IsFalse(s.IsAt(SplashKit.PointAt(10, 50)));
            Assert.IsFalse(s.IsAt(SplashKit.PointAt(50, 10)));
        }

        [Test()]
        public void TestShapeAtWhenMoved()
        {
            Rectangle1 s = new Rectangle1();
            s.X = 25;
            s.Y = 25;
            s.Width = 50;
            s.Height = 50;

            Assert.IsTrue(s.IsAt(SplashKit.PointAt(50, 50)));

            s.X = 100;
            s.Y = 100;

            Assert.IsFalse(s.IsAt(SplashKit.PointAt(50, 50)));
        }

        [Test()]
        public void TestShapeAtWhenResized()
        {
            Rectangle1 s = new Rectangle1();
            s.X = 25;
            s.Y = 25;
            s.Width = 50;
            s.Height = 50;

            Assert.IsTrue(s.IsAt(SplashKit.PointAt(70, 70)));

            s.Width = 5;
            s.Height = 5;

            Assert.IsFalse(s.IsAt(SplashKit.PointAt(70, 70)));
        }

        [Test()]
        public void TestSelected()
        {
            Shape s = new Rectangle1();
            s.Selected = true;
            Assert.IsTrue(s.Selected);

            s.Selected = false;
            Assert.IsFalse(s.Selected);
        }
    }
}