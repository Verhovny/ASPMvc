using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStore.Data;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class SeedController : Controller
    {
        private DataContext context;

        public SeedController(DataContext ctx) => context = ctx;

        public IActionResult Index()
        {
            ViewBag.Count = context.Products.Count();

            return View(context.Products
                .Include(p => p.Category).OrderBy(p => p.Id).Take(20));
        }

        [HttpPost]
        public IActionResult CreateProductionData()
        {
            ClearData();
            context.Categories.AddRange(new Category[]
            {
                new Category
                {
                    Name = "Watesports",
                    Description =  "Make a splash",
                    Products = new Product[]
                    {
                        new Product
                        {
                            Name = "Kayak",
                            Description = "A boat for one person",
                            PurchasePrice = 200,
                            RetailPrice = 275
                        }

                    }
                }

            });

            context.SaveChanges();
            return RedirectToAction(nameof(Index));
                
            
        }


        [HttpPost]
        public IActionResult CreateSeedData(int count)
        {
            ClearData();

            if(count > 0)
            {
                context.Database.SetCommandTimeout(System.TimeSpan.FromMinutes(10));
                context.Database.ExecuteSqlRaw("Drop procedure if exists CreateSeedData");


                context.Database.ExecuteSqlRaw($@"

                create procedure CreateSeedData
                @RowCount decimal
                as
                    begin
                        set nocount on
                        declare @i int = 1;
                        declare @catId Bigint;
                        declare @catCount int = @rowCount / 10;
                        declare @pprice decimal(5,2);
                        declare @rprice decimal(5,2);

                        begin transaction
                            while @i <= @CatCount
                                begin
                                    insert into Categories(Name, Description)
                                    values (Concat('Category-', @i),'Test Data Category');
                                set @catId = Scope_Identity();
                                declare @j int = 1;
                                while @j <= 10
                                    begin
                                       set @pprice = rand()*(500-5+1);
                                       set @rprice = (rand()*@pprice) + @pprice
                                       insert into Products(Name,CategoryId,PurchasePrice,RetailPrice)
                                       values(concat('Product',@i,'-',@j),@catId,@pprice,@rprice)
                                       set @j=@j+1
                                    end
                                    set @i=@i+1
                                end
                                commit
                end"

);

                context.Database.BeginTransaction();
                context.Database.ExecuteSqlRaw($"EXEC CreateSeedData @RowCount = {count}");
                context.Database.CommitTransaction();

            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ClearData()
        {
            context.Database.SetCommandTimeout(System.TimeSpan.FromMinutes(10));
            context.Database.BeginTransaction();
            context.Database.ExecuteSqlRaw("delete from orders");
            context.Database.ExecuteSqlRaw("delete from categories");
            context.Database.CommitTransaction();
            return RedirectToAction(nameof(Index));
        }
    }
}
