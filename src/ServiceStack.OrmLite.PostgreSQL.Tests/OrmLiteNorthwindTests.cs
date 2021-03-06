using System.Data;
using System.IO;
using Northwind.Common.DataModel;
using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace ServiceStack.OrmLite.Tests
{
    [TestFixture]
	//[Ignore("Long running tests")]
	public class OrmLiteNorthwindTests
		: OrmLiteTestBase
	{
		public static void CreateNorthwindTables(IDbConnection db)
		{
		
			db.DropTable<EmployeeTerritory>();
			db.DropTable<Territory>();
			db.DropTable<Region>();
			db.DropTable<CustomerDemographic>();			
			db.DropTable<CustomerCustomerDemo>();
			db.DropTable<OrderDetail>();
			db.DropTable<Product>();
			db.DropTable<Order>();
			db.DropTable<Supplier>();
			db.DropTable<Shipper>();
			db.DropTable<Customer>();
			db.DropTable<Category>();
			db.DropTable<Employee>();
			
 
			db.CreateTables
			(
				 true,
				 typeof(Employee),
				 typeof(Category),
				 typeof(Customer),
				 typeof(Shipper),
				 typeof(Supplier),
				 typeof(Order),
				 typeof(Product),
				 typeof(OrderDetail),
				 typeof(CustomerCustomerDemo),
				 typeof(Category),
				 typeof(CustomerDemographic),
				 typeof(Region),
				 typeof(Territory),
				 typeof(EmployeeTerritory)
			);
		}

		private static void LoadNorthwindData(IDbConnection db)
		{
			NorthwindData.Categories.ForEach(x => db.Insert(x));
			NorthwindData.Customers.ForEach(x => db.Insert(x));
			NorthwindData.Employees.ForEach(x => db.Insert(x));
			NorthwindData.Shippers.ForEach(x => db.Insert(x));
			NorthwindData.Orders.ForEach(x => db.Insert(x));
			NorthwindData.Suppliers.ForEach(x => db.Insert(x));
			NorthwindData.Products.ForEach(x => db.Insert(x));
			NorthwindData.OrderDetails.ForEach(x => db.Insert(x));
			NorthwindData.CustomerCustomerDemos.ForEach(x => db.Insert(x));
			NorthwindData.Regions.ForEach(x => db.Insert(x));
			NorthwindData.Territories.ForEach(x => db.Insert(x));
			NorthwindData.EmployeeTerritories.ForEach(x => db.Insert(x));
		}

		[Test]
		public void Can_create_all_Northwind_tables()
		{
			using (var db = ConnectionString.OpenDbConnection())
			{
				CreateNorthwindTables(db);
			}
		}

		[Test]
		public void Can_insert_Northwind_Data()
		{
			using (var db = ConnectionString.OpenDbConnection())
			{
				CreateNorthwindTables(db);

				NorthwindData.LoadData(false);
				LoadNorthwindData(db);
			}
		}

		[Test]
		public void Can_insert_Northwind_Data_with_images()
		{
			using (var db = ConnectionString.OpenDbConnection())
			{
				CreateNorthwindTables(db);

				NorthwindData.LoadData(true);
				LoadNorthwindData(db);
			}
		}

	}
}