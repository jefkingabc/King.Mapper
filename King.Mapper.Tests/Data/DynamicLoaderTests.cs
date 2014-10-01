﻿namespace King.Mapper.Tests.Data
{
    using King.Mapper.Data;
    using NUnit.Framework;
    using System;
    using System.Data;

    [TestFixture]
    public class DynamicLoaderTests
    {
        [Test]
        public void Constructor()
        {
            new DynamicLoader();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DictionaryDataTableNull()
        {
            var l = new DynamicLoader();
            l.Dictionary((DataTable)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DictionariesDataTableNull()
        {
            var l = new DynamicLoader();
            l.Dictionaries((DataTable)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DictionaryDataSetNull()
        {
            var l = new DynamicLoader();
            l.Dictionary((DataSet)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DictionariesDataSetNull()
        {
            var l = new DynamicLoader();
            l.Dictionaries((DataSet)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DictionaryIDataReaderNull()
        {
            var l = new DynamicLoader();
            l.Dictionary((IDataReader)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DictionariesIDataReaderNull()
        {
            var l = new DynamicLoader();
            l.Dictionaries((IDataReader)null);
        }
    }
}