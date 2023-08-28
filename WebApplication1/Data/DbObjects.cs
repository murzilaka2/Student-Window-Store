using WebApplication1.Data.Helpers;
using WebApplication1.Data.Models;
using WebApplication1.Data.Repository;

namespace WebApplication1.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContext appDbContext)
        {
            if (!appDbContext.Users.Any())
            {
                //Password = qwerty
                appDbContext.Users.Add(new User
                {
                    Name = "Leonid",
                    Email = "admin@gmail.com",
                    Role = "Administrator",
                    Salt = "/1AM9ixCGDhuA1kzU93IDTMYg1FReHYiGyYslo+tKk8kqn5vTiVI41vDpZ5TIEsWwvcr2tRBq7UH0FqG0a+Sz+jqbEYPiQ==",
                    HashedPassword = "H7sy+CEPpPLZrd+Ivf6/OXBU1F6xhqC5xU14sYaLEYcoOwOumnhyK6dzBa086bGh05z241uLCYx4R7yCW8ckkk4Fy44Vaw=="
                });
                appDbContext.Users.Add(new User
                {
                    Name = "Maxim",
                    Email = "maxim@gmail.com",
                    Role = "Administrator",
                    Salt = "/1AM9ixCGDhuA1kzU93IDTMYg1FReHYiGyYslo+tKk8kqn5vTiVI41vDpZ5TIEsWwvcr2tRBq7UH0FqG0a+Sz+jqbEYPiQ==",
                    HashedPassword = "H7sy+CEPpPLZrd+Ivf6/OXBU1F6xhqC5xU14sYaLEYcoOwOumnhyK6dzBa086bGh05z241uLCYx4R7yCW8ckkk4Fy44Vaw=="
                });
            }
            if (!appDbContext.SiteSettings.Any())
            {
                appDbContext.SiteSettings.Add(new SiteSettings
                {
                    SiteId = 1,
                    FormEmail = "admin@gmail.com",
                    FormNotHashedPassword = "qwerty",
                    FormSenderName = "Leonid",
                    Address = "Киев, ул. Победы, дом 23.",
                    Email = "windowsstore@info.com",
                    LogoImage = "/images/logo-default-290x57.png",
                    PhoneNumber = "380965161487",
                    ProductCount = 9,
                    SiteName = "Windows Store",
                    WorkTime = "Понедельник-Пятница: 9:00 - 18:00"
                });
            }
            if (!appDbContext.Invitation.Any())
            {
                appDbContext.Invitation.AddRange(
                    new Invitation { Href = "/auth/register?code=fw6f7f7saf6as7fsaf8a6sd78f6asf67dsad7f6asf8as87df", Code = "fw6f7f7saf6as7fsaf8a6sd78f6asf67dsad7f6asf8as87df", IsUsed = true, GeneratedDate = DateTime.Now.AddMonths(-1) },
                    new Invitation { Href = "/auth/register?code=szgf1f7saf6as5fsaf8a6sd33f6asf25dsad2f6asf9as87df", Code = "szgf1f7saf6as5fsaf8a6sd33f6asf25dsad2f6asf9as87df", IsUsed = false, GeneratedDate = DateTime.Now.AddMonths(-2) },
                    new Invitation { Href = "/auth/register?code=hj6t1ggjkl61f45bva8a6sd12f6asf34dsad3f6asf5as87df", Code = "hj6t1ggjkl61f45bva8a6sd12f6asf34dsad3f6asf5as87df", IsUsed = true, GeneratedDate = DateTime.Now.AddMonths(-2) },
                    new Invitation { Href = "/auth/register?code=aa1b6n1mio9ps7fsaf8a6sd36f6asf17dsad4f6asf4as87df", Code = "aa1b6n1mio9ps7fsaf8a6sd36f6asf17dsad4f6asf4as87df", IsUsed = true, GeneratedDate = DateTime.Now.AddMonths(-1) }
                );
            }
            if (!appDbContext.Categories.Any())
            {
                appDbContext.Categories.AddRange(Categories.Select(e => e.Value));
            }
            if (!appDbContext.Suppliers.Any())
            {
                appDbContext.Suppliers.AddRange
                    (
                    new Supplier
                    {
                        Name = "Бастет Трейд",
                        Description = "Основное направление деятельности компании – производство и реализация комплектующих для окон.",
                        Address = "Киев, ул. Будиндустрии, 9а",
                        Phone = "+380 67 622 1088",
                        Email = "batettreyd@gmail.com",
                        Image = "https://okna.ua/smap/bastetplus_ru.png"
                    },
                    new Supplier
                    {
                        Name = "ЧП Ловекс-К",
                        Description = "ЧП \"Ловекс - К\" - многопрофильная компания, включающая в свой состав один из крупнейших в Украине заводов " +
                        "по изготовлению систем вентиляции - ООО \"СТ СПЕЦМОНТАЖ\" и кровельную компанию \"ЛОВЕКС - К\".",
                        Address = "Киев, ул. Здолбуновская, 7Д, корпус З, офис 305 02081",
                        Phone = "+380 44 502 2592",
                        Email = "lovexxx@gmail.com",
                        Image = "https://okna.ua/smap/loveks-okna_ru.png"
                    }
                    );
            }
            if (!appDbContext.Windows.Any())
            {
                appDbContext.AddRange
                    (
                    new Window
                    {
                        Name = "WDS 5S",
                        ShortDescription = "Конструкции из новой серии пятикамерного профиля WDS серии 5S идеальный выбор для Вас.",
                        LongDescription = "Оконная система WDS 5S разработана для людей, которые предпочитают простоту классического окна, " +
                        "не затрачивая при этом большие суммы денег. Окна WDS 5S удобны в эксплуатации и не требуют дополнительного ухода. " +
                        "Идеально подходят для установки в различных помещениях и выглядят необычно и стильно в ламинации под дерево. " +
                        "Самый популярный вид профиля для балконов, лоджий и окон в средне-бюджетном ценовом сегменте. " +
                        "К любым металлопластиковым конструкциям из профиля ВДС 5S серии необычайно точно подходят подоконники ВДС, " +
                        "На белых матовых подоконниках WDS точно такой же цвет и оттенок, как на профиле WDS 5S серии.",
                        Image = "https://wds.ua/wp-content/uploads/2019/04/wds_5s_white_opened.png",
                        Price = 3500,
                        IsFavorite = true,
                        Available = 20,
                        Category = Categories["WDS"]
                    },

                    new Window
                    {
                        Name = "WDS 6S",
                        ShortDescription = "Профильная система WDS 6S была создана как оптимальное решение в сегменте шестикамерных систем по доступной цене.",
                        LongDescription = "Окна из этой системы обеспечивают существенное снижение затрат на остекление при крупном строительстве, " +
                        "особенно при реализации масштабных проектов.Цвет уплотнителя в это серии профиля - черный. " +
                        "К окнам из профиля ВДС серии 6S всегда можно заказать подоконники ВДС, москитные сетки, различные дополнения и комплектующие. В этом разделе представлены самые популярные и часто встречающиеся размеры и конфигурации оконно - дверных конструкций начального ценового уровня.",
                        Image = "https://wds.ua/wp-content/uploads/2019/04/wds_6s_white_opened.png",
                        Price = 5750,
                        IsFavorite = false,
                        Available = 53,
                        Category = Categories["WDS"]
                    },

                new Window
                {
                    Name = "WDS 8",
                    ShortDescription = "Окна и двери, изготовленные из профиля WDS 8 SERIES, обеспечивают превосходную теплоизоляцию для сохранения комфорта в вашем доме в любую погоду.",
                    LongDescription = "Эта система была спроектирована, прежде всего, для энергосбережения. Профиль ВДС 8 серии имеет 6 (шесть) воздушных камер, " +
                    "при толщине самого профиля 82 мм! Это самый теплый и самый шумоизолированный профиль, серийно выпускаемый в Украине. Окна WDS 8 SERIES сохраняют " +
                    "в 2,5 раза больше тепла по сравнению бюджетными с окнами из трёхкамерного профиля в стандартной комплектации, благодаря чему в доме зимой тепло, " +
                    "а летом – прохладно. Как опцию, для всех конструкций из профиля ВДС 8 серии мы предлагаем антивзломную фурнитуру, " +
                    "детский замок (безопасная ручка с ключем), стильные подоконники WDS (премиум класс), москитные сетки и высокотехнологичные " +
                    "энергосберегающие и мультифункциональные стеклопакеты.",
                    Image = "https://wds.ua/wp-content/uploads/2018/10/800_s_class_white.png",
                    Price = 4750,
                    IsFavorite = true,
                    Available = 20,
                    Category = Categories["WDS"]
                },

                new Window
                {
                    Name = "Steko IDEAL 8000",
                    ShortDescription = "Окна и двери, изготовленные из профиля WDS 8 SERIES, обеспечивают превосходную теплоизоляцию для сохранения комфорта в вашем доме в любую погоду.",
                    LongDescription = "Эта система была спроектирована, прежде всего, для энергосбережения. Профиль ВДС 8 серии имеет 6 (шесть) воздушных камер, " +
                    "при толщине самого профиля 82 мм! Это самый теплый и самый шумоизолированный профиль, серийно выпускаемый в Украине. Окна WDS 8 SERIES сохраняют " +
                    "в 2,5 раза больше тепла по сравнению бюджетными с окнами из трёхкамерного профиля в стандартной комплектации, благодаря чему в доме зимой тепло, " +
                    "а летом – прохладно. Как опцию, для всех конструкций из профиля ВДС 8 серии мы предлагаем антивзломную фурнитуру, " +
                    "детский замок (безопасная ручка с ключем), стильные подоконники WDS (премиум класс), москитные сетки и высокотехнологичные " +
                    "энергосберегающие и мультифункциональные стеклопакеты.",
                    Image = "https://e-dveri.com.ua/image/cache/catalog/steko/s700-500x500.png",
                    Price = 6200,
                    IsFavorite = true,
                    Available = 65,
                    Category = Categories["Steko"]
                },

                new Window
                {
                    Name = "WDS 12",
                    ShortDescription = "Окна и двери, изготовленные из профиля WDS 8 SERIES, обеспечивают превосходную теплоизоляцию для сохранения комфорта в вашем доме в любую погоду.",
                    LongDescription = "Эта система была спроектирована, прежде всего, для энергосбережения. Профиль ВДС 8 серии имеет 6 (шесть) воздушных камер, " +
                    "при толщине самого профиля 82 мм! Это самый теплый и самый шумоизолированный профиль, серийно выпускаемый в Украине. Окна WDS 8 SERIES сохраняют " +
                    "в 2,5 раза больше тепла по сравнению бюджетными с окнами из трёхкамерного профиля в стандартной комплектации, благодаря чему в доме зимой тепло, " +
                    "а летом – прохладно. Как опцию, для всех конструкций из профиля ВДС 8 серии мы предлагаем антивзломную фурнитуру, " +
                    "детский замок (безопасная ручка с ключем), стильные подоконники WDS (премиум класс), москитные сетки и высокотехнологичные " +
                    "энергосберегающие и мультифункциональные стеклопакеты.",
                    Image = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBUSFRUVEhIYEhgSGBgUGBgZGRgSGBIRGBkZGRgVHBkcIC4lHB4rHxoYJjgmKy8xNTU1GiQ7QDszPy40NTEBDAwMEA8QHxISHzQrISExNDQ2NDQ0PzQ0MTQ0MTQ0NDQ0NDQxNDE0NDQxPzE0NDQ0NDQxNDQ0NDQxNDQ0NDE0NP/AABEIAOEA4QMBIgACEQEDEQH/xAAcAAEAAgMBAQEAAAAAAAAAAAAAAwYEBQcCAQj/xABLEAACAQIDAgkIBQoEBQUAAAABAgADEQQSIQUxBhMiMkFRcZGxIyRhcoGhssFSc7PR8BQzNEJDU3SCkqIHYoThFWODk8IWVFVk8f/EABkBAQADAQEAAAAAAAAAAAAAAAABAgMEBf/EACkRAQEAAgEDAgUEAwAAAAAAAAABAhExAxJBBCETUWFxkSIyM4EUQsH/2gAMAwEAAhEDEQA/AOzREQEREBERAREQEREBE85he19eqeoEdQ2BI6AT7pjcc3X4TJrc1uw+EwhJiKkNZuvwlMwOPxGNxIw74l6dNaTVn4sKj1CHRAucC6ryiTlsfSJbXMpXBL9OP8M/21KT4Ut95Fi23iqWAoMyUc5NltqS17gF3NyfbrI6VN6dBGq1XI/OMEZ1PKAIUMzFsoBtvGokfD5LYSsekmn1fTX7pmNmeiijRSik6b+QLduolsfqz6stlk9r4aPb3Cko3F4fMoQhePdiULZc/FqhzM5I0zEAAnfM7Ym2Krm+Ic62yhQgRh2Zc17/AOb/AHoHDVQuJo5QLnRiNASKhXvGovLlgaeainWASO8y/bjLquf4nUuPdxZ4+elySqTqDcdRFrTIVgZqNi186m/OU2Pp00P46psL2NxMspq6rqwzmWMynFZUTypvrPUq2IiICIiAiIgIiICIiAiIgIiIENc2ViNLAzCosSNSTr06zNxHNbsMwKO72yYreWjoVQmNc2vbN8E3g2pm3La/p/2lZqtbFP8AzfBMzDvylEtYzmWm+TEFgb9R8IkNHcew+ElMhd5aUrgkfPj/AAr9X76l1y6NKVwVPnp/hW9H7alJ8K3mN5/iAfM6vbT+0E2OBXyK+onR/kXvmq4fnzOr61P41m1wX5lfUXq+gnfEVvLknCu/5ZVvqEqEgdWoYy/7HN6SEdI+ZlF4Vr53ifRUPgJceC1TNhqX+UFT7Cbe60t4ZcXTfbM5FQ9TDxP3zeETT0V5N+m5HhNsjXAPWLyMrvVX6OPbvH+/y90DvEmmPexBmRKVvj8vk+xESFiIiAiIgIiICIiAiIgIiIEOI5rdhmvpbpsMRzW7DMCnukxW8qtij5y/a3wSbDPy07ZjY4+cv2t8BnrBv5RO2XY+Voo7j2HwkpkNHcew+EmMhqjaUngsbY1v4VvR+3pS7NKPwXPnp/hW9H7alJnCmXMbrh8fM6vanxrNtgz5Ffqx1fu0/Gs0/D0+Z1e1PtEm1wZ8knqL1fQX8ayEXlzLhGmbG4gfSqEd6ib3gPWvTdfolW/qWx+GaTbZ8+rfW/ITe8F6eR3Xr07jpNMZvGuXqZWZ4/dcsOOQe37pnYNrr2Ej5/OYmEHJPafATIwR5w7DM/FdM9s5fnGS4kyG4EibdPVE6dkjw1ntl900REquREQEREBERAREQEREBERAixHNbsM19PdNhiea3YZr6e6WitVDaJ85f1j8BnzAt5VO35T5tQ+cP6x+Azxs8+WTt+Rl2HlcaO49hkxkFLcZM0q2RvKPwYPnv+lb0ftqUu7yi8G2tjf9M321OTOGeXMbnh0fM6vbT+NJtsE3kk+rXpH0F7vbNNw4bzSr/wBP40m1wb+TT0IvT/y17oR5c621+nVvrR4CWbZlMrUDdDFfeg+crG2j59V+sHgJcsAOSP5D3AfdL41z9ab1flYsWD5vt+6TYbR+0GQ4Tm+37pkUxqPQfGZ/N0WcX6smfaPTPk9U98jw1vMqaIiVXIiICIiAiIgIiICIiAiIgRYjmt2Ga9N0z8TzW7JgJukxWqbtb9Ib1j8BkWzj5ZO35GS7X/SH9Y/AZBsw+Wp+t8jNPDDyulKTtIKcmaVbImlD4PHz3/TP9rT6pe3MoGwT54P4Z/tafVJjPLlueGjeaVP5PjSbTBv5NPQidO7kL3TTcMm82qD1PjSbPBP5NNf1E69OQv40hRQ9sfptX6weAlvwr2yDoZB3gSnbVPnlT637pb6A1p9g8BL48sev+3c+i0YPm+37pOh5XcZj4Lme35CTfrDsmfl0ZftlZk+pviF390hrfCeIiVXIiICIiAiIgIiICIiAiIgRYnmt2TXpumwxPNbsmvXdJitUzbH6Q/rH4DINmHy1P1vkZNtj8+/rH4DMfZh8vT9b5GaeGF5XanJ2mOknaVbRA5nPtiHzwfwzfa05f6pnO9jN52P4dvtUkxnk3HC5vNqn8nxrNlg28mnqL1/u1/Gk1HCxvNn/AJPjWbDC1AKa3IHIXfp+oslmpe0Gvi3P/M+6XbBLcIepR4CVCtgKtTEu1Ok9RS97qpYEdYtvlvwDblIKlVAIIsQdBu7QZbHlTqTeKx4DmD8dAmRaa2htGjTTylanT9DOqncOgmeafCHDMSErq5UXOW7WHaBaZ+W2/wBLfiBvlOxH+I2DTRRVqEaclAouPXYRhuHSVUd0oMOLF+W4F9CegG26RJV7ljpd4mHs3HLXRXUjlAEi98pI3TMlWku32IiEkREBERAREQEREBERAhxPNbsmAN0z8TzW7JgdEmK1Sts/n39Y/AZjbLPl6frfIzI2yfLv6x+AzF2WfL0/W+RmnhheV4QyZ2mOhk6kdV/bKtox2Un0TSYXgtTpvnzuz5cl7qBkLBrWt1gS0K46FXuvJBWPRYewSNo7ZeWmGxUbRqZqeuWYejQm09Yith8LZciNVO5VCi3USbaTdUqhJAJ/FpyBdqeXqk3J4x7nrOcxPdGWsZ7LRwq4TV8PWXIGamtKjWKUkzVKrO7g6ncgyi9uv06VtNr02xmJVVqK9UJXfOVypyVIRekaOL36QeuW3ZtejinocbSJekQKbg5WUEglD1qbbjOU47FM208ffUitWS+g5CVcqjTqVVHsk8K33m2XX4I4uqzVEqUglVmqKGaoCEcllvZCAbEdMz9hbFrYE1XrshDKFGVnJzAk65lWZuF4YYRERKlQ03RQjK1N2sU5NwVVgQbAjt6JibW4QUMUAlBzUIOdjkdAAAVAOYAkm99L82RLdrWTtYC8EMU/L42kocBwOWSFflKDyLXsR0zY4PZr4OjVFaoG40ALYHSwN9Db6QmZQ4Y4IIivWKOiojKUqMVZFCnVUIOoPu3TX7X23RxRUUKhcJmLHKyi72sOUASRlPRbUekCZbtXPGdq3cH8U+Gwtch7tSaktyAbKzeFj75a9h7aWsArEBu4N2en0TnfBraVHE4ZsPVr8W78XZwjObU2uAd1+qZdKm+GrtSL5jTbLmGl9AQbdGhEWbJlZp1WfZjYFyyKSbkqpPpJUXmTKNyIiAiIgIiICIiAiIgQ4nmt2TXndNhiea3ZNcxkxWqVtk+Xf1j8BmJss+Xp+t8jMjbJ8u/rH4DMXZh8vT9b5GaeGF5XhDJlMx0MmUyrWJlM9iRKZIsJT4fnD2+E4nxXlqv1j/G07Xh+cPb4TlPFYc1amXFpfO9wyVUsc5uLhCJEVz4WLgwioWqubLQRqrHqVRf8dkp/5RQqFqxoqj1y1RrUzcM7FiC1rnUy6YPBcdhsTh0rUw9emURgxIub8kggGx3bumafGcDAAGxW0Gw3F0sxSjd+RTDF6hFrnQHcOiaY5SW2uL1PRz60mON1Pe270r7UsKxJNJCTqSaRJP8AbPVNMMt8tJVvvtSOvcs2GC2fs9WU/wDFMdUsb2NCsFNtbG9KeK2H2aWLflW1Dck5VR1UX6AOLFh7Zp8SfJxf4Oe9fEuvu17UMKSSaSknUnitST082e6SYdb5aarffamRf3TZYWvs2mwIXalTo5SsV7rCeqr7MRgoobQrAgHNxlVFBIvlOZ1Nx06R8T6F9Flxerfy1+DwoNeiMPS6WzBVyk7jutroDL3jdgmtiKtVK6c5Sy2OZTlUAEAdPzkOwkwatQalRqg1CWVnqu5RgSmt3Pp0mVjEqI1Y4elWapXqDM5XKqIp3q17G4AAMyyu7uPS9N0r0+nrK7/vwtGCTKirvygL1XsANxmVI6Y3/joEkmTtIiICIiAiIgIiICIiBFiea3ZNW5mzxPNbsmkxeLSnz3RPWYL4yYpkp+2D5w/rH4DMXZx8snrfIz5jsalTEvkbMCWII3EBDPmDNqqH0zRheV1ptMhDNdRrCZaVRKtJWYpkizGR5MrwvGVh+cPb4TiIp+Xq/W1Pjadswx5Q9vhOQpS8rV+sf4zEUz4WDY/k1Z/3al/5gOT/AHZR7Z9rCylerBVO88aZ8qHJQA6arqv8i8tvfknrEnl1h9HCMO+kW/8AKW8ssv21yPb20qy4iqq1aihXIADsAB1AA6TCTalc761T/uP98zNu4Go+IrFELAubWsfde81rYSonPpsnpZWUd5ErlvdT0pjenOOI2VHaFX97UP8AOx+c2mFxTne7H2k/OaCgZucDLYbcfqMZI6IjG2GsbaP9oZsX2hW/KHXjnyhyAM7WA6gLzWrzcN2P9oZkP+k1PXMnLmujofxY/aOm0d346hJJHS3d3gJJMXcREQERED5ExcVi1pqWJAA6fkOuV/bXCTiOLawyMFqM7sVCUiRfkrva24dcmRW5SLNWrqgu7BR1khR75ra/CHDp+0zHqUFvfu9857ia5qVnrCqXSonk110DENmI7Atu0yF6pO5e+WmLO9S+F1xHDFB+bpM3pYhfC80+L4Y1zzclMegZj3sbe6aVNn1qm5SB/T4ydOD5Orv3Xb3mT2xHdlWHjeEFZ7hq7tfoBIHcthNJUrO3MQk9590t6bHpJ+rm9bX3bp5rZFFlAHoAkqX6q5sXCuHZ6i25JC+0G+k2iaMG6p7Rrsew+E8XhDcYbFBunXq3GbGm0queT0Me6bm06jqI0tKttNpko0rmH2+g/OLlH0hqO7/9m6wOMp1RmpuHB100PcdRK1eVtcCeUPb4Tna7YV6jqcLR0d1vy7mzEXPL3zoeB549vhKU3BHEB3YKDmdmGoGhYmInKXXsj2uwLYYBQgys2UXtmL2J1JO5R3T7iD5TF+jDsv8AThwPlJNs4R6bYYOhU5WHQRfPe1xp0jvkNMq1fGh2yLlxClrZsqqrre3ToN0mMs5bLGBsHYtPF1nVlyBMzM4J3DptuvLpgNkYakjIHZwxU3IAIym+ht6Zi8FcCho12ouahqsFJK8WQu8jU+mTDCkc1iPfJt3ajo9Pswkynvpp9t/4d4XF1atWnWqUqlYlrck0w5HSuW9r9RnLMKjI5RxZkYow6mU2I7xO64NKmYAEHW+um7WUDhHsfD/l+ILCogZgxKZTdnVWY2aw5xPTIx9qj1HT7sPblmLzcN2P9oZkP+k1PXM+4igAMPxWd1yublRe5ck6LcT7iaTriXJRgC5IJBAI7Za3d2jpY3HpyXmSR0ulu7vASSR0d346hJJi7SIiAniruM9yOtuMCk8JXYltToSOwAzW7OxVHFcRh65KVEIReTnSvTvfIw6DYWufQZs+EH63rN4mV3gzhOMxqHcKQaqexRYDvYTTww/2WY7DpgnTQaBRoqqNAoA6AJkU8Iic1QvYPnMitUJOkhykyE6jy5AmO7HomSyTyUhFa+ohMxXwl5uDSnw05O0aaQYGRvs6b8UOncOszwELG1Nc5+kdFH3xs7VfbZp36AdZ0E8U9nltKa5/8xGVfYN5luobFzHNVOY9R3DsWbNMMqc0WjuTMFTwnBgGzVTmPUdw7F3CbrDbORLZRabIrPqrK7XmMjFfBV7lqFZVNhyHQMt7WuGGo98rWJbaOGZmcmopJY3GdRc30ZdVHUCRL3hemZEb0tcdudV+FeZVWpglq5DmF6lgD1jkHxkA4YUgxZ9nqhe4Yls2YNzgTksb3MvON2JQrXL0wGP6y8lr9em/23ldx/As6mkwYfRbknvGh90mWKWZR5wfCPDshSmq4cMQSAMgJ7RpNhTdWF1II6xrKTjuD7Uzy0amevcD2EaGYiLWpG9Nz3lT3jfJ0ru+XR1MyDiCTcqhPXlBMoOG4TVaelRbjrYW/uXSbvB8JaT2zXX+4d4+6RpMyjB4b/lfHp+T1KiIaSEojsi58z3NlI6MsxNlV8ShHGPWHrM9vebTe8I3xTMGweKA4ukhegtg5GrZ1uNeSRp6JqNlbaxDmz12a/p3xEZcumUd346hJJFQ3fjqEllG5ERASOtuMkkdbcYFM2yULuHqBOUd4br67WkPBlKSPVCVabPUVVWzoWNiSy5b36u6eeEiXL+sfGVLY2Ez4lGYcmjese1OZ/eUmnhhv9Tpb0QvPZE0J5TAGw3m3VMJ9o4YaNjMOPRxiD5zSVnJRCTcmhWa+/eSfnOe7RTVu0+MmY7m3P1vU/DymOuXV22xghvx+GH/AFU++eP+PYH/AORwv/dT75wvFCaqtKX2bdPqd04foyvtnAplz4/DrnUMt3XVGF1bfuImbgcRQqcWyYinUWoSFy8oOQSpAPaCPZPzAnOX0keM7azcRg6LUgENJ3ZLAAKVqMRp1SZNza2WcxymOuZv8LTtWqQ/JUZVO7oNjulgwyqVVgoXMqtYdFxeaDaG3qVPNxqJdQ5N97FbZLdt/cZv8DV4xEcDKHRHt1Blvb3yK0x5SsJGwkrTwwhaoiJ9UT6RPSrAnodMnnimlp7lUkREDw6gixAIO8HW81GN4OUKlyF4s9a6D+nd3Wm6nyTLpFkvKi47gnUW5S1Qejkt/SfkZUds4ZsOFPFFWNRFbQqUQ3uxHTqANfpTtEjq0VcWZQw6iAfGTMlL054UDYWycQuKVqlRqoB43MVCinSZbrSBHO0Kj0ZZBhthYhHLCkcpYmw0sCb21nRlpKAABYDQDXQdU9ZB+Lx3J7I80N346hJZ8An2VXIiICR1txkkjrbjApG3HphnFRmHKO5b9PbNXQ4oUKr0WzZmyMSpUjKA1td9847pmcJxq3rN4maXZxthK31zfBTmjnvNZ9XREH/1G96AyiY/e3afGXvHaOV+jhXXuQCUPHc5u0+M0x/a831n8s+zQ4yamsJu69ImYj4WZ5R0dHqSRqqS8pfWHiJ2faH6CnrVfjecmXD2I7R4zq+0j5inrVPjeMZqNMs5l1Z9r/xLw3GpM6Hsb8xQ+qpfAJzzhwd/tnQ9jfmKH1NL4BIrpw5rNM8NPZnm190hq8BbzKp07dsU0t2ySRsIiJAREQEREBERAREQEREBERASOvzTJJHUW4IECq7T2XxjMTURQSTqbTCHB1jRZEqIQzl7g6WKqOr0S0DZis2Z9dbhTuElr0GPJUADQLYaDtlu5n2qrithO9R3DJZkdAM3SwsJXP8A0TiHblpTCsSSwq5raE822uvjOn4bAqmtrnrOsypMzs4ZdT02HUsuXMcdbgRiNfIXA3Wq07n2THbgZiP/AGlT2PSP/lO02HUJ5dQAeSD6Lb5PxKy/wOn4t/Li2I4D1VyniajXANlytlJ1yn0jptN5iNlYiphEQ0HV81QlSLkAu+W9usWPtnQ1oljrye/q6J9xakLZN9uvUxct+y/T9NMLuW328qFwn2TUrM1kaw9Bl32WmWlSU6FaaLbqIW094PDMgJqOzHfa+g/3ktK56LXA06t8ra6Mcde6QC8mVbQq2nqVXIiICIiAiIgIiICIiAiIgIiICIiAiIgIiIHyIiEE+xEJfJG28T7ED3MbCfrez5xEDKiIgIiICIiAiIgIiICIiAiIgIiICIiB/9k=",
                    Price = 4750,
                    IsFavorite = true,
                    Available = 20,
                    Category = Categories["WDS"]
                },

                new Window
                {
                    Name = "Framex 80",
                    ShortDescription = "На заводе КОНТИНЕНТ изготавливаются окна различного уровня сложности.",
                    LongDescription = "Окна могут иметь самые разные формы: обычные прямоугольные, арочные, круглые, трапециевидные, " +
                    "треугольные или многоугольные. Они могут иметь всевозможные варианты по размерам и открыванию.",
                    Image = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBUVFBUVFRUYGRgYGhgYGRoaGBoZGhwYGhgaGRkYGBgcIS4lHB4rIRgYJjgmKy8xNTU1GiQ7QDs3Py40NTEBDAwMEA8QGhESGjEhIyE0NDQ0MTc/NjExMTExMTQ0MTQxMTYxMTQ0NDE0MTs7OD84MT8/MTE0MTQxMT80NDQ0NP/AABEIAR8ArwMBIgACEQEDEQH/xAAbAAACAgMBAAAAAAAAAAAAAAAABgQHAQMFAv/EAE4QAAIBAgIDCQoMBAQFBQAAAAECAAMRBBIFITEGIjJBUXGBkbEHEzRhcnOhsrPCFCQzNUJidIKSwdHwI0RStCWEosMWQ1Ph8RVFg5Ok/8QAGgEBAQADAQEAAAAAAAAAAAAAAAECAwQFBv/EACURAQEAAgEDAwQDAAAAAAAAAAABAhEDBCExBRJBMlFxsRNhof/aAAwDAQACEQMRAD8AsyZhCRQu2DwXbB5YxpMx3h45x7ONOG2RWx/hy849mY04bZJViWnFJBkZZJMsKWN1fymG8r30jKmzri1ur+Uw/le/TjLT2df72fvx7YRyf59vsi+3fxyVpr5CpzDtEjf+4N9kX27yTpo/F6nN+Y8cKp7Dn+K/lH05h+cbdwZ+NN5s+uP1ET1O/fyvzMaNxlYLjkH9aVEHQof3JUWgIgaQ/g6bpPxVCh/Gho+st4/iIPdJU062ExCjWuYdNN1dB/qaBZERu6Xh7rh6n9NRk/Gub/b9MdkIIBGw6x0zgbucPnwbnjRkcdDgN/pLSK87hcRmwaLfWjOh68wHU6xkiN3N8RqxFPkZHH3gVPqDrjzAIQhA40IQkULtg8F2weWJSbpHw5eceoY0YbZFfSfhy/d9Qxow2ySkSlkmRlkkyxKWN1nymH5/fpxlp7OuLW63h4fnPr04y0tnXA5P8+32RfbvJWmvkKnkjtEinw8/ZF9u/i/KStNfIVOYdohVOU/lH8r3jOroitkxWGfkqKD5JIVvQTOVT+UfyveM6OlKOR6ZGrOlNx0plJ/EpiJVzCKvdIw2fBh/+nURuhr0+11jJhK4dEcbHVX/ABKG/ORN0+G75g8QtrnvbMB9ZN+vpUSjbuXxPfMHh2vc97VSeVlGRj1qZL0ph++Uaqf1o69JUgRb7muJzYMp/wBOo69DWqdrmN8iqw3B4jLjcvE9Nxb6wKuPQG65Z8qSkfg+kqfEErlPuu5pg/heW3CQQhCFcaEJmRQJh5kTDyxKTdK+HJ931WjRhtkWNLeGp93saM+F2SUiUskyMskyxKV91vDw/OfXpxmp7Ov97f34tkWd1vDw/O3rU4z09nXA5P8APn7Ivt3kjTfg9TmHaPFI/wDPn7Ivt2kjTfg9TmHaPFCqdp8N/K94xj3S0LUsA/8AVTCfgYn34uU+G/le8Y7bpKN9GYVx9Bkv5LKwPpCxEpp3J1c2DofVXJ+AlR6AJ2woYFTsIIPMdRiruCq3w7p/S9+hhYelWjZSlCB3MnKVMXh2Otch6ULI59WWJK50V/A03WTYKnfOt1WvfrBljSKqXug0jTxbMuosEdecAC/4kMtTDVw6I42OqsOZgCO2IHdQw++ovbaroT5NmUf626o07jcRnwWHPIgT8BK9iiEdyEIQrjwhCRQJh5kTDyxKTtM+Gp9z3oz4XZFjTfhlPmT1mjPhdklIlLJJkZZIliUsbruHh+dvWSM9PZ1xY3X8LD87etTjNT2df7/fp2wOV/Pn7Ivt2kjTng9TmHaJH/nz9kX27TfpzwepzDtEKp2lw38r3jLLx+Hz6IYf00Vf/wCthUPoUytKXDfyveln4k20PX+x1vYvAgbgK9ndP6kzfgcj34+0pT3cmHxj/wCFv9mXDSlRXW7GstDS2DqkgZ+9DbrJFQo9h5LqJZUqPusfOWih9df7inLckUm905QMGHP0Ki9TKy26yD0TT3KseKuEcLeyVCouLfQQkdd+ubO6t83t5yn2mcvuJD4lW8+3qJAsiEIQOPCEJFAmHmZh5YlJ2nPDKfMnrPGbC7Is6e8Lp8yeu8ZsLsikS1kgyOskGIlK+6/hYfnf1qcZ6ezr/ez9+PbFjdhwqHO/bTjPT2dco5X8+fsi+3bmm/Tng9TmHaJo/nz9kX27c35Tfp0/F6nMO0SKp2lw38r35Z2N+Zq/2Kv7B5WNLhv5Xvyzsd8zV/sVb2DwE/uT+EHzDdtGW/S45UHcn8IPmW7aEt+jxwiqe6p86aK8un/c05bcqTuo/O2ivLp/3KS24Uld1fwA+cT3jOd3Ex8Rqeff1Kcnd1k/ER51PVeRO4qPiD+ff1KcCw4QhA48IQkUTDzMHiJSbug8Lpcyeu8ZsLsi1uh8Kpcyeu0ZcLslpEtZIMjrJBiJSvux20Od+1Iz09nX2xY3Y7aHO/akZ6ezr7ZRyT4d/lB7dub8pv06fi9TmHrDxzQfDv8AKD27Tfp4/F6nMPWHjkVTtLhv5Xvyz8d8zV/sVb2DysKXDfy/fln6Q+Zq/wBiq+waAodyfwg+ZbtoS3aPHKj7k/hDeZbtoS3KPHKiqe6cf8Y0WPrUf7pJbkqLulC+mtF+Vh/7oS3ZFInddPxFPHXT2dQ/lNHcV+b28+/qU5u7r5+JU/Pp7OrNXcXH+HHx1qnqoPygWDCEIHHhCEiiDwg8RKTt0fhVHmT12jLhdkWt0nhNH7nrmMmF2S0iYskGR1kgxEpX3Zf8nnftpxmp7Ovt/f71RY3Zf8nnf/bjRQGZcwII12INx1i/75Nko5J8O/yg9u03afPxepzD1hNLasd/lB7dps3QN8Xqcw9ZZFU9S4b+V78s/SXzNX+x1PYtKwonfv5XvSztJ/M1f7HU9iYQqdyb5d/MntoS3KPHKk7kvy7eZPbRlt0eOUVT3RNenNFj7P8A3R/SW5Kj3f8Az9oweLDf3T/pLckUg92A/Eqfn09nVme40P8ADR52p2LPHdjPxOl59fZ1Ju7jvzavnKnaID1CEIHIhAwkUGeXnozy8RKUN03hNH7ntIx4XZFzdN4RR+77SMeF2S0iYskGR1kgxEpV3abKX3/cnPwGOdNaMRy2O3XxqdR9Mn7tTqpff9yLlIsoFtfNz8ko72F08Phedx/LhN6LW/iFrkHpnV05jKb4WqUcHUtxexG+XapsYg1K4NfX/wBMDk+m3VPdVzY2N+fb1wFikd+/le9LU0k3+DVvsb+xMqpOG/le9LAxOnqL6Lr0sxVxhqiAMLZiKRXesLg34ht8Ug5ncl+XfzP50ZbdDj6JUPcpcCs9zb+D+dKWpQx1MGxcAnZfUOs6pRWm735/0ZzYb+5qS3JUO7jXuh0d5OGP/wCioZb0iq87sp+J0fPj2dSS+4/82J5yp60hd2Y/FKHnvceTu5EP8MpeXV9cwHeEIQOS20zEy+085mJFYM81J6M8sYiUo7p/l6P3fXEY8Lsi5uo+Wo9HriMWE2S1ImrN1RiPon9880rNyVCPGJJdLYXd0mjqldUyWGTNqPHe3HxbIu/Aaqb1lseQ6r8zcEyxrBtnUf1mupQBFmUEchEu00qrEJ8YysCD3sGxBU8NtfNr2zVXQjYb9volkYvQyOuUAFduR9YB5VO1T4xri5jtz5U7w5fqVDdT5FQc2xhztGxXWezMSPpHtJmcW471UykjeNq2jZsHJOtjdHsjFKqFCSSA2w8pRxqbbtBnI0hg8qOVOxSbH9eSFY0RWZAGTaMuw2PAXWDyxrwW6Z9Suc3ibet18fPr54jYd2K7zXaxNtvBAvbjEm0tIgjK6g24iNY6No55UTtN44NpXCVFJUKtLXxraq51W55a+A3RtYZsrr/UCAesaj6JReJqK2Lo5SQtk1k5rHM2y+0bI2YepVTfLvh/Um3pTb2yKY+6zpBKuFo5SbircgixG8Ycx28U7fcj+a6PlVfaNKz3W6X75QRWIJzHWBY3y7CP/EaO5viPiNMhrMrVBcGxtna378UC2oThYTSdTYyFxygG/oFjOvQrZhfKy+JlIMCBU2nnM8z0+0857Z5kVgzW5mxpqcxGNKe6n5Wj+/pLGPCbIt7qj/Eo9PrLGTB7JaROWZmFmZGQmxKpGo6x45rmYRvWx2dRmHS+ojoM0zbQc3AOsRsQMTotWUqACp2o4DIfuntiBu30JSoUKjBmpuUcpTJzq+VSzd7ZjmUgXOvNs4o5aT0+3ecfkHejh1YCpqYggkF8hW1ha/HKw3Q6bqnDAYmm5zLXpUGz52PfASajO18wuLb0gAahqFpQt7n3Jd9Ray3JUb4axrK/S6ATO1WoJUU3ANtVxtB5Dxi3JJHciK/CMQjLmz0RvbAg2qLfUePfC0e9LbkqNUkoCji1ze9gddrg3HEbEkSWyGrVM4vCWxKIrXvlsTxXLajbmnbo1qtG2YEDl2r17R0zOldFd70tRw7uX31FS9rGzE8WwnXydEs2juUoAC7OwNybnggXvcgajqOrXax6ZbIslqp90+NFRKZyjMGNzq1jLsvxyxO4uV7y1r3Ae+vVfvh4uI5ckUe6bo2hh2oJRXKxDs41m3AyEg7Abv1GG4TTNXCWZLMr3DodhXMdjbVP6mWXfdLNLf0pjWvZWYcxt2SdoFiabEkk5jrJJOxeMxYxWIWogr0mJQkBlbU6MfosOMchH/eMW5lr0SfrHsWUbqnCbnPbPE91eE3Oe2eJBhpHqNJMw+BD6wx5tnZEKR91lUB6PT2pGfAPcCZxm5+m43y3PEeMcxkKlo6rhuDd09I6PzEtSO6s9SNhcUrgWMlCRkxCerTFoGJsocJeeeJ7ocIQEetpGpRxmINMgZqjhgRdSMx2iL3dYpNW/wDTwoFzTqvkUWBYtTvlXiJudevx8s62lVZcZWDKVu7sLgi6ljZhyg8sxuwwjs+jKoF0Sk+Y32EmmR12tMmJJ3MYbGYSt31KGa6lCrFQCpIJBN7qdQ1iN1TT+kn4NPDpflux2k2JzbNZ65y33R0RsN/JR37FmV0wzoGpo7kkrlCgNcC9yGOofrsmPtlX3VzcVuZrVqxr1a698JBNlJ2bLG4sBqsANVp2HwGIcWfHVzxWVigsNg1GGHGOdlHwOqFJsWF2sOWwSS/+HNKPfLTpoLmxckm19VwXHZLoc7/hyhfNULu3K7m/JtFryC2ECVWWmhCDLlsCRrUE6+cmMjbksSEHf8Th6DAks2ddY4hZl1TUNA4akadSrpdWViwVVtUVyNTZQjayCeQwe2uvoWlnwdSxt/Ep6+LUG9GuOe5/CvTpZWFjmJ6LD9Jz8Nhe9UsOcMVy1HVqrlCA1HI7FmB4J1KLnXOhue0gMRSNUKFDO+WwsSobes31iLEwj1W4Tc57Z4mytwm5zPEisTINoQhW9KwPC6/1mwpIk9pUI5uSEacTo5WOZd63KNh8oTQtR0OVxzHiPMf1nWRw2zqg9MEWIuPHAho4M9zTUwRXWhuP6T+RmKdfiO309IhW+09UOEs8gz3RG+ECr8bj6iYzEJYVKffqhNN7kA5zvkbbTbxrqPGDO/i6OExHwMvVr0mUNSSmBfMTkBLEKVsMwsxtt6Jz8fg0XFV2arSBao7ZWq0w2tieDmzeiR0q3xjseDhsyLzUczu3S4duYgcUyYp+ExmBUUTQwmYVKhphqjAalCkvlFwRvhq1TkLuyxr1KlOl3iiqs6rko3bKrFRwmIJ1Di6JjAJYYBfr1D6MOB+c4ejwO/V7mwNSpyH6Z5Zz9RlljJ7brd07+h48M7lcsd6m3fx+l8Ywu+MqBbBT3nIguFAJJUZlYkEnWNZNrCwHBxeOLH+JVr1OLf1nYbLbL2k18I976z9YbbeO/YbjmmmvoEvwTZvECQedNo51vzTRlw527mVv9bdvF1PDjNXjkv305QNNeBSp9K3Ml4WrmNiqgHiCgdE5+KwFagQXQhTwXGtG12uG57jXyGTcBUuR++Kc3JjcfPl6HDnjnO3eHhd0bpRqI1JKyUaWFKBrrcVKeHVg+3ML1WbZxAeMOm5nE98w6PkVLlt6gsosxGoStXpMyYgAEk0sJ6Pgl+yWNuSQjC0wQQd9t8sz1p4fK5fUk1+E3PNc2V+E3PNcAhCEAhCEAm+nX4m65ohAnjxTTXwyvtGviI2zQlQjZJdOqG5+SEc56bp415R+Ym/C1AWWZ0ppJMPSeq9yEC5lQZm3xCqAvKSQNcU8JpxcRjMIaDBaf8QVUBVv4oByoWU2uFzMbXFwBfbdoKOMwpGOxTFdRrVSD99p0mwzd8x9gbk4kDx98LJq/HJ+kt1SU69RDgqYtUcF2bPchiCzLlGW58ZGvbJulN0tZWoik1Fe+UlqNlAZsxZgTa5sp3tiRr16zbVkjmYbRdYtg2FN8qZiTlOos6jWfuCLVfRr0KlQPluxZhldWNs998qm4Osbei8ZtO4a+lKdTWRUShUW+sA3yWHJwAemJuisKS9VbWLM/rkzm6nxPzP29DoNzLPv8X9GDRdQgcojDpHH0ME4U4epWqplZirKqqxAYar3NtXEZytB4Q99po2wug6MwvDdg2XFuC6MzWfem5UXKBW+sAmzmm3COfmy3eybhN1VKrZRhKSqN7ZjmstySLFQOM9cV9PYBcPj69NFCoCGUDYFZA1gOIBiwA8Un6NxFIsoqiwuMzrttx9MYN0egKdfEJiBiaSL3pEs7DMbZyGtca7OOqa+fjueFk8tvRdR/FybyvZxMZiaoTEKKrgImFVcjlQBmwt8pUjbdtfGCZYW5K/wSlcknf6ybnhtxmI+mKuGw9erh6grVHdKObIqKgyimy2YsT/yx9Hjj3uaKnDU8qkLvrAkMRvm2kAX6pvjjvluxHCaa5MxFC+sbe2QyJjVEIQlBCEIBCEIBNuG4Y6ewzVNuG4Y6ewwK00Rj6DHSOGrO1E1K7lairm3yYh2FxY69Q2ixF5509otcEtEYcZkZC7lLjhGyuqEkhcoA1EzkonxrE+fre1ed/dkptgyLgjDpZl4udeMenxjXMmJY+FK423B/fRNK4fKcyatd7bNfKLTFSmGNzZHP0l4D845eo9s9KzIbOLeMaweYwH/AEVp1GoUy1BXekqoGe2YZdmu2rZI9fdDTUlkwVAPytr90SDoxf4K+O569f5zXWwt+KF3ptrbscWdVIUaZH0RTt6WJ7IoYql32o7tenWdmdjYAMzG7NYWBuTxdcYW0ceSbFwysMrrmHpHjB2g+Ma+aNJstLXqUTashy/1jWOk8XTGHRzo4zKQf3xyZiNGPh6SVSQ9B2yBW1uCQx2AWK71uTi1HbI+ldAU6NLD4qg5HfKqU2prwVzhidd7g70C2oa9ggdDdjQwy45nqV0puypZSKjMQFA2IjR73N5fg1KzZhY2NiL75uI64lYPTdbH0MYtajlAou9OmyhmVlsUdWyg7Txg611E67Ou5lCuFoggghTcEWPCPFA600VqAbxHl/Wb4SK5boVNjPM6dRAwsZBrUSvNyzHStUIQlBCEIBNuG4Y6ewzVNuG4Y6ewwKkrYZ6WMrrUVlLVarrcWurVGKsOUEGNO6GhmXC+YQcf7/8AETaGNqpicSmqpTOJxB729yoJrOSyHajeNSL8d9kfl0jhX+DK6VQ5XIqAqQFSwLs2re69uomx1apkxKtfRQIPEebUecTzo7Q1YuA1F3p7TlQuOTek6ifETzm07+E3SAthe84ZEFaoykuS7hFNLWDqsx74eMgZeOKlHdfjX7671iQDYKoCKFLWsClmBtx3vNfJy44SW/Lo4Ony5rZjZNTZ3wug6qllVGVVZgpc0wGANgbIbAG1wQBqIuL6p5xWGp0tVfE4ekeRqgzfhNpW+MrtV198qP8AUqOzOOWxOph4wAfqga5xKiANqAsdc1Zc9nw68PT93vl/i0qul9GpqbFs55KdJj1NYr6ZHXdNgSbJh61Q8Rdgin8JJ9Erqks6eCXfDp7DOfPqs54dnH6Xxa77q0MWtLGYaklNqVMJkq1KbPrTPSDrdiL2tV22135xN9Xc8XwyUEqIctcO7bQAlwygcbA2Gu1jzRHxNiuKYpcGhhLqu91ZcJcC2z/tLJ3JBPgyZM+UlzvwAxObWTYntnoR4N8upSwlNGZkRVZuEwUAtx6yNZkmEIBCEIBPJF9RnqECDXw9tY2dkjzrSJXw99a7eSTQiQgRCFE24bhjp7DNU24bhDp7DAqj4IRicQSNtaseuoxk3FNlfEMdXeaHelP1nUqeqrXYdAng6cdsTXQUqKqtaqt8rsxy1GW5zOVubX4PHPGOx1WomPV3BUVCFARFsFxlMDgqCTbjNzMmKfo7AVGfAsqMyJviQpIBNUA3I8VMRTxWjHw4qJUy3NmGVlbVnHCUG6nxHovGGgL4rAAk2FNCBfVf4VV125dQ6on4BB3urYbSPXnH1dkxn5j1PS8blnZPs1M48fVNVV8x135+Pp5e3nkwUZnvPinHeZ7OPT67olNSJ0MJwh0+qZrFK2yb8PTIa9jax1nZsPHNVu3RJ7ce5lbHuiYjKtMFKOFUNkLMbrhASwZipO+Nt6Ng6bA3IuWwtMsQSc97KqjhH6KgD0SvMUhIxeVbbzC2AubD4pqF+S0sPciPitL7/rme5Hxl8u7CEIQQhCAQhCAQhCBorUA3iPL+shOhBsZ1J4qUwwsZNDmTbhuEOnsMxVpFeblmcNwh09hhVSYdLYvE+fr+1ebqy7zSHnG/vac7+PTAU6ztUxYDmo5KojOwYuSVJUGx121xg0TovCVlqVEVmFRmzZja5zBzYDXttMmJNwyH4TgTbV3tBf8AzVWLGjtG1hnUozZthUXPCvYqO2XjR0ZSXLlpoMupbrcjWW1E69pJ6ZKSmALDUOQADsmvl48eSarfwc+fBl7sVP0ty2KY2GHfi1syIpuLixueXo2bZ0sPuFxJ4XeU8pmc+jVLQyjkhaacek4p8bdWfqfUZfOvwr87iFpqWq4h7KLsKdHsIBMNHYHRzsiKlaobhSzmwJLaiwuDcX4hxCWDIA0VSFTvgUBhr1agCOMATbOLDHxI5c+o5c/qytJuktL1KNRlp4GllvkFRnL5lQhRdcosRkXVc8GN25/ENUoI7qqsc2pVyqLMRqFzJi4RACAii5zGwAu175j478ckATY0swhCAQhCAQhCAQhCAQhCB5IvqMjChlYEbNfRqMlwgLWI3K06hLVGzMWJDBQDlLXym976tQM6uB0WlJFRM1lYsLsb3Isb2tcW4tk6EIBCEIBCEIBCEIBCEIBCEIH/2Q==",
                    Price = 8400,
                    IsFavorite = false,
                    Available = 45,
                    Category = Categories["KONTINENT"]
                },

                new Window
                {
                    Name = "Panorama FX5",
                    ShortDescription = "ООО “Панорама” работает на рынке светопрозрачных конструкций более 12 лет и является одним из наиболее активно развивающих " +
                    "участников рынка ПВХ в Западной Украине.",
                    LongDescription = "ООО “Панорама” работает на рынке светопрозрачных конструкций более 12 лет и является одним из наиболее активно развивающих " +
                    "участников рынка ПВХ в Западной Украине. Миссия компании - успешная работа по созданию качественных изделий и услуг, способствующих улучшению " +
                    "качества жизни людей. Они несут ответственность за результат своей работы. Это - один из основных принципов политики компании.",
                    Image = "https://oknaekipazh.com.ua/wp-content/uploads/2020/09/Alyuplast-2000.png",
                    Price = 7230,
                    IsFavorite = false,
                    Available = 32,
                    Category = Categories["PANORAMA"]
                },

                new Window
                {
                    Name = "Steko 4s",
                    ShortDescription = "Современные металлопластиковые окна Стеко (Steko) – это новейшие технологии и материалы, системный контроль качества изготовления " +
                    "профиля на всех этапах производства.",
                    LongDescription = "Компания «Steko»(Стеко) производит все виды профильных систем для изготовления металлопластиковых конструкций. " +
                    "Металлопластиковые окна «Steko»(Стеко) созданы по современным технологиям, ведущих европейских компаний. Отличаются высокими показателями в отношении " +
                    "эстетичности, функциональности и надежности. При этом цена изделий Стеко, самая оптимальная на рынке в Днепропетровке и Украине.",
                    Image = "https://mobiplast.kiev.ua/wp-content/uploads/2018/11/SOFTLINE-70-min.jpg.pagespeed.ce.bJbo3UPahh.jpg",
                    Price = 5650,
                    IsFavorite = false,
                    Available = 8,
                    Category = Categories["Steko"]
                },

                new Window
                {
                    Name = "Elegant",
                    ShortDescription = "На заводе КОНТИНЕНТ изготавливаются окна различного уровня сложности.",
                    LongDescription = "Окна могут иметь самые разные формы: обычные прямоугольные, арочные, " +
                    "круглые, трапециевидные, треугольные или многоугольные. Они могут иметь всевозможные варианты по размерам и открыванию.",
                    Image = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBIVFRgSEhEYGBgZGh0ZGhgYGBgaGBgcGBwaGhkYGBgcIy4lHR4rIRoYJjgmKy8xNTU1GiQ7QDs0Py40NTEBDAwMEA8QHxISHTEmISMxNDQ0NT02NDoxPzQxNTU1NTw3NDU0PzE0MT0/NDQ/NTQ0NDE1MTQ1MTQ/MTE0Oz0/NP/AABEIAR8ArwMBIgACEQEDEQH/xAAbAAABBQEBAAAAAAAAAAAAAAAAAgQFBgcDAf/EAEwQAAIBAgEHBQsIBwcFAQAAAAECAAMRBAUGEiExQbIyUXFycwcTIjM0YYGRobHBFCM1UnSDs8IkNkJigpLRFSVEU6K08GOTw9LhQ//EABoBAQADAQEBAAAAAAAAAAAAAAABAwQCBQb/xAAoEQEBAQABAwMCBgMAAAAAAAAAAQIRAwQxIUFxMlEFIiMzgbESExT/2gAMAwEAAhEDEQA/ANVrco9MTFVuUemJgEUdkTPTsgZ3ifL/AL08Bl6w+yUXE+X/AHp4Gl6w+yA5WLxnIfqN7jELF43xb9RuEwKZmfyH644RLQ0q+aHIfrjhEs7bumBEZv8A+K+11PckkcdyW6G4ZHZv/wCJ+1VPySQxx8B+q3CYGQI19Mczn2kf/Zbe54fnG6PgJT6B8Op1viZb+5zy26D8IGjCUDNr5nKuIo7A+nYfxCov+m8v4mf5a+ZyvRqbA/eyf4r0j7AIGhNKrn/Q0sOj/UqKfQ1095WWppFZx0NPDVlteyFh0p4Y4YDDub4i9CpTJ1pUJHmV1Uj2hpcpm3c2xGjiKtP69MP/ACNb/wAk0mAQhCBH1eUemIi6vKPTEQCenZPJ62yBnWI8v+9PA0veH2Si4ny/708DS9YfZAcrF43kP1G4TELF43xb9RuEwKZmhyH644RLM26VnNDkP1/yiWZt3TAic39mI+1VfeskMcfAfqtwmR2b+zEfaq3EJIY/kP1W4TAxyjy363/tLn3Oj8448zfCUylyqnW9xMt/c9e1dxzhrew+4GBpAlD7pdMq2HrrtGmt/ONF09zS+CVjuhYfTwmn9SojfzEp+cQLMlUOquNjAMOhhce+BQMCp2EEHoOoyIzSxGngqDc1MJ/2yU/LJdYGZZq1DRx9JWO0vTbpIYD/AFBZr0xvOQ/J8czjVoVUq+tlqH3mbEDfXAVCEIEfV5R6YiLq8o9MRAJ62yeT1tkDOsR9IfetwNL3h9kotby/71uBpesNsgOUisd4up1G4TPFhj/Fv1H4TAp2aHIfr/lEszbumVnNDkP1/wAqyzNu6YERm9ya/wBqrccf5R8W/UfhMj83T4Nf7VX44/yl4t+o/CYGP4YXdxztb2tJ/NGpoYlL/wCYEP8AGGT3mQOE5T9f4mStzSr1G3q6uPWHHvga+Iwzhw+nha6AXJpsR0qNJfaBHysDYjYdfrnRVBuDsOo9BgU/ub4jSwr0/qVGA6GCsPbpS2rM/wC50xp1sThidY99N2RuIS/rAzrulYe1ZX3PT9qlgfZozQ83MT3zC0Kl7k00v1goDe0GVHul4e9GnU+q7J/Ot/ySW7m+J08Eq/5bsnrs/wCeBbIQhAj6vKPTERdXlHpiYBBtkINsgZ1W+kPvW4Gl8w2yUOr9IfevwtL5h9kBysMf4t+o/CYLPMf4t+zfhMCn5o8h+v8AlWWU7umVrNHkP1/yrLK27pgQ+bh8Cv8Aaq/4hj/Kfi36j8JjDNvkVvtWI/EaPsqH5p+o/CYGRYPlP1/iZOZy1USsgN71MOj6h9V3U39CiQeC5T9f4mSOenlOH+yfnqQNSyBiNPDUKn1qaHX1RJRJCZp+R4bsk4RJpIGZ5MxWhl6tQVbAlyTfbp01qnV1jNJWZbgP1jrdLf7dJqKwK53RX0cBUYbVZLX87qp9hMiu4zineliNI6g6WAFtzX9w9Uku6V9H1etT/ESRPcRHzGI7Rfc0DT4QhAj6vKPTExVXlHpiYBBtkINsgZzU+kPvX4Xl9w+yUOp9IfevwPL5h9kBys8yh4qp2b8JnqzzH+Kqdm/CYFOzR5D9p+VZZW3dMrWaXIftDwrLId3T/WBEZtcit9qxH4rR9lU/NP1H4TGGbPIrfasT+M8e5VPzT9m/CYGS4Hlv1/iZIZ5n9KofZBx1JHYHlv2nxMkM8/LKP2NeOrA07NTyPDdinCJMpIbNbyPDdinCJMJAyrJv6xV+l/wFE1JZluSP1hxH8f4dMTUVgVnuln9AqdenxrIvuIj9Hr9ovCZJd0s/oD9dOMSP7iXk1ftBwwNMhCECPq8o9MTFVeUemJgEG2Qg2yBnVT6Q+9fgaXzD7JQ3+kPvX4Xl8w+yA5WJyj4qp2b8JiliMpeKqdm/CYFQzS5D9oeFZYzu6f6yuZo8h+ueFJYzu6f6wIfNjxdX7Vifxnj3KviX7N+Exjmx4ur9qxP49SPcreJfs34TAyfAcpu0+MfZ5eW0vsScVaMcn8pu0+MfZ5eW0vsScVaBp+a/keG7CnwCTCSHzY8kw3YU+BZMJAyrIv6w4n7zgpiagsy/If6w4roqcNOagsCrd0zyB+unFGXcR8mrdoOGPe6Yf0B+0TijPuI+S1u1/KIGlQhCBH1eUemJiqvKPTPIBPG2T2eNsgZy/wBIfevwvL7h9kobfSB7V+F5fMPsgOViMp+Jqdm/CYtZyyqfmavZvwmBUs0uQ/aHhSWI7un+sr2aABRl0l0u+E6JIuRorrA9ctBwratY2+fz+aBX82D81U+1Yn/cVI8yv4mp1H4TGebAIpP9pxP+4qRzllvmKnZvwtAyvJ3LPafGPs8fLaX2JOKrI/JjDTPaD3x/nj5bS+xJxVYGo5s+SYbsKfAsl1kPm15Jhuwp8CyXWBlmQf1gxXRV91Oaeky/IH6wYroq/wDjmnpAq3dNP6A3aJ7zG3cT8kq9t+VY47px/QG7RPeZw7iXkdXtjwJA0iEIQGFXlHpiYqryj0xMAnjbJ7EtsgZ230h96/C8vmH2ShH6QPavwvL7h9kBys5ZV8TV7N+Ezqm2ccrH5mr2b8JgZpgWIJsd8nMHnBWS2kdNRrs23ZfU233yu4dtt77do3Tuzm31h7dkCx5n5WpGkyM4Vmr4h7NqFnrVGAvsO3/5JPOGmvyeqRq+bfo2NM4yYw0Dz6dTp5bx6coVVRqYclGUqVOsWI3A7PRaBV8nco9oPeJJZ3n9MT7GnFUkZgGsxJ3VBf1iPs66qti0ZWDD5IguCCLgvcXG+Bq2bh/RcP2NPgWS6NITIFRRhsOCw8TT3/uLJKniqZOjpi/Nfb0QM1zeP9/4rore+mJp6TLs2j/f2L6K/FTE09WgVXuon9B+8T80R3E/I6vbngSed1F/0IdqnC897ifkVTt24KcDR4QhAYVeUemJiqvKPTEwCJfZFRDQM7J/vA9q/C8vuH2ShDy89q/ueX3D7IDpBrEb5VR2puiqbsjKL6hcqQJ3E6rU3HWPbAyynk+ojaFWmyEnUd3RzMOi3TFYjCOusi4+svxG0e7zzTquFRxYgMPqsJFYjItvF7PqPrHoO0QMvyePANx+2+sdd4VXsNRvq9OyWzE5vUtaqrUXJLbdTFjc7bqwuencCJAZSyZUpAl0uoHLQEgagLsu1faPPAqtBgdJTtLE2Ma1NVZuzO2SaoCp1aQv/wAtInGEK9lJ5O/bbXcQJ/JeX8RRAW+mgA8E67DmG8eg+iWPDZw0qtrnQPMdnr3ekCUZC4sWXSXR2ryh0jfHNLRfkkEj0MPjAe5vV2XKld0bX87rGu4009Y2TScNls7KifxL8QZjGT2YYlyrEEaevfqYbxLZg8u1E1VF0hz7/wCYfEemBYO6TiUfBDQYH51NW/kvtG0R73FPIqnbtwU5Ts7soU3ww0Gse+LqOo8l9+w+gyc7kld1w1SzEWrHoI0Kevz79cDWoSMo5S3OvpH9I+p1VbWrAwGtXlHpiYqryj0xMAnNp0nFzAz5fLz2r8Ly+4fZKCnl/wB6/ueX7D7IDkT2eCewPROi1Pra/fOcIC6lBHFiAw5iJFYnJBsRTIZd6PrHQDu9MkhO6PfUReBm+UM0qTNenpUHJuUPIbntu9UzzOrC94xBpVCCQikkDVrvqtuItNWy3nh3us+FfA1NFTolmGkz6QbQqU0S40DYnTLC1rWB1DGc4GJqeE+mwWzG5JBLOdE+cAiBOvgXphDURkDopVjrR7i4swuCbbr35xEPRU63Wx+suoj0zT8lNTfDUlOi6tSQEamDDQXURsMh8o5r02N8MWRj+wVZkPPYHWvouB9WBmOAD/KHCMNLw+WL6XhDUfOdsnKOJANqilDz7UPQ270xjm9k41sbUo3VT85cknRGi4v5zL1hs0WBCvXB0r+Do3sBvJufN6xqipUnOOmBSVgBYuNYOo+C3Nqj/MLK4wqVKj3KAsWUX8I6KqgOiCbaTLc7hF595Cp4ajTam5u72KfsiyMb2G/zxhmdlA0T4VIVEJbSQnRvpLo3DgEi2o6uaPZDQssZ31aVPDPTw9EGsjswcO4Uo2gAutfbJnM7LFfE6ffdAaKqQETRtcm+8mU/Oh0elgnSkKYtXUIGLhQroeURckljLJ3Pxrq9VfeYFuqco9MTFVOUemJgEb1jHEGwqPvIPNeBmSVB8v8AvH9zTQsMdUhsp5oU2Y1KRKPe51mxPPfaD5xPMFjKtE97xCHV+1v6fOPOIFkEVOFCsri6kEeadxAIQnsDydKW0REXS2iBQcl5xvVxb4bE0adXQxNRKdQ2V6atUZLCw1i1huOoXudczDPLDU6eMrJTUKgdwFXYNF3X3KJeMhsDlF9f+Lf8ZpEtQAx2Md1FjXq2JF9ffG9sCQyBnth6eGp03SoXSmqaKKCLIALht2kL36eidnz4cro0MJVJC2UuABf6zaI1+i2/zWbCpTHJHqFoHFDmMcJ5VnJWFx1Kv8pRLOSxOkVs2mbsGF9hllfK2VX2vRQWt4Ki4BsDY6+YeqefKidQA98c0sJin5FCoeim1vXaEIXG5Ir4hg2KxRcgWFlAsOYDZ7NwkVgKYpu1PXYOwud9jb4S90s3Me3/AOJHWZF9l7xNXNR0v33EYWiTe5eoAb7ydXxgN8tUy2GwTKLgHEX9L0/6Sz5gDxnQn5ozpUxQwV6VXD4sUXABKlgq1XAI01ezWJ5tg9JtmS6lO7oiqtRAgqKlMABmUNza9rb9VoDupyj0xMVU5R6TEwCewhA6pV3N6988xGGR1syhh7ug7pznqORsgRFfJdSkdOkxI3jf6Rv6ds7YXKIPgv4J9h6D8JMo4PmMa4zJyPc2s3PuPSIHoM9kX85SNiLrzE8LfA+yPsPiVcaj0jeOkQO8XS2iIE6UhrEDF3wVenjK1SmDf5RUcW1kHvjMDLvlXID4oJiKNNKb1BeqKhdTpgBdS2It4J1gXOozPcp5Wxj4mupxdbRFaooVajqoUOwA0VIGoWGySGEXQp1azklhScaRJJvUtSGs69tQQJunkTD06gGIx+GureHTDlmNjrBUFWB3RtlbOalQxFTD0Mm4chG0Q7+GW1A6WjYW288hsXhwa61wNVamrnrr4FT0ll0/vI3zgH6diOuOBZV1tXOeY09p0873xqJXGd0OvTJpjRRht71SUAXAOrTLc/NIzEZ+Yt9Rq1T5w4T8NVkNlHAl6rm20jo2D1Ti2Sag1qNLzb/RuPvlczdZltvj7tF3nO7mZkkvHhItlyvU1Mxa/wBd3c+tmM6Iiuln0FsVsSFVVJYDbuGu1zIrDixsRYjaDqI9ElGF6bjq8QlGpxqfMbs3np34v9NMyO1NaGHp/KsOAe+BkYCotRg6OrKVcXKDR3keGOYR/moMOwr1KGINdqjBnYqUFyWIsCNms+oSmYBLfJB56zevvY/JLD3NFtQqfwe5pvjwdeVtqco9Jnk9qbT0meSUCEIQCEIQCdUrbjOUIDpkVhYgESLxWTCDpUydX8w6DvHmjxGI2RwlQHzGBDUcaV1VB/F/7DdJOgwJBBnLKbUFXTrVEpjZpsyqOi51GVPJ2XX/ALTGBVLIFe7k8tkG1BuA39MCgYjDkYmsSNtaofW7R9lgMMKQguXqIh6qh6jf6lpyfxFXJAqPp5QDMzsdFEY6yxNtIAgmd8dj8mUaFOo1OtUVqrogJVSW0ULX1jVYC2/bArWFGnh9Y8Kk4fz6D2pv/q70fQYxzg8uxHaflWXDJOX8M9RadPJ6KrsELM5Y6LkA6ivxlRzj8uxNv81h6rCUdf6G3sf3P4dsOoZ26dcslPJuFoFGxmKpUdKz95c+Gy33re4vYjf65AZBW+LUHYaqerSWReedWoMfie+qxBqHR0wdaDwVKk7VsLC3NOuj9M+HHdX9S8ferhjBkSqFXvtRiul4SIwY6RuLsy6wN3mkDl7I/wAmJRX06bqr033srNsYfWFvTq2bA0yHTpuyrTNmJACnnJsJa87cmVT8npIhdloIDoAsLqxvYgSOriXi+/MT23V1m2W+llNMJysKP+m7et6g/LLD3Nx8xU6U9xkQcnvTfDvVK01WjonvjoliXrE6nIOxl9csGYmGCUaih0fwl102DAWG8jVLoy68rFU2npM8nSshBvuM5wgQhCAQhCAQhCARQngnogU7OrI2FxuK72tY08WiKPCLBWptdrIf2XGvWuvnB1Fc+x+WK2AxznDkOKLNTVql3uQCjNUsQdLz3F7DbLtldf75Q9j7xM8ztRhjsUw31n6D4R2wIx6umzObXYljbZdiSbDm1yQbKOIeiMM1QtSD6egQOVYAEta5tbUCZGJQB1r4J5tx6I7oEjUwsYFhzVxJWvSViLd8QksbaIDAkkndYHbLFlvAZMetUrVMqUULuWshFRhfcQp+Ep+EXlEbkY/6SB7SIwGT+YSLJZxXWdXN5zeKu1PLmRcO6uKuIqsrBhoUiqkqbjW4W41c8p2dGVq2LxDYhmZkuRTBCgpT0iVUhNtrnXc9MSmDI8Fl0l5j8OadqWTHXwqJ0hvRuUOjniSScQurq83yZYKpsIPpEumCzlx2ilNcQVVVCgKlMagLDXo3lfo4KnU2XpvvFtV/3ljxKFWlbviEKTZXsdBjtsG2XsDq26jJcpbPe7nBO50mNFiWO0+ENplu7n6Wo1B++vDIrLOSGq0MNXJVUp0PDdmVVXXfXcydzHCCk+hUWoNMa0vYeD+8Bf0XgWoi8bVaNtY2e6O4QI+E71aG9fV/ScIBCEIBCEIHonqxMUsDPMu4xEyyumbAd5JPMNWsyIzpyUy4utpry3ZxzFXJYEe7pBjnP7Jrvj3qJ9RB6lljwuAqYzDIKiaFal4AZwwV0tq8K2si3n2fvQM3q5I3pqPNu9HNG5p28FxNFoZHw5YI2Pw+kTbRRg5vzWBEZKcj1EZxWq1ggVjoKUJ0mVBbSA3su/nkWyeUzOreJOUHhcj1Ep98IbQcWBKnRvcGwbfsPqM6pg1E64jPTAIAlLJrvoFrd+q6IGlohtS6YI8BNXmnBu6HiB4jCYakOozN/NdR7Jzd5i2dDd9j6hktn5FN26qsfcI9o5q4lta0SPOxVbes3ldqZ5ZRqbcUyjmVEUesLpe2O8mYzEOKxatUdvk9e2m7Nr7y9rBiRtnH+6f5SceV3/FuZurZ6TlLZyZOSmlBCE+UKWLlBrKNySzW1nULdJnXOFnqZLoBwWIrKqgLckKrqo1c+y/nnPC514p6L1DhqHfkRfDKEljpohJF/qsdV9tuiXjNnGVK1BKlW2kdK9hYamsLCXMasZt5GxjCocQ695qYbvSIC2jZlAW6aRF1F7tYHWdt5Y82cifJaZp6Ye7XuBYDVa198nLDmioBCEIBONWlfWNvvnaECPItthHdSmD088aspBsYHkIQgAiliYpYFLytXxP9phFqOKXzfgqbAkgaV7az6ZB5r5ExdOotSuKjEK/h1C1+Q299ZktlnG1v7U70KzhB3uyB2CawCbqDY+mVfMZL1FdiS2i+sm5Pzb7SYHLMymA9M/vLIPIa8j+H4Sw5pDw06RIHIv7H8PwmbufD0fw6fmqMrctus3vM6UhOtWgdJusffPUpESu6nDTMWaOqCyw5v1SnfXUAlaFZgGF1JFJzZhvEgqIk5kYeDX+z1/wnleb+efLR1Zx0NfFOcHlbEGhWcEKdBLd6SnTYXrUgdFgt72J2maXm4D8np3qVKl1Y6VQEObtvBJOrd5plGGS+GrD9xPx6M1LNKq7YamzszNZ/CYkk2awuTPRfOp6EIQCEIQCEIQCIZQRYxcIDGpTK/wBYmPiL6jG1WlbWNnugcopYmKWBn+WfpZvuuFZA5k8pOo/4byfywD/azfd8CyHzOoMrqrD9l/w3gNc0+Un/ADdK/kRgdAj934S3ZsZNqK6AISL7gTbVvnHB5jYsEPTpFdhIchAem+sGU9fp3WfTy2dn1s9LfOvCBNLWekxQpeaXahmJXblvTX+JnPqCj3yVw+YVMcuszdRFXi0pknR6t9nqa7zt8+/PxGbLRO6TGRKRPfk2FsPXA/7bD4iXvE5r4ekhanhmrsP2WqspPoUWPRac828epdkXC0qACEmy+FqttbVcS3Hb6mpdWejJ1/xDG8XGJfX09VRyfkms1GrTSmxJRLWUm9qtJt3mBPomjZsYV6eHpo6lWAe4O0Xa49kYZw4HHE98w2JfQ30wFBHnVgLn136ZJ5AWoKKCqSXsxJY6RsWuLm/MRNjyktCEIBCEIBCEIBCEIBCEIDarR3r6v6Tiu2P5xqUr6xt98CHylkunptilw7VagsQobRvogAW59UiM3MqI9Xva4JKJCnWTpOLD6xA88uFNSLnXrOw21ararTkMJTDmoFAcixawuf8Al/dzQOqoLajq82z2ReiOaAWwsIqAQhCATgtBAxcKAzWuQBc22XneEBIFtULCKhAIQhA//9k=",
                    Price = 6500,
                    IsFavorite = true,
                    Available = 13,
                    Category = Categories["KONTINENT"]
                }

                );
            }
            appDbContext.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        private static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{ CategoryName = "WDS", Descroption = "ТМ WDS - это ключевой бренд компании МИРОПЛАСТ, одного из крупнейших производителей " +
                        "оконных и дверных ПВХ профилей. Уникальное качество продукции под ТМ WDS признано производителями окон и дилерами по всей стране."},

                        new Category{ CategoryName = "Steko", Descroption = "Компания Stekloplast производит окна с 1997 года. В производственном цикле используется " +
                        "оборудование от ведущих мировых производителей (Sturtz, Federgenn, Rotox, Aluma), которое позволяет изготавливать до 1800 конструкций " +
                        "в сутки, сохраняя высокое качество изделий."},

                        new Category{ CategoryName = "PANORAMA", Descroption = "ООО “Панорама” работает на рынке светопрозрачных конструкций более 12 лет и является одним из " +
                        "наиболее активно развивающих участников рынка ПВХ в Западной Украине. Миссия компании - успешная работа по созданию качественных " +
                        "изделий и услуг, способствующих улучшению качества жизни людей."},

                        new Category{ CategoryName = "KONTINENT", Descroption = "Завод производит окна и двери из ПВХ и алюминия различной конфигурации и назначения. " +
                        "Кроме стандартных конструкций, на заводе изготавливаются окна и двери необычных форм, размеров и способов открывания."},
                    };
                    category = new Dictionary<string, Category>();
                    foreach (var item in list)
                    {
                        category.Add(item.CategoryName, item);
                    }
                }
                return category;
            }
        }
    }
}
