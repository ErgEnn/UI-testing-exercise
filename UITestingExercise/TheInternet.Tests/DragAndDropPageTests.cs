using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TheInternet.Tests
{
    [TestClass]
    public class DragAndDropPageTests : BaseWebPageTest
    {

        [TestMethod]
        public void ShouldBeInABOrderByDefault()
        {
            new HomePage(Driver).ClickDragAndDropLink();
            var dnd = new DragAndDropPage(Driver);
            dnd.Elements().Should().ContainInOrder("A", "B");
        }

        [TestMethod]
        public void ShouldBeInBAOrderAfterDragAndDrop()
        {
            new HomePage(Driver).ClickDragAndDropLink();
            var dnd = new DragAndDropPage(Driver);
            dnd.DragFromColAToColB();
            dnd.Elements().Should().ContainInOrder("B", "A");
        }

    }
}
