# CleanArch

# General Scope:

- To embark upon a web project aimed at managing products and categories, which can be utilized to create a comprehensive sales catalog;
- Develop an ASP .NET Core MVC application using Visual Studio 2022 Community that enables the efficient management of produtos and categories;
- Within the project, estabilish funcionalities, that encompass the ability to perform CRUD operations for both products and categories;
- Define the domains model using classes, specifying their properties and behaviors: Product and Category;
- To define the architecture to be used in the project, we will employ the Clean Architecture approach;
- Whe will implement the following patterns in the project: MVC, Repository, and CQRS;

# Rules Product

- Defining the functionality for displaying products;
- Defining the functionality for creating new product;
- Allowing the modifications of properties for an existing product (The product ID cannot be changed);
- Defining the functionality for deleting an existing product by its ID;
- Defining the relationship between a product and its category (navigation properties);
- Preventing the creation of a product with inconsistent state (implementing a parameterized constructor);
- Preventing external modification of product attributes (private setters);
- Preventing the attributes Id, Stock and Price from having negative values;
- Preventing the attributes Name and Description sejam nulos ou vazios;
- Allowing the attribute "image" to be null;
- Restricting the attribute "Name" from having fewer than 3 characters;
- Restricting the attribute "Description" from having fewer 5 characters;
- Restricting the attribute "Image" from having more than 250 characters;
- Storing the "Image" attribute as a string ang separating the file into a project folder;
- Defining validation for business rules in the domain;

# Rules Category

- Defining the functionality to display categories;
- Defining the functionality for creating a new category;
- Allowing the modification of properties for an existing category (the category ID cannot be changed);
- Defining the functionality to delete an existing category by its ID;
- Defining then relationship between a category and a product (navigation property);
- Preventing the creation of an inconsistent state for a category (creating a parametrized);
- Preventing external modification of category attributes (private setters);
- Preventing the attribute "CategoryId" from having a negative value;
- Previnting the attribute "Name" from being null or empty;
- Restricting the attribute "Name" from having fewer than 3 characters;
- Defining validatiuon for business rules in the Category domain;

# The data persistence employed in the project.

- Utilizing a relational database for data persistence, specificaly SQL Server;
- Using then ORM tool: Entity Framework Core;
- Using the Code-First approach of Entity Framework Core to create the database and tables;
- Database provider: Microsoft.EntityFrameworkCore.SqlServer;
- To for applying migrations: Microsoft.EntityFrameworkCore.Tools;
- Decoupling the data acess layer from the ORM: Repository pattern;

# Naming

- Using the naming conventions recommende by Microsoft for naming classes, methods, parameters, and variables;
- Camelcase: In compound words or pharses, the first letter of the first word is lowercase;
- PascalCase: In compound words or phrases formed with multiple words, the first letter of each word is capitalized. Example: CalculateIncomeTax(), DiscountValue.







