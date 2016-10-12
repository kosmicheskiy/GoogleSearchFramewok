using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using GoogleSearchFramewok;

namespace GoogleTest
{

    [TestFixture]
    public class TestSettings
    {
        [SetUp]
        public void Init()
        {
            Driver.Initialize();
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}
