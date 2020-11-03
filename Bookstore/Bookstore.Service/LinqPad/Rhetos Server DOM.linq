<Query Kind="Program">
  <Reference Relative="..\bin\Autofac.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Autofac.dll</Reference>
  <Reference Relative="..\bin\EntityFramework.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\EntityFramework.dll</Reference>
  <Reference Relative="..\bin\EntityFramework.SqlServer.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\EntityFramework.SqlServer.dll</Reference>
  <Reference Relative="..\bin\NLog.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\NLog.dll</Reference>
  <Reference Relative="..\bin\Oracle.ManagedDataAccess.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Oracle.ManagedDataAccess.dll</Reference>
  <Reference>..\bin\Rhetos.AspNetFormsAuth.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Configuration.Autofac.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.Configuration.Autofac.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dom.DefaultConcepts.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.Dom.DefaultConcepts.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dom.DefaultConcepts.Interfaces.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.Dom.DefaultConcepts.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dom.Interfaces.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.Dom.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dsl.DefaultConcepts.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.Dsl.DefaultConcepts.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dsl.Interfaces.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.Dsl.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Interfaces.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Logging.Interfaces.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.Logging.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Persistence.Interfaces.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.Persistence.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Processing.DefaultCommands.Interfaces.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.Processing.DefaultCommands.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Processing.Interfaces.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.Processing.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Security.Interfaces.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.Security.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.TestCommon.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.TestCommon.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Utilities.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Rhetos.Utilities.dll</Reference>
  <Reference Relative="..\bin\Bookstore.Service.dll">C:\Users\Martin\Desktop\git\RhetosWorkshop\Bookstore\Bookstore.Service\bin\Bookstore.Service.dll</Reference>
  <Reference>..\bin\Generated\ServerDom.Orm.dll</Reference>
  <Reference>..\bin\Generated\ServerDom.Repositories.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.AccountManagement.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>Rhetos.Configuration.Autofac</Namespace>
  <Namespace>Rhetos.Dom</Namespace>
  <Namespace>Rhetos.Dom.DefaultConcepts</Namespace>
  <Namespace>Rhetos.Dsl</Namespace>
  <Namespace>Rhetos.Dsl.DefaultConcepts</Namespace>
  <Namespace>Rhetos.Logging</Namespace>
  <Namespace>Rhetos.Persistence</Namespace>
  <Namespace>Rhetos.Security</Namespace>
  <Namespace>Rhetos.Utilities</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Data.Entity</Namespace>
  <Namespace>System.DirectoryServices</Namespace>
  <Namespace>System.DirectoryServices.AccountManagement</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Runtime.Serialization.Json</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Xml</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
  <Namespace>Autofac</Namespace>
  <Namespace>Rhetos.TestCommon</Namespace>
  <Namespace>Rhetos</Namespace>
</Query>

void Main()
{
	string applicationFolder = Path.GetDirectoryName(Util.CurrentQueryPath);
	ConsoleLogger.MinLevel = EventType.Info; // Use EventType.Trace for more detailed log.
	
	using (var container = ProcessContainer.CreateTransactionScopeContainer(applicationFolder))
    {
        var context = container.Resolve<Common.ExecutionContext>();
        var repository = context.Repository;

		// Assignment
		var query2 = repository.Bookstore.Book.Query().Select(book => new { book.Title, book.NumberOfPages, book.Author.Name }).Dump();
		Console.WriteLine(query2.ToString());
		Console.WriteLine("Done.");

		var actionParameter = new Bookstore.InsertManyBooks
		{
			NumberOfBooks = 10,
			Title = "TitleTest"
		};
		repository.Bookstore.InsertManyBooks.Execute(actionParameter);

		var query3 = repository.Bookstore.Book.Load().Dump();

		//Contents

		var allBooks = repository.Bookstore.Book.Load();
		allBooks.Dump();

		var someBooks = repository.Bookstore.Book.Load(book => book.Title.StartsWith("The"));
		someBooks.Dump();

		var query22 = repository.Bookstore.Book.Query();

		var query23 = query22
			.Where(b => b.Title.StartsWith("B"))
			.Select(b => new { b.Title, b.Author.Name });

		// Entity Framework overrides ToString to return the generated SQL query.
		query22.ToString().Dump("Generated SQL (query)");
		query23.ToString().Dump("Generated SQL (query2)");

		// ToList will force Entity Framework to load the data from the database.
		var items = query23.ToList();
		items.Dump();

		var queryy = repository.Common.Claim.Query()
	.Where(c => c.ClaimResource.StartsWith("Common.") && c.ClaimRight == "New");

		queryy.ToString().Dump("Claims query SQL");
		queryy.ToList().Dump("Claims query items"); // With navigation properties.

		queryy.ToSimple().ToString().Dump("Claims ToSimple SQL"); // Same as above.
		queryy.ToSimple().ToList().Dump("Claims ToSimple items"); // Without navigation properties.

		repository.Bookstore.Book.Load(book => book.Title.StartsWith("The"));

		Guid id = new Guid("F7A779D2-F482-4CD4-B5A8-5269A614A37E");
		repository.Bookstore.Book.Load(new[] { id }).Single().Dump();

		// Generic property filter:
		var filter1 = new FilterCriteria("Title", "StartsWith", "B");
		repository.Bookstore.Book.Query(filter1).Dump();

		// IEnumerable of generic filters:
		var filter2 = new FilterCriteria("Title", "Contains", "ABC");
		var manyFilters = new[] { filter1, filter2 };
		var filtered = repository.Bookstore.Book.Query(manyFilters);
		filtered.ToString().Dump(); // The SQL query contains both filters.
		filtered.ToSimple().Dump();

		var filter11 = new FilterCriteria("Title", "StartsWith", "The"); // Generic property filter.
		var filter3 = new Guid[] { // Predefined IEnumerable<Guid> filter.
    new Guid("9b1dd9c7-6e78-4ea0-a24c-9e812a8c15d5"),
	new Guid("57b50538-c599-4629-8941-d2d996822c61") };

		var query = repository.Bookstore.Book.Query(filter11);
		query = repository.Bookstore.Book.Filter(query, filter3);
		query.ToString().Dump();

		var comments = repository.Bookstore.Comment.Query();
		var booksWithComments = repository.Bookstore.Book.Query()
			.Where(book => comments
				.Any(comment => comment.BookID == book.ID));

		booksWithComments = repository.Bookstore.Book.Query()
.Where(book => repository.Bookstore.Comment.Subquery
.Any(comment => comment.BookID == book.ID));

		// Insert a record in the `Common.Principal` table:
		var testUser = new Common.Principal { Name = "Test123", ID = Guid.NewGuid() };
		repository.Common.Principal.Insert(testUser);

		// Update the existing record:
		Guid idd = testUser.ID;
		var loadedUser = repository.Common.Principal.Load(new[] { idd }).Single();
		loadedUser.Name = loadedUser.Name + "xyz";
		repository.Common.Principal.Update(loadedUser);

		// Delete:
		repository.Common.Principal.Delete(testUser);

		// Print logged events for the `Common.Principal`:
		repository.Common.LogReader.Query()
			.Where(log => log.TableName == "Common.Principal" && log.ItemId == testUser.ID)
			.ToList()
			.Dump("Common.Principal log");

		repository.Bookstore.Insert5Books.Execute(null);

		Console.WriteLine("Done.");
	
		
		//container.CommitChanges(); // Database transaction is rolled back by default.
    }
}