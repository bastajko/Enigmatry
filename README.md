I was trying to follow the document specifications strictly.

I created services for the main logic, and repositories for data acces layer.

I didn't create Generic Repository because I consider it's not necessary for this small project.

When it comes to steps 6 and 8 and the property configurations I made one small change, if the property visibility is not set, the property won't be selected at all.

This is because the point 6 says that document structure may vary upon the product code. What I understood by it is that some properties might be exluded or included in the response.

For that reason my PropertyVisibility enum has Masked property also (not like specified in point 8).

I added few test cases where I just tried to show different techniques of testing.

For any questions contact me at sbastajic@gmail.com
