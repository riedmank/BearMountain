using System;
using Xunit;
using BearMountain.Models;

namespace BearMountainTests
{
    public class UnitTest1
    {
        /// <summary>
        /// Determines whether this instance [can set sku].
        /// </summary>
        [Fact]
        public void CanSetSKU()
        {
            Product item = new Product();
            item.SKU = "test";

            Assert.Equal("test", item.SKU);
        }

        /// <summary>
        /// Determines whether this instance [can get sku].
        /// </summary>
        [Fact]
        public void CanGetSKU()
        {
            Product item = new Product();
            item.SKU = "test";

            Assert.Equal("test", item.SKU);
        }

        /// <summary>
        /// Determines whether this instance [can set name].
        /// </summary>
        [Fact]
        public void CanSetName()
        {
            Product item = new Product();
            item.Name = "test";

            Assert.Equal("test", item.Name);
        }

        /// <summary>
        /// Determines whether this instance [can get name].
        /// </summary>
        [Fact]
        public void CanGetName()
        {
            Product item = new Product();
            item.Name = "test";

            Assert.Equal("test", item.Name);
        }

        /// <summary>
        /// Determines whether this instance [can set price].
        /// </summary>
        [Fact]
        public void CanSetPrice()
        {
            Product item = new Product();
            item.Price = 7.42m;

            Assert.Equal(7.42m, item.Price);
        }

        /// <summary>
        /// Determines whether this instance [can get price].
        /// </summary>
        [Fact]
        public void CanGetPrice()
        {
            Product item = new Product();
            item.Price = 7.42m;

            Assert.Equal(7.42m, item.Price);
        }

        /// <summary>
        /// Determines whether this instance [can set desription].
        /// </summary>
        [Fact]
        public void CanSetDesription()
        {
            Product item = new Product();
            item.Description = "test";

            Assert.Equal("test", item.Description);
        }

        /// <summary>
        /// Determines whether this instance [can get description].
        /// </summary>
        [Fact]
        public void CanGetDescription()
        {
            Product item = new Product();
            item.Description = "test";

            Assert.Equal("test", item.Description);
        }

        /// <summary>
        /// Determines whether this instance [can set image].
        /// </summary>
        [Fact]
        public void CanSetImage()
        {
            Product item = new Product();
            item.Image = "test";

            Assert.Equal("test", item.Image);
        }

        /// <summary>
        /// Determines whether this instance [can get image].
        /// </summary>
        [Fact]
        public void CanGetImage()
        {
            Product item = new Product();
            item.Image = "test";

            Assert.Equal("test", item.Image);
        }
    }
}
