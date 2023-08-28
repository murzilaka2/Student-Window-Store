using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//если 2 пользователя зайдут в корзину, то будет выданы разные корзины
builder.Services.AddScoped(e => ShopCart.GetCart(e));
//подключаем сессию для хранения данных
builder.Services.AddMemoryCache();
builder.Services.AddSession();
//подключаем MVC сервис для работы с проектом
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddTransient<IAllWindows, WindowRepository>();
builder.Services.AddTransient<IWindowsCategory, CategoryRepository>();
//сервис для работы с корзиной
builder.Services.AddTransient<ICartService, CartInfo>();
//для оформления заказа
builder.Services.AddTransient<IAllOrder, OrderRepository>();
//пользователи
builder.Services.AddTransient<IAllUser, UserRepository>();
//настройки сайта
builder.Services.AddTransient<ISiteSettings, SiteSettingsRepository>();
//статистика приглашений
builder.Services.AddTransient<IInvitation, InvitationRepository>();
//записи
builder.Services.AddTransient<IBooked, BookedRepository>();
//отзывы
builder.Services.AddTransient<IFeedBack, FeedBackRepository>();
//поставщики
builder.Services.AddTransient<ISupplier, SupplierRepository>();


//получение файла настроек для устанвоки соединения с базой данных
IConfigurationRoot _confString = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("dbsettings.json").Build();
//подключение файла в общие сервисы (в самом файле нас интересует одна строка - DefaultConnection).
//options.UseSqlServer - необходимо подключить пространство имен
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

// аутентификация с помощью куки
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/login");
builder.Services.AddAuthorization();


var app = builder.Build();

//при старте программы, вызываем функцию Initial для заполнения данными
using (var scope = app.Services.CreateScope())
{
    //подключаем AppDbContext и на основе данного класса мы сможем подключаться к базе данных
    //и работать с ней (добавлять значения, удалять и т.д.)
    AppDbContext appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbObjects.Initial(appDbContext);
}
//используем сессию
app.UseSession();
//позволяет отображать коды страниц
app.UseStatusCodePages();
//позволяет выводить возникшие ошибки на страницу
app.UseDeveloperExceptionPage();
//позволяет отображать различные css, html файлы и картинки
app.UseStaticFiles();
//позволяет использовать встроенную маршрутизацию и сразу же
//появляется возможность обрабатывать запросы как в MVC 
//При этом что бы работало, при регистрации сервиса MVC на 7 строке
//добавляем в параметры: options => options.EnableEndpointRouting = false
//app.UseMvcWithDefaultRoute();
// добавление middleware аутентификации 
app.UseAuthentication();
// добавление middleware авторизации
app.UseAuthorization();



//Собственные URL адреса
app.UseMvc(routes =>
{
    //устаналиваем страницу по умолчанию. Параметр Id? - является не обязательным
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
    //Если оставляем параметр action без названия представления, может использоваться любое
    //представление. Сам параметр category, должен точно совпадать с параметром метода
    //в контроллере. Значение по умолчанию defaults, указываем какой контроллер и метод будет использоваться по умолчанию
    //на случай если мы не передадим параметры /{action}/{category?}, в контроллере 
    routes.MapRoute(name: "categoryFilter", template: "{Windows}/{action}/{category?}", defaults: new { Controller = "Windows", action = "Index" });
});

// добавляем поддержку контроллеров, которые располагаются в области
app.MapControllerRoute(
    name: "Account",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");




app.Run();
