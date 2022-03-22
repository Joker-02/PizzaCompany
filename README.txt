INTRUCTION
-LOGIN:IF(MANAGER)==>MENUFORM==>(PRODUCT,ORDER,EMPLOYEE,REPORT,EXIT)
       IF(STAFF OR CASIOR) ==>MENUFORM==>(ORDER,EXIT)
ADMIN USER:
Username:Admin@Pizza.kh
Password:Admin@123
To Run Program need to Follow Step Bellow:
1.Run script table in sql manangement studio
2.change servername ,username,db,password in Connector Class
3.now let run our app
that all folks.
Patterm :
--Composite:
	Base Class Employeee
	Derived Staff ,Manager(Composite class)
--Singlton:
	Connector
--Decorator:
	Bass Class Pizza
	Derived Class AddInPizza,
	Decorator:Crust,Topping,SizePizza check in that Folder