using System;
using System.Collections.Generic;
using _01_CafeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTest
{

    /*The Menu Items:
A meal number, so customers can say "I'll have the #5"
A meal name
A description
A list of ingredients,
A price

Your Task:
Create a Menu Class with properties, constructors, and fields.
Create a MenuRepository Class that has methods needed.
Create a Test Class for your repository methods. (You don't need to test your constructors or objects, just your methods)
Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.

Notes:
We don't need to be able to update items right now.*/


    [TestClass]
    public class CafeTest
    {
        private Menu _item;
        private MenuRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _item = new Menu(1, "cheeseburger", "Our spin on the All-American Classic, with fries and drink included.", new List<string> { "bun", "patty", "cheese", "lettuce", "tomato", "pickle" }, 4.99m );
            _repo.AddMenuItem(_item);
        }

        [TestMethod]
        public void AddMenuItem_ShouldReturnAreEqual()
        {
            //Arrange       //adding the item up above in TestInitialize, so no need to do it again here
            //_repo.AddMenuItem(_item);

            //Act
            int expected = 1;
            int actual = _repo.DisplayMenuItems().Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMenuItemByName_ShouldReturnCorrectItem()
        {
            Menu searchedItem = _repo.GetMenuItemByName("cheeseburger");
            Assert.AreEqual("cheeseburger", searchedItem.MealName);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnAreEqual()
        {
            //Arrange
            _repo.DeleteMenuItem(_item);

            //Act
            int expected = -1;
            int actual = _repo.DisplayMenuItems().Count;

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void DisplayMenuItems_ShouldReturnFullMenuList()
        {
            //Arrange
            Menu testItem = new Menu();
            MenuRepository testRepo = new MenuRepository();
            testRepo.AddMenuItem(testItem);

            //Act
            List<Menu> testMenu = testRepo.DisplayMenuItems();
            bool menuHasItems = testMenu.Contains(testItem);

            //Assert
            Assert.IsTrue(menuHasItems);
        }
    }
}
