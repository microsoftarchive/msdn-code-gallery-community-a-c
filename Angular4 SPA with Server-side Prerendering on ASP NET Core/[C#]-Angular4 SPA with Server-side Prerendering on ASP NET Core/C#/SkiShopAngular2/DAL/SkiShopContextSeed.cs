using System.Collections.Generic;
using System.Linq;
using SkiShopAngular2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SkiShopAngular2.DAL
{
    public static class SkiShopContextSeed
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (SkiShopContext context = app.ApplicationServices
                .GetRequiredService<SkiShopContext>())
            {
                if (!context.Styles.Any())
                {
                    context.Brands.AddRange(
                        new Brand
                        {
                            BrandName = "Rossignol",
                            MadeIn = "Spain"
                        },
                        new Brand
                        {
                            BrandName = "Atomic",
                            MadeIn = "Austria"
                        },
                        new Brand
                        {
                            BrandName = "DPS",
                            MadeIn = "USA"
                        },
                        new Brand
                        {
                            BrandName = "Voile",
                            MadeIn = "USA"
                        },
                        new Brand
                        {
                            BrandName = "Komperdell",
                            MadeIn = "Czech"
                        },
                        new Brand
                        {
                            BrandName = "Volkl",
                            MadeIn = "Germany"
                        },
                        new Brand
                        {
                            BrandName = "Fischer",
                            MadeIn = "Ukraine"
                        },
                        new Brand
                        {
                            BrandName = "Salomon",
                            MadeIn = "Austria"
                        },
                        new Brand
                        {
                            BrandName = "La Sportiva",
                            MadeIn = "USA"
                        },
                        new Brand
                        {
                            BrandName = "Foon Skis",
                            MadeIn = "Canada"
                        },
                        new Brand
                        {
                            BrandName = "K2",
                            MadeIn = "China"
                        },
                        new Brand
                        {
                            BrandName = "Head",
                            MadeIn = "Czech Republic"
                        },
                        new Brand
                        {
                            BrandName = "G3",
                            MadeIn = "China"
                        });

                    context.Categories.AddRange(
                        new Category
                        {
                            CategoryName = "Cross-Country"
                        },
                        new Category
                        {
                            CategoryName = "Backcountry"
                        },
                        new Category
                        {
                            CategoryName = "Downhill"
                        });

                    context.Styles.AddRange(
                        new Style()
                        {
                            StyleNo = "123456",
                            StyleName = "X-ium Skating NIS Skis",
                            Gender = "Unisex",
                            PriceCurrent = 365.00M,
                            PriceRegular = 489.00M,
                            ImageBig = "/image/skis/123456big.jpg",
                            ImageSmall = "/image/skis/123456small.jpg",
                            BrandName = "Rossignol",
                            CategoryName = "Cross-Country",
                            StockLocation = new StockLocation
                            {
                                Zone = "A",
                                Slot = "1"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "12345601",
                                    Size = "173cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "12345602",
                                    Size = "180cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "12345603",
                                    Size = "186cm",
                                    Quantity = 4
                                },
                                new Sku
                                {
                                    SkuNo = "12345604",
                                    Size = "192cm",
                                    Quantity = 2
                                }
                            }, 
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "123457",
                            StyleName = "Sport Pro Skintec Skis",
                            Gender = "Unisex",
                            PriceCurrent = 279.00M,
                            PriceRegular = 399.00M,
                            ImageBig = "/image/skis/123457big.jpg",
                            ImageSmall = "/image/skis/123457small.jpg",
                            BrandName = "Atomic",
                            CategoryName = "Cross-Country",
                            StockLocation = new StockLocation
                            {
                                Zone = "A",
                                Slot = "2"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "12345701",
                                    Size = "176cm",
                                    Quantity = 1
                                },
                                new Sku
                                {
                                    SkuNo = "12345702",
                                    Size = "184cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "12345703",
                                    Size = "192cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "12345704",
                                    Size = "200cm",
                                    Quantity = 2
                                }, 
                                new Sku
                                {
                                    SkuNo = "12345705",
                                    Size = "208cm",
                                    Quantity = 1
                                } 
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style()
                        {
                            StyleNo = "123458",
                            StyleName = "E99 Easy Skin Xtralite Skis",
                            Gender = "Unisex",
                            PriceCurrent = 489.00M,
                            PriceRegular = 489.00M,
                            ImageBig = "/image/skis/123458big.jpg",
                            ImageSmall = "/image/skis/123458small.jpg",
                            BrandName = "Fischer",
                            CategoryName = "Cross-Country",
                            StockLocation = new StockLocation
                            {
                                Zone = "A",
                                Slot = "3"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "12345801",
                                    Size = "180cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "12345802",
                                    Size = "185cm",
                                    Quantity = 0
                                },
                                new Sku
                                {
                                    SkuNo = "12345803",
                                    Size = "190cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "12345804",
                                    Size = "195cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "12345805",
                                    Size = "200cm",
                                    Quantity = 0
                                },
                                new Sku
                                {
                                    SkuNo = "12345806",
                                    Size = "205cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "12345807",
                                    Size = "210cm",
                                    Quantity = 1
                                }
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        }, 
                        new Style
                        {
                            StyleNo = "123459",
                            StyleName = "Delta Course Classic NIS Skis",
                            Gender = "Unisex",
                            PriceCurrent = 299.00M,
                            PriceRegular = 399.00M,
                            ImageBig = "/image/skis/123459big.jpg",
                            ImageSmall = "/image/skis/123459small.jpg",
                            BrandName = "Rossignol",
                            CategoryName = "Cross-Country",
                            StockLocation = new StockLocation
                            {
                                Zone = "A",
                                Slot = "4"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "12345901",
                                    Size = "186cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "12345902",
                                    Size = "196cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "12345903",
                                    Size = "201cm",
                                    Quantity = 0
                                },
                                new Sku
                                {
                                    SkuNo = "12345904",
                                    Size = "206cm",
                                    Quantity = 1
                                }
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "123460",
                            StyleName = "SCS Skate NIS Skis",
                            Gender = "Unisex",
                            PriceCurrent = 287.00M,
                            PriceRegular = 384.00M,
                            ImageBig = "/image/skis/123460big.jpg",
                            ImageSmall = "/image/skis/123460small.jpg",
                            BrandName = "Fischer",
                            CategoryName = "Cross-Country",
                            StockLocation = new StockLocation
                            {
                                Zone = "A",
                                Slot = "5"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "12346001",
                                    Size = "172cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "12346002",
                                    Size = "177cm",
                                    Quantity = 0
                                },
                                new Sku
                                {
                                    SkuNo = "12346003",
                                    Size = "182cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "12346004",
                                    Size = "187cm",
                                    Quantity = 1
                                },
                                new Sku
                                {
                                    SkuNo = "12346005",
                                    Size = "192cm",
                                    Quantity = 0
                                },
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "123461",
                            StyleName = "Equipe 8 Skate Skis",
                            Gender = "Unisex",
                            PriceCurrent = 279.00M,
                            PriceRegular = 279.00M,
                            ImageBig = "/image/skis/123461big.jpg",
                            ImageSmall = "/image/skis/123461small.jpg",
                            BrandName = "Salomon",
                            CategoryName = "Cross-Country",
                            StockLocation = new StockLocation
                            {
                                Zone = "A",
                                Slot = "6"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "12346101",
                                    Size = "174cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "12346102",
                                    Size = "179cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "12346103",
                                    Size = "186cm",
                                    Quantity = 0
                                },
                                new Sku
                                {
                                    SkuNo = "12346104",
                                    Size = "191cm",
                                    Quantity = 1
                                }
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "123462",
                            StyleName = "SC Skate NIS Skis",
                            Gender = "Unisex",
                            PriceCurrent = 186.00M,
                            PriceRegular = 249.00M,
                            ImageBig = "/image/skis/123462big.jpg",
                            ImageSmall = "/image/skis/123462small.jpg",
                            BrandName = "Fischer",
                            CategoryName = "Cross-Country",
                            StockLocation = new StockLocation
                            {
                                Zone = "A",
                                Slot = "7"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "12346201",
                                    Size = "172cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "12346202",
                                    Size = "177cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "12346203",
                                    Size = "182cm",
                                    Quantity = 0
                                },
                                new Sku
                                {
                                    SkuNo = "12346204",
                                    Size = "187cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "12346205",
                                    Size = "192cm",
                                    Quantity = 0
                                },
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "123463",
                            StyleName = "Snowscape 7 Siam Skis",
                            Gender = "Women's",
                            PriceCurrent = 189.00M,
                            PriceRegular = 189.00M,
                            ImageBig = "/image/skis/123463big.jpg",
                            ImageSmall = "/image/skis/123463small.jpg",
                            BrandName = "Salomon",
                            CategoryName = "Cross-Country",
                            StockLocation = new StockLocation
                            {
                                Zone = "A",
                                Slot = "8"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "12346301",
                                    Size = "Small",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "12346302",
                                    Size = "Medium",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "12346303",
                                    Size = "Large",
                                    Quantity = 0
                                },
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "223458",
                            StyleName = "Wailer 99 Tour1 Skis",
                            Gender = "Men's",
                            PriceCurrent = 1099.00M,
                            PriceRegular = 1099.00M,
                            ImageBig = "/image/skis/223458big.jpg",
                            ImageSmall = "/image/skis/223458small.jpg",
                            BrandName = "DPS",
                            CategoryName = "Backcountry",
                            StockLocation = new StockLocation
                            {
                                Zone = "B",
                                Slot = "1"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "22345801",
                                    Size = "168cm",
                                    Quantity = 1
                                },
                                new Sku
                                {
                                    SkuNo = "22345802",
                                    Size = "176cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "22345803",
                                    Size = "184cm",
                                    Quantity = 2
                                },
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "223459",
                            StyleName = "Super Charger Skis",
                            Gender = "Women's",
                            PriceCurrent = 938.00M,
                            PriceRegular = 938.00M,
                            ImageBig = "/image/skis/223459big.jpg",
                            ImageSmall = "/image/skis/223459small.jpg",
                            BrandName = "Voile",
                            CategoryName = "Backcountry",
                            StockLocation = new StockLocation
                            {
                                Zone = "B",
                                Slot = "2"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "22345901",
                                    Size = "154cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "22345902",
                                    Size = "164cm",
                                    Quantity = 2
                                }
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                         new Style
                         {
                             StyleNo = "223460",
                             StyleName = "Vapor Svelte Skis",
                             Gender = "Unisex",
                             PriceCurrent = 1299.00M,
                             PriceRegular = 1299.00M,
                             ImageBig = "/image/skis/223460big.jpg",
                             ImageSmall = "/image/skis/223460small.jpg",
                             BrandName = "La Sportiva",
                             CategoryName = "Backcountry",
                             StockLocation = new StockLocation
                             {
                                 Zone = "B",
                                 Slot = "3"
                             },
                             Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "22346001",
                                    Size = "168cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "22346002",
                                    Size = "178cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "22346003",
                                    Size = "188cm",
                                    Quantity = 1
                                }
                            },
                             StyleIdealFors = new List<StyleIdealFor>()
                         },
                         new Style
                         {
                             StyleNo = "223461",
                             StyleName = "Superneo Skis",
                             Gender = "Unisex",
                             PriceCurrent = 1199.00M,
                             PriceRegular = 1199.00M,
                             ImageBig = "/image/skis/223461big.jpg",
                             ImageSmall = "/image/skis/223461small.jpg",
                             BrandName = "Foon Skis",
                             CategoryName = "Backcountry",
                             StockLocation = new StockLocation
                             {
                                 Zone = "B",
                                 Slot = "4"
                             },
                             Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "22346101",
                                    Size = "158cm",
                                    Quantity = 4
                                },
                                new Sku
                                {
                                    SkuNo = "22346102",
                                    Size = "165cm",
                                    Quantity = 5
                                },
                                new Sku
                                {
                                    SkuNo = "22346103",
                                    Size = "175cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "22346104",
                                    Size = "185cm",
                                    Quantity = 1
                                }
                            },
                             StyleIdealFors = new List<StyleIdealFor>()
                         },
                         new Style
                         {
                             StyleNo = "223462",
                             StyleName = "V-Werks BMT 122 Skis",
                             Gender = "Unisex",
                             PriceCurrent = 899.00M,
                             PriceRegular = 1199.00M,
                             ImageBig = "/image/skis/223462big.jpg",
                             ImageSmall = "/image/skis/223462small.jpg",
                             BrandName = "Volkl",
                             CategoryName = "Backcountry",
                             StockLocation = new StockLocation
                             {
                                 Zone = "B",
                                 Slot = "5"
                             },
                             Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "22346201",
                                    Size = "176cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "22346202",
                                    Size = "186cm",
                                    Quantity = 0
                                }
                            },
                             StyleIdealFors = new List<StyleIdealFor>()
                         },
                          new Style
                          {
                              StyleNo = "223463",
                              StyleName = "Gretski Skis",
                              Gender = "Unisex",
                              PriceCurrent = 1149.00M,
                              PriceRegular = 1149.00M,
                              ImageBig = "/image/skis/223463big.jpg",
                              ImageSmall = "/image/skis/223463small.jpg",
                              BrandName = "Foon Skis",
                              CategoryName = "Backcountry",
                              StockLocation = new StockLocation
                              {
                                  Zone = "B",
                                  Slot = "6"
                              },
                              Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "22346301",
                                    Size = "175cm",
                                    Quantity = 4
                                },
                                new Sku
                                {
                                    SkuNo = "22346302",
                                    Size = "188cm",
                                    Quantity = 2
                                }
                            },
                              StyleIdealFors = new List<StyleIdealFor>()
                          },
                          new Style
                          {
                              StyleNo = "223464",
                              StyleName = "Wailer 106 Tour1 Skis",
                              Gender = "Men's",
                              PriceCurrent = 1099.00M,
                              PriceRegular = 1099.00M,
                              ImageBig = "/image/skis/223464big.jpg",
                              ImageSmall = "/image/skis/223464small.jpg",
                              BrandName = "DPS",
                              CategoryName = "Backcountry",
                              StockLocation = new StockLocation
                              {
                                  Zone = "B",
                                  Slot = "7"
                              },
                              Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "22346401",
                                    Size = "168cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "22346402",
                                    Size = "178cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "22346403",
                                    Size = "185cm",
                                    Quantity = 0
                                }
                            },
                              StyleIdealFors = new List<StyleIdealFor>()
                          },
                          new Style
                          {
                              StyleNo = "223465",
                              StyleName = "Talkback 96 Skis",
                              Gender = "Women's",
                              PriceCurrent = 699.00M,
                              PriceRegular = 699.00M,
                              ImageBig = "/image/skis/223465big.jpg",
                              ImageSmall = "/image/skis/223465small.jpg",
                              BrandName = "K2",
                              CategoryName = "Backcountry",
                              StockLocation = new StockLocation
                              {
                                  Zone = "B",
                                  Slot = "8"
                              },
                              Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "22346501",
                                    Size = "163cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "22346502",
                                    Size = "170cm",
                                    Quantity = 3
                                }
                            },
                              StyleIdealFors = new List<StyleIdealFor>()
                          },
                          new Style
                          {
                              StyleNo = "223466",
                              StyleName = "Empire 115 Skis ",
                              Gender = "Unisex",
                              PriceCurrent = 699.00M,
                              PriceRegular = 949.00M,
                              ImageBig = "/image/skis/223466big.jpg",
                              ImageSmall = "/image/skis/223466small.jpg",
                              BrandName = "G3",
                              CategoryName = "Backcountry",
                              StockLocation = new StockLocation
                              {
                                  Zone = "B",
                                  Slot = "9"
                              },
                              Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "22346601",
                                    Size = "170cm",
                                    Quantity = 1
                                },
                                new Sku
                                {
                                    SkuNo = "22346602",
                                    Size = "175cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "22346603",
                                    Size = "180cm",
                                    Quantity = 0
                                },
                                new Sku
                                {
                                    SkuNo = "22346604",
                                    Size = "185cm",
                                    Quantity = 0
                                },
                                new Sku
                                {
                                    SkuNo = "22346605",
                                    Size = "190cm",
                                    Quantity = 1
                                }
                            },
                              StyleIdealFors = new List<StyleIdealFor>()
                          },
                        new Style
                        {
                            StyleNo = "323460",
                            StyleName = "Ski Set",
                            Gender = "Kids' - Children",
                            PriceCurrent = 55.00M,
                            PriceRegular = 55.00M,
                            ImageBig = "/image/skis/323460big.jpg",
                            ImageSmall = "/image/skis/323460small.jpg",
                            BrandName = "Komperdell",
                            CategoryName = "Downhill",
                            StockLocation = new StockLocation
                            {
                                Zone = "C",
                                Slot = "1"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "32346001",
                                    Size = "60cm",
                                    Quantity = 5
                                },
                                new Sku
                                {
                                    SkuNo = "32346002",
                                    Size = "70cm",
                                    Quantity = 3
                                }
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "323461",
                            StyleName = "Flair SC Skis + Bindings",
                            Gender = "Women's",
                            PriceCurrent = 674.00M,
                            PriceRegular = 899.00M,
                            ImageBig = "/image/skis/323461big.jpg",
                            ImageSmall = "/image/skis/323461small.jpg",
                            BrandName = "Volkl",
                            CategoryName = "Downhill",
                            StockLocation = new StockLocation
                            {
                                Zone = "C",
                                Slot = "2"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "32346101",
                                    Size = "153cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "32346102",
                                    Size = "158cm",
                                    Quantity = 5
                                },
                                new Sku
                                {
                                    SkuNo = "32346103",
                                    Size = "163cm",
                                    Quantity = 4
                                }
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "323462",
                            StyleName = "Supershape i-Rally Skis + Bindings",
                            Gender = "Unisex",
                            PriceCurrent = 899.00M,
                            PriceRegular = 1199.00M,
                            ImageBig = "/image/skis/323462big.jpg",
                            ImageSmall = "/image/skis/323462small.jpg",
                            BrandName = "Head",
                            CategoryName = "Downhill",
                            StockLocation = new StockLocation
                            {
                                Zone = "C",
                                Slot = "3"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "32346201",
                                    Size = "156cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "32346202",
                                    Size = "163cm",
                                    Quantity = 5
                                },
                                new Sku
                                {
                                    SkuNo = "32346203",
                                    Size = "170cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "32346204",
                                    Size = "177cm",
                                    Quantity = 1
                                },
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "323463",
                            StyleName = "RTM 78 Skis + Bindings",
                            Gender = "Men's",
                            PriceCurrent = 674.00M,
                            PriceRegular = 899.00M,
                            ImageBig = "/image/skis/323463big.jpg",
                            ImageSmall = "/image/skis/323463small.jpg",
                            BrandName = "Volkl",
                            CategoryName = "Downhill",
                            StockLocation = new StockLocation
                            {
                                Zone = "C",
                                Slot = "4"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "32346301",
                                    Size = "156cm",
                                    Quantity = 0
                                },
                                new Sku
                                {
                                    SkuNo = "32346302",
                                    Size = "163cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "32346303",
                                    Size = "170cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "32346304",
                                    Size = "177cm",
                                    Quantity = 0
                                },
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "323464",
                            StyleName = "W-Pro SW Skis With Bindings",
                            Gender = "Women's",
                            PriceCurrent = 549.00M,
                            PriceRegular = 799.00M,
                            ImageBig = "/image/skis/323464big.jpg",
                            ImageSmall = "/image/skis/323464small.jpg",
                            BrandName = "Salomon",
                            CategoryName = "Downhill",
                            StockLocation = new StockLocation
                            {
                                Zone = "C",
                                Slot = "5"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "32346401",
                                    Size = "148cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "32346402",
                                    Size = "155cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "32346403",
                                    Size = "162cm",
                                    Quantity = 5
                                }
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "323465",
                            StyleName = "X-Pro SW Skis With Bindings",
                            Gender = "Men's",
                            PriceCurrent = 579.00M,
                            PriceRegular = 799.00M,
                            ImageBig = "/image/skis/323465big.jpg",
                            ImageSmall = "/image/skis/323465small.jpg",
                            BrandName = "Salomon",
                            CategoryName = "Downhill",
                            StockLocation = new StockLocation
                            {
                                Zone = "C",
                                Slot = "6"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "32346501",
                                    Size = "155cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "32346502",
                                    Size = "162cm",
                                    Quantity = 0
                                },
                                new Sku
                                {
                                    SkuNo = "32346503",
                                    Size = "169cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "32346504",
                                    Size = "176cm",
                                    Quantity = 3
                                }
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "323466",
                            StyleName = "Total Joy Skis + Bindings",
                            Gender = "Women's",
                            PriceCurrent = 599.00M,
                            PriceRegular = 799.00M,
                            ImageBig = "/image/skis/323466big.jpg",
                            ImageSmall = "/image/skis/323466small.jpg",
                            BrandName = "Head",
                            CategoryName = "Downhill",
                            StockLocation = new StockLocation
                            {
                                Zone = "C",
                                Slot = "7"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "32346601",
                                    Size = "148cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "32346602",
                                    Size = "153cm",
                                    Quantity = 0
                                },
                                new Sku
                                {
                                    SkuNo = "32346603",
                                    Size = "158cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "32346604",
                                    Size = "163cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "32346605",
                                    Size = "168cm",
                                    Quantity = 2
                                }
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new Style
                        {
                            StyleNo = "323467",
                            StyleName = "Strong Instinct Ti Skis + Bindings",
                            Gender = "Men's",
                            PriceCurrent = 559.00M,
                            PriceRegular = 749.00M,
                            ImageBig = "/image/skis/323467big.jpg",
                            ImageSmall = "/image/skis/323467small.jpg",
                            BrandName = "Head",
                            CategoryName = "Downhill",
                            StockLocation = new StockLocation
                            {
                                Zone = "C",
                                Slot = "8"
                            },
                            Skus = new Sku[]
                            {
                                new Sku
                                {
                                    SkuNo = "32346701",
                                    Size = "156cm",
                                    Quantity = 2
                                },
                                new Sku
                                {
                                    SkuNo = "32346702",
                                    Size = "163cm",
                                    Quantity = 3
                                },
                                new Sku
                                {
                                    SkuNo = "32346703",
                                    Size = "170cm",
                                    Quantity = 1
                                },
                                new Sku
                                {
                                    SkuNo = "32346704",
                                    Size = "177cm",
                                    Quantity = 0
                                }
                            },
                            StyleIdealFors = new List<StyleIdealFor>()
                        }
                        );

                    context.IdealFors.AddRange(
                        new IdealFor
                        {
                            IdealForWhat = "Skate ski racing",
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new IdealFor
                        {
                            IdealForWhat = "Recreational classic skiing",
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new IdealFor
                        {
                            IdealForWhat = "Fitness classic skiing",
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new IdealFor
                        {
                            IdealForWhat = "Alpine touring",
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new IdealFor
                        {
                            IdealForWhat = "Ski mountaineering",
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new IdealFor
                        {
                            IdealForWhat = "Freeride and freeskiing",
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new IdealFor
                        {
                            IdealForWhat = "Downhill skiing",
                            StyleIdealFors = new List<StyleIdealFor>()
                        }, 
                        new IdealFor
                        {
                            IdealForWhat = "Off-track touring",
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new IdealFor
                        {
                            IdealForWhat = "Classic ski racing",
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new IdealFor
                        {
                            IdealForWhat = "Fitness skate skiing",
                            StyleIdealFors = new List<StyleIdealFor>()
                        },
                        new IdealFor
                        {
                            IdealForWhat = "Backcountry skiing",
                            StyleIdealFors = new List<StyleIdealFor>()
                        });

                    context.SaveChanges();

                    AddManyToMany("123456", new string[] {"Skate ski racing"}, context);
                    AddManyToMany("123457", new string[] 
                        { "Recreational classic skiing", "Fitness classic skiing" }, context);
                    AddManyToMany("123458", new string[] { "Off-track touring" }, context);
                    AddManyToMany("123459", new string[]
                        { "Fitness classic skiing", "Classic ski racing" }, context);
                    AddManyToMany("123460", new string[]
                       { "Fitness skate skiing", "Skate ski racing" }, context);
                    AddManyToMany("123461", new string[]
                       { "Fitness skate skiing", "Skate ski racing" }, context);
                    AddManyToMany("123462", new string[] { "Fitness skate skiing" }, context);
                    AddManyToMany("123463", new string[]
                       { "Recreational classic skiing", "Fitness classic skiing" }, context);
                    AddManyToMany("223458", new string[] 
                        {"Alpine touring","Ski mountaineering","Freeride and freeskiing"}, context);
                    AddManyToMany("223459", new string[] { "Alpine touring" },context );
                    AddManyToMany("223460", new string[] { "Alpine touring" }, context);
                    AddManyToMany("223461", new string[]
                        {"Alpine touring","Freeride and freeskiing"}, context);
                    AddManyToMany("223462", new string[]
                        {"Alpine touring","Freeride and freeskiing"}, context);
                    AddManyToMany("223463", new string[]
                       {"Alpine touring","Ski mountaineering"}, context);
                    AddManyToMany("223464", new string[] { "Backcountry skiing" }, context);
                    AddManyToMany("223465", new string[]
                       {"Alpine touring","Ski mountaineering"}, context);
                    AddManyToMany("223466", new string[]
                       {"Alpine touring","Freeride and freeskiing"}, context);
                    AddManyToMany("323460", new string[] { "Downhill skiing"}, context);
                    AddManyToMany("323461", new string[] { "Downhill skiing"}, context);
                    AddManyToMany("323462", new string[] { "Downhill skiing" }, context);
                    AddManyToMany("323463", new string[] { "Downhill skiing" }, context);
                    AddManyToMany("323464", new string[] { "Downhill skiing" }, context);
                    AddManyToMany("323465", new string[] { "Downhill skiing" }, context);
                    AddManyToMany("323466", new string[] { "Downhill skiing" }, context);
                    AddManyToMany("323467", new string[] { "Downhill skiing" }, context);

                    context.SaveChanges();

                }
            }
        }

        public static void AddManyToMany(string styleNo, string[] idealForWhats, SkiShopContext context)
        {
            Style style = context.Styles.FirstOrDefault(s => s.StyleNo == styleNo);

            foreach (var idealForWhat in idealForWhats)
            {
                IdealFor idealFor = context.IdealFors.FirstOrDefault(i => i.IdealForWhat == idealForWhat);
                StyleIdealFor styleIdealFor=new StyleIdealFor
                {
                    StyleId =style.StyleId,
                    Style = style,
                    IdealForId = idealFor.IdealForId,
                    IdealFor = idealFor
                };

                style.StyleIdealFors.Add(styleIdealFor);
                idealFor.StyleIdealFors.Add(styleIdealFor);

                context.Styles.Update(style);
                context.IdealFors.Update(idealFor);
                context.StyleIdealFors.Add(styleIdealFor);
            }



        }
    }
}
