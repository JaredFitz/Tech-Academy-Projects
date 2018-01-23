Papa Bob's Mega Challenge Requirements
======================================

See Order Form picture for example of how the form should look.

1. Using the "maintenance driven" approach to building
   and application, create all the necessary projects
   to adequately separate concerns: presentation,
   domain, persistence.  Also, use data transfer
   objects to communicate between layers.

2. To create the order form (default.aspx) follow the 
   user interface design detailed in the OrderForm.png
   file.

3. The following prices apply (but may change over time).
   The following should also be used to populate the
   respective the drop down list.

Size:
- Small (12 inch - $12)
- Medium (14 inch - $14)
- Large (16 inch - $16)

Crust:
- Regular
- Thin
- Thick (+ $2)

Toppings:
- Sausage (+ $2)
- Pepperoni (+ $1.50)
- Onions (+ $1)
- Green Peppers (+ $1)

4. As each change to the order is made, update the Total Cost
   label at the bottom.

5. When the user clicks the Order button, validate 
   the data where appropriate.  Provide the end 
   user with an appropriate message telling him or 
   her what to do next.  All text fields are 
   required, and the user must select a form of
   payment.  If data is missing, communicate between 
   the layers with exceptions.

6. If the order passes validation, store the order
   in a SQL Server database.  Use a uniqueidentifier 
   data type for the order id (key).

7. Upon success, redirect the user to a simple 
   succcess.aspx page.

6. Create a second Web Form called OrderManagement.aspx.
   Display a list of orders not yet completed in a tabular
   format using the GridView.  Display all of the columns
   required to create the pizza (not the payment or delivery
   information).

7. Add a hyperlink to each row in the first column with the
   word "Finished".  When the pizza maker clicks this 
   button, the order should be hidden from the list.  Do
   not delete the order.  Papa Bob's needs  that for 
   future reporting and analytics.

Good luck!  Papa Bob is counting on you.  Don't let him down.