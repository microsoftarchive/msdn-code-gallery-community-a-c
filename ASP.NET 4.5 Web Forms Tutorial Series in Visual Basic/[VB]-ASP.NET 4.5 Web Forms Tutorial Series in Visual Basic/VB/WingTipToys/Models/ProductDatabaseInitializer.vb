Imports System.Data.Entity

Public Class ProductDatabaseInitializer
    Inherits DropCreateDatabaseIfModelChanges(Of ProductContext)

    Protected Overrides Sub Seed(context As ProductContext)
        GetCategories().ForEach(Function(c) context.Categories.Add(c))
        GetProducts().ForEach(Function(p) context.Products.Add(p))
    End Sub

    Private Shared Function GetCategories() As List(Of Category)
        Dim categories = New List(Of Category)() From { _
            New Category() With { _
                .CategoryID = 1, _
                .CategoryName = "Cars" _
            }, _
            New Category() With { _
                .CategoryID = 2, _
                .CategoryName = "Planes" _
            }, _
            New Category() With { _
                .CategoryID = 3, _
                .CategoryName = "Trucks" _
            }, _
            New Category() With { _
                .CategoryID = 4, _
                .CategoryName = "Boats" _
            }, _
            New Category() With { _
                 .CategoryID = 5, _
                .CategoryName = "Rockets" _
            } _
        }

        Return categories
    End Function

    Private Shared Function GetProducts() As List(Of Product)
        Dim products = New List(Of Product)() From { _
            New Product() With { _
                .ProductID = 1, _
                .ProductName = "Convertible Car", _
                .Description = "This convertible car is fast! The engine is powered by a neutrino based battery (not included)." + "Power it up and let it go!", _
                .ImagePath = "carconvert.png", _
                .UnitPrice = 22.5, _
                .CategoryID = 1 _
            }, _
            New Product() With { _
                .ProductID = 2, _
                .ProductName = "Old-time Car", _
                .Description = "There's nothing old about this toy car, except it's looks. Compatible with other old toy cars.", _
                .ImagePath = "carearly.png", _
                .UnitPrice = 15.95, _
                .CategoryID = 1 _
            }, _
            New Product() With { _
                .ProductID = 3, _
                .ProductName = "Fast Car", _
                .Description = "Yes this car is fast, but it also floats in water.", _
                .ImagePath = "carfast.png", _
                .UnitPrice = 32.99, _
                .CategoryID = 1 _
            }, _
            New Product() With { _
                .ProductID = 4, _
                .ProductName = "Super Fast Car", _
                .Description = "Use this super fast car to entertain guests. Lights and doors work!", _
                .ImagePath = "carfaster.png", _
                .UnitPrice = 8.95, _
                .CategoryID = 1 _
            }, _
            New Product() With { _
                .ProductID = 5, _
                .ProductName = "Old Style Racer", _
                .Description = "This old style racer can fly (with user assistance). Gravity controls flight duration." + "No batteries required.", _
                .ImagePath = "carracer.png", _
                .UnitPrice = 34.95, _
                .CategoryID = 1 _
            }, _
            New Product() With { _
                .ProductID = 6, _
                .ProductName = "Ace Plane", _
                .Description = "Authentic airplane toy. Features realistic color and details.", _
                .ImagePath = "planeace.png", _
                .UnitPrice = 95.0, _
                .CategoryID = 2 _
            }, _
            New Product() With { _
                .ProductID = 7, _
                .ProductName = "Glider", _
                .Description = "This fun glider is made from real balsa wood. Some assembly required.", _
                .ImagePath = "planeglider.png", _
                .UnitPrice = 4.95, _
                .CategoryID = 2 _
            }, _
            New Product() With { _
                .ProductID = 8, _
                .ProductName = "Paper Plane", _
                .Description = "This paper plane is like no other paper plane. Some folding required.", _
                .ImagePath = "planepaper.png", _
                .UnitPrice = 2.95, _
                .CategoryID = 2 _
            }, _
            New Product() With { _
                .ProductID = 9, _
                .ProductName = "Propeller Plane", _
                .Description = "Rubber band powered plane features two wheels.", _
                .ImagePath = "planeprop.png", _
                .UnitPrice = 32.95, _
                .CategoryID = 2 _
            }, _
            New Product() With { _
                .ProductID = 10, _
                .ProductName = "Early Truck", _
                .Description = "This toy truck has a real gas powered engine. Requires regular tune ups.", _
                .ImagePath = "truckearly.png", _
                .UnitPrice = 15.0, _
                .CategoryID = 3 _
            }, _
            New Product() With { _
                .ProductID = 11, _
                .ProductName = "Fire Truck", _
                .Description = "You will have endless fun with this one quarter sized fire truck.", _
                .ImagePath = "truckfire.png", _
                .UnitPrice = 26.0, _
                .CategoryID = 3 _
            }, _
            New Product() With { _
                .ProductID = 12, _
                .ProductName = "Big Truck", _
                .Description = "This fun toy truck can be used to tow other trucks that are not as big.", _
                .ImagePath = "truckbig.png", _
                .UnitPrice = 29.0, _
                .CategoryID = 3 _
            }, _
            New Product() With { _
                .ProductID = 13, _
                .ProductName = "Big Ship", _
                .Description = "Is it a boat or a ship. Let this floating vehicle decide by using its " + "artifically intelligent computer brain!", _
                .ImagePath = "boatbig.png", _
                .UnitPrice = 95.0, _
                .CategoryID = 4 _
            }, _
            New Product() With { _
                .ProductID = 14, _
                .ProductName = "Paper Boat", _
                .Description = "Floating fun for all! This toy boat can be assembled in seconds. Floats for minutes!" + "Some folding required.", _
                .ImagePath = "boatpaper.png", _
                .UnitPrice = 4.95, _
                .CategoryID = 4 _
            }, _
            New Product() With { _
                .ProductID = 15, _
                .ProductName = "Sail Boat", _
                .Description = "Put this fun toy sail boat in the water and let it go!", _
                .ImagePath = "boatsail.png", _
                .UnitPrice = 42.95, _
                .CategoryID = 4 _
            }, _
            New Product() With { _
                .ProductID = 16, _
                .ProductName = "Rocket", _
                .Description = "This fun rocket will travel up to a height of 200 feet.", _
                .ImagePath = "rocket.png", _
                .UnitPrice = 122.95, _
                .CategoryID = 5 _
            } _
        }

        Return products

    End Function

End Class