﻿namespace King.Mapper.Tests
{
    using King.Mapper.Tests.Models;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class PropertyInfoTests
    {
        [Test]
        public void GetAttributesPropertyNull()
        {
            PropertyInfo info = null;
            Assert.That(() => info.GetAttributes<ActionNameAttribute>(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void GetAttributePropertyNull()
        {
            PropertyInfo info = null;
            Assert.That(() => info.GetAttribute<ActionNameAttribute>(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void GetAttributes()
        {
            var info = (from p in typeof(TestActionNames).GetProperties()
                        where p.Name == "Song"
                        select p).FirstOrDefault();

            Assert.IsNotNull(info);

            var attrs = info.GetAttributes<ActionNameAttribute>();
            Assert.AreEqual(2, attrs.Count());
            var action = (from a in attrs
                          where a.Action == ActionFlags.Execute
                          && a.Name == "Insert"
                          select a).FirstOrDefault();
            Assert.IsNotNull(action);
            action = (from a in attrs
                      where a.Action == ActionFlags.Load
                      && a.Name == "GuidGuid"
                      select a).FirstOrDefault();
            Assert.IsNotNull(action);
        }

        [Test]
        public void GetAttribute()
        {
            var info = (from p in typeof(TestActionNames).GetProperties()
                        where p.Name == "Id"
                        select p).FirstOrDefault();

            Assert.IsNotNull(info);

            var action = info.GetAttribute<ActionNameAttribute>();
            Assert.IsNotNull(action);
            Assert.AreEqual("MyIdentifier", action.Name);
            Assert.AreEqual(ActionFlags.Execute, action.Action);
        }

        [Test]
        public void GetAttributesNull()
        {
            PropertyInfo info = null;
            Assert.That(() => info.GetAttribute<ActionNameAttribute>(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SetPropertyNull()
        {
            PropertyInfo info = null;
            Assert.That(() => info.Set(new object()), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SetOwnerNull()
        {
            var info = typeof(FillObject).GetProperties()[0];
            Assert.That(() => info.Set(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void SetPropertyNullableGuid()
        {
            var data = new FillObject();
            var info = (from p in data.GetType().GetProperties()
                        where p.Name == "TheGuid"
                        select p).FirstOrDefault();
            info.Set(data, null);
            Assert.IsNull(data.TheGuid);
        }

        [Test]
        public void SetPropertyGuid()
        {
            var expected = Guid.NewGuid();
            var data = new FillObject();
            var info = (from p in data.GetType().GetProperties()
                        where p.Name == "Song"
                        select p).FirstOrDefault();
            info.Set(data, expected);

            Assert.AreEqual(expected, data.Song);
        }

        [Test]
        public void SetPropertyNullableEnum()
        {
            var data = new FillObject();
            var info = (from p in data.GetType().GetProperties()
                        where p.Name == "NullableEnum"
                        select p).FirstOrDefault();
            info.Set(data, null);
            Assert.IsNull(data.NullableEnum);
        }

        [Test]
        public void SetPropertyEnum()
        {
            var expected = HappyLand.MarioLand;
            var data = new FillObject();
            var info = (from p in data.GetType().GetProperties()
                        where p.Name == "SuperEnum"
                        select p).FirstOrDefault();
            info.Set(data, expected);

            Assert.AreEqual(expected, data.SuperEnum);
        }
    }
}