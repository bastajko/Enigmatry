I was trying to strictly follow the document specifications.

Apart from specification I created middleware which is retrieving header property that should be common for all api's, and that's tenantId.

I created services for the main logic, and repositories for the data access layer.

I didn't create a Generic Repository because I consider it's not necessary for this small project.

When it comes to steps 6 and 8 and the property configurations I made one small change, if the property visibility is not set, the property won't be selected at all.

This is because point 6 says that document structure may vary upon the product code. What I understood by it is that some properties might be excluded or included in the response.

For that reason my PropertyVisibility enum has Masked property also (not like specified in point 8).

I added a few test cases where I just tried to show different techniques of testing.

I used sqlite for dev purposes since the focus is on code.
I wouldn't use it in a real world scenario.

For any questions contact me at sbastajic@gmail.com
