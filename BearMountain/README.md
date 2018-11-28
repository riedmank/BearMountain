# Bear Mountain E-Commerce Platform  
We sell various sporting goods for the adventurous who love the outdoors.  
The claims we are capturing upon registration are the user's full name and the user's email address.  We are capturing these claims because they will be used to authorize users access to different pages on the site.
We are enforcing an email policy: over user's with an email ending with "@bearmountain.com".  Users without this email address will be unable to access a shopping cart feature of our platform.  We chose this policy mostly for marketing purposes and brand recognition.  

Link to deployed site:  
https://bearmountain.azurewebsites.net  

#Database Schema  

![BearMountainDb Schema](../assets/BearMountainDb.png "Bear Mountain Db Schema")

## Products
The products table contains all product information including: ID, SKU, Name, Description, Price, and Image. The ID is used as a primary key which is referenced in the Basket Items table.  

## Basket Items
The basket items table contains all the products that a user has added to his or her basket. The table contains an ID, User Basket ID, Product ID, Quantity, and CheckedOut properties. The CheckedOut property is used to indicate whether the product has been checked out, or purchased. It has navigation properties with the Products and User Basket.  

## User Basket 
The user basket table is used to assign a user to a basket ID upon registration on Bear Mountain. It contains an ID and the UserId which is the user's email. It is referenced in the Basket Items table.  