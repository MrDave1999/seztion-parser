using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeztionParser.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using SeztionParser.Helpers;

namespace SeztionParser.Tests
{
    [TestClass]
    public class SingleLineSectionTests
    {
        [TestMethod]
        public void GetFirstLineDecimal_IsTheConversionValid_ReturnDecimal()
        {
            // Arrange
            string data = @"
                [section1]
                12.456
            ";
            var sections = new SectionsParser().Parse(data);
            decimal expected = 12.456M;

            // Act
            decimal actual = sections.GetFirstLineDecimal("section1");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstLineDouble_IsTheConversionValid_ReturnDouble()
        {
            // Arrange
            string data = @"
                [section1]
                12.456
            ";
            var sections = new SectionsParser().Parse(data);
            double expected = 12.456;

            // Act
            double actual = sections.GetFirstLineDouble("section1");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstLineFloat_IsTheConversionValid_ReturnFloat()
        {
            // Arrange
            string data = @"
                [section1]
                12.456
            ";
            var sections = new SectionsParser().Parse(data);
            float expected = 12.456f;

            // Act
            float actual = sections.GetFirstLineFloat("section1");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstLineInt_IsTheConversionValid_ReturnInt()
        {
            // Arrange
            string data = @"
                [section1]
                12
            ";
            var sections = new SectionsParser().Parse(data);
            int expected = 12;

            // Act
            int actual = sections.GetFirstLineInt("section1");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstLineLong_IsTheConversionValid_ReturnLong()
        {
            // Arrange
            string data = @"
                [section1]
                12
            ";
            var sections = new SectionsParser().Parse(data);
            long expected = 12;

            // Act
            long actual = sections.GetFirstLineLong("section1");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
