using System.Xml.Linq;
using Microsoft.Playwright;

namespace small_task
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {

        private IBrowser browser;


        [Test]
        public async Task TC01_FirstTest()
        {

            //Step 1: Here i launched the browser and navigated to Sauce Labs
            browser =  await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.saucedemo.com/");   



            //Step 2: I entered valid credentials and Logged in
            await page.FillAsync("[name=\'user-name']","standard_user");
            await page.FillAsync("[name=\'password']", "secret_sauce");
            await page.ClickAsync("[name=\'login-button']");



            //Step 3: Here i validated that it took me to the inventory page after log in
            await Expect(page).ToHaveURLAsync("https://www.saucedemo.com/inventory.html");



            //Step 4: I used the item name to select an item wit name "Sauce Labs Bolt T-Shirt"
            await page.ClickAsync("text='Sauce Labs Bolt T-Shirt'");



            //Step 5:Here i verified that the details page of the item i selected opens up
            await Expect(page).ToHaveURLAsync(new Regex(".*inventory-item.html.*"));



            //Step 6: I added the item to cart by clicking add to cart button
            await page.ClickAsync("[name=\'add-to-cart']");


            //Step 7: I verified that the item was added to cart by checking the badge
            var cartCount = await page.InnerTextAsync(".shopping_cart_badge");
            Assert.AreEqual("1", cartCount);


            //Step 8: Navigated to the cart screen by pressing the cart button
            await page.ClickAsync(".shopping_cart_link");



            // Step 9: Verify the cart page is displayed
            await Expect(page).ToHaveURLAsync("https://www.saucedemo.com/cart.html");



            // Step 10: Here i verified the item name matched the item I added to cart
            var cartItemName = await page.InnerTextAsync(".inventory_item_name");
            Assert.AreEqual("Sauce Labs Bolt T-Shirt", cartItemName);

            //Here i verified the price also matched 
            var cartItemPrice = await page.InnerTextAsync(".inventory_item_price");
            Assert.AreEqual("$15.99", cartItemPrice);


            //Here i verfied the item description matched as well
            var cartItemDescription = await page.InnerTextAsync(".inventory_item_desc");
            Assert.AreEqual("Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.", cartItemDescription);


            //Step 11: I checked out by clicking the checkout button
            await page.ClickAsync("button[id='checkout']");


            //Step 12: veified that the checkout pages is displayed
            await Expect(page).ToHaveURLAsync("https://www.saucedemo.com/checkout-step-one.html");


            //Step 13: Filled the form to check out
            await page.FillAsync("[name='firstName']", "kelvin");
            await page.FillAsync("[name = 'lastName']", "vershima");
            await page.FillAsync("[name = 'postalCode']", "12345");


            //Step 14: Clicked the continue button to checkout
            await page.ClickAsync("#continue");


            // Step 15: Verify order summary page is displayed
            await Expect(page).ToHaveURLAsync("https://www.saucedemo.com/checkout-step-two.html");


            //Step 16: Clciekd on the Finish button
            await page.ClickAsync("#finish");


            //Step 17: Verified the order confirmation page is displayed by checking for the text Checkout: Complete!
            await Expect(page).ToHaveURLAsync("https://www.saucedemo.com/checkout-complete.html");
            var confirmationMessage = await page.InnerTextAsync(".title");
            Assert.AreEqual("Checkout: Complete!", confirmationMessage);


            //Step 18: Looged user out
            await page.ClickAsync("#react-burger-menu-btn");
            await page.ClickAsync("#logout_sidebar_link");



            // Step 19: Verify redirection to the login page
            await Expect(page).ToHaveURLAsync("https://www.saucedemo.com/");



            // Close browser
            await browser.CloseAsync();

        }
    }
}
